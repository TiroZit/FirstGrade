using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectMonoGame01.KeyboardLayouts;
using System.IO;

namespace ProjectMonoGame01
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;

        protected Texture2D tex1, tex2;
        protected GameObject spaceship1;
        protected GameObject spaceship2;

        protected KeyboardController keyboardController1;
        protected KeyboardController keyboardController2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            // FullHD
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            // полноэкранный режим
            // graphics.IsFullScreen = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic 
            base.Initialize();

            spaceship1 = new GameObject(tex1);
            spaceship1.SetPosition(900, 500);
            spaceship1.SetVelocity(0, 0);

            spaceship2 = new GameObject(tex2);
            spaceship2.SetPosition(500, 500);
            spaceship2.SetVelocity(0, 0);

            keyboardController1 = new KeyboardController();
            keyboardController1.Attach(spaceship1);

            KeyboardLayout customLayout = new KeyboardLayout();
            customLayout.KeyActions.Add(new KeyAction(Keys.T, Direction.Left));
            customLayout.AddKey(Keys.Y, Direction.Up);
            customLayout.AddKey(Keys.G, Direction.Right);
            customLayout.AddKey(Keys.H, Direction.Down);

            keyboardController2 = new KeyboardController( new KeyboardLayoutWasd() );
            keyboardController2.Attach(spaceship2);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            using (var fs = new FileStream("spaceship.png", FileMode.Open))
            {
                tex1 = Texture2D.FromStream(GraphicsDevice, fs);
            }
            using (var fs = new FileStream("redship4.png", FileMode.Open))
            {
                tex2 = Texture2D.FromStream(GraphicsDevice, fs);
            }
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
            keyboardController1.Update();
            keyboardController2.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spaceship1.Draw(spriteBatch);
            spaceship2.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
