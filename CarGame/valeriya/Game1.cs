using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace valeriya
{
    
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Car car, bot;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            car = new Car(Content.Load<Texture2D>("red_car2"),
                                  new Vector2(100,200), null,Color.White,0, new Vector2(400, 200), 
                                  new Vector2(0.3f), SpriteEffects.None, 0  );

            bot = new Car(Content.Load<Texture2D>("red_car2"),
                                  new Vector2(200, 300), null, Color.White, 0, new Vector2(400, 200),
                                  new Vector2(0.3f), SpriteEffects.None, 0);
        }

        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        
        protected override void Update(GameTime gameTime)
        {
            G.update();
            car.move();
            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            car.draw(spriteBatch);
            bot.draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
