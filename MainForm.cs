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
        Bitmap mazeBitmap;

        PointF mazePos;
        PointF mazeSize;
        public MainForm()
        {
            InitializeComponent();
            maze = Maze.Instance;
            maze.createEmtpyMaze((int)mazeH.Value, (int)mazeW.Value);

            mazeBitmap = new Bitmap(mazeBox.Size.Width,mazeBox.Size.Height);
            mazeBox.Image = mazeBitmap;

            generateTimer.Interval = (int)generationSpeed.Value;
            generateTimer.Tick += onGenerateTick;

            refreshTimer.Interval = (int)refreshTimeout.Value;
            refreshTimer.Tick += RefreshTimer_Tick;

            generationSpeed.ValueChanged += GenerationSpeed_ValueChanged;
            refreshTimeout.ValueChanged += RefreshTimeout_ValueChanged;


            wallsColorBtn.BackColor = colorDialog1.Color;
            PathColorBtn.BackColor = colorDialog2.Color;
            bgrndColorBtn.BackColor = colorDialog3.Color;


            //this.ResizeEnd += MainForm_ResizeEnd;
            this.Resize += MainForm_Resize;
            this.ResizeEnd += MainForm_ResizeEnd;

            //this.Paint += new PaintEventHandler(MainForm_Paint);
            //mazeBox.Paint += new PaintEventHandler(MainForm_Paint); ;

            mazePos = new PointF(0, 0);
            mazeSize = new PointF(mazeBox.Size.Height - (int)lineW.Value*2, mazeBox.Size.Width-(int)lineW.Value*2);
            //mazeSize = new PointF(10000 - (int)lineW.Value * 2, 10000 - (int)lineW.Value * 2);

            updateMaze();
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            updateMaze();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            mazeBitmap = new Bitmap(mazeBox.Size.Width, mazeBox.Size.Height);
            mazeBox.Image = mazeBitmap;
            mazeSize = new PointF(mazeBox.Size.Height - (int)lineW.Value * 2, mazeBox.Size.Width - (int)lineW.Value * 2);

            if (this.WindowState == FormWindowState.Maximized)
            {
                updateMaze();
            }
            else
            {
                drawMaze(true);
                mazeBox.Refresh();
            }
        }

        private void RefreshTimeout_ValueChanged(object sender, EventArgs e)
        {
            refreshTimer.Interval = (int)(sender as NumericUpDown).Value;
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            updateMaze();
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
                progressBar1.Value = maze.visitedCells / (maze.CellCount / 100);
                procentsLabel.Text = progressBar1.Value.ToString() + "%";
            }
            else
            {
                progressBar1.Value = 100;
                procentsLabel.Text = progressBar1.Value.ToString() + "%";
                generateTimer.Enabled = false;
                refreshTimer.Enabled = false;

                startGenerationButton.Text = "Start generation";
            }
        }

        private void drawMaze(bool drawOnlyRectangle)
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

            if(CellSize * maze.cols > mazeSize.Y)
            {
                CellSize = (mazeSize.Y / maze.cols);
            }

            if (CellSize * maze.rows > mazeSize.X)
            {
                CellSize = (mazeSize.X / maze.rows);
            }

            Graphics g;
            g = Graphics.FromImage(mazeBitmap);

            g.Clear(colorDialog3.Color);

            using (Pen myPen = new Pen(colorDialog1.Color, lineWidth))
            {
                SizeF fieldsize = new SizeF(CellSize * maze.cols,
                                            CellSize * maze.rows);

                SizeF centering = new SizeF((mazeSize.Y - (fieldsize.Width - lineWidth)) / 2,
                                            (mazeSize.X - (fieldsize.Height - lineWidth)) / 2);

                PointF border1 = new PointF(mazePos.X, mazePos.Y + fieldsize.Height);
                PointF border2 = new PointF(mazePos.X + fieldsize.Width, mazePos.Y);

                

                if (!drawOnlyRectangle)
                {
                    g.DrawLine(myPen, mazePos + centering, border1 + centering);
                    g.DrawLine(myPen, mazePos + centering, border2 + centering);

                    for (int h = 0; h < maze.rows; h++)
                    {
                        for (int w = 0; w < maze.cols; w++)
                        {
                            cellPos.X = w * CellSize;
                            cellPos.Y = h * CellSize;
                            cellPos += centering;

                            PointF RBCorner = new PointF(cellPos.X + CellSize,
                                                         cellPos.Y + CellSize);



                            if (semptyOption.Checked)
                            {
                                if (maze.getCell(w, h).bottom)
                                {
                                    PointF BottomWall = new PointF(cellPos.X, cellPos.Y + CellSize);

                                    g.DrawLine(myPen, RBCorner, BottomWall);
                                }
                                if (maze.getCell(w, h).right)
                                {
                                    PointF RightWall = new PointF(cellPos.X + CellSize, cellPos.Y);

                                    g.DrawLine(myPen, RBCorner, RightWall);
                                }
                            }
                            else
                            {
                                if (maze.getCell(w, h).visited)
                                {
                                    if (maze.getCell(w, h).bottom)
                                    {
                                        PointF BottomWall = new PointF(cellPos.X, cellPos.Y + CellSize);

                                        g.DrawLine(myPen, RBCorner, BottomWall);
                                    }
                                    if (maze.getCell(w, h).right)
                                    {
                                        PointF RightWall = new PointF(cellPos.X + CellSize, cellPos.Y);

                                        g.DrawLine(myPen, RBCorner, RightWall);
                                    }
                                }
                            }



                            if (visitOption.Checked)
                                if (!maze.getCell(w, h).visited)
                                {
                                    myPen.Color = Color.Red;
                                    System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Orange);
                                    g.FillRectangle(myBrush, new Rectangle((int)cellPos.X, (int)cellPos.Y, (int)CellSize + lineWidth, (int)CellSize + lineWidth));
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

                        g.DrawLines(myPen, path);
                    }
                }
                else
                {
                    g.DrawRectangle(myPen, new Rectangle((int)centering.Width, (int)centering.Height, (int)fieldsize.Width, (int)fieldsize.Height));
                }
            }
            g.Dispose();
        }

        private void updateMaze()
        {
            drawMaze(false);
            mazeBox.Refresh();
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

                if (generateTimer.Enabled)
                {
                    (sender as Button).Text = "Pause generation";
                }
                else
                {
                    (sender as Button).Text = "Start generation";
                }
            }
            else
            {
                maze.generate();
                updateMaze();
            }
        }

        private void WallsBtn_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            (sender as Button).BackColor = colorDialog1.Color;
            updateMaze();
        }

        private void PathColorBtn_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            (sender as Button).BackColor = colorDialog2.Color;
            updateMaze();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            maze.createEmtpyMaze((int)mazeH.Value, (int)mazeW.Value);
            updateMaze();
        }

        private void savePictureToolStripMenu_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            mazeBox.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
        }

        private void bgrndColorBtn_Click(object sender, EventArgs e)
        {
            colorDialog3.ShowDialog();
            (sender as Button).BackColor = colorDialog3.Color;
            updateMaze();
        }

        private void aboutToolStrip_Click(object sender, EventArgs e)
        {
            (new AboutBox1()).ShowDialog(this);
        }

        private void ResizeBtn_Click(object sender, EventArgs e)
        {
            mazeBitmap = new Bitmap(mazeBox.Size.Width, mazeBox.Size.Height);
            mazeBox.Image = mazeBitmap;
            mazeSize = new PointF(mazeBox.Size.Height - (int)lineW.Value * 2, mazeBox.Size.Width - (int)lineW.Value * 2);
            updateMaze();
        }
    }
}
