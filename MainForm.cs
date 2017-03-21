using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGeneratorGUI
{
    public partial class MainForm : Form
    {
        Maze maze;
        Position mazePos;
        Position mazeSize;
        public MainForm()
        {
            InitializeComponent();

            maze = Maze.Instance;
            maze.createEmtpyMaze(60, 60);
            maze.generate();

            mazePos = new Position(15, 15);
            mazeSize = new Position(600, 600);

            this.Paint += new System.Windows.Forms.PaintEventHandler(MainForm_Paint);
            this.DoubleBuffered = true;
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            float CellSize = (float)mazeSize.x / (float)maze.cols;
            int lineWidth = 2;
            PointF cellPos = new PointF();

            using (Pen myPen = new Pen(System.Drawing.Color.Black, lineWidth))
            {
                e.Graphics.DrawLine(myPen, mazePos.x + lineWidth, mazePos.y + lineWidth, mazePos.x + lineWidth, maze.rows * CellSize + mazePos.y + lineWidth);
                e.Graphics.DrawLine(myPen, mazePos.x + lineWidth, mazePos.y + lineWidth, maze.cols * CellSize + mazePos.x + lineWidth, mazePos.y + lineWidth);

                for (int h = 0; h < maze.rows; h++)
                {
                    for (int w = 0; w < maze.cols; w++)
                    {
                        cellPos.X = w * CellSize + lineWidth + mazePos.x;
                        cellPos.Y = h * CellSize + lineWidth + mazePos.y;

                        if (maze.getCell(w, h).bottom)
                        {
                            e.Graphics.DrawLine(myPen, cellPos.X, cellPos.Y + CellSize, cellPos.X + CellSize, cellPos.Y + CellSize);
                        }
                        if (maze.getCell(w, h).right)
                        {
                            e.Graphics.DrawLine(myPen, cellPos.X + CellSize, cellPos.Y, cellPos.X + CellSize, cellPos.Y + CellSize);
                        }
                    }
                }
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void startGenerationButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
