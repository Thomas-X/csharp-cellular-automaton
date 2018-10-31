using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomBitMapImage
{
    class World
    {
        public static int pixelSize = 1;
        static int chanceToGetLand = 80;
        public static int height = 0;
        public static int width = 0;
        Random rand = new Random();
        public static Bitmap world = null;
        public static int multiplier = 0;

        // since there is a setting for pixelsize meaning the tiles are not 1:1 to pixels, depending on the 
        // pixelSize this tiles ratio is 1:pixelSize. 
        // so when a bitmap is 400x400 and the pixelSize = 8 the tiles tilegroup would be a size of 50,50 (400/8)
        
        public static TileGroup[,] tiles;


        public World (int height, int width)
        {
         
            World.height = height;
            World.width = width;
        
            World.multiplier = World.pixelSize;

        }
        
        public Bitmap regenerateWorld()
        {
            World.tiles = new TileGroup[World.height / pixelSize, World.width / pixelSize];
            World.world = new Bitmap(World.height, World.width);

            this.createTileGroups();
            Console.WriteLine(World.tiles);
            return World.world;
        }

        private void createTileGroups()
        {
            for (int y = 0; y < World.height; y += World.multiplier)
            {
                for (int x = 0; x < World.width; x += World.multiplier)
                {
                    bool isLand = rand.Next(100) <= World.chanceToGetLand;
                    int tileCoordX = x / pixelSize;
                    int tileCoordY = y / pixelSize;
                    World.tiles[tileCoordY, tileCoordX] = this.createTileGroup(x, y, isLand);
                }
            }
        }

        private TileGroup createTileGroup(int x, int y, bool isLand)
        {
            return new TileGroup(x, y, isLand);
        }
    }
}
