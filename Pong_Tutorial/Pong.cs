using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong_Tutorial
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Pong : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private GameObjects gameObjects;
        private Paddle CPUPaddle;
        private Paddle playerPaddle;
        private Ball ball;
        private Score score;
        //private Texture2D paddle;

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
            // TODO: Add your initialization logic here
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

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

            
            var paddleTexture = Content.Load<Texture2D>("Pong_Pad");
            var PlayerPaddlePos = new Vector2(0, 100);
            var gameBoundaries = new Rectangle(0, 0, GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height);
            var CPUPaddlePos = new Vector2(gameBoundaries.Width - paddleTexture.Width, 0);
            // TODO: use this.Content to load your game content here
            playerPaddle = new Paddle(paddleTexture, PlayerPaddlePos, gameBoundaries, PlayerTypes.Human);
            CPUPaddle = new Paddle(paddleTexture, CPUPaddlePos, gameBoundaries, PlayerTypes.CPU);
            ball = new Ball(Content.Load<Texture2D>("Ball"), Vector2.Zero, gameBoundaries);
            ball.AttachTo(playerPaddle);

            score = new Score(Content.Load<SpriteFont>("GameFont"), gameBoundaries);

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            playerPaddle.Update(gameTime, gameObjects);
            CPUPaddle.Update(gameTime, gameObjects);
            ball.Update(gameTime, gameObjects);
            score.Update(gameTime, gameObjects);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            playerPaddle.Draw(spriteBatch);
            CPUPaddle.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            score.Draw(spriteBatch);
            //spriteBatch.Draw(paddle, Vector2.Zero, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
