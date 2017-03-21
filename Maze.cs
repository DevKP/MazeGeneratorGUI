using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MazeGeneratorGUI
{
    class Maze
    {
        private static Maze instance;

        private List<Cell> field;

        public Stack<PointF> stack = new Stack<PointF>();
        public PointF current = new PointF(0, 0);
        public PointF next = new PointF();

        public int cols;
        public int rows;
        public bool generated { get; set; }


        private Maze() { }
        public static Maze Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Maze();
                }
                return instance;
            }
        }

        public void createEmtpyMaze(int h, int w)
        {
            this.field = new List<Cell>(w * h);

            for (int i = 0; i < w * h; i++)
                this.field.Add(new Cell());

            this.rows = h;
            this.cols = w;

            this.generated = false;
        }

        public bool draw(Position current)
        {
            return true;
        }

        public Cell getCell(int column, int row) //return cell from Column and Row indexes
        {
            if ((row * cols + column) > field.Count - 1)
                return null;
            else
                return field[row * cols + column];
        }

        public Cell getCell(Position p)
        {
            if ((p.y * cols + p.x) > field.Count - 1)
                return null;
            else
                return field[p.y * cols + p.x];
        }

        public Cell getCell(PointF p)
        {
            if ((p.Y * cols + p.X) > field.Count - 1)
                return null;
            else
                return field[(int)p.Y * cols + (int)p.X];
        }

        public bool generate()
        {
            while(!this.generated)
            {
                this.generateOneStep();
            }

            return true;
        }

        public bool generateOneStep()
        {
            if (field == null)
            {
                return false;
            }

            getCell(current).visited = true;

            next = getNext(current);
            if (next.X != -1f)
            {
                getCell(next).visited = true;

                stack.Push(current);

                removeWalls(current, next);

                current = next;
            }
            else if (stack.Count > 0)
            {
                current = stack.Pop();
            }
            else
            {
                generated = true;
            }

            
            return generated;
        }

        private PointF getNext(PointF current)
        {

            RandomNumber rand = new RandomNumber();

            List<PointF> neighbors = new List<PointF>();

            PointF top = new PointF( current.X, current.Y - 1 );
            PointF right = new PointF(current.X + 1, current.Y );
            PointF bottom = new PointF(current.X, current.Y + 1 );
            PointF left = new PointF(current.X - 1, current.Y );


            //check for valid coords and visit flag
            if (coordsInMaze(top))
                if (!getCell(top).visited)
                {
                    neighbors.Add(top);
                }

            if (coordsInMaze(right))
                if (!getCell(right).visited)
                {
                    neighbors.Add(right);
                }

            if (coordsInMaze(bottom))
                if (!getCell(bottom).visited)
                {
                    neighbors.Add(bottom);
                }

            if (coordsInMaze(left))
                if (!getCell(left).visited)
                {
                    neighbors.Add(left);
                }

            if (neighbors.Count > 0)
            {
                return neighbors[rand.Next(neighbors.Count)];
            }
            else
            {
                return new PointF(-1f,-1f);
            }
        }

        private bool coordsInMaze(PointF p)
        {
            if (p.X < cols && p.Y < rows)
                if (p.X >= 0 && p.Y >= 0)
                    return true;

            return false;
        }

        private void removeWalls(PointF f, PointF s)
        {
            int d = (int)f.X - (int)s.X;
            if (d > 0)
            {
                getCell(s).right = false;
                getCell(f).left = false;
            }
            else if (d < 0)
            {
                getCell(f).right = false;
                getCell(s).left = false;
            }
            d = (int)f.Y - (int)s.Y;
            if (d > 0)
            {
                getCell(s).bottom = false;
                getCell(f).top = false;
            }
            else if (d < 0)
            {
                getCell(f).bottom = false;
                getCell(s).top = false;
            }
        }
    }
}