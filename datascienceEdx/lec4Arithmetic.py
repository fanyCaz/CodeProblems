import pandas as pd

## Growth rate is the rate of increase per unit time		
## 		x * (1+g)	after one time unit, a quantity x growing at a rate g
##		x * (1+g) ** t 		after t time units, a quantity x growing at rate g
## 		if after and before are measurements of the same quantity taken t times units apart, 
##  	then the growth rate:
##		(after/before) ** (1/t) - 1

##	OUTBRAKE OF EBOLA VIRUS
sept7 = 4366
aug7 = 1830
growthPerMonth = (sept7/aug7) - 1

print(growthPerMonth)

print("What would had happen if the growth persisted?")

oct7 = sept7 * (1 + growthPerMonth)
nov7 = sept7 * (1 + growthPerMonth) ** 2
sept7_2 = sept7 * (1 + growthPerMonth) ** 12
print(oct7)
print(nov7)
print(sept7_2)

##	FEDERAL BUDGET OF USA
fed2002 = 2370000000000
fed2012 = 3380000000000
print( "Difference of budget in a decade : " + str(fed2012 - fed2002) )
grow = (fed2012/fed2002 ) ** (1/10) - 1 
print("Growth of the decade : " + str( grow ) )
fed2018 = fed2002 * (1 + grow ) ** 16
print("Budget of 2018 : " + str(fed2018) )

## ARRAYS & TABLES
tabl1 = Table().with_columns('uno',[1,2,3],'dos',[4,5,6])
print(tabl1)


