def commonCharacterCount(s1,s2):
    counter = 0
    stringS1 = set(s1)  #turn it  into a set, so the values aren't repeated,
    for i in stringS1:
        # and now you can count how many times this value is in the other
        counter+=min(s1.count(i),s2.count(i))
    return counter

print( commonCharacterCount('a','aaa') )