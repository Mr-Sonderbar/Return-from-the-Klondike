using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaldLabyrinth
{
    internal class Labyrinth
    {
        private int[][] grid;
        private Punkt currentPos = new Punkt(0, 0);

        public Labyrinth(string gridRaw) 
        {
            string[] rows = gridRaw.Split('\n');
            grid = new int[rows.Length][];

            if (rows.Length % 2 == 1)
            {
                currentPos.setY(rows.Length / 2);
                for (int i = 0; i < rows.Length; i++)
                {
                    string[] columns = rows[i].Split(' ');
                    grid[i] = new int[columns.Length];
                    for (int j = 0; j < columns.Length; j++)
                    {
                        grid[i][j] = Convert.ToInt32(columns[j]);
                    }
                }

                int columnsLength = rows[0].Split(' ').Length;

                if (columnsLength % 2 == 1)
                {
                    currentPos.setX(columnsLength / 2);
                }
            }
        }

        public void printGrid()
        {
            for (int i = 0; i <= grid.Length*4-2; i++) {
                Console.Write('-');
            }
            Console.WriteLine();
            for (int i = 0;i < grid.Length;i++)
            {
                for(int j = 0;j < grid[i].Length; j++)
                {
                    if (currentPos.getX() == j && currentPos.getY() == i)
                    {
                        Console.Write('[' + grid[i][j].ToString() + "] ");
                    } else
                    {
                        Console.Write(' ' + grid[i][j].ToString() + "  ");
                    }
                }
                Console.WriteLine();
            }
            for (int i = 0; i <= grid.Length * 4-2; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();
        }

        public int[][] getGrid()
        {
            return grid;
        }

        public Punkt getCurrentPos()
        {
            return currentPos;
        }

        public List<Punkt> getMoves()
        {
            int steps = grid[currentPos.getY()][currentPos.getX()];

            List<Punkt> moves = new List<Punkt>();

            int N = currentPos.getY() - steps;
            int S = currentPos.getY() + steps;
            int W = currentPos.getX() - steps;
            int E = currentPos.getX() + steps;

            if (N > 0)
            {
                Punkt N_Punkt = new Punkt(currentPos.getX(), N);
                moves.Add(N_Punkt);
            }
            if (S < grid.Length)
            {
                Punkt S_Punkt = new Punkt(currentPos.getX(), S);
                moves.Add(S_Punkt);
            }
            if (W > 0)
            {
                Punkt W_Punkt = new Punkt(W, currentPos.getY());
                moves.Add(W_Punkt);
            }
            if (E < grid[currentPos.getY()].Length)
            {
                Punkt E_Punkt = new Punkt(E, currentPos.getY());
                moves.Add(E_Punkt);
            }
            if (N > 0 && W > 0)
            {
                Punkt NW_Punkt = new Punkt(W, N);
                moves.Add(NW_Punkt);
            }
            if (S < grid.Length && W > 0)
            {
                Punkt SW_Punkt = new Punkt(W, S);
                moves.Add(SW_Punkt);
            }
            if (N > 0 && E < grid[currentPos.getY()].Length)
            {
                Punkt NE_Punkt = new Punkt(N, E);
                moves.Add(NE_Punkt);
            }
            if (S < grid.Length &&  E < grid[currentPos.getY()].Length)
            {
                Punkt SE_Punkt = new Punkt(S, E);
                moves.Add(SE_Punkt);
            }

            return moves;
        }

        public void moveUp()
        {
            int x = currentPos.getX();
            int y = currentPos.getY();
            int steps = grid[y][x];

            currentPos.setY(y - steps);
            printGrid();
        }

        public void moveRight()
        {
            int x = currentPos.getX();
            int y = currentPos.getY();
            int steps = grid[y][x];

            currentPos.setX(x + steps);
            printGrid();
        }

        public void moveDown()
        {
            int x = currentPos.getX();
            int y = currentPos.getY();
            int steps = grid[y][x];

            currentPos.setY(y + steps);
            printGrid();
        }

        public void moveLeft()
        {
            int x = currentPos.getX();
            int y = currentPos.getY();
            int steps = grid[y][x];

            currentPos.setX(x - steps);
            printGrid();
        }

        public void moveUpRight()
        {
            int x = currentPos.getX();
            int y = currentPos.getY();
            int steps = grid[y][x];

            currentPos.setY(y - steps);
            currentPos.setX(x + steps);
            printGrid();
        }

        public void moveDownRight()
        {
            int x = currentPos.getX();
            int y = currentPos.getY();
            int steps = grid[y][x];

            currentPos.setY(y + steps);
            currentPos.setX(x + steps);
            printGrid();
        }

        public void moveDownLeft()
        {
            int x = currentPos.getX();
            int y = currentPos.getY();
            int steps = grid[y][x];

            currentPos.setY(y + steps);
            currentPos.setX(x - steps);
            printGrid();
        }

        public void moveUpLeft()
        {
            int x = currentPos.getX();
            int y = currentPos.getY();
            int steps = grid[y][x];

            currentPos.setY(y - steps);
            currentPos.setX(x - steps);
            printGrid();
        }
    }
}
