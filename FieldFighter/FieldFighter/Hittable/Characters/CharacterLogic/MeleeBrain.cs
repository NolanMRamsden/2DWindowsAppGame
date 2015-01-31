using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.CharacterLogic
{
    class MeleeBrain : CharacterBrain
    {
        private int attackDistance;

        public MeleeBrain(int attackDistance) : base()
        {
            this.attackDistance = attackDistance;
        }

        public override CharacterEnums.ECharacterAction determineAction(HittableCharacter me, HittableTarget frontEnemy)
        {
            if (me.facing == CharacterEnums.EDirection.RIGHT)
            {
                if (me.getFrontLocationX() + attackDistance >= frontEnemy.getFrontLocationX())
                    return CharacterEnums.ECharacterAction.MELEEATTACK;
            }else
            {
                if (me.getFrontLocationX() - attackDistance <= frontEnemy.getFrontLocationX())
                    return CharacterEnums.ECharacterAction.MELEEATTACK;
            }
            return CharacterEnums.ECharacterAction.WALKFORWARD;
        }
    }
}
