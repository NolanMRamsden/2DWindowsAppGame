using FieldFighter.Hittable.CharacterLogic;
using FieldFighter.Hittable.Elements;
using FieldFighter.Utilities;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Characters.BaseCharacters
{
    class BasicTurret : TurretCharacter
    {
        private static LoaderPackage package = new LoaderPackage()
        {
            sourceString = "Soldier",
            attackAnim = 1,
            attackSprites = 1,
            walkAnim = 1,
            walkSprites = 1
        };

        public BasicTurret() : base() 
        {
            canAttackType = CharacterEnums.EType.BOTH;
            myType = CharacterEnums.EType.GROUND;
        }

        protected override int getRangedDamage()
        {
            return 250;
        }

        protected override Type getProjectileType()
        {
            return typeof(SniperBullet);
        }

        protected override int getAttackCount()
        {
            return 80;
        }
        public override string ToString()
        {
            return "Basic Turret";
        }
        protected override int getOffSetDivisor()
        {
            return -1;
        }
        protected override CharacterBrain getBrain()
        {
            return new RangedBrain(1100, -100);
        }

        protected override AnimationSet getAnimSet()
        {
            return RectangleGenerator.getRectangleAnimSet(50, 50);
        }
    }
}
