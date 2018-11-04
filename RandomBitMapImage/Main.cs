using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace RandomBitMapImage
{
    // TODO Add a method for updating a tile (TileGroup)
    // TODO keep track of the tile underneath when a person is on top of it.

    public partial class Main : Form
    {
        // how many MS 
        static int tickSpeed = 2000; 
        Random rand = new Random();
        World world;


        public Main()
        {
            InitializeComponent();
        }

        public void tick(object sender, EventArgs e)
        {
            this.world.onTick();
            pictureBox1.Image = World.world;
        }

        private void setupWorld()
        {
            this.world = new World(400, 400);
            Bitmap bmp = this.world.regenerateWorld();
            pictureBox1.Image = bmp;
            Timer timer = new Timer();
            timer.Interval = Main.tickSpeed;
            timer.Tick += new EventHandler(this.tick);
            timer.Start();
        }

        private void onLoadWorld(object sender, EventArgs e)
        {
            this.setupWorld();
        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.setupWorld();
            Console.WriteLine("you clicked on the button the re-render!!");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
