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
        private static Texture2D[] nums = new Texture2D[]
        {
            AnimationLoader.pngToTexture("Numbers/0.png"),
            AnimationLoader.pngToTexture("Numbers/1.png"),
            AnimationLoader.pngToTexture("Numbers/2.png"),
            AnimationLoader.pngToTexture("Numbers/3.png"),
            AnimationLoader.pngToTexture("Numbers/4.png"),
            AnimationLoader.pngToTexture("Numbers/5.png"),
            AnimationLoader.pngToTexture("Numbers/6.png"),
            AnimationLoader.pngToTexture("Numbers/7.png"),
            AnimationLoader.pngToTexture("Numbers/8.png"),
            AnimationLoader.pngToTexture("Numbers/9.png"),
        };

        public static void drawNumber(SpriteBatch batch, int number, int x, int y)
        {
            drawNumber(batch, number, x, y, 30);
        }

        public static void drawNumber(SpriteBatch batch, int number, int x, int y, int size)
        {
            Char[] num = number.ToString().ToCharArray();
            int xPoint = x;
            foreach (Char c in num)
            {
                batch.Draw(nums[(int)Char.GetNumericValue(c)],new Rectangle(xPoint,y,size,(int)(size*1.5)),Color.White);
                xPoint += size + 2;
            }
        }
    }
}
