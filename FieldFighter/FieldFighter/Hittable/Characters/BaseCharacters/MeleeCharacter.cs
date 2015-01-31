using FieldFighter.Hittable.CharacterLogic;
using FieldFighter.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Characters.BaseCharacters
{
    abstract class MeleeCharacter : HittableCharacter
    {
        protected override int getMaxHealth()
        {
            return 500;
        }

        protected override int getWalkSpeed()
        {
            return 4;
        }

        protected override int getMeleeDamage()
        {
            return 20;
        }

        protected override int getAttackCount()
        {
            return 50;
        }

        protected override CharacterBrain getBrain()
        {
            return new MeleeBrain(Constants.defaultMeleeDistance);
        }
    }
}
