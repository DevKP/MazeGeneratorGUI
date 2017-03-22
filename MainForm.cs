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
        PointF mazePos;
        PointF mazeSize;
        public MainForm()
        {
            InitializeComponent();
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

            mazePos = new PointF(0, 0);
            mazeSize = new PointF(mazeBox.Size.Height - (int)lineW.Value*2, mazeBox.Size.Width-(int)lineW.Value*2);
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
                for (int i = 0; i < iterOption.Value; i++)
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
            if (maze.cols < maze.rows)
            {
                CellSize = (mazeSize.X / maze.rows);
            }
            else
            {
                CellSize = (mazeSize.Y / maze.cols);
            }

            using (Pen myPen = new Pen(colorDialog1.Color, lineWidth))
            {
                SizeF fieldsize = new SizeF(CellSize * maze.cols, 
                                            CellSize * maze.rows);

                SizeF centering = new SizeF((mazeSize.Y - (fieldsize.Width - lineWidth)) / 2,
                                            (mazeSize.X - (fieldsize.Height - lineWidth)) / 2);

                PointF border1 = new PointF(mazePos.X,                   mazePos.Y + fieldsize.Height);
                PointF border2 = new PointF(mazePos.X + fieldsize.Width, mazePos.Y);

                e.Graphics.DrawLine(myPen, mazePos + centering, border1 + centering);
                e.Graphics.DrawLine(myPen, mazePos + centering, border2 + centering);

                for (int h = 0; h < maze.rows; h++)
                {
                    for (int w = 0; w < maze.cols; w++)
                    {
                        cellPos.X = w * CellSize;
                        cellPos.Y = h * CellSize;
                        cellPos += centering;

                        PointF RBCorner = new PointF(cellPos.X + CellSize, 
                                                     cellPos.Y + CellSize);


                      


                        if (maze.getCell(w, h).bottom)
                        {
                            PointF BottomWall = new PointF(cellPos.X, cellPos.Y + CellSize);

                            e.Graphics.DrawLine(myPen, RBCorner, BottomWall);
                        }
                        if (maze.getCell(w, h).right)
                        {
                            PointF RightWall = new PointF(cellPos.X + CellSize, cellPos.Y);

                            e.Graphics.DrawLine(myPen, RBCorner, RightWall);
                        }

                        if(visitOption.Checked)
                            if (!maze.getCell(w, h).visited)
                            {
                                myPen.Color = Color.Red;
                                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Orange);
                                e.Graphics.FillRectangle(myBrush, new Rectangle((int)cellPos.X, (int)cellPos.Y, (int)CellSize + lineWidth, (int)CellSize + lineWidth));
                                myPen.Color = colorDialog1.Color;
                            }
                    }
                }

                if (maze.stack.Count > 1)
                {
                    PointF[] path = maze.stack.ToArray();

                    int index = 0;
                    foreach (var pos in maze.stack)
                    {
                        path[index].X = mazePos.X + path[index].X * CellSize + CellSize / 2;
                        path[index].Y = mazePos.Y + path[index].Y * CellSize + CellSize / 2;

                        path[index] += centering;
                        index += 1;
                    }

                    myPen.Color = colorDialog2.Color;
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

        private void WallsBtn_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            mazeBox.Refresh();
        }

        private void PathColorBtn_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            mazeBox.Refresh();
        }
    }
}
