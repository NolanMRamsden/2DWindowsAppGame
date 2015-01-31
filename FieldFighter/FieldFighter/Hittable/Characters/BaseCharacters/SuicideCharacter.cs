using FieldFighter.Hittable.CharacterLogic;
using FieldFighter.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Characters.BaseCharacters
{
    abstract class SuicideCharacter : HittableCharacter
    {
        protected override CharacterBrain getBrain()
        {
            return new MeleeBrain(Constants.defaultMeleeDistance/2);
        }

        protected override int getMaxHealth()
        {
            return 50;
        }

        protected override int getWalkSpeed()
        {
            return 7;
        }

        protected override int getMeleeDamage()
        {
            return 1000;
        }

        protected override int getAttackCount()
        {
            return 70;
        }

        /** altered attack method to kill themself on attack */
        protected override void attack(HittableTarget target, Boolean isMelee)
        {
            if (canAttackType == CharacterEnums.EType.BOTH || canAttackType == target.myType || target.myType == CharacterEnums.EType.BOTH)
            {
                attackCounter++;
                if (attackCounter >= getAttackCount())
                {
                    attackCounter = 0;
                    Logger.d(ToString() + " attacked " + target.ToString() + "(Melee " + getMeleeDamage() + " dmg)");
                    target.getHit(getMeleeDamage());
                    this.healthBar.sethealth(0);
                }
            }
        }
    }
}
