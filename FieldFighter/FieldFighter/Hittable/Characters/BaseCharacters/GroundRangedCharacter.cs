using FieldFighter.Hittable.CharacterLogic;
using FieldFighter.Hittable.Elements;
using FieldFighter.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Characters.BaseCharacters
{
    class GroundRangedCharacter : RangedCharacter
    {
        private static LoaderPackage package = new LoaderPackage()
        {
            sourceString = "SoldierRanged",
            attackAnim = 19,
            attackSprites = 5,
            walkAnim = 9,
            walkSprites = 6
        };

        public GroundRangedCharacter() : base()
        {
            canAttackType = CharacterEnums.EType.GROUND;
            myType = CharacterEnums.EType.GROUND;
        }

        public override string ToString()
        {
            return "Ground Ranged";
        }

        protected override int getWalkSpeed()
        {
            return 3;
        }

        protected override int getMaxHealth()
        {
            return 300;
        }

        protected override int getMeleeDamage()
        {
            return 10;
        }

        protected override int getRangedDamage()
        {
            return 100;
        }

        protected override int getAttackCount()
        {
            return 100;
        }

        protected override CharacterBrain getBrain()
        {
            return new RangedBrain(500,52);
        }

        protected override AnimationSet getAnimSet()
        {
            return AnimationLoader.loadAnimation(package);
        }

    }

    class GroundRangedCharacterPlus : GroundRangedCharacter
    {
        public override string ToString()
        {
            return base.ToString() + "+";
        }

        protected override int getAttackCount()
        {
            return (int)(base.getAttackCount()*0.65);
        }

        protected override int getRangedDamage()
        {
            return (int)(base.getRangedDamage()*1.2);
        }

    }
}
