using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong_Tutorial
{
    public enum PlayerTypes
    {
        Human,
        CPU
    }

    public class Paddle : Sprite
    {
        private readonly PlayerTypes playerType;

        public Paddle(Texture2D texture, Vector2 location, Rectangle screenBounds, PlayerTypes playerType) 
            : base(texture, location, screenBounds)
        {
            this.playerType = playerType;
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if(playerType == PlayerTypes.CPU)
            {
                var random = new Random();
                var reactionThreshold = random.Next(30, 130);

                //CPU movement
                if(gameObjects.Ball.Location.Y + gameObjects.Ball.Height < Location.Y + reactionThreshold)
                    Velocity = new Vector2(0, -0.5f);
                if(gameObjects.Ball.Location.Y > Location.Y + Height + reactionThreshold)
                    Velocity = new Vector2(0, 0.5f);
            }
            if (playerType == PlayerTypes.Human)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    //Move paddle up
                    Velocity = new Vector2(0, -10.2f);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    //Move paddle down
                    Velocity = new Vector2(0, 10.2f);
                    Console.WriteLine("Is going Down");
                }
            }
            base.Update(gameTime, gameObjects);
        }

        protected override void CheckBounds()
        {
            Console.WriteLine("Height: "+ gameBoundaries.Height + "Text Heigth: "+texture.Height);
            Location.Y = MathHelper.Clamp(Location.Y, 0, gameBoundaries.Height - texture.Height);
        }
    }
}