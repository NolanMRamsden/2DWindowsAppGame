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
    class TankTurret : TurretCharacter
    {
        private static LoaderPackage package = new LoaderPackage()
        {
            sourceString = "Soldier",
            attackAnim = 1,
            attackSprites = 1,
            walkAnim = 1,
            walkSprites = 1
        };

        public TankTurret() : base() 
        {
            canAttackType = CharacterEnums.EType.BOTH;
            myType = CharacterEnums.EType.GROUND;
        }

        protected override int getRangedDamage()
        {
            return 400;
        }

        protected override int getAttackCount()
        {
            return 100;
        }
        public override string ToString()
        {
            return "Tank Turret";
        }
        protected override Type getProjectileType()
        {
            return typeof(TankBullet);
        }

        protected override AnimationSet getAnimSet()
        {
            return RectangleGenerator.getRectangleAnimSet(50, 50);
        }

        protected override int getOffSetDivisor()
        {
            return -1;
        }
    }
}
