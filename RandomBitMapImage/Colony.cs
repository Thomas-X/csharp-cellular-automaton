using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomBitMapImage
{
    class Colony
    {
        static int maxColonySize = 50;
        // initial random number generator
        static int maxAge = 40;
        // reproduce limit / initial random number
        static int maxStrength = 100;

        public int id;
        public Color color;
        public string name;
        public int colonySize;
        public Person[] people;
        public int[] startPosition;

        public Colony (int id, Color color, string name)
        {
            this.id = id;
            this.color = color;
            this.name = name;
            this.colonySize = World.rand.Next(Colony.maxColonySize);
            this.people = new Person[this.colonySize];
            int x = World.rand.Next(World.tiles.GetLength(0));
            int y = World.rand.Next(World.tiles.GetLength(1));
            this.startPosition = new int[] { x,y };
            for (int o = 0; o < this.colonySize;o++)
            {
                // init random stats
                int age = World.rand.Next(Colony.maxAge);
                int strength = World.rand.Next(Colony.maxStrength);
                bool isSick = false;
                
                // init person
                Person p = new Person(age, strength, isSick, this.color);

                // set person data
                p.setStartPosition(this.startPosition);
                p.setColonyID(this.id);
                p.spawnOnTheWorld();

                // update array
                this.people.SetValue(p, o);
            }
        }

        public void update()
        {
            for (int o = 0; o < this.people.Length;o++)
            {
                this.people[o].update();
            }
        }
    }
}
