﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomBitMapImage
{
    class Tile
    {
        public int x;
        public int y;


        public Tile (int x, int y, Color color)
        {
            this.x = x;
            this.y = y;
            World.world.SetPixel(x, y, color);
        }

        public void editTile (Color color)
        {
            World.world.SetPixel(this.x, this.y, color);
        }
    }
}