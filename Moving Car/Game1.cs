using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq.Expressions;
using static System.Net.Mime.MediaTypeNames;

namespace CarMovingProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _texture, _resizeText;
        private Vector2 _position;
        float scale = 0.5f;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _texture = Content.Load<Texture2D>("Images/newCar");
            _position = new Vector2(100, 50);
            _resizeText = ResizeTexture(GraphicsDevice, _spriteBatch, _texture, 150, 150);

            // TODO: use this.Content to load your game content here
        }

        private Texture2D ResizeTexture(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Texture2D originalTexture, int newWidth, int newHeight)
        {
            RenderTarget2D renderTarget = new RenderTarget2D(graphicsDevice, newWidth, newHeight);
            graphicsDevice.SetRenderTarget(renderTarget);
            graphicsDevice.Clear(Color.Transparent);

            spriteBatch.Begin();
            spriteBatch.Draw(originalTexture, new Rectangle(0, 0, newWidth, newHeight), Color.White);
            spriteBatch.End();

            graphicsDevice.SetRenderTarget(null);

            Texture2D resizeTexture = new Texture2D(graphicsDevice, newWidth, newHeight);
            Color[] data = new Color[newWidth * newHeight];
            renderTarget.GetData(data);
            resizeTexture.SetData(data);    
            renderTarget.Dispose();

            return resizeTexture;
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                _position.Y -= 3;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                _position.Y += 3;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _position.X -= 5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _position.X += 5;
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(_resizeText, _position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
