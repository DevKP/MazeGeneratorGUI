using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGeneratorGUI
{
    class Maze
    {
        private static Maze instance;

        Cell[] field;
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
            this.field = new Cell[w * h];

            this.rows = h;
            this.cols = w;

            this.generated = false;
        }

        public bool draw(Position current)
        {
            return true;
        }

        private Cell getCell(int column, int row) //return cell from Column and Row indexes
        {
            return field[row * cols + column];
        }

        private Cell getCell(Position p)
        {
            return field[p.y * cols + p.x];
        }

        public bool generate()
        {
            if (field == null)
            {
                return false;
            }

            Stack<Position> stack = new Stack<Position>();
            Position current = new Position(0, 0);
            Position next = new Position();

            getCell(current).visited = true;

            while (true)
            {
                next = getNext(current);
                if (next != null)
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
                    break;
            }



            generated = true;
            return generated;
        }

        private Position getNext(Position current)
        {

            Random rnd = new Random();

            List<Position> neighbors = new List<Position>();

            Position top = new Position( current.x, current.y - 1 );
            Position right = new Position(current.x + 1, current.y );
            Position bottom = new Position(current.x, current.y + 1 );
            Position left = new Position(current.x - 1, current.y );


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
                return neighbors[rnd.Next(0,neighbors.Count - 1)];
            }
            else
            {
                return null;
            }
        }

        private bool coordsInMaze(Position p)
        {
            if (p.x < cols && p.y < rows)
                if (p.x >= 0 && p.y >= 0)
                    return true;

            return false;
        }

        private void removeWalls(Position f, Position s)
        {
            int d = f.x - s.x;
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
            d = f.y - s.y;
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