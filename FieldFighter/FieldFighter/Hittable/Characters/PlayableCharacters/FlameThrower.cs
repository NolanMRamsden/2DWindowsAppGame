using FieldFighter.Hittable.CharacterLogic;
using FieldFighter.Hittable.Characters.BaseCharacters;
using FieldFighter.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Characters.PlayableCharacters
{
    class FlameThrower : MeleeCharacter
    {
        private static LoaderPackage package = new LoaderPackage()
        {
            sourceString = "FlameThrower",
            attackAnim = 5,
            attackSprites = 5,
            walkAnim = 7,
            walkSprites = 6
        };

        public FlameThrower() : base()
        {
            canAttackType = CharacterEnums.EType.GROUND;
            myType = CharacterEnums.EType.GROUND;
        }

        public override string ToString()
        {
            return "FlameThrower";
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
            return 5;
        }

        protected override int getSplashRange()
        {
            return 50;
        }

        protected override int getAttackCount()
        {
            return 1;
        }

        protected override CharacterBrain getBrain()
        {
            return new MeleeBrain(-35);
        }

        protected override AnimationSet getAnimSet()
        {
            return AnimationLoader.loadAnimation(package);
        }
    }
}
