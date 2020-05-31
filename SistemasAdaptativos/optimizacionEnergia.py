# ecuacion de minimizacion

#tc = sumatoria cj * (mcj + ccj) + pd/ndg * sumatoria xdg,t

#librerias
from enum import Enum
import random
import numpy as np

#variables de algoritmo
probabilidad_mutacion = 0.2
# pressure              = 2   #cantidad de individuos que se reproduciran
numero_individuos      = 5   #panel solar - turbina viento - generador diesel - bateria cargada - bateria descargada
longitud               = 2   #longitud de material genetico para cada individuo (variables decision)
numero_poblaciones     = 6

#variables de sistema
flh = 1825	#horas anuales de PV
horasRadiacion = 9.25
capacidadSolar = 0
for i in range(8760):	#8760 horas totales en un año
	capacidadSolar+=horasRadiacion

class Precios(Enum):	#ccj
	SOLAR   = 2835
	VIENTO  = 5832
	DIESEL  = 596
	BATERIA = 148

class PreciosMantenimiento(Enum):	#mcj
	SOLAR   = 56.7
	VIENTO  = 116.64
	DIESEL  = 38.08
	BATERIA = 2.96

class Capacidad(Enum):	#cj
	SOLAR   = capacidadSolar
	VIENTO  = 1
	DIESEL  = 1
	BATERIA = 0.8

class Eficiencia(Enum): #nj
	DIESEL = .40
	BATERIA = 85.5

def obtenerSiguienteStatusBateria(capacidad,uso,statusAnterior):
	return statusAnterior + (uso*Eficiencia.BATERIA.value)

def PoblacionInicial():
	poblacion = np.zeros( (numero_poblaciones,numero_individuos,longitud) )
	# poblacion = np.zeros( (numero_individuos,longitud) )
	for k in range(0, numero_poblaciones):
		for i in range(0, numero_individuos):
			for j in range(0, longitud):
				poblacion[k,i,j] = random.randint(0,100)
	return poblacion

def ObtenerFitness(individuos):
	fitness = 0
	costo = 0
	precioDiesel = 0
	for index,hijo in enumerate(individuos):
		#ecuacion 2 para los dos primeros objetos
		if index == 1:
			fitness += 1 if (hijo[1] <= (hijo[0] * Capacidad.SOLAR.value)) else 0
			costo += Capacidad.SOLAR.value * (Precios.SOLAR.value + PreciosMantenimiento.SOLAR.value)
		elif index == 2:
			fitness += 1 if (hijo[1] <= (hijo[0] * Capacidad.VIENTO.value)) else 0
			costo += Capacidad.VIENTO.value * (Precios.VIENTO.value + PreciosMantenimiento.VIENTO.value)
			for i in range(3760):
				precioDiesel += hijo[1]
		#fin ecuacion 2
		elif index == 3:
			fitness += 1 if (hijo[1] <= (hijo[0] * Capacidad.DIESEL.value)) else 0
			costo += Capacidad.DIESEL.value * (Precios.DIESEL.value + PreciosMantenimiento.DIESEL.value)
			####
			statusBateriaAnterior = (1 - Capacidad.BATERIA.value) * hijo[0]
			statusBateria = obtenerSiguienteStatusBateria(hijo[0],hijo[1],statusBateriaAnterior)
			if hijo[1] <= statusBateria:	#ecuacion 4
				fitness += 1
			if hijo[1] <= ((Capacidad.BATERIA.value * statusBateria) / Eficiencia.BATERIA.value):	#ecuacion 3
				fitness += 1

		costo += ((Precios.DIESEL.value / Eficiencia.DIESEL.value) + precioDiesel)
	return fitness

def Reproduccion(padres):
	#FITNESS
	fitnessPorPoblacion = np.zeros( (numero_poblaciones,2) )
	#obtener fitness de cada poblacion
	for index,individuos in enumerate(padres):
		#Obtener el fitness de cada poblacion
		fit = ObtenerFitness(individuos)
		fitnessPorPoblacion[index,0] = fit
		fitnessPorPoblacion[index,1] = index #se guarda ubicacion de ese arreglo en poblacion original
	
	#SELECCION
	#hacer un sort de estos individuos por el fitness para seleccion
	poblacionSorted = fitnessPorPoblacion[fitnessPorPoblacion[:,0].argsort()]
	print( padres )
	print( poblacionSorted )

	#REPRODUCCION
	for i in range( int((len(poblacionSorted)/2)) ):
		print( "parejas" )
		indexPrimerPareja  = int(poblacionSorted[i,1])
		indexSegundaPareja = int(poblacionSorted[len(poblacionSorted)-(1+i),1])
		pareja1 = padres[ indexPrimerPareja ]
		pareja2 = padres[ indexSegundaPareja ]
		#copia de arreglos, porque por some reason los arreglos cambian
		copiaPareja2 = pareja2.copy()
		copiaPareja1 = pareja1.copy()
		for j in range(numero_individuos):
			print("pareja1 : {}".format(pareja1[j]))
			print("pareja2 : {}".format(pareja2[j]))
			
			padres[indexPrimerPareja,j,0] = pareja1[j,0]
			padres[indexPrimerPareja,j,1] = pareja2[j,1]

			padres[indexSegundaPareja,j,0] = copiaPareja1[j,1]
			padres[indexSegundaPareja,j,1] = copiaPareja2[j,0]

	print( padres )


# def Mutacion(hijos):
#Crear una poblacion con varios habitantes
padres = PoblacionInicial()


# print(padres)
Reproduccion(padres)

# if fit <= 6:
# 	print("otr vez")

