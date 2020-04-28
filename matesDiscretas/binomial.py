#http://www.rellek.net/book/s_strings_bin-coeff.html
import math as m

#Cuenta el tamaño del string, y luego cuantos elementos hay de cada uno en el mismo
def multinomialCoefficents(elementos):
	n = len(arregloStr)
	producto = 1;
	for key,elemento in elementos.items():
		producto *= m.factorial(elemento)
	return m.factorial(n) / producto, n

def contarElementosDentroString(string):
	letrasContadas = {}
	for l in string:
		letrasContadas[l] = string.count(l)
	print(letrasContadas)
	return multinomialCoefficents(letrasContadas)

#MULTINOMIAL COEFFICENTS

arregloStr = "MITCHELTKELLERANDWILLIAMTTROTTERAREGENIUSES!!"

combinacion,n = contarElementosDentroString(arregloStr)

print("Tamaño del string: {}, Resultado: {}".format(n,combinacion))