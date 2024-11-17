using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace TargetShootingGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        private Texture2D backGround;
        private Texture2D target;
        private Texture2D crosssHair;
        private SpriteFont font;
        private SoundEffect gunShot;


        private Vector2 targetPosition = new Vector2(300,300);
        MouseState mstate;
        private bool mRelease = true;
        const int targetRedius = 45;
        private int score;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            IsMouseVisible = false;
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
           
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            backGround = Content.Load<Texture2D>("Images/sky");
            target = Content.Load<Texture2D>("Images/target");
            crosssHair = Content.Load<Texture2D>("Images/croshair");
            font = Content.Load<SpriteFont>("Font/myFont");
            gunShot = Content.Load<SoundEffect>("Sound/gunSound");


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            
            mstate = Mouse.GetState();
            
            if(mstate.LeftButton == ButtonState.Pressed && mRelease == true)
            {
                gunShot.Play();
                float mouseTarget = Vector2.Distance(targetPosition, mstate.Position.ToVector2());
                if(mouseTarget < targetRedius)
                {
                    
                    Random rnd = new Random();
                    targetPosition.X = rnd.Next(0,_graphics.PreferredBackBufferWidth);
                    targetPosition.Y = rnd.Next(0, _graphics.PreferredBackBufferWidth); ;
                    score++;
                }
                
                mRelease = false;
            }

            if(mstate.LeftButton == ButtonState.Released)
            {
                mRelease = true;
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            var mouseState = Mouse.GetState();  
            var mousePosition = new Vector2(mouseState.X, mouseState.Y);    
            _spriteBatch.Begin();
            _spriteBatch.Draw(backGround,new Vector2(0,0),Color.White);
            _spriteBatch.Draw(target, new Vector2(targetPosition.X - targetRedius, targetPosition.Y - targetRedius), Color.White);
            _spriteBatch.DrawString(font,"Score : " + score.ToString(), new Vector2(0, 0), Color.Red);
            _spriteBatch.Draw(crosssHair,mousePosition,Color.White);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
