using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class StartScreen : UserControl
    {
        SolidBrush letterBrush = new SolidBrush(Color.White);
        Font arial28 = new Font("Arial", 28);
        Font arial14 = new Font("Arial", 14);

        //button values
        int buttonsize = 50;
        Bitmap greenButton;
        Bitmap redButton;

        //bools for keypresses
        bool redKeyPressed = false;
        bool greenKeyPressed = false;
        public StartScreen()
        {
            InitializeComponent();
            startScreenTimer.Start();
            greenButton = new Bitmap(Properties.Resources.greenButton, new Size(buttonsize, buttonsize));
            redButton = new Bitmap(Properties.Resources.redButton, new Size(buttonsize, buttonsize));
        }

        private void StartScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    greenKeyPressed = true;
                    break;
                case Keys.M:
                    redKeyPressed = true;
                    break;
                default:
                    break;
            }
        }

        private void StartScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    greenKeyPressed = false;
                    break;
                case Keys.M:
                    redKeyPressed = false;
                    break;
                default:
                    break;
            }
        }

        private void startScreenTimer_Tick(object sender, EventArgs e)
        {
            if (greenKeyPressed == true)
            {
                startScreenTimer.Stop();
                Form1.ChangeScreen("GameScreen", this);
            }
            if (redKeyPressed == true)
            {
                startScreenTimer.Stop();
                Application.Exit();
            }
        }

        private void StartScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("Snake", arial28, letterBrush, 180, 12);
            e.Graphics.DrawString("start", arial14, letterBrush, 250, 102);
            e.Graphics.DrawImage(greenButton, 200, 92);
            e.Graphics.DrawString("exit", arial14, letterBrush, 250, 192);
            e.Graphics.DrawImage(redButton, 200, 182);
        }
    }
}
