using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FieldFighter.Hittable.Elements;
using FieldFighter.Utilities;
using FieldFighter.Hittable.CharacterLogic;

namespace FieldFighter.Hittable.Characters.BaseCharacters
{
    public abstract class TurretCharacter : RangedCharacter
    {
        public TurretCharacter() : base() { }

        protected override ELocation getHealthBarLocation()
        {
            return ELocation.INVISIBLE;
        }

        protected override CharacterBrain getBrain()
        {
            return new PureRangedBrain(1000);
        }

        protected override int getWalkSpeed()
        {
            return 0;
        }

    }

}
