using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ping_Pong
{

    public partial class Form1 : Form
    {
        bool goup; // boolean to be used to detect player up position
        bool godown; //boolean to be used to detect player down position
        int speed = 5;
        int ballx = 5;
        int bally = 5;
        int score = 0;
        int cpuPoint = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void keydown(object sender, MouseEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                // if player presses the up key
                // change the go up boolean to true 
                goup = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                // if player presses the down key
                // change the go down hoolean to true 
                godown = true;
            }
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                // if player leaves the up key 
                // change the go up boolean to flase
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                // if player presses the down key
                // change the go down hoolean to true 
                godown = false;
            }
        }

        private void gamerTimer_Tick(object sender, EventArgs e)
        {
            //this is the main timer event, this event will trigger every 20 milliseconds
            playerScore.Text = "" + score; // show player score on label 1 
            cpuLabel.Text = "" + cpuPoint; // show CPU score o label 2

            ball.Top -= bally; // assing the ball Top to ball Y integer 
            ball.Left -= ballx; //  assing the ball Left to ball X integer

            cpu.Top += speed; // assigment the CPU top seepd integer 

            // if teh score is less than 5
            if (score < 5)
            {
                // then do the following 

                // if CPU has reached the top or gone to the botton of the screen
                if (cpu.Top < 0 || cpu.Top > 455)
                {
                    //then
                    //change the speed direction so it moves back up or down 
                    speed = -speed;
                }

            }
            else
            {
                // if teh score is greater than 5
                // then make the game difficult by
                // alliwing the CPU follow the ball so it doens`t miss
                cpu.Top = ball.Top + 30;
            }

            //check the score 
            // if the ball has gone pass the player throught the left 
            if (ball.Left < 0)
            {
                //then ball.Left = 432; // reset the ball to the middle of the csreen
                ballx = -ballx; // change the balls direction 
                ballx -= 2; // increase the speed
                cpuPoint++; // add 1 to the Cpu score
            }
            // if the ball has gone past the right through CPU
            if  (ball.Left + ball.Width > ClientSize.Width)
            {
                // then 
                ball.Left = 434; // set the ball to center of the screen 
                ballx = -ballx; // change the direction of the ball
                ballx = 2; // increase the speed of the ball
                score++; // add one to the player score
            }
            //controlling the ball
            //if the ball eitherreachers the top the screen or the bottom
            if (ball.Top < 0 || ball.Top + ball.Height > ClientSize.Height)
            {
                // then 
                // reverrse the speed of the ball so it stays within the sreen
                bally = -bally;
            }

            // if the ball hits the player or the CPU
            if (ball.Bounds.IntersectsWith(player.Bounds) || ball.Bounds.IntersectsWith(cpu.Bounds))
            {
                // then bounce the ball in the other direction
                ballx = -ballx;
            }

            // controlling the player
            
            // if go up  boolean is true and player is within the top boundary 
            if (goup == true && player.Top > 0)
            {
                // then 
                // move player towards to the top 
                player.Top -= 8;
            }
            // if go down boolean is true and player is within the bottom boundary
            if (godown == true && player.Top < 455)
            {
                // then 
                // move player towards the bottom of screen
                player.Top += 8;
            }
            // final score and ending the game 
            // if the player score more than 10 
            //then we will stop the timer and show a message box
            if(score > 10)
            {
                gamerTimer.Stop();
                MessageBox.Show("You win this game");
            }
            // if the CPU scores more tahn 10
            // then we will stop the timer and show a message box
            if(cpuPoint > 10)
            {
                gamerTimer.Stop();
                MessageBox.Show("CPU wins, ypu lose");
            }
        }
       
        
    }
}
