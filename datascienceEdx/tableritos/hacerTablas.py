#Parte de paquete de tableros para mostrar graficamente objetos
import matplotlib.pyplot as plotGraph
import plotly.graph_objects as plotTbl
from plotly.subplots import make_subplots
import plotly.express as px
import numpy as np

class Tabla:
	def __init__(self, headers, columns, title):
		self.headers = headers
		self.columns = columns
		self.title   = title

	def __str__(self):
		return "Tabla : " + self.title

	def tablaBasica(self):
		fig = make_subplots(
		    rows=1, cols=1,
		    shared_xaxes=True,
		    vertical_spacing=0.03,
		    specs=[[{"type": "table"}] ]
		)
		fig.add_trace(
			plotTbl.Table(
				header=dict(
						values=self.headers
					),
				cells=dict(
						values=self.columns
					)
				),
			row=1,col=1
		)
		fig.update_layout(
			title_text=self.title
		)

		fig.show()

	def muestra(self,veces):
		cMostrar = [k[:veces] for k in self.columns]
		return Tabla(self.headers,cMostrar,self.title + ", valores de 1 a " + str(veces)).tablaBasica()

def crearTabla(titulo, headers, columns):
	try:
		tabla = Tabla(headers,columns,titulo)
	except:
		return "No ha sido posible generar la tabla. Verifica los argumentos enviados"
	return tabla