using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Utilities
{
    class RectangleGenerator
    {
        public static GraphicsDevice device;

        public static Texture2D filled()
        {
            return filled(50, 50);
        }
        public static Texture2D filled(int width, int height)
        {
            Texture2D rect = new Texture2D(device, width, height);
            Color[] data = new Color[width * height];
            for (int i = 1; i < width; i++)
                for (int j = 0; j < height; j++ )
                    data[i * j] = Color.White;
            rect.SetData(data);
            return rect;
        }
        public static Texture2D outline()
        {
            Texture2D rect = new Texture2D(device, 1, 1);
            rect.SetData(new[] { Color.Black, Color.Transparent, Color.Black });
            return rect;
        }
        public static AnimationSet getRectangleAnimSet(int width, int height)
        {
            Texture2D text = RectangleGenerator.filled(width, height);
            AnimationSet animSet = new AnimationSet();
            animSet.currentAnimation = animSet.leftWalk = animSet.rightWalk = new Animation(text, 1, 1, 0, 1);
            animSet.leftAttack = animSet.rightAttack = new Animation(text, 1, 1, 0, 1);
            return animSet;
        }
    }
}
