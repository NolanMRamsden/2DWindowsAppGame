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
    class BasicSoldier : HittableCharacter
    {
        private static LoaderPackage package = new LoaderPackage()
        {
            sourceString = "Soldier",
            attackAnim = 5,
            attackSprites = 5,
            walkAnim = 7,
            walkSprites = 6
        };

        public BasicSoldier() : base()
        {
            canAttackType = CharacterEnums.EType.GROUND;
            myType = CharacterEnums.EType.GROUND;
        }

        public override string ToString()
        {
            return "Ground Melee";
        }

        protected override int getMaxHealth()
        {
            return 300;
        }

        protected override int getWalkSpeed()
        {
            return 4;
        }

        protected override int getMeleeDamage()
        {
            return 20;
        }

        protected override int getAttackCount()
        {
            return 50;
        }

        protected override CharacterBrain getBrain()
        {
            return new MeleeBrain(Constants.defaultMeleeDistance);
        }

        protected override AnimationSet getAnimSet()
        {
            return AnimationLoader.loadAnimation(package);
        }
    }

    class BasicSoldierPlus : BasicSoldier
    {
        public override string ToString()
        {
            return base.ToString() + "+";
        }

        protected override int getMaxHealth()
        {
            return (int)(base.getMaxHealth() * 1.5);
        }

        protected override int getMeleeDamage()
        {
            return (int)(base.getMeleeDamage() * 1.5);
        }
    }
}
