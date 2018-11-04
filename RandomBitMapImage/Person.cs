using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomBitMapImage
{
    class Person
    {
        static int spawnRadiusAroundColony = 5;

        int colonyID;
        int[] startPosition;
        int currentX;
        int currentY;
        int oldX;
        int oldY;
        int age;
        int strength;
        int moveCount = 0;
        bool isSick;
        Color color;

        public Person(int age, int strength, bool isSick, Color color)
        {
            this.color = color;
            this.age = age;
            this.strength = strength;
            this.isSick = isSick;
        }

        // TODO add support for not overriding underlying land when on a tile
        public void spawnOnTheWorld()
        {
            this.move(this.startPosition[0], this.startPosition[1]);
        }


        private int randomMove()
        {
            int num = World.rand.Next(3);
            if (num == 0 || num == 1)
            {
                return num;
            }
            if (num == 2)
            {
                return -1;
            }
            return num;
        }

        public void update ()
        {
            this.moveCount++;
            // TODO use -1 to go up, there are 3 possibilities for each x / y coord:
            // -1
            // 1
            // 0
            this.move(this.currentX + this.randomMove(), this.currentY + this.randomMove());
        }

        public void move (int xMove, int yMove)
        {
            int modifiedX = xMove;
            int modifiedY = yMove;
            if (modifiedX <= 1)
            {
                modifiedX = 0;
            }
            if (modifiedY <= 1)
            {
                modifiedY = 0;
            }
            int x = modifiedX;
            int y = modifiedY;
            if (this.moveCount < 1)
            {
                x = modifiedX + World.rand.Next(spawnRadiusAroundColony);
                y = modifiedY + World.rand.Next(spawnRadiusAroundColony);
            }

            if (x >= World.tiles.GetLength(0))
            {
                x = World.tiles.GetLength(0) - 1;
            }
            if (y >= World.tiles.GetLength(1))
            {
                y = World.tiles.GetLength(1) - 1;
            }
            

            this.currentX = x;
            this.currentY = y;
            // move to tile
            TileGroup tilegroup = World.tiles[x, y];
            tilegroup.setOccupant(x, y, this.color, this);

            if (this.moveCount > 0)
            {
                TileGroup tilegroupOld = World.tiles[this.oldX, this.oldY];
                tilegroupOld.removeOccupant();
                this.oldX = x;
                this.oldY = y;
            }
        }

        public void setStartPosition(int[] startPosition)
        {
            this.startPosition = startPosition;
        }

        public void setColonyID(int colonyID)
        {
            this.colonyID = colonyID;
        }
    }
}
