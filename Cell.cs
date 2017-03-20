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

        public static bool operator==(Position pos1, Position pos2)
        {
            if(pos1.x == pos2.x && pos1.y == pos2.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator!=(Position pos1, Position pos2)
        {
            if (pos1.x == pos2.x)
            {
                return false;
            }

            if (pos1.y == pos2.y)
            {
                return false;
            }
            return true;
        }

        public int x;
        public int y;
    }


}
