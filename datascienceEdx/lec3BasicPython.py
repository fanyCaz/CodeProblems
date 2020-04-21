import numpy as np
import pandas as pnd	#Lee formatos como .csv
import tableritos.hacerTablas as tblr

print( max([2,3,4]) )	#print the max number inside an array
print( max([2,3,4],[1,2,4]) )	#print the array where the values are bigger

flowers = pnd.read_csv('flowers.csv')

print("Numero de petalos mostrados en la tabla (columna)")
for petal in flowers['Petals']:
	print(petal)
print("Petalos directo del csv")
print( flowers['Petals'].head() )
print("Tabla con valores")
print( flowers.head() )	#Imprime una tabla con los valores

tablaFlores = tblr.crearTabla('Flores random',['Pétalos','Nombre','Color'],[flowers[k] for k in flowers.columns])
print(tablaFlores)
#Tabla completa
tablaFlores.tablaBasica()

#Solo pétalos
tablaPetalos = tblr.crearTabla('Solo Petalos',['Pétalos'],[flowers['Petals']])
tablaPetalos.tablaBasica()

##Sorting
lista = [1,2,3,5,7,2]
print( sorted(lista) )

movies = pnd.read_csv('top_movies_by_title.csv')
moviesBar = pnd.DataFrame(movies)
moviesSorted = pnd.DataFrame(movies).sort_values(by='Gross',ascending=False)
moviesSortedByStudio = pnd.DataFrame(movies).sort_values(by=['Studio','Gross'])
tablaPeliculas = tblr.crearTabla('Peliculas por título',[mov for mov in movies],[movies[k] for k in movies.columns] )
tablaPeliculas.tablaBasica()
tablaPeliculasPorGross = tblr.crearTabla('Películas por ganancia mayor a menor',[mov for mov in movies],[moviesSorted[k] for k in moviesSorted.columns])
tablaPeliculasPorGross.tablaBasica()
tablaPeliculasPorGross.muestra(3)	#Solo ocupa Tres valores
tablaPeliculasPorStudio = tblr.crearTabla('Películas ordenadas por estudio de menor ganancia a mayor',[mov for mov in movies],[moviesSortedByStudio[k] for k in moviesSortedByStudio.columns])
tablaPeliculasPorStudio.tablaBasica()

tblr.bar(moviesSortedByStudio)