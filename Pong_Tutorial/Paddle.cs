using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong_Tutorial
{
    //Enumerates the 2 types of paddles
    public enum PlayerTypes
    {
        Human,
        CPU
    }
    //Paddle class is Sprite's son
    public class Paddle : Sprite
    {
        //The possible player types
        private readonly PlayerTypes playerType;

        //Constructor to set texture, location, screen bounds and the types of player
        public Paddle(Texture2D texture, Vector2 location, Rectangle screenBounds, PlayerTypes playerType) 
            : base(texture, location, screenBounds)
        {
            this.playerType = playerType;
        }
        //Update function updates player and CPU paddle velocity
        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            //If is the CPU's paddle update, check ball's position and update its speed accordingly
            if(playerType == PlayerTypes.CPU)
            {
                //Random variable to turn AI easier
                //Adds to current location so it can delay itself from moving
                var random = new Random();
                var reactionThreshold = random.Next(30, 130);

                //CPU movement
                //If ball is above, go upwards
                if(gameObjects.Ball.Location.Y + gameObjects.Ball.Height < Location.Y + reactionThreshold)
                    Velocity = new Vector2(0, -10f);
                //If ball is below, go upwards
                else if (gameObjects.Ball.Location.Y > Location.Y + Height + reactionThreshold)
                    Velocity = new Vector2(0, 10f);
            }
            //If is the player's paddle update, check input
            if (playerType == PlayerTypes.Human)
            {
                //If player ir pressing left arrow key
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    //Move paddle up
                    Velocity = new Vector2(0, -10f);
                }
                //If player ir pressing right arrow key
                else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    //Move paddle down
                    Velocity = new Vector2(0, 10f);
                }
                //If none are pressed, stop moving
                else
                {
                    Velocity = Vector2.Zero;
                }
            }
            //Call Sprite  (parent) update function
            base.Update(gameTime, gameObjects);
        }
        //Check screen bounds and clamp paddle position so it always remains on screen 
        protected override void CheckBounds()
        {
            Location.Y = MathHelper.Clamp(Location.Y, 0, gameBoundaries.Height - texture.Height);
        }
    }
}