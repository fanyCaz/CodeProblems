class Maze:
	class Node:
		def __init__(self,position):
			self.Position   = position
			self.Neighbours = [None,None,None,None]

	def __init__(self,image):
		width = image.size[0]
		height = image.size[1]
		data = list(image.GetData(0))

		self.start = None
		self.end   = None

		#Top row buffer **find out what this means**
		topNodes = [None] * width
		count    = 0

		for x in range(1,width - 1):	#empieza en 1 porque no cuenta al borde, y termina en uno menos por la misma razon
			if data[x] > 0:
				self.start = Maze.Node((0,x))
				topNodes[x] = self.start
				count += 1
				break

		for y in range(1,height-1):
			print("row {}".format(y))

			rowOffset = y * width
			rowAboveOffset = rowOffset - width
			rowBelowOffset = rowOffset + width

			#inicializar valores
			previus = False
			current = False
			nextVal = data[rowOffset + 1] > 0

			leftNode = None

			for x in range(1, width - 1):
				previus = current
				current = nextVal
				nextVal = data[rowOffset + x + 1] > 0

