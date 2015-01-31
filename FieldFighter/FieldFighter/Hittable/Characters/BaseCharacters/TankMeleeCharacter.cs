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
            return RectangleGenerator.getRectangleAnimSet(100, 100);
        }

        public override string ToString()
        {
            return "Ground Tank Man";
        }
    }
}
