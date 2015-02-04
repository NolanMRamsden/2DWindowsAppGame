using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Utilities
{
    public class LoaderPackage
    {
        public string sourceString { get; set; }
        public int attackAnim {get; set;}
        public int attackSprites { get; set; }
        public int walkAnim { get; set; }
        public int walkSprites { get; set; }
        public int rangeAttackAnim { get; set; }
        public int rangeAttackSprites { get; set; }
        public Boolean hasSecondaryAnim = false;
    }

    public class AnimationLoader
    {
        public static ContentManager content; 
        //png package naming conventions
        const String leftAttack = "LA.png";
        const String rightAttack = "RA.png";
        const String leftAttackRange = "LA2.png";
        const String rightAttackRange = "RA2.png";
        const String leftWalk = "LW.png";
        const String rightWalk = "RW.png";

        public static AnimationSet loadAnimation(LoaderPackage p)
        {
            AnimationSet set = new AnimationSet();
            String baseString = p.sourceString+"/"+p.sourceString;
            set.leftAttack = pngToAnimation(baseString + leftAttack, p.attackSprites, p.attackAnim);
            set.leftWalk = pngToAnimation(baseString + leftWalk, p.walkSprites, p.walkAnim);
            set.rightAttack = pngToAnimation(baseString + rightAttack, p.attackSprites, p.attackAnim);
            set.rightWalk = pngToAnimation(baseString + rightWalk, p.walkSprites, p.walkAnim);
            if (p.hasSecondaryAnim)
            {
                set.rightAttackRange = pngToAnimation(baseString + rightAttackRange, p.rangeAttackSprites, p.rangeAttackAnim);
                set.leftAttackRange = pngToAnimation(baseString + leftAttackRange, p.rangeAttackSprites, p.rangeAttackAnim);
            }else
            {
                set.rightAttackRange = set.rightAttack;
                set.leftAttackRange = set.leftAttack;
            }

            set.currentAnimation = set.rightWalk;
            return set;
        }

        public static Texture2D pngToTexture(String pngName)
        {
            return content.Load<Texture2D>(pngName);
        }

        public static AnimationSet loadTurretAnimation(LoaderPackage p)
        {
            AnimationSet set = new AnimationSet();
            String baseString = "Turrets/"+p.sourceString+"/"+p.sourceString;
            set.rightAttack =  set.leftAttack = pngToAnimation(baseString +"A.png", p.attackSprites, p.attackAnim);
            set.rightWalk =  set.leftWalk = pngToAnimation(baseString + ".png", p.walkSprites, p.walkAnim);
            if (p.hasSecondaryAnim)
            {
                set.rightAttackRange = pngToAnimation(baseString + rightAttackRange, p.rangeAttackSprites, p.rangeAttackAnim);
                set.leftAttackRange = pngToAnimation(baseString + leftAttackRange, p.rangeAttackSprites, p.rangeAttackAnim);
            }else
            {
                set.rightAttackRange = set.rightAttack;
                set.leftAttackRange = set.leftAttack;
            }

            set.currentAnimation = set.rightWalk;
            return set;
        }

        private static Animation pngToAnimation(String pngName, int sprites, int count)
        {
            Texture2D tex = content.Load<Texture2D>(pngName);
            return new Animation(tex, sprites, 1, 1, count);
        }
    }
}
