# ecuacion de minimizacion

#tc = sumatoria cj * (mcj + ccj) + pj/nj * sumatoria xj,t

#librerias
from enum import Enum
import random
import numpy as np
import math

#variables de algoritmo
probabilidad_mutacion = 0.2
numero_individuos      = 5   #panel solar - turbina viento - generador diesel - bateria cargada - bateria descargada
longitud               = 2   #longitud de material genetico para cada individuo (variables decision)
numero_poblaciones     = 6

def SetValoresSistema(horasSolar,velocidadViento):
	valoresSistema = []
	valoresSistema = Optimizar(horasSolar,velocidadViento)
	return valoresSistema

#cj Capacidad de cada elemento en un periodo t, las demas se definen dependiendo del usuario
Capacidad = {'DIESEL':1,'BATERIA':0.8}

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

class Eficiencia(Enum): #nj
	DIESEL = .40
	BATERIA = 85.5

def obtenerSiguienteStatusBateria(capacidad,uso,statusAnterior):	#esto para evaluar la bateria en estado de descarga
	return statusAnterior + (uso*Eficiencia.BATERIA.value)

def PoblacionInicial():
	poblacion = np.zeros( (numero_poblaciones,numero_individuos,longitud) )
	for k in range(0, numero_poblaciones):
		for i in range(0, numero_individuos):
			for j in range(0, longitud):
				poblacion[k,i,j] = random.randint(0,100)
	return poblacion

def ObtenerFitness(individuos):
	fitness = 0
	for index,hijo in enumerate(individuos):
		#ecuacion 2 para los dos primeros objetos
		if index == 0:
			fitness += 1 if (hijo[1] <= (hijo[0] * Capacidad['SOLAR'])) else 0
		elif index == 1:
			fitness += 1 if (hijo[1] <= (hijo[0] * Capacidad['VIENTO'])) else 0
		elif index == 2:
			fitness += 1 if (hijo[1] <= (hijo[0] * Capacidad['DIESEL'])) else 0
		#fin ecuacion 2
		elif index == 3:
			statusBateriaAnterior = (1 - Capacidad['BATERIA']) * hijo[0]
			statusBateria = obtenerSiguienteStatusBateria(hijo[0],hijo[1],statusBateriaAnterior)
			if hijo[1] <= statusBateria:	#ecuacion 4
				fitness += 1
			if hijo[1] <= ((Capacidad['BATERIA'] * statusBateria) / Eficiencia.BATERIA.value):	#ecuacion 3
				fitness += 1
	return fitness

def ObtenerCosto(hijos):
	costos = []
	for hijo in hijos:
		costo = 0
		precioSolar = 0
		precioViento = 0
		precioDiesel = 0
		precioBateria = 0
		for index,unidad in enumerate(hijo):
			if index == 0:
				for i in range(3760):
					precioSolar += unidad[1]
				costo += precioSolar
			elif index == 1:
				for i in range(3760):
					precioViento += unidad[1]
				costo += precioViento
			elif index == 2:
				for i in range(3760):
					precioDiesel += unidad[1]
				costo += precioDiesel	
			costo += Capacidad['SOLAR'] * (Precios.SOLAR.value + PreciosMantenimiento.SOLAR.value)
			costo += Capacidad['DIESEL'] * (Precios.DIESEL.value + PreciosMantenimiento.DIESEL.value)
			costo += Precios.DIESEL.value / Eficiencia.DIESEL.value
		costos.append(costo)
	return costos

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

	#REPRODUCCION
	#selecciona el de mayor fitness y luego el de menor
	for i in range( int((len(poblacionSorted)/2)) ):
		indexPrimerPareja  = int(poblacionSorted[i,1])
		indexSegundaPareja = int(poblacionSorted[len(poblacionSorted)-(1+i),1])
		pareja1 = padres[ indexPrimerPareja ]
		pareja2 = padres[ indexSegundaPareja ]
		
		copiaPareja2 = pareja2.copy()
		copiaPareja1 = pareja1.copy()
		for j in range(numero_individuos):	#se hace una reproduccion con los elementos con mejor fitness a los que tuvieron menos
			padres[indexPrimerPareja,j,0] = copiaPareja1[j,1]
			padres[indexPrimerPareja,j,1] = copiaPareja2[j,0]

	return padres

def MutacionIndividuos(hijos):
	for hijo in hijos:
		if random.random() <= probabilidad_mutacion:
			variableDecicion  = random.randint(0,1)
			individuoACambiar = random.randint(0,4)
			nuevoValor        = random.randint(0,100)
			while nuevoValor == hijo[individuoACambiar,variableDecicion]:
				nuevoValor = random.randint(0,100)
			hijo[individuoACambiar,variableDecicion] = nuevoValor

	return hijos

def Optimizar(horasSolar,velocidadViento):
	#variables de sistema
	# horasSolar	#horas anuales de PV
	horasRadiacion = 9.25
	capacidadSolar = 0
	for i in range(horasSolar):	# horas totales en un año
		capacidadSolar+=horasRadiacion

	Capacidad['SOLAR'] = capacidadSolar

	if velocidadViento < 6:
		capacidadViento = 0
	elif velocidadViento >= 6 and velocidadViento < 10:
		capacidadViento = .0075 * math.pow(1.6,velocidadViento)
	elif velocidadViento >= 10 and velocidadViento < 12:
		capacidadViento = -0.05 + (0.0875*velocidadViento)
	else:
		capacidadViento = 1

	Capacidad['VIENTO'] = capacidadViento
	#Crear una poblacion con seis comunidades
	
	hijos = PoblacionInicial()
	for i in range(100):
		hijos = Reproduccion(hijos)
		hijos = MutacionIndividuos(hijos)

	costos = ObtenerCosto(hijos)
	indexHijoCostoMinimo = np.where(costos == np.amin(costos)) #costo minimos de todas las generaciones
	minimoCosto = min(costos)
	valoresSistema = [round(minimoCosto,2)]
	
	for hijo in hijos[indexHijoCostoMinimo]:
		for j in hijo:
			valoresSistema.append(j[0])
			valoresSistema.append(j[1])

	print("Poblacion con subsistema menor:\n {}".format(hijos[indexHijoCostoMinimo]))
	print("Costo de este subsistema: {}".format(round(minimoCosto,2)))
	return valoresSistema