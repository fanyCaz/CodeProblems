def reverseInParentheses(inputString):
    indexes = ['']
    for c in inputString:
        if c =='(':
            indexes.append('')
        elif c == ')':
            add = indexes.pop()[::-1]
            print(add)
            indexes[-1] += add
            print(indexes)
        else:
            indexes[-1] += c
    return indexes.pop()
    

print( reverseInParentheses('abc(xwz(df))') )