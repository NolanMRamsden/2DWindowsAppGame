using FieldFighter.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Characters.BaseCharacters
{
    class TankMeleeCharacter : GroundMeleeCharacter
    {
        private static LoaderPackage package = new LoaderPackage()
        {
            sourceString = "RiotMan",
            attackAnim = 25,
            attackSprites = 5,
            walkAnim = 7,
            walkSprites = 6
        };

        protected override int getAttackCount()
        {
            return base.getAttackCount()*2;
        }

        protected override int getMaxHealth()
        {
            return base.getMaxHealth()*2;
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
            return "Ground Tank Man";
        }
    }
}
