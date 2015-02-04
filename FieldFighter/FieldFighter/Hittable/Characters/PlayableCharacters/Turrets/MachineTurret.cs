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
    class MachineTurret : TurretCharacter
    {
        private static LoaderPackage package = new LoaderPackage()
        {
            sourceString = "MachineTurret",
            attackAnim = 5,
            attackSprites = 2,
            walkAnim = 100,
            walkSprites = 1
        };

        public MachineTurret() : base() 
        {
            canAttackType = CharacterEnums.EType.BOTH;
            myType = CharacterEnums.EType.GROUND;
        }

        protected override int getRangedDamage()
        {
            return 8;
        }

        protected override int getAttackCount()
        {
            return 5;
        }
        public override string ToString()
        {
            return "Machine Turret";
        }

        protected override int getOffSetDivisor()
        {
            return 10;
        }

        protected override AnimationSet getAnimSet()
        {
            return AnimationLoader.loadTurretAnimation(package);
        }
    }
}
