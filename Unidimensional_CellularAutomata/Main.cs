using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Unidimensional_CellularAutomata.Classes;

namespace Unidimensional_CellularAutomata
{
    public class Main : Game
    {
        // Constants
        private static readonly Color _BACKGROUND_COLOR = Color.Black;


        // Fields
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _pixelTexture;

        private Interface _interface;
        private Grid _grid;
        private CellularAutomataManager _caManager;


        // Ctor
        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        // Methods
        protected override void Initialize()
        {
            _interface = new Interface(_graphics);
            _grid = new Grid(Interface.WINDOW_DIMENSIONS);
            _caManager = new CellularAutomataManager(_grid);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _pixelTexture = Content.Load<Texture2D>("Pixel");
            _grid.LoadContent(_pixelTexture);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _caManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Main._BACKGROUND_COLOR);


            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _grid.Draw(_spriteBatch);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}