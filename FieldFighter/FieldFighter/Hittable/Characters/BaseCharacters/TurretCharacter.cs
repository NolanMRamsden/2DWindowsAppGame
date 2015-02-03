using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FieldFighter.Hittable.Elements;
using FieldFighter.Utilities;

namespace FieldFighter.Hittable.Characters.BaseCharacters
{
    public class TurretCharacter : RangedCharacter
    {

        public TurretCharacter() : base() { }

        protected override AnimationSet getAnimSet()
        {
            return RectangleGenerator.getRectangleAnimSet(75, 350);
        }

        protected override ELocation getHealthBarLocation()
        {
            return ELocation.INVISIBLE;
        }

        protected override int getWalkSpeed()
        {
            return 0;
        }

    }

}
