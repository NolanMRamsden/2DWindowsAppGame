using FieldFighter.Hittable.CharacterLogic;
using FieldFighter.Utilities;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Characters.BaseCharacters
{
    class AirMeleeCharacter : HittableCharacter
    {
        private static LoaderPackage package = new LoaderPackage()
        {
            sourceString = "OrangeBirdSmall",
            attackAnim = 4,
            attackSprites = 4,
            walkAnim = 7,
            walkSprites = 4
        };

        public AirMeleeCharacter() : base()
        {
            canAttackType = CharacterEnums.EType.BOTH;
            myType = CharacterEnums.EType.AIR;
        }

        public override string ToString()
        {
            return "Air Melee";
        }

        protected override int getMaxHealth()
        {
            return 500;
        }

        protected override int getWalkSpeed()
        {
            return 4;
        }

        protected override int getMeleeDamage()
        {
            return 60;
        }

        protected override int getAttackCount()
        {
            return 50;
        }

        protected override CharacterBrain getBrain()
        {
            return new MeleeBrain(50);
        }

        protected override AnimationSet getAnimSet()
        {
            return AnimationLoader.loadAnimation(package);
            //return RectangleGenerator.getRectangleAnimSet(50, 20);
        }
    }

    class AirMeleeCharacterPlus : AirMeleeCharacter
    {
        private static LoaderPackage package = new LoaderPackage()
        {
            sourceString = "OrangeBird",
            attackAnim = 4,
            attackSprites = 4,
            walkAnim = 7,
            walkSprites = 4
        };

        public override string ToString()
        {
            return base.ToString()+"+";
        }

        protected override int getAttackCount()
        {
            return (int)(base.getAttackCount() * .75);
        }

        protected override int getMeleeDamage()
        {
            return (int)(base.getMeleeDamage() * 1.3);
        }

        protected override AnimationSet getAnimSet()
        {
            return AnimationLoader.loadAnimation(package);
            //return RectangleGenerator.getRectangleAnimSet(50, 20);
        }
    }
}
