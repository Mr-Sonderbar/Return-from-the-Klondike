using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaldLabyrinth;

namespace Return_from_the_Klondike
{
    public partial class Form1 : Form
    {
        Labyrinth game;

        public Form1()
        {
            string filepath = "H:\\LF05 - Programmierung\\repos\\Return from the Klondike\\Labyrinth_wald_1.txt";

            if (filepath != null)
            {
                try
                {
                    TextReader reader = File.OpenText(filepath);

                    string text = reader.ReadToEnd();

                    game = new Labyrinth(text);

                    game.printGrid();

                    InitializeComponent();

                    int i = 0;
                    int x = 0;
                    int y = 0;
                    int[][] grid = game.getGrid();
                    foreach (Control item in flowLayoutPanel1.Controls)
                    {
                        y = i / 21;
                        x = i % 21;
                        i++;

                        item.Text = grid[y][x].ToString();
                        item.Name = x.ToString() + "-" + y.ToString();
                    }

                    this.updateGrid();
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
        }

        private void updateGrid()
        {
            int[][] grid = game.getGrid();

            int i = 0;
            int x = 0;
            int y = 0;

            int steps = grid[game.getCurrentPos().getY()][game.getCurrentPos().getX()];

            List<Punkt> moves = game.getMoves();

            // Console.WriteLine(moves.ToString());
            
            foreach (Control item in flowLayoutPanel1.Controls)
            {
                y = i / 21;
                x = i % 21;
                i++;
                item.BackColor = Color.White;

                item.Click -= new System.EventHandler(this.Move_Click);

                string[] coords = item.Name.Split('-');

                Punkt punkt = new Punkt(int.Parse(coords[0]), int.Parse(coords[1]));

                Punkt move = moves.Find(l => (l.getX() == punkt.getX()) && (l.getY() == punkt.getY()));

                if (move != null)
                {
                    // Console.WriteLine(move.ToString());
                    // item.BackColor = Color.Green;
                }

                if (game.getCurrentPos().getX() == x && game.getCurrentPos().getY() == y)
                {
                    item.BackColor = Color.Blue;
                }
                if (game.getCurrentPos().getX() + steps == x || game.getCurrentPos().getX() - steps == x || game.getCurrentPos().getX() == x)
                {
                    if (game.getCurrentPos().getY() + steps == y || game.getCurrentPos().getY() - steps == y || game.getCurrentPos().getY() == y)
                    {
                        if (game.getCurrentPos().getX() != x || game.getCurrentPos().getY() != y)
                        {
                            item.BackColor = Color.Green;
                            item.Click += new System.EventHandler(this.Move_Click);
                        }
                    }
                }
            }


            foreach (Punkt punkt in moves) {
                Console.WriteLine(punkt.ToString());
            }

            Console.WriteLine(game.getMoves().ToString());
        }
        private void Move_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;

            string[] coords = control.Name.Split('-');

            int x = int.Parse(coords[0]);
            int y = int.Parse(coords[1]);

            if (x > game.getCurrentPos().getX())
            {
                if (y > game.getCurrentPos().getY())
                {
                    game.moveDownRight();
                }
                else if (y == game.getCurrentPos().getY())
                {
                    game.moveRight();
                }
                else if (y < game.getCurrentPos().getY())
                {
                    game.moveUpRight();
                }
            } else if (x < game.getCurrentPos().getX())
            {
                if (y > game.getCurrentPos().getY())
                {
                    game.moveDownLeft();
                }
                else if (y < game.getCurrentPos().getY())
                {
                    game.moveUpLeft();
                }
                else if (y == game.getCurrentPos().getY())
                {
                    game.moveLeft();
                }
            } else if (x == game.getCurrentPos().getX())
            {
                if (y > game.getCurrentPos().getY())
                {
                    game.moveDown();
                }
                else if (y < game.getCurrentPos().getY())
                {
                    game.moveUp();
                }
            }

            this.updateGrid();
        }
    }
}
