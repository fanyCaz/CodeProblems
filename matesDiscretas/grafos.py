#Ejemplo de libro Matematicas Discretas pag 323
#Cada vertice representa a un programa que tiene tres dimensiones(propiedades) p1, p2 y p3

#funcion de disimilitud s(programas,w) w=(q1,q2,q3) 
#donde w es el vector vecino con el que se va a comparar

S = 25		#Valor que determina si dos vertices pertenecen a una misma clase, o el valor que quieres que sea
			#el mas bajo en la trayectoria de dos vertices
programas = [ [66,20,1],[41,10,2],[68,5,8],[90,34,5],[75,12,14] ]
verticesMasCercanos = []
s = []
def funcionDisimilitud(v,w):		#DISIMIL: Que es diferente
	suma = 0;						#En este caso magnitud de diferencia entre las propiedades de los vertices
	for i in range(len(v)):
		suma += abs(v[i] - w[i])
	return suma

def similitud(programas,i,y):
	if(i >= len(programas)):
		pass
	else:
		print()	#y es el lugar donde comenzara ahora la iteracion, para evitar valores repetidos
		for j in range(y,len(programas)):
			suma = funcionDisimilitud(programas[i],programas[j])
			if(suma < S):
				verticesMasCercanos.append([programas[i],programas[j]])
			s.append([i,j,suma])	#s = (v,w)
			print( str(i+1) + "," + str(j+1) + ": " + str(suma) )
		i+=1
		y+=1
		similitud(programas,i,y)

similitud(programas,0,1)

print("Vertices con mayor cercanía")
print(verticesMasCercanos)