using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong_Tutorial
{
    //Ball class is Sprite's son
    public class Ball : Sprite
    {
        //Paddle which the ball is attached to (the player's one)
        private Paddle attachedToPaddle;
        //Constructor just calls parent's one
        public Ball(Texture2D texture, Vector2 location, Rectangle gameBoundaries) : base(texture, location, gameBoundaries)
        {
        }
        //Check bounds to not let it get away vertically
        protected override void CheckBounds()
        {
            //If hit a wall upwards or downards
            if (Location.Y >= (gameBoundaries.Height - texture.Height) || Location.Y <= 0)
            {
                //Go to the other direction, vertically
                var newVelocity = new Vector2(Velocity.X, -Velocity.Y);
                Velocity = newVelocity;
            }
        }
        //Update function for the ball
        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            //If ball is attached to player's paddle
            if (attachedToPaddle != null)
            {
                //If the player pressed Space key, launch the ball
                if(Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    //Gives the ball a constant x-velocity and a y-velocity a little slower than the paddle's
                    var newVelocity = new Vector2(20, attachedToPaddle.Velocity.Y * 0.75f);
                    Velocity = newVelocity;
                    //Detach ball from paddle
                    attachedToPaddle = null;
                }
                //Else, move ball along paddle
                else
                {
                    Location.X = attachedToPaddle.Location.X + attachedToPaddle.Width;
                    Location.Y = attachedToPaddle.Location.Y;
                }
                
            }
            //If ball is detached, just check collisions
            else
            {
                //If hits any paddle, inverts x-velocity
                if(BoundingBox.Intersects(gameObjects.PlayerPaddle.BoundingBox) || BoundingBox.Intersects(gameObjects.CPUPaddle.BoundingBox))
                {
                    Velocity = new Vector2(-Velocity.X, Velocity.Y);
                }
            }
            //Call's sprite update function
            base.Update(gameTime, gameObjects);
        }
        //Attaches ball to given paddle
        internal void AttachTo(Paddle paddle)
        {
            attachedToPaddle = paddle;
        }
    }
}