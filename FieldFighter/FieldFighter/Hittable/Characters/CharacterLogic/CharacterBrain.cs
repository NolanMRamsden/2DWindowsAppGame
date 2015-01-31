using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable
{
    public abstract class CharacterBrain
    {
        public HittableTarget myTarget;

        public CharacterBrain()
        {

        }
        /** filter out ground and air then call specific brain determining action */
        public FieldFighter.Hittable.CharacterEnums.ECharacterAction determine(HittableCharacter me, HittableTarget groundTarget, HittableTarget airTarget)
        {
            myTarget = groundTarget;
            if (me.myType == CharacterEnums.EType.BOTH)
                myTarget = airTarget.inFront(airTarget, groundTarget);
            else if (me.myType == CharacterEnums.EType.AIR)
                myTarget = airTarget;
            return determineAction(me, myTarget);
        }
        public abstract FieldFighter.Hittable.CharacterEnums.ECharacterAction determineAction(HittableCharacter me, HittableTarget frontEnemy);
    }
}
