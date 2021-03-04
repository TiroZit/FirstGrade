using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectMonoGame01.Controllers;
using ProjectMonoGame01.KeyboardLayouts;
using ProjectMonoGame01.GameObjects;
using System.IO;
using ProjectMonoGame01.Guns;

namespace ProjectMonoGame01
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;

        protected Texture2D tex1, tex2, tex3, tex4, tex5;
        protected GameObject spaceship1;
        protected GameObject spaceship2;
        protected Player spaceship3;
        protected Player spaceship4;
        protected GameObject mouseCursor;

        protected KeyboardControllerRotate keyboardController1;
        protected KeyboardController keyboardController2;
        protected MouseController mouseController;
        protected MouseControllerWatch mouseWatch;
        protected MouseControllerPursuit mousePursuit;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            // FullHD
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            // полноэкранный режим
            // graphics.IsFullScreen = true;
            GameConstants.Graphics = graphics;
            GameConstants.BulletsManager = new BulletsManager();
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
            spaceship1.SetPosition(1200, 500);
            spaceship1.SetVelocity(0, 0);

            spaceship2 = new GameObject(tex2);
            spaceship2.SetPosition(400, 500);
            spaceship2.SetVelocity(0, 0);

            spaceship3 = new Player(tex4);
            spaceship3.SetPosition(650, 500);
            spaceship3.SetVelocity(0, 0);
            spaceship3.SetScale(0.4f);

            mouseCursor = new GameObject(tex3);
            mouseCursor.SetPosition(100,100);

            spaceship4 = new Player(tex5);
            spaceship4.SetPosition(200, 500);
            spaceship4.SetVelocity(0, 0);


            keyboardController1 = new KeyboardControllerRotate();
            keyboardController1.Attach(spaceship1);

            KeyboardLayout customLayout = new KeyboardLayout();
            customLayout.KeyActions.Add(new KeyAction(Keys.T, ActionType.Left));
            customLayout.AddKey(Keys.Y, ActionType.Up);
            customLayout.AddKey(Keys.G, ActionType.Right);
            customLayout.AddKey(Keys.H, ActionType.Down);

            keyboardController2 = new KeyboardController( new KeyboardLayoutWasd() );
            keyboardController2.Attach(spaceship2);

            mouseController = new MouseController();
            mouseController.Attach(mouseCursor);

            mouseWatch = new MouseControllerWatch();
            mouseWatch.Attach(spaceship3);
            mouseWatch.Fire += spaceship3.Fire;

            mousePursuit = new MouseControllerPursuit();
            mousePursuit.Attach(spaceship4);
            mousePursuit.Fire += spaceship4.Fire;

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            using (var fs = new FileStream("spaceship.png", FileMode.Open))
            {
                tex1 = Texture2D.FromStream(GraphicsDevice, fs);
            }
            using (var fs = new FileStream("redship4.png", FileMode.Open))
            {
                tex2 = Texture2D.FromStream(GraphicsDevice, fs);
            }
            using (var fs = new FileStream("cursor.png", FileMode.Open))
            {
                tex3 = Texture2D.FromStream(GraphicsDevice, fs);
            }
            using (var fs = new FileStream("alienspaceship.png", FileMode.Open))
            {
                tex4 = Texture2D.FromStream(GraphicsDevice, fs);
            }
            using (var fs = new FileStream("alien2.png", FileMode.Open))
            {
                tex5 = Texture2D.FromStream(GraphicsDevice, fs);
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
            mouseController.Update();
            mouseWatch.Update();
            mousePursuit.Update();
            GameConstants.BulletsManager.Update();

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
            spaceship3.Draw(spriteBatch);
            spaceship4.Draw(spriteBatch);
            GameConstants.BulletsManager.Draw(spriteBatch);

            mouseCursor.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
