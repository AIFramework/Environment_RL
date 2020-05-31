using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Environment_RL.Game
{
    /// <summary>
    /// Игровой объект
    /// </summary>
    public interface IGameObj
    {
        int CoordX { get; set; }
        int CoordY { get; set; }
        int H { get; set; }
        int W { get; set; }
        bool IsDestroyed { get; set; }

        Bitmap GetSprite();
    }
}
