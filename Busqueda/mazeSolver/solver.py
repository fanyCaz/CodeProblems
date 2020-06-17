from PIL import Image
from factory import SolverFactory
import time
import argparse #lee argumentos de la linea de comandos

Image.MAX_IMAGE_PIXELS = None

def solve(factory,method,input_file,output_file):
	print("Loading Image")
	image = Image.open(input_file)

	print("Creating Maze")
	t0 = time.time()
	maze = Maze(image)

def main():
	solver = SolverFactory()
	parser = argparse.ArgumentParser()
	parser.add_argument("-m","--method",nargs='?',const=solver.Default, default=solver.Default, choices=solver.Choices)
	parser.add_argument("input_file")
	parser.add_argument("output_file")
	args = parser.parse_args()

	#objeto , metodo, maze, maze resuelto
	solve(solver,args.method,args.input_file,args.output_file)

if __name__ == "__main__":
	main()
