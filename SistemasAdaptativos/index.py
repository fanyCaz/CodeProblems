import tkinter as tk
from tkinter import RIGHT,BOTH,RAISED,LEFT,CENTER,X,N
from PIL import ImageTk, Image
import optimizacionEnergia as oe

def ImprimirResultados(resultados):

	lblC = tk.Label(frameForm, text="Costo Total : " + str(str(resultados[0])), width=6)
	lblC.pack(side=LEFT, padx=5, pady=5)

	lblTS = tk.Label(frameForm, text="SOLAR")
	lblCS = tk.Label(frameForm, text="Capacidad de uso : " + str(resultados[1]), width=6)
	lblCS.pack(side=LEFT, padx=5, pady=5)

	lblUS = tk.Label(frameForm, text="Porcentaje de uso : " + str(resultados[2]), width=6)
	lblUS.pack(side=LEFT, padx=5, pady=5)

	lblTV = tk.Label(frameForm, text="VIENTO")
	lblCV = tk.Label(frameForm, text="Capacidad de uso : " + str(resultados[3]), width=6)
	lblCV.pack(side=LEFT, padx=5, pady=5)

	lblUV = tk.Label(frameForm, text="Porcentaje de uso : " + str(resultados[4]), width=6)
	lblUV.pack(side=LEFT, padx=5, pady=5)

	lblTD = tk.Label(frameForm, text="DIESEL")
	lblCD = tk.Label(frameForm, text="Capacidad de uso : " + str(resultados[5]), width=6)
	lblCD.pack(side=LEFT, padx=5, pady=5)

	lblUD = tk.Label(frameForm, text="Porcentaje de uso : " + str(resultados[6]), width=6)
	lblUD.pack(side=LEFT, padx=5, pady=5)

	lblTBC = tk.Label(frameForm, text="BATERIA ÁCIDO SÓLIDO -cargada")
	lblCBC = tk.Label(frameForm, text="Capacidad de uso : " + str(resultados[7]), width=6)
	lblCBC.pack(side=LEFT, padx=5, pady=5)

	lblUBC = tk.Label(frameForm, text="Porcentaje de uso : " + str(resultados[8]), width=6)
	lblUBC.pack(side=LEFT, padx=5, pady=5)

	lblTBD = tk.Label(frameForm, text="BATERIA ÁCIDO SÓLIDO -en descarga")
	lblCBD = tk.Label(frameForm, text="Capacidad de uso : " + str(resultados[9]), width=6)
	lblCBD.pack(side=LEFT, padx=5, pady=5)

	lblUBD = tk.Label(frameForm, text="Porcentaje de uso : " + str(resultados[10]), width=6)
	lblUBD.pack(side=LEFT, padx=5, pady=5)

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


# Imagen De Viento
# imgV = Image.open("viento.jpg")
# imgV = imgV.resize((100,100),Image.ANTIALIAS)
# photoV = ImageTk.PhotoImage(imgV)
# label = tk.Label(image=photoV)
# label.image = photoV
# label.grid(row=2,column=4,padx=5,pady=5)
# # #Image De Solar
# imgS = Image.open("solar.jpg")
# imgS = imgS.resize((100,100),Image.ANTIALIAS)
# photoS = ImageTk.PhotoImage(imgS)
# labelS = tk.Label(image=photoS)
# labelS.image = photoS
# label.grid(row=1,column=0,padx=5,pady=5)
# #Imagen De Diesel
# imgD = Image.open("diesel.jpg")
# imgD = imgD.resize((100,100),Image.ANTIALIAS)
# photoD = ImageTk.PhotoImage(imgD)
# labelD = tk.Label(image=photoD)
# labelD.image = photoD
# label.grid(row=1,column=0,sticky="we")
# #Image De Bateria
# imgB = Image.open("bateria.jpg")
# imgB = imgB.resize((100,100),Image.ANTIALIAS)
# photoB = ImageTk.PhotoImage(imgB)
# labelB = tk.Label(image=photoB)
# labelB.image = photoB
# label.grid(row=4,column=0)
# photoFrame.pack()


label1 = tk.Label(text="1", bg="black", fg="white")
label2 = tk.Label(text="2", bg="black", fg="white")
# label3 = tk.Label(text="3", bg="black", fg="white")
# label4 = tk.Label(text="4", bg="black", fg="white")

# label1.grid(row=2, column=0,sticky="nsew")
# label2.grid(row=1, column=2)
# label3.grid(row=0, column=2, sticky="nsew")
# label4.grid(row=0, column=3, sticky="nsew")

# window.mainloop()
# frameForm = tk.Frame()
# frameForm.pack(fill=X)
# lbl1 = tk.Label(frameForm, text="Horas totales de Luz Solar", width=20)
# lbl1.pack(side=LEFT, padx=5, pady=5)

# entry1 = tk.Entry(frameForm)
# entry1.pack(fill=X, padx=5, expand=True)

# lbl2 = tk.Label(frameForm, text="Velocidad del viento", width=20)
# lbl2.pack(side=LEFT, padx=5, pady=5)

# entry2 = tk.Entry(frameForm)
# entry2.pack(fill=X, padx=5, expand=True)

# btnPrograma = tk.Button(text="Optimizar", fg="white", bg="#965d75", height=5,width=20,command=buttonClick)
# btnPrograma.pack(side=RIGHT)
root.mainloop()

