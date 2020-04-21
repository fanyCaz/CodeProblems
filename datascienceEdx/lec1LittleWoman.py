# from datascience import *
from urllib.request import urlopen
import numpy as np
import matplotlib.pyplot as plt
import plotly.graph_objects as plotTbl
import re
"""https://matplotlib.org/3.2.0/gallery/style_sheets/style_sheets_reference.html
 Estilos de graficas"""
# plots.style.use('seaborn-pastel')	#tipo de grafica escogida

print("Lecture 1. Analisys of data from the book Little Women")

def read_url(url):	#re sirve para 'scape' special chars
	return re.sub('\\s+',' ',urlopen(url).read().decode())

little_woman_url 	= 'https://www.inferentialthinking.com/data/little_women.txt'
little_women_text 	= read_url(little_woman_url)	#asigna el texto de esa pagina web
chapters			= little_women_text.split('CHAPTER ')[1:]

tabla = plotTbl.Figure( data=[plotTbl.Table(header=dict(values=['Chapters']),
						cells=dict(values=[chapters])) ])
#No lo muestro porque se me muere:C
# tabla.show()

#busca en todos los arrays por la palabra Christmas y muestra cuantas veces aparece
numberChapters = np.char.count(chapters,'Christmas')

numberJo = np.char.count(chapters,'Jo')
numberMeg = np.char.count(chapters,'Meg')
numberAmy = np.char.count(chapters,'Amy')
numberBeth = np.char.count(chapters,'Beth')
numberLaurie = np.char.count(chapters,'Laurie')
numberPeriods = np.char.count(chapters,'.')
print("Tabla 1. Numero de veces que sale el nombre de los protagonistas en el libro")
tablaPersonajes = plotTbl.Figure( data=[plotTbl.Table(name='toipo',visible=True,header=dict(
							values=['Jo','Meg','Amy','Beth','Laurie'],
							line_color='white', fill_color='lightblue',align='center'),
							cells=dict(values=[numberJo,numberMeg,numberAmy,numberBeth,numberLaurie])) ])
tablaPersonajes.show()
#arreglo desde el 0 a la cantidad de capitulos 0...46
numCaps = np.arange(0,len(chapters))
def sumatoria(number):		#para poner avance de acuerdo al cap
	x=0
	s = []
	for j in number:
		x+=j
		s.append(x)
	return s

print("Gráfica 1. Número de veces que un personaje es mencionado a través de los capítulos")
#para x van a ser los capitulos y para y el numero de veces que sale el nombre
plt.ylabel('Sumatoria')
plt.xlabel('Numero de capítulo')
plt.title('Número de veces que aparece el nombre en el libro')
# plt.legend(['Jo','Meg','Amy','Beth','Laurie'],loc='upper right')
plt.plot( numCaps, sumatoria(numberJo) )
plt.plot( numCaps, sumatoria(numberMeg) )
plt.plot( numCaps, sumatoria(numberAmy) )
plt.plot( numCaps, sumatoria(numberBeth) )
plt.plot( numCaps, sumatoria(numberLaurie) )
plt.legend(['Jo','Meg','Amy','Beth','Laurie'])
plt.show()

print("Gráfica 2. Número de puntos por capítulo")
#Calcular la longitud de cada capitulo vs el numero de puntos por capitulos
#Linear asociation: the more periods there is, the more sentences, so the longer length of the chapter
plt.xlabel('Longitud del capítulo')
plt.ylabel('Número de puntos por capitulo')			#arreglo de valores random para cada cap(colores)
plt.scatter( [len(c) for c in chapters] , numberPeriods,c=np.random.rand(47), alpha=0.5)
plt.show()

#Imprime la tabla pero no muestra todos los datos. Esto viene de la libreria datascience de los profes de Bekerley
# print( Table().with_columns('Jo',numberJo) )