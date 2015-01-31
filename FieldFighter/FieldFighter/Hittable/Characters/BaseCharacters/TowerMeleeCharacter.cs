using FieldFighter.Hittable.CharacterLogic;
using FieldFighter.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Characters.BaseCharacters
{
    class TowerMeleeCharacter : HittableCharacter
    {
        /** can hit and be hit by both ground and air characters */
        public TowerMeleeCharacter()
        {
            canAttackType = CharacterEnums.EType.BOTH;
            myType = CharacterEnums.EType.BOTH;
        }

        public override string ToString()
        {
            return "Tower Melee";
        }

        protected override int getMaxHealth()
        {
            return 700;
        }

        protected override int getWalkSpeed()
        {
            return 5;
        }

        protected override int getMeleeDamage()
        {
            return 40;
        }

        protected override int getAttackCount()
        {
            return 70;
        }

        protected override CharacterBrain getBrain()
        {
            // hide just behind base melee characters on the ground
            return new MeleeBrain(Constants.defaultMeleeDistance+5);
        }

        protected override AnimationSet getAnimSet()
        {
            return RectangleGenerator.getRectangleAnimSet(30, (Constants.groundHeight-Constants.airHeight)+50);
        }
    }
}
