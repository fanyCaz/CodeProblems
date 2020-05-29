import pygame
import numpy as np
import os  
import time

#Regla 58

#Posicion en la pantalla
os.environ['SDL_VIDEO_WINDOW_POS'] = str(50) + "," + str(150)

#Configuracion de pygame
pygame.init()

width, height = 600,600
pantalla = pygame.display.set_mode((height,width))

bg = 25,25,25
pantalla.fill(bg)
#---fin config pygame

#congiguracion de celdas al inicio
numCeldasX, numCeldasY = 25,25	#cantidad de celdar en la cuadricula

dimCX = width / numCeldasX #dimension de celdas en x
dimCY = width / numCeldasY #dimension de celdas en y

#1 vivo 0 ded
estadosCeldas = np.zeros( (numCeldasX, numCeldasY) )

#unica celula viva al principio
estadosCeldas[10,0] = 1
estadosCeldas[11,0] = 1
estadosCeldas[11,6] = 1
estadosCeldas[21,0] = 1

while True:
	#se hace una copia para mantener los estados originales mientras dure la iteracion
	nuevoEstadosCeldas = np.copy(estadosCeldas)

	pantalla.fill(bg)
	time.sleep(0.1)

	for y in range(0,numCeldasX):
		for x in range(0,numCeldasY):
			if(y + 1) == 25 :		#Para que no rompa las dimensiones del juego
				break

			#dando la forma continua
			vecinoIzq = estadosCeldas[(x-1) % numCeldasX, y % numCeldasY]
			vecinoDer = estadosCeldas[(x+1) % numCeldasX, y % numCeldasY]
			#Estados de la regla 58
			if vecinoIzq == 1 and estadosCeldas[x,y] == 1 and vecinoDer == 1:
				nuevoEstadosCeldas[x,y+1] = 0
			elif vecinoIzq == 1 and estadosCeldas[x,y] == 1 and vecinoDer == 0:
				nuevoEstadosCeldas[x,y+1] = 0
			elif vecinoIzq == 1 and estadosCeldas[x,y] == 0 and vecinoDer == 1:
				nuevoEstadosCeldas[x,y+1] = 1
			elif vecinoIzq == 1 and estadosCeldas[x,y] == 0 and vecinoDer == 0:
				nuevoEstadosCeldas[x,y+1] = 1
			elif vecinoIzq == 0 and estadosCeldas[x,y] == 1 and vecinoDer == 1:
				nuevoEstadosCeldas[x,y+1] = 1
			elif vecinoIzq == 0 and estadosCeldas[x,y] == 1 and vecinoDer == 0:
				nuevoEstadosCeldas[x,y+1] = 0
			elif vecinoIzq == 0 and estadosCeldas[x,y] == 0 and vecinoDer == 1:
				nuevoEstadosCeldas[x,y+1] = 1
			else:
				nuevoEstadosCeldas[x,y+1] = 0

			#El poligono se manda a pygame para mostrar las celdas
			poligono = [(x   * dimCX, y     * dimCY),
						((x+1) * dimCX, y     * dimCY),
						((x+1) * dimCX, (y+1) * dimCY),
						(x   * dimCX, (y+1) * dimCY)]

			if nuevoEstadosCeldas[x,y] == 0:
				pygame.draw.polygon(pantalla, (128,128,128), poligono,1)
			else:
				pygame.draw.polygon(pantalla, (255,255,255), poligono,0)

	estadosCeldas = np.copy(nuevoEstadosCeldas)

	pygame.display.flip()