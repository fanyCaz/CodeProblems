def sortByHeight(a: list):
    people = [i for i in a if i > -1]
    people.sort(reverse=True)
    x = len(people) - 1
    for index,i in enumerate(a):
        if i != -1:
            a[index] = people[x]
            x -=1
    return a

print( sortByHeight( [-1, 150, 190, 170, -1, -1, 160, 180] ) )