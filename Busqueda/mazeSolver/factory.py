#Esto solo para importar el algoritmo necesario que requieras para usar en el solver

class SolverFactory:
	def __init__(self):
		self.Default = "breadthfirst"
		self.Choices = ["breadthfirst"]

	def CreateSolver(self,type):
		import breadthfirst
		return ["Breadth First Search", breadthfirst.solve]