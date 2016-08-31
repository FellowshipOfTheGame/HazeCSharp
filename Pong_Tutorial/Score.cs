using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong_Tutorial
{
    /*
     *Class responsible to update and show the score of the game
    */
    public class Score
    {
        //Text's font
        private readonly SpriteFont font;
        //Boundaries of game screen
        private readonly Rectangle gameBoundaries;
        //Score of the player
        public int PlayerScore { get; set; }
        //Score of the player
        public int ComputerScore { get; set; }

        //Constructor of the score
        public Score(SpriteFont font, Rectangle gameBoundaries)
        {
            this.font = font;
            this.gameBoundaries = gameBoundaries;
        }
        //Draw function of the score
        public void Draw(SpriteBatch spriteBatch)
        {
            //Format of the score
            var scoreText = string.Format("{0}:{1}", PlayerScore, ComputerScore);
            //X coordinate position in the middle of the screen
            var xPosition = (gameBoundaries.Width/2) - (font.MeasureString(scoreText).X/2);
            //Place at the bottom of the screen (in the middle)
            var position = new Vector2(xPosition, gameBoundaries.Height - (font.MeasureString(scoreText).Y));
            //Calls the sprite batch funtion to draw the string
            spriteBatch.DrawString(font, scoreText, position, Color.Black);
        }
        //Update function of the score
        public void Update(GameTime gameTime, GameObjects gameObjects)
        {
            //Check if computer scored a point (Ball passed player's side of screen)
            if(gameObjects.Ball.Location.X + gameObjects.Ball.Width < 0)
            {
                ComputerScore++;
                gameObjects.Ball.AttachTo(gameObjects.PlayerPaddle);
            }
            //Check if player scored a point (Ball passed computer's side of screen)
            else if (gameObjects.Ball.Location.X > gameBoundaries.Width)
            {
                PlayerScore++;
                gameObjects.Ball.AttachTo(gameObjects.PlayerPaddle);
            }
        }
    }
}