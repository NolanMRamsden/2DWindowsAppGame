using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Utilities
{
    public class Constants
    {
        /** screen size dependants */
        public static int groundHeight;
        const double groundFactor = .7;
        public static int airHeight;
        const double airFactor = .65;
        public static int screenHeight;
        public static int screenWidth;
        const double baseFactor = .05;
        public static int leftBaseX;
        public static int rightBaseX;
        
        public const int startingMoney = 2000;
        public const double moneyEarnRate = .25;
        public const double upgradeHealthBoost = .10;

        public const int defaultMeleeDistance = 5;



        public static void setConstants(Rectangle ScreenBounds)
        {
            screenHeight = ScreenBounds.Height;
            screenWidth = ScreenBounds.Width;
            groundHeight = (int)(ScreenBounds.Height * groundFactor);
            airHeight = (int)(ScreenBounds.Height * airFactor);
            leftBaseX = (int)(ScreenBounds.Width * baseFactor);
            rightBaseX = (int)(ScreenBounds.Width * (1 - baseFactor));
        }
    }
}
