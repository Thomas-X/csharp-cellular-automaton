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

namespace RandomBitMapImage
{
    // TODO Add a method for updating a tile (TileGroup)
    // TODO keep track of the tile underneath when a person is on top of it.

    public partial class Main : Form
    {
        Random rand = new Random();


        public Main()
        {
            InitializeComponent();
        }
       
        private void randomBitmap()
        {
            World world = new World(400, 400);
            Bitmap bmp = world.regenerateWorld();
            pictureBox1.Image = bmp;
        }

        private void onLoadWorld(object sender, EventArgs e)
        {
            
            this.randomBitmap();
        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.randomBitmap();
            Console.WriteLine("you clicked on the button the re-render!!");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
