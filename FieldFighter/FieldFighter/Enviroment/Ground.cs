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
    class Ground : EnviromentObject
    {
        public static Texture2D texture;
        private int groundHeight;
        private int screenWidth;
        private int screenHeight;

        public Ground(int groundHeight, int screenWidth, int screenHeight) : base()
        {
            this.groundHeight = groundHeight;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            texture = RectangleGenerator.filled(100, 100);
        }

        public override void update()
        {
            
        }

        public override void draw(SpriteBatch batch)
        {
            batch.Draw(texture, new Rectangle(0, groundHeight, screenWidth, screenHeight - groundHeight), Color.White);
        }
    }
}
