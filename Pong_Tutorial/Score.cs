using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong_Tutorial
{
    public class Score
    {
        private readonly SpriteFont font;
        private readonly Rectangle gameBoundaries;
        private SpriteFont spriteFont;

        public int PlayerScore { get; set; }
        public int ComputerScore { get; set; }


        public Score(SpriteFont font, Rectangle gameBoundaries)
        {
            this.font = font;
            this.gameBoundaries = gameBoundaries;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var scoreText = string.Format("{0}:{1}", PlayerScore, ComputerScore);
            var xPosition = (gameBoundaries.Width/2) - (font.MeasureString(scoreText).X/2);
            var position = new Vector2(xPosition, gameBoundaries.Height - 100);

            spriteBatch.DrawString(font, scoreText, position, Color.Black);
        }

        public void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if(gameObjects.Ball.Location.X + gameObjects.Ball.Width < 0)
            {
                ComputerScore++;
                gameObjects.Ball.AttachTo(gameObjects.PlayerPaddle);
            }
            if (gameObjects.Ball.Location.X > gameBoundaries.Width)
            {
                ComputerScore++;
                gameObjects.Ball.AttachTo(gameObjects.PlayerPaddle);
            }
        }
    }
}