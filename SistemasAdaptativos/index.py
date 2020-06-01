import tkinter as tk
from tkinter import RIGHT,BOTH,RAISED,LEFT,CENTER,X,N
from PIL import ImageTk, Image
import optimizacionEnergia as oe

def ImprimirResultados(resultados):
	frameResultado = tk.Frame()

	lblC = tk.Label(frameResultado, text="Costo Total : " + str(str(resultados[0])), width=6)
	lblC.pack(fill="both", ipadx=5, ipady=5)

	lblTS = tk.Label(frameResultado, text="SOLAR")
	lblTS.pack(fill="both", ipadx=5, ipady=5)
	if resultados[1] != 0 or resultados[2] != 0:
		lblCS = tk.Label(frameResultado, text="Capacidad de uso : " + str(resultados[1]), width=6)
		lblCS.pack(fill="both", ipadx=5, ipady=5)

		lblUS = tk.Label(frameResultado, text="Porcentaje de uso : " + str(resultados[2]), width=6)
		lblUS.pack(fill="both", ipadx=5, ipady=5)
	else:
		lblTS = tk.Label(frameResultado, text="No es necesario el uso de este producto")
		lblTS.pack(fill="both", ipadx=5, ipady=5)

	lblTV = tk.Label(frameResultado, text="VIENTO")
	lblTV.pack(fill="both", ipadx=5, ipady=5)
	lblCV = tk.Label(frameResultado, text="Capacidad de uso : " + str(resultados[3]), width=6)
	lblCV.pack(fill="both", ipadx=5, ipady=5)

	lblUV = tk.Label(frameResultado, text="Porcentaje de uso : " + str(resultados[4]), width=6)
	lblUV.pack(fill="both", ipadx=5, ipady=5)

	lblTD = tk.Label(frameResultado, text="DIESEL")
	lblTD.pack(fill="both", ipadx=5, ipady=5)
	lblCD = tk.Label(frameResultado, text="Capacidad de uso : " + str(resultados[5]), width=6)
	lblCD.pack(fill="both", ipadx=5, ipady=5)

	lblUD = tk.Label(frameResultado, text="Porcentaje de uso : " + str(resultados[6]), width=6)
	lblUD.pack(fill="both", ipadx=5, ipady=5)

	lblTBC = tk.Label(frameResultado, text="BATERIA ÁCIDO SÓLIDO -cargada")
	lblTBC.pack(fill="both", ipadx=5, ipady=5)
	lblCBC = tk.Label(frameResultado, text="Capacidad de uso : " + str(resultados[7]), width=6)
	lblCBC.pack(fill="both", ipadx=5, ipady=5)

	lblUBC = tk.Label(frameResultado, text="Porcentaje de uso : " + str(resultados[8]), width=6)
	lblUBC.pack(fill="both", ipadx=5, ipady=5)

	lblTBD = tk.Label(frameResultado, text="BATERIA ÁCIDO SÓLIDO -en descarga")
	lblTBD.pack(fill="both", ipadx=5, ipady=5)
	lblCBD = tk.Label(frameResultado, text="Capacidad de uso : " + str(resultados[9]), width=6)
	lblCBD.pack(fill="both", ipadx=5, ipady=5)

	lblUBD = tk.Label(frameResultado, text="Porcentaje de uso : " + str(resultados[10]), width=6)
	lblUBD.pack(fill="both", ipadx=5, ipady=5)

	frameResultado.pack()

def buttonClick():
	horasLuzSolar = entry1.get()
	velocidadViento = entry2.get()
	valoresSistema = oe.SetValoresSistema(int(horasLuzSolar),int(velocidadViento))

	ImprimirResultados(valoresSistema)

root = tk.Tk()
root.title("Sistemas Adaptativos")
root.height=6000
root.width=1500

w = tk.Frame(root, bg="#357C5E",height=400,width=1000)
w.pack()
titulo = tk.Label(master=w,width=30,font="Verdana",text="Optimización de Sistemas de Energía", fg="black")
titulo.pack()

photoFrame = tk.Frame(root, height=100, width=500)
#Imagen De Viento
imgV = Image.open("viento.jpg")
imgV = imgV.resize((100,100),Image.ANTIALIAS)
photoV = ImageTk.PhotoImage(imgV)
label = tk.Label(photoFrame,image=photoV)
label.image = photoV
label.pack(side=RIGHT)
#Image De Solar
imgS = Image.open("solar.jpg")
imgS = imgS.resize((100,100),Image.ANTIALIAS)
photoS = ImageTk.PhotoImage(imgS)
labelS = tk.Label(photoFrame,image=photoS)
labelS.image = photoS
labelS.pack(side=LEFT)
#Imagen De Diesel
imgD = Image.open("diesel.jpg")
imgD = imgD.resize((100,100),Image.ANTIALIAS)
photoD = ImageTk.PhotoImage(imgD)
labelD = tk.Label(photoFrame,image=photoD)
labelD.image = photoD
labelD.pack(side=RIGHT)
#Image De Bateria
imgB = Image.open("bateria.jpg")
imgB = imgB.resize((100,100),Image.ANTIALIAS)
photoB = ImageTk.PhotoImage(imgB)
labelB = tk.Label(photoFrame,image=photoB)
labelB.image = photoB
labelB.pack(side=LEFT)
photoFrame.pack()

photoFrame = tk.Frame(root, height=100, width=500)

frameForm = tk.Frame()

lbl1 = tk.Label(frameForm, text="Horas totales de Luz Solar al día: ", width=25)
lbl1.pack(side=LEFT, padx=5, pady=5)

entry1 = tk.Entry(frameForm)
entry1.pack(fill=X, padx=5, expand=True)

lbl2 = tk.Label(frameForm, text="Velocidad del viento en promedio: ", width=25)
lbl2.pack(side=LEFT, padx=5, pady=5)

entry2 = tk.Entry(frameForm)
entry2.pack(fill=X, padx=5, expand=True)

frameForm.pack(fill=X)

btnPrograma = tk.Button(text="Optimizar", fg="white", bg="#965d75", height=2, width=10, command=buttonClick)
btnPrograma.pack(side=RIGHT)
root.mainloop()

