using FieldFighter.Hittable.CharacterLogic;
using FieldFighter.Hittable.Characters.BaseCharacters;
using FieldFighter.Hittable.Elements;
using FieldFighter.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Characters.PlayableCharacters
{
    class PhoneGuy : RangedCharacter
    {
        private static LoaderPackage package = new LoaderPackage()
        {
            sourceString = "PhoneGuy",
            attackAnim = 30,
            attackSprites = 9,
            walkAnim = 9,
            walkSprites = 6
        };

        public PhoneGuy() : base()
        {
            canAttackType = CharacterEnums.EType.GROUND;
            myType = CharacterEnums.EType.GROUND;
        }

        public override string ToString()
        {
            return "Phone Guy Rocket";
        }

        protected override Type getProjectileType()
        {
            return typeof(AirStrike);
        }

        protected override int getWalkSpeed()
        {
            return 4;
        }

        protected override int getMaxHealth()
        {
            return 1;
        }

        protected override int getMeleeDamage()
        {
            return 0;
        }

        protected override int getRangedDamage()
        {
            return 250;
        }

        protected override int getAttackCount()
        {
            return 300;
        }

        protected override CharacterBrain getBrain()
        {
            return new RangedBrain(900,-1);
        }

        protected override AnimationSet getAnimSet()
        {
            return AnimationLoader.loadAnimation(package);
        }

        public override int getSpawnCost()
        {
            return 1000;
        }
    }

    class PhoneGuyLazor : PhoneGuy
    {
        public override string ToString()
        {
            return "Phone Guy Lazor";
        }
        protected override Type getProjectileType()
        {
            return typeof(SateliteStrike);
        }
        protected override int getAttackCount()
        {
            return 500;
        }
        public override int getSpawnCost()
        {
            return 900;
        }
    }
}
