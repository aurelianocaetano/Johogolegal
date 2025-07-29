using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace JohogoLegal
{
    public class Vector2
    {
        public int x { get; set; }
        public int y { get; set; }

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2 Up() => new Vector2(x, y - 1);
        public Vector2 Down() => new Vector2(x, y + 1);
        public Vector2 Left() => new Vector2(x - 1, y);
        public Vector2 Right() => new Vector2(x + 1, y);

        public static int Distance(Vector2 a, Vector2 b)
        {
            if (a == null || b == null) return -1;
            return (int)Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2));
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2 other)
            {
                return x == other.x && y == other.y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }
    }
}