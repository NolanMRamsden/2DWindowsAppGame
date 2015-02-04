using FieldFighter.Hittable;
using FieldFighter.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Enviroment
{
    class GameEnviroment : EnviromentObject
    {
        private Sky sky;
        private Ground ground;
        private Board b;

        public GameEnviroment(Rectangle screenBounds, Castle leftCastle, Castle rightCastle)
        {
            ground = new Ground(Constants.groundHeight, screenBounds.Width, screenBounds.Height);
            b = new Board(leftCastle, new Point(10, 10));
        }

        public override void update()
        {

        }

        public override void draw(SpriteBatch batch)
        {
            ground.draw(batch);
            b.draw(batch);
        }
    }

    public abstract class EnviromentObject
    {
        public abstract void update();
        public abstract void draw(SpriteBatch batch);
    }
}
