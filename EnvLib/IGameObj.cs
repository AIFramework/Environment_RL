using System.Drawing;

namespace EnvLib
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

        void Update();

        Bitmap GetSprite();
    }
}
