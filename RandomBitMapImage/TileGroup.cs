using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomBitMapImage
{
    class TileGroup
    {
        public bool isLand;
        public Color color;
    
        public TileGroup(int x, int y, bool isLand)
        {
            Color color = Color.FromArgb(255, 0, 0, 0);
            if (isLand == true)
            {
                color = Color.FromArgb(255, 124, 252, 0);
            }
            else if (isLand == false)
            {
                color = Color.FromArgb(255, 0, 0, 230);
            }
            this.isLand = isLand;
            this.color = color;

            for (int i = 0; i < World.pixelSize; i += 1)
            {
                for (int o = 0; o < World.pixelSize; o += 1)
                {
                    int newX = x + o;
                    int newY = y + i;
                    this.createTile(newX, newY, color);
                }
            }
        }

        public Tile createTile(int x, int y, Color color)
        {
            return new Tile(x,y,color);
        }
    }
}
