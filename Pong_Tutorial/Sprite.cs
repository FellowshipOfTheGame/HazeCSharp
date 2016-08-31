using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong_Tutorial
{
    /*
    Parent class for all the sprites in the game
    Has the sprite's texture, location in window, width and height, bounding box and velocity and also the boundaries of the scene (for collision purposes)
    */
    public abstract class Sprite
    {
        //Sprite's texture
        protected readonly Texture2D texture;
        //Location of the sprite on screen
        public Vector2 Location;
        //Boundaries of the scene/window
        protected Rectangle gameBoundaries;
        //Width and height of the sprite
        public int Width
        {
            get { return texture.Width; }
        }
        public int Height
        {
            get { return texture.Height; }
        }
        //Bounding box of the sprite, used for collision
        //Shouldn't be here!
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int) Location.X, (int) Location.Y, Width, Height);
            }
        }
        //Current velocity of the sprite
        public Vector2 Velocity { get; protected set; }
        //Constructor
        public Sprite(Texture2D texture, Vector2 location, Rectangle gameBoundaries)
        {
            this.texture = texture;
            Location = location;
            this.gameBoundaries = gameBoundaries;
            //Starts stationary
            Velocity = Vector2.Zero;
        }
        //Draw function for the sprite
        public void Draw(SpriteBatch spriteBatch)
        {
            //Calls the draw function of the engine's spriteBatch
            spriteBatch.Draw(texture, Location, Color.White);
        }
        //Update function for the sprite
        public virtual void Update(GameTime gameTime, GameObjects gameObjects)
        {
            //Adds the current velocity to the sprite's position
            //Shouldn't be here!
            Location += Velocity;
            CheckBounds();
        }
        //Check boundaries of screen
        protected abstract void CheckBounds();
    }

}