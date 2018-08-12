# zlua
设计
## 栈式虚拟机和指令集
### 调用与返回协议
1. 宿主和Lua函数协议相同
2. no vararg，这个特性根本用不到（python都很少用）
3. 调用流程：push closure，push args（被解析lua代码中的实参列表从左到右压栈），`_call会逆序args（因为压栈）然后以closure(args)调用它
4. 返回流程：pop ret：单返回值，以多返回值形式写的会被包装到tuple里（目前是table）

### 解包/多重赋值协议
1. a,b,c这样的会被包装成tuple
2. 赋值右侧的tuple自动解包
3. 不允许类似于 a, b, c = 1, (2, 3)，个数要严格匹配

### 虚拟机执行流程
1. 因为python严格不允许goto（事实上真的不好，你得逼自己想一个好的，抽象的solution）
2. thread只知道要执行Lua closure，第一次需要手动push chunk，然后调用execute执行

### 运行时环境
#### Stack<LuaClosure>
关于luaclosure，我们增加了运行时的结构
因为block的原因，这里有点乱
我们使用了两个栈，而不是一个proto和block的多态栈，因为还是要判断local
我们用栈来替代了parent
一个proto内的locals要根据curr来确定，是proto的locals加上block栈上的所有locals
坚持了C#的内部block不能与外部有同名局部变量，因此block的作用是我可以在同一层的三个子block里都声明一个i，这很重要
刚刚想到了一个特殊情况，说明了这样的重要性。本来最早的认知是：debug显示很不好。事实上允许同名会出现这样的情况
local a{{local b=a}local a}，你看，运行时回去找到后面一个a，这是错误的。
重名会在编译期检查好。所以运行时虽然所有声明都已加入locals（而不是声明了再加）但是是对的

关于PythonClosure
python closure被注册到G，lua里调用后参数照样传入
call指令会取出参数直接调用py func，返回值压栈
不需要栈帧
2.

### 指令集设计
#### move
不需要，因为没有寄存器
#### loadk
不需要，常量直接编码到指令，不需要这样间接映射
#### push/pop upval
push name: push当前lua closure的upval字典中name的val
pop name：同上
#### push/pop G/L
同上
#### closure
从inner里用index取出一个proto，变成closure后push
你还要考虑全局函数的问题，应该是closure了加入array，然后setG/L
#### get/settable
push table，使用前面三条指令（而不是新增push table指令）
push key，同上
get table 指令：pop前两个值然后把val压栈，之后用其他指令赋值给其他
set table 指令：要再push val，pop三个值后赋值即可
#### newtable
a b 是部分的大小，可能不需要这个指令
#### self
忘了，去看
#### arith
双单，还要元方法
#### 控制流类，一个都没做


#### 新指令：new locals names
因为是声明，我们直接在block内新建key val pair（虽然key已经有了）

#### 新指令：unpack n_names
弹出栈顶的array（table），检查是否解包成n names个元素，不行则error
解包的值正序（从左到右）压栈（因为popn也是正序取出的）

#### self name
表对象已经在栈顶，弹出后压入t\[name\]，再压入表
所以方法应该这样翻译和执行
obj:f()
一个push指令（LUG）压入obj
有一个self f指令，压入f，压入obj
然后call

####新指令 push_l o
l=literal
因为push重复了。

####call nargs
函数自己和参数已经压栈，取出后调用，nargs标记了实参列表长度（虽然exp栈理论上长度可以推出来，但是不好）


####return 1/0
旧版：(无参。自动检测有没有返回值，因为exp栈在计算后保持是空的，如果有就是有返回值返回他)
新版：1表示有一个返回值。不这样设计的后果是要区分call procedure，然后compiler这里的逻辑很复杂（对，可以写，我想出来了，
但是这个问题在于你吃掉了return的一个参数，which让事情变得复杂）
其实道理很简单。函数有没有返回值当然是return管。
因为有没return的函数体，所以自动附加ret



### 相等性
似乎不用管，元方法也可以不管，用不到

### 类型模型
不用实现，如果需要实现一个单独的类即可
#### table
1. 直接多继承list和dict不存在的
2. 有几个类型上的地方，使用py默认的即可，因为比lua的沉默（偷偷做转换）要好
3. 

### 变量与scope实现
#### upval
#### 检查

### 表达式与指令生成
之前想折叠常量，不太好弄。local a=True, not(not(a))，外面那个not a，在C#里我们返回一个temp，但是栈式没有temp
你也不能会上去判断之前的exp不是literal exp（num，str等），这样很丑
所以visit*没有返回值，直接emit
常量折叠的另一一个问题是，编译期和runtime的指令实现会repeat yourself，估计很难提取函数，很丑（因为其实函数本身很简单）
### 多重赋值
函数返回任意多的值，直接压栈

##TODO 处理runtime scope，怎么用startpc和endpc，最好简洁。

#### prefixexp的实现 处理
说一句。语法的写法很重要。第一，这是antlr的api，你最后要能用来实现解释器
第二，语法的递归要自然。理论上。parer rule应该是每一个实现一次。不要自定而下去分类讨论，这样会崩。
语句当然是自顶而下，但是再下一层就不应该了。prefixexp这里就很明显。你要是因为没想好，选择分类讨论，那么几乎不可能解决

prefixexp: varOrExp nameAndArgs *; // var或带括号的exp；注意看下一条，如果有nameAndArgs就是函数调用。
很难。var or exp是右值，var是name或表字段，表本身可能是函数调用
name args是调用

###表创建指令
####setlist n
一个newtable和n个exp已经正序（从左到右）压栈，取出exps加入表，把表压栈
####newtable
local a={}。所以{}是一个表达式，所以要有指令，所有ctor以newtable打头
