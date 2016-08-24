using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong_Tutorial
{
    public class Paddle : Sprite
    {
        private readonly Rectangle screenBounds;

        public Paddle(Texture2D texture, Vector2 Location, Rectangle screenBounds) : base(texture, Location)
        {
            this.screenBounds = screenBounds;
        }

        public override void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                //Move paddle up
                Velocity = new Vector2(0, -0.5f);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                //Move paddle down
                Velocity = new Vector2(0, 0.5f);
            }
            base.Update(gameTime);

        }

        protected override void CheckBounds()
        {
            Location.Y = MathHelper.Clamp(Location.Y, 0, screenBounds.Height - texture.Height);
        }
    }
}