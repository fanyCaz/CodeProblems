def allLongestStrings(inputArray: list):
    m = max(len(s) for s in inputArray)
    print(m)
    longestStrings = []
    for i in inputArray:
        if len(i) == m:
            longestStrings.append(i)
    return longestStrings

ex = ["d"]
print( allLongestStrings(ex) )