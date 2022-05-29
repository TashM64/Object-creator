using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Object_creator
{
    public partial class Form1 : Form
    {
        //Initialise variables

        List<PictureBox> items = new List<PictureBox>();
            Random rand = new Random();

        int x;
        int y;
        int playerSpeed = 8;
        int spawnTime = 20;

        Color[] newColor = { Color.Red, Color.Turquoise, Color.Gold, Color.LimeGreen };

        bool goUp;
        bool goDown;
        bool goLeft;
        bool goRight;

        public Form1()
        {
            InitializeComponent();
        }

        private void MakePictureBox()
        {
            PictureBox new_pic = new PictureBox();
            new_pic.Width = 30;
            new_pic.Height = 30;
            new_pic.BackColor = newColor[rand.Next(0, newColor.Length)];

            x = rand.Next(10, this.ClientSize.Width - new_pic.Width);
            y = rand.Next(10, this.ClientSize.Height - new_pic.Height);

            new_pic.Location = new Point(x, y);

            items.Add(new_pic); //Adds to the lsit

            this.Controls.Add(new_pic); //Add to the form
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            //Handles player movement

            if (goLeft)
            {
                player.Left -= playerSpeed;
            }
            if (goRight)
            {
                player.Left += playerSpeed;
            }
            if (goDown)
            {
                player.Top += playerSpeed;
            }
            if (goUp)
            {
                player.Top -= playerSpeed;
            }

            //shows total number of items left in the list
            lbl_itemCount.Text = "Items: " + items.Count();

            spawnTime -= 1;

            if(spawnTime < 1)
            {
                MakePictureBox();
                spawnTime = 20;
            }

            //Collision detection

            foreach (PictureBox item in items.ToList())
            {
                if (player.Bounds.IntersectsWith(item.Bounds))
                {
                    items.Remove(item);
                    this.Controls.Remove(item);
                }

            }
        }

        //When key is being pressed down the following method will allow movement
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }
        }
        //When key is released the following method will stop movement
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
        }
    }
}
