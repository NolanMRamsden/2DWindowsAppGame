using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.CharacterLogic
{
    /** will retreat into cover of base if enemy gets too close */
    class RangedHiderBrain : RangedBrain
    {
        public RangedHiderBrain(int rangedAttackDistance, int hideBufferDistance)
            : base(rangedAttackDistance, hideBufferDistance)
        {

        }

        public override CharacterEnums.ECharacterAction determineAction(HittableCharacter me, HittableTarget frontEnemy)
        {
            CharacterEnums.ECharacterAction acc = base.determineAction(me, frontEnemy);
            if(acc == CharacterEnums.ECharacterAction.MELEEATTACK)
                return CharacterEnums.ECharacterAction.WALKBACKWARD;
            else 
                return acc;

        }
    }
}
