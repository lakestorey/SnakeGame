using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class GameScreen : UserControl
    {
        //sounds
        SoundPlayer zipSound = new SoundPlayer(Properties.Resources.Zip);
        SoundPlayer wilhelmSound = new SoundPlayer(Properties.Resources.Wilhelm_Scream);

        //create necessary variables and tools
        bool upArrowUp, downArrowUp, leftArrowUp, rightArrowUp;
        SolidBrush snakeBrush = new SolidBrush(Color.Green);
        SolidBrush dotBrush = new SolidBrush(Color.White);
        Font arial14 = new Font("Arial", 14, FontStyle.Bold);

        //variables for snake
        int snakeX, snakeY, snakeSpeed, snakeSize, snakeDirection, sectionNums;
        public static int scoreCount;

        //variables for dots
        int dotX, dotY, dotSize, countDown, countDownCounter;

        bool dotCollected, gameStarted;

        //random number generator
        Random randGen = new Random();

        //list to hold sections of snake
        List<Snake> sections = new List<Snake>();

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
           
        }

        /// <summary>
        /// Set initial game values here
        /// </summary>
        public void OnStart()
        {
            //set keys up to true
            upArrowUp = downArrowUp = leftArrowUp = rightArrowUp = false;

            //set snake values
            snakeX = this.Width / 2;
            snakeY = this.Height / 2;
            snakeSpeed = 12;
            snakeSize = 10;
            snakeDirection = 3;
            sectionNums = 1;

            //set dot values
            dotSize = 8;
            dotX = 1;
            dotY = 1;
            dotCollected = true;

            //set gameStarted to false
            gameStarted = false;
            countDown = 3;
            countDownCounter = 1;
            
            //add initial sections to snake
            Snake s = new Snake(snakeX - snakeSize * sectionNums, snakeY -snakeSize * sectionNums, snakeSize, snakeSpeed);
            Snake s1 = new Snake(snakeX - snakeSize * sectionNums - 2 * sectionNums, snakeY - snakeSize * sectionNums - 2 * sectionNums, snakeSize, snakeSpeed);
            Snake s2 = new Snake(snakeX - snakeSize * sectionNums - 2 * sectionNums, snakeY - snakeSize * sectionNums - 2 * sectionNums, snakeSize, snakeSpeed);
            sections.Add(s);
            sections.Add(s1);
            sections.Add(s2);

            gameTimer.Start();
        }

        #region keyup and down events
        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrowUp = true;
                    break;
                case Keys.Down:
                    downArrowUp = true;
                    break;
                case Keys.Left:
                    leftArrowUp = true;
                    break;
                case Keys.Right:
                    rightArrowUp = true;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrowUp = false;
                    break;
                case Keys.Down:
                    downArrowUp = false;
                    break;
                case Keys.Left:
                    leftArrowUp = false;
                    break;
                case Keys.Right:
                    rightArrowUp = false;
                    break;
                default:
                    break;
            }

        }
        #endregion

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (gameStarted == false)
            {
                if (countDown >= 0 && countDownCounter == 0)
                {
                    countDown--;
                }
                if (countDownCounter == 30)
                {
                    countDownCounter = -1;
                }
                if (countDown == 0)
                {
                    gameStarted = true;
                }
                countDownCounter++;
            }
            else if (gameStarted == true)
            {

                #region movement
                //update location and movement of snake
                if (upArrowUp == true && snakeDirection != 2)
                {
                    snakeDirection = 1;
                }
                if (downArrowUp == true && snakeDirection != 1)
                {
                    snakeDirection = 2;
                }
                if (leftArrowUp == true && snakeDirection != 4)
                {
                    snakeDirection = 3;
                }
                if (rightArrowUp == true && snakeDirection != 3)
                {
                    snakeDirection = 4;
                }

                for (int i = sections.Count() - 1; i > 0; i--)
                {
                    sections[i].x = sections[i - 1].x;
                    sections[i].y = sections[i - 1].y;
                }
                sections[0].Move(snakeDirection, snakeSpeed);
                #endregion

                #region collision detection

                #region wall detection
                //check collision for snake with walls
                if (sections[0].x <= 0)
                {
                    gameTimer.Stop();

                    wilhelmSound.Play();
                    Thread.Sleep(1000);

                    Form1.ChangeScreen("EndScreen", this);
                }
                if (sections[0].x - snakeSize >= this.Width)
                {
                    gameTimer.Stop();

                    wilhelmSound.Play();
                    Thread.Sleep(1000);

                    Form1.ChangeScreen("EndScreen", this);
                }
                if (sections[0].y <= 0)
                {
                    gameTimer.Stop();

                    wilhelmSound.Play();
                    Thread.Sleep(1000);

                    Form1.ChangeScreen("EndScreen", this);
                }
                if (sections[0].y + snakeSize >= this.Height)
                {
                    gameTimer.Stop();

                    wilhelmSound.Play();
                    Thread.Sleep(1000);

                    Form1.ChangeScreen("EndScreen", this);
                }
                #endregion

                //snake sections with each other
                for (int i = 1; i < sections.Count(); i++)
                {
                    Rectangle section1Rec = new Rectangle(sections[0].x, sections[0].y, snakeSize, snakeSize);
                    Rectangle sectionCurrentRec = new Rectangle(sections[i].x, sections[i].y, snakeSize, snakeSize);
                    if (section1Rec.IntersectsWith(sectionCurrentRec))
                    {
                        gameTimer.Stop();

                        wilhelmSound.Play();
                        Thread.Sleep(1000);

                        Form1.ChangeScreen("EndScreen", this);
                    }
                }

                //snake  with dots
                Rectangle dotRec = new Rectangle(dotX, dotY, dotSize, dotSize);
                Rectangle snakeRec = new Rectangle(sections[0].x, sections[0].y, snakeSize, snakeSize);
                if (dotRec.IntersectsWith(snakeRec))
                {
                    //add new section to snake
                    Snake s3 = new Snake(snakeX - snakeSize * sectionNums - 2 * sectionNums, snakeY - snakeSize * sectionNums - 2 * sectionNums, snakeSize, snakeSpeed);
                    sections.Add(s3);

                    //reset dot
                    dotCollected = true;

                    zipSound.Play();
                }
                #endregion

                #region dot spawning
                //update postion and spawning of dot
                if (dotCollected == true)
                {
                    dotX = randGen.Next(0, this.Width - dotSize);
                    dotY = randGen.Next(0, this.Height - dotSize);
                    dotCollected = false;
                }
                #endregion

                scoreCount = sections.Count() - 3;

                
            }
            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            if (gameStarted == true)
            {
                foreach (Snake s in sections)
                {
                    e.Graphics.FillRectangle(snakeBrush, s.x, s.y, s.size, s.size);
                }
                e.Graphics.FillEllipse(dotBrush, dotX, dotY, dotSize, dotSize);
            }
            if (gameStarted == false)
            {
                e.Graphics.DrawString("" + countDown, arial14, dotBrush, this.Width / 2 - 14, this.Height / 2 - 14);
            }
        }
    }
}
