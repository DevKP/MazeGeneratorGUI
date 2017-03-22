using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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

            //this.DoubleBuffered = true;
           // typeof(GroupBox).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
           //| BindingFlags.Instance | BindingFlags.NonPublic, null,
           //mazeBox, new object[] { true });

            maze = Maze.Instance;
            maze.createEmtpyMaze((int)mazeH.Value, (int)mazeW.Value);

            generateTimer.Interval = 5;
            generateTimer.Tick += onGenerateTick;

            refreshTimer.Interval = (int)refreshTimeout.Value;
            refreshTimer.Tick += RefreshTimer_Tick;

            generationSpeed.ValueChanged += GenerationSpeed_ValueChanged;
            refreshTimeout.ValueChanged += RefreshTimeout_ValueChanged;
            

            //this.Paint += new PaintEventHandler(MainForm_Paint);
            mazeBox.Paint += new PaintEventHandler(MainForm_Paint); ;

            mazePos = new Position((int)lineW.Value, (int)lineW.Value);
            mazeSize = new Position(mazeBox.Size.Height - (int)lineW.Value*2, mazeBox.Size.Width - (int)lineW.Value * 2);
        }

        private void RefreshTimeout_ValueChanged(object sender, EventArgs e)
        {
            refreshTimer.Interval = (int)refreshTimeout.Value;
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            mazeBox.Refresh();
        }

        private void GenerationSpeed_ValueChanged(object sender, EventArgs e)
        {
            generateTimer.Interval = (int)(sender as NumericUpDown).Value;
        }

        private void onGenerateTick(object sender, EventArgs e)
        {
            if (!maze.generated)
            {
                maze.generateOneStep();
            }
            else
            {
                generateTimer.Enabled = false;
                refreshTimer.Enabled = false;
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            int lineWidth = (int)lineW.Value;
            PointF cellPos = new PointF();

            float CellSize;
            if (mazeSize.x > mazeSize.y)
            {
                CellSize = ((float)mazeSize.x / (float)maze.cols);
            }
            else
            {
                CellSize = ((float)mazeSize.y / (float)maze.rows) ;
            }

            using (Pen myPen = new Pen(Color.Black, lineWidth))
            {
                e.Graphics.DrawLine(myPen, mazePos.x, mazePos.y, mazePos.x, maze.rows * CellSize + mazePos.y);
                e.Graphics.DrawLine(myPen, mazePos.x, mazePos.y, maze.cols * CellSize + mazePos.x , mazePos.y);

                for (int h = 0; h < maze.rows; h++)
                {
                    for (int w = 0; w < maze.cols; w++)
                    {
                        cellPos.X = mazePos.x + (w * CellSize);
                        cellPos.Y = mazePos.y + (h * CellSize);

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

                if (maze.stack.Count > 1)
                {
                    PointF[] path = maze.stack.ToArray();

                    //myPen.Color = Color.Green;
                    //myPen.Width = CellSize * 0.8f;

                    //for (int i = 0;i < maze.stack.Count - 1;i++)
                    //{
                    //    PointF f = new PointF(mazePos.x + lineWidth + path[i].X * CellSize + CellSize / 2,
                    //       mazePos.y + lineWidth + path[i].Y * CellSize + CellSize / 2);
                    //    PointF s = new PointF(mazePos.x + lineWidth + path[i + 1].X * CellSize + CellSize / 2,
                    //       mazePos.y + lineWidth + path[i + 1].Y * CellSize + CellSize / 2);
                    //    e.Graphics.DrawLine(myPen, f, s);
                    //}
                    int index = 0;
                    foreach (var pos in maze.stack)
                    {
                        path[index].X = mazePos.x + path[index].X * CellSize + CellSize / 2;
                        path[index].Y = mazePos.y + path[index].Y * CellSize + CellSize / 2;
                        index += 1;
                    }

                    myPen.Color = Color.Green;
                    myPen.Width = CellSize * ((float)pathSizeOption.Value / 100);

                    e.Graphics.DrawLines(myPen, path);
                }
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void startGenerationButton_Click(object sender, EventArgs e)
        {
            if (maze.generated)
            {
                maze.createEmtpyMaze((int)mazeH.Value, (int)mazeW.Value);
            }
            if (visGen.Checked)
            {
                generateTimer.Enabled = !generateTimer.Enabled;
                refreshTimer.Enabled = !refreshTimer.Enabled;
            }
            else
            {
                maze.generate();
                mazeBox.Refresh();
            }
        }
    }
}
