using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomBitMapImage
{
    class Tile
    {

        public Tile (int x, int y, Color color)
        {
            World.world.SetPixel(x, y, color);
        }
    }
}
