class Table:
    def __init__(self):
        self.apart = []
        self.hpart = {}

    def append(self, obj):
        self.apart.append(obj)

    def put(self, key, val):
        self.hpart[key] = val

    def __getitem__(self, key):
        if isinstance(key, int):
            try:
                return self.apart[key]
            except IndexError:
                return self.hpart[key]
        elif isinstance(key, str):
            return self.hpart[key]
        else:
            raise TypeError('不要使用int和str以外的类型作为key')

    def __setitem__(self, key, value):
        if isinstance(key, int):
            try:
                self.apart[key] = value
            except IndexError:
                self.hpart[key] = value
        elif isinstance(key, str):
            self.hpart[key] = value
        else:
            raise TypeError('不要使用int和str以外的类型作为key')

    def __iter__(self):
        for i in self.apart: yield i
        for k, v in self.hpart.items(): yield k, v


if __name__ == '__main__':
    t = Table()
    t.append('ele1')
    t[2] = 'ele2'
    for i in t: print(i)
