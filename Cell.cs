using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGeneratorGUI
{

    class Cell
    {
        public Cell()
        {
            this.top = true;
            this.right = true;
            this.bottom = true;
            this.left = true;

            this.visited = false;
        }

        public bool top;
        public bool right;
        public bool bottom;
        public bool left;

        public bool visited;
    };

    class Position
    {
        public Position(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }
        public Position() { }
        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Position p = obj as Position;
            if (p == null)
            {
                return false;
            }

            return (x == p.x) && (y == p.y);
        }

        public override int GetHashCode()
        {
            return x ^ y;
        }

        public int x;
        public int y;
    }
}
