grid = [[0,1,0,0],
 [1,1,1,0],
 [0,1,0,0],
 [1,1,0,0]];

class  Solution:
	def islandPerimeter(self, grid: List[List[int]]) -> int:
			
		perimetro = 0
		izq, der, arr , aba = 0,0,0,0
		for i in range(len(grid)):
			for j in range(len(grid[i])):
				izq = 0 if(j == 0) else grid[i][j - 1]
				der = 0 if(j == len(grid[i]) - 1) else grid[i][j + 1]
				arr = 0 if(i == 0) else grid[i - 1][j]
				aba = 0 if(i == len(grid - 1)) else grid[i + 1][j]
				perimetro += (4 - izq + der + arr + aba)
				print(grid[i][j])

		return perimetro

Solution.islandPerimeter(grid)