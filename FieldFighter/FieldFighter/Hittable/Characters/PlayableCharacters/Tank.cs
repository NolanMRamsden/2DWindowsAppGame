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
    class Tank : RangedCharacter
    {
        private static LoaderPackage package = new LoaderPackage()
        {
            sourceString = "BasicTank",
            attackAnim = 25,
            attackSprites = 10,
            walkAnim = 5,
            walkSprites = 3
        };

        public Tank() : base()
        {
            canAttackType = CharacterEnums.EType.GROUND;
            myType = CharacterEnums.EType.GROUND;
        }

        public override string ToString()
        {
            return "Tank";
        }

        protected override int getWalkSpeed()
        {
            return 2;
        }

        protected override int getMaxHealth()
        {
            return 1000;
        }

        protected override int getMeleeDamage()
        {
            return 0;
        }

        protected override int getRangedDamage()
        {
            return 300;
        }

        protected override int getAttackCount()
        {
            return 250;
        }

        protected override CharacterBrain getBrain()
        {
            return new RangedBrain(950,20);
        }

        protected override Type getProjectileType()
        {
            return typeof(TankBullet);
        }

        protected override int getOffSetDivisor()
        {
            return -8;
        }

        protected override AnimationSet getAnimSet()
        {
            return AnimationLoader.loadAnimation(package);
        }

        public override int getSpawnCost()
        {
            return 1500;
        }
    }
}
