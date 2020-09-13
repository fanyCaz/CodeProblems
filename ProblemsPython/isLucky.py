def isLucky(n:int):
    stringV = str(n)
    firstHalf,secondHalf = stringV[:int(len(stringV)/2)], stringV[int(len(stringV)/2):]
    fh = [int(i) for i in firstHalf]
    sh = [int(i) for i in secondHalf]
    return sum(fh) == sum(sh)

print( isLucky(100000) )