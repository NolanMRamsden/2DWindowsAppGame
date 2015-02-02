using FieldFighter.Enviroment;
using FieldFighter.Hittable;
using FieldFighter.Hittable.CharacterLogic;
using FieldFighter.Hittable.Characters;
using FieldFighter.Hittable.Characters.BaseCharacters;
using FieldFighter.Hittable.Elements;
using FieldFighter.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FieldFighter
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        public Castle left, right;
        private GameEnviroment env;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            AnimationLoader.content = Content;
            RectangleGenerator.device = GraphicsDevice;
            //TODO: switch healthbar to use the rectangle generator
            HealthBar.device = GraphicsDevice;
            Constants.setConstants(Window.ClientBounds);
            left = new Castle(CharacterEnums.EDirection.RIGHT, Constants.leftBaseX);
            right = new Castle(CharacterEnums.EDirection.LEFT, Constants.rightBaseX);
            env = new GameEnviroment(Window.ClientBounds);   
        }

        protected override void UnloadContent()
        {
           
        }

        protected override void Update(GameTime gameTime)
        {
            left.updateCharacters(right);
            right.updateCharacters(left);
            base.Update(gameTime);
        }

        //TODO : Partition the screen using GraphicsDevice.ViewPort for optimization
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            env.draw(spriteBatch);
            left.draw(spriteBatch);
            right.draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
