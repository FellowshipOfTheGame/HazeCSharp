using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong_Tutorial
{
    public abstract class Sprite
    {
        protected readonly Texture2D texture;
        public Vector2 Location;
        public int Width
        {
            get { return texture.Width; }
        }
        public int Height
        {
            get { return texture.Height; }
        }

        public Vector2 Velocity { get; protected set; }

        public Sprite(Texture2D texture, Vector2 location)
        {
            this.texture = texture;
            Location = location;
            Velocity = Vector2.Zero;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Location, Color.White);
        }

        public virtual void Update(GameTime gameTime)
        {
            Location += Velocity;

            CheckBounds();
        }

        protected abstract void CheckBounds();
    }

}