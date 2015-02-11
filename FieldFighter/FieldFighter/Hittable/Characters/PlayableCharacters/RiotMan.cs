using FieldFighter.Hittable.CharacterLogic;
using FieldFighter.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Characters.BaseCharacters
{
    class RiotMan : BasicSoldier
    {
        private static LoaderPackage package = new LoaderPackage()
        {
            sourceString = "RiotMan",
            attackAnim = 25,
            attackSprites = 5,
            rangeAttackAnim = 10,
            rangeAttackSprites = 6,
            walkAnim = 7,
            walkSprites = 6,
            hasSecondaryAnim = true
        };

        protected override int getMeleeDamage()
        {
            return base.getMeleeDamage()*2;
        }

        protected override int getAttackCount()
        {
            return base.getAttackCount()*2;
        }

        protected override int getMaxHealth()
        {
            return base.getMaxHealth()*8;
        }

        protected override int getWalkSpeed()
        {
            return 2;
        }

        protected override AnimationSet getAnimSet()
        {
            return AnimationLoader.loadAnimation(package);
        }

        public override string ToString()
        {
            return "Riot Man";
        }

        public override int getSpawnCost()
        {
            return 250;
        }
    }
}
