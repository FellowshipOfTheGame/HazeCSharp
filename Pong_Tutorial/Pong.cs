﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong_Tutorial
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Pong : Game
    {
        //Graphics device configurations
        GraphicsDeviceManager graphics;
        //Stores and draws the sprites in Draw phase
        SpriteBatch spriteBatch;

        //Contains all the game objects on screen
        private GameObjects gameObjects;
        //Player and CPU paddles
        private Paddle CPUPaddle;
        private Paddle playerPaddle;
        //Ball
        private Ball ball;
        //Score
        private Score score;

        //Constructor instantiates the graphics device manager and sets 
        //root directory for game content to be loaded
        public Pong()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //See the mouse on game window
            IsMouseVisible = true;
            //Fullscreen
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            //Calls parent (Game) initialization
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Loads texture file for paddle
            var paddleTexture = Content.Load<Texture2D>("Pong_Pad");
            //Position for player's starting point
            var PlayerPaddlePos = new Vector2(0, 0);
            //Define game (or game window) boundaries
            var gameBoundaries = new Rectangle(0, 0, GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height);
            //Position for CPU starting point (the other side of the screen)
            var CPUPaddlePos = new Vector2(gameBoundaries.Width - paddleTexture.Width, 0);
            //Instantiates player paddle
            playerPaddle = new Paddle(paddleTexture, PlayerPaddlePos, gameBoundaries, PlayerTypes.Human);
            //Instantiates CPU paddle
            CPUPaddle = new Paddle(paddleTexture, CPUPaddlePos, gameBoundaries, PlayerTypes.CPU);
            //Instantiates ball
            ball = new Ball(Content.Load<Texture2D>("Ball"), Vector2.Zero, gameBoundaries);
            //Attach ball to player's paddle, so he can begin the match as he chooses
            ball.AttachTo(playerPaddle);
            //Instantiates the score
            score = new Score(Content.Load<SpriteFont>("GameFont"), gameBoundaries);
            //Instantiates list of game objects
            gameObjects = new GameObjects { PlayerPaddle = playerPaddle, CPUPaddle = CPUPaddle, Ball = ball, Score = score};
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //Check if any exit key is pressed and, if so, exit the game
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Calls update function for each object in the game
            playerPaddle.Update(gameTime, gameObjects);
            CPUPaddle.Update(gameTime, gameObjects);
            ball.Update(gameTime, gameObjects);
            score.Update(gameTime, gameObjects);
            //Calls Game (parent) update function
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //Calls draw function for each object in the game
            spriteBatch.Begin();
            playerPaddle.Draw(spriteBatch);
            CPUPaddle.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            score.Draw(spriteBatch);
            spriteBatch.End();
            //Calls Game (parent) draw function
            base.Draw(gameTime);
        }
    }
}
