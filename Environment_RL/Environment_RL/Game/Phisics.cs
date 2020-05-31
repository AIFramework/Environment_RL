using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Environment_RL.Game
{
    public static class Physics
    {
        public static bool IsColision(IGameObj obj1, IGameObj obj2)
        {
            int endX1 = obj1.W + obj1.CoordX;
            int endX2 = obj2.W + obj2.CoordX;
            int x1 = obj1.CoordX;
            int x2 = obj2.CoordX;

            int endY1 = obj1.H + obj1.CoordY;
            int endY2 = obj2.H + obj2.CoordY;
            int y1 = obj1.CoordY;
            int y2 = obj2.CoordY;

            bool x = x1 > x2 && x1 < endX2;
            bool y = y1 > y2 && y1 < endY2;

            bool xE = endX1 > x2 && endX1 < endX2;
            //bool yE = y1 > y2 && y1 < endY2;


            return (x && y)||(xE&&y);
        }
    }
}
