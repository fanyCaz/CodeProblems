#strings => arrays
import math

def permutar(m,n):
	return math.factorial(m) / math.factorial(m - n)
# P(m,n) = m! / (m - n)!

def combinar(n,k):
	return math.factorial(n) / (math.factorial(k) * math.factorial(n-k))
#C(n,k) = n! / k!(n-k)!

#COMBINACIONES
numbers = (0,1,2,3,4,5,6,7,8,9)
letters = ('A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z')

print("Numero de combinaciones para una matricula #### AAA")
# string resultante debe ser {1-9} {0-9} {0-9} {0-9} ' ' {A-Z} {A-Z} {A-Z}
print( 9 * math.pow(len(numbers), 3) * 1 * math.pow(len(letters),3) )
print("Numero de combinaciones sin que se repitan letras")
print( 9 * math.pow(len(numbers), 3) * 1 * permutar(26,3) )

print("Numero de usernames disponibles para una pagina web")
#string resultante debe ser
# {A-Z} {A-z 0-9} {A-z 0-9} {A-z 0-9} {A-z 0-9} {A-z 0-9} {@, .} {a-z,*,%,#} {a-z,*,%,#} {a-z,*,%,#} {a-z,*,%,#} {a-z,*,%,#} {0-9}
print( 26 * math.pow( (len(letters) * 2) + 10 , 5) * 2 * math.pow(len(letters) + 3, 5) * 10 )

print("Combinaciones de alumnos para un comite teniendo un poll de 80")
print( combinar(80,4) )

#PERMUTACIONES
#El orden importa
print("Permutacion de 9,3") #entonces solo puede ir 9 8 7 = 504
print( permutar(9,3) )

print("""Cuantas combinaciones de alumnos puede haber en los elegidos para Presi,Vice,Secretario y Tesorero
	Hay 80 alumnos en candidatura""")
print( permutar(80,4) )

print("Subset de un Set; se muestra la correspondencia del subset al set")
print("X = {a,b,c,d,e,f,g} V = {b,c,g} V is a subset of X : 01100010")
print("Hay {} numero de combinaciones para el subset de 3 del set X".format(combinar(8,3)) )
# X = {a,b,c,d,e,f,g} V = {b,c,g} V is a subset of X 01100010

#COMBINATORIAL PROOFS->2.4 http://www.rellek.net/book/s_strings_comb-proof.html
#The office assistant is distributing supplies. In how many ways can he distribute 18 identical
# folders among four office employees: Audrey, Bart, Cecilia and Darren, 
# with the additional restriction that each will receive at least one folder?
print("Si son 18 y cada uno debe tener uno, entonces se combinan los restantes")
print( combinar(17,3) )