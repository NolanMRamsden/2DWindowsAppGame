using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.CharacterLogic
{
    class RangedBrain : CharacterBrain
    {
        private int rangedAttackDistance;
        private int meleeAttackDistance;

        public RangedBrain(int rangedAttackDistance, int meleeAttackDistance ) : base()
        {
            this.rangedAttackDistance = rangedAttackDistance;
            this.meleeAttackDistance = meleeAttackDistance;
        }

        public override CharacterEnums.ECharacterAction determineAction(HittableCharacter me, HittableTarget frontEnemy)
        {
            if (me.facing == CharacterEnums.EDirection.RIGHT)
            {
                if (me.getFrontLocationX() + meleeAttackDistance >= frontEnemy.getFrontLocationX())
                    return CharacterEnums.ECharacterAction.MELEEATTACK;
                if (me.getFrontLocationX() + rangedAttackDistance >= frontEnemy.getFrontLocationX())
                    return CharacterEnums.ECharacterAction.RANGEATTACK;
            }else
            {
                if (me.getFrontLocationX() - meleeAttackDistance <= frontEnemy.getFrontLocationX())
                    return CharacterEnums.ECharacterAction.MELEEATTACK;
                if (me.getFrontLocationX() - rangedAttackDistance <= frontEnemy.getFrontLocationX())
                    return CharacterEnums.ECharacterAction.RANGEATTACK;              
            }
            return CharacterEnums.ECharacterAction.WALKFORWARD;
        }
    }
}
