﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong_Tutorial
{
    public class Ball : Sprite
    {
        private Paddle attachedToPaddle;
        public Ball(Texture2D texture, Vector2 location) : base(texture, location)
        {
        }

        protected override void CheckBounds()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Space) && attachedToPaddle != null)
            {
                var newVelocity = new Vector2(5, attachedToPaddle.Velocity.Y);
                Velocity = newVelocity;
                attachedToPaddle = null;
            }

            if (attachedToPaddle != null)
            {
                Location.X = attachedToPaddle.Location.X + attachedToPaddle.Width;
                Location.Y = attachedToPaddle.Location.Y;
            }
            base.Update(gameTime);
        }

        internal void AttachTo(Paddle paddle)
        {
            attachedToPaddle = paddle;
        }
    }
}