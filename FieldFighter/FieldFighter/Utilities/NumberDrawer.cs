using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Utilities
{
    public class NumberDrawer
    {
        public static void drawNumber(SpriteBatch batch, int number, int x, int y)
        {
            drawNumber(batch, number, x, y, 20);
        }

        public static void drawNumber(SpriteBatch batch, int number, int x, int y, int size)
        {
            batch.Draw(RectangleGenerator.filled(20, 20), new Rectangle(x, y, number.ToString().Length * 20, 20), Color.White);
        }
    }
}
