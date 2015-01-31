using FieldFighter.Hittable.CharacterLogic;
using FieldFighter.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Characters.BaseCharacters
{
    class AirRangedCharacter : RangedCharacter
    {
        public AirRangedCharacter() : base()
        {
            canAttackType = myType = CharacterEnums.EType.AIR;
        }

        public override string ToString()
        {
            return "Air Ranged";
        }

        protected override int getWalkSpeed()
        {
            return 3;
        }

        protected override int getMaxHealth()
        {
            return 300;
        }

        protected override int getMeleeDamage()
        {
            return 10;
        }

        protected override int getRangedDamage()
        {
            return 100;
        }

        protected override int getAttackCount()
        {
            return 100;
        }

        protected override CharacterBrain getBrain()
        {
            return new RangedBrain(500, 52);
        }

        protected override AnimationSet getAnimSet()
        {
            return RectangleGenerator.getRectangleAnimSet(30, 60);
        }
    }

    class AirRangedCharacterPlus : AirRangedCharacter
    {
        public override string ToString()
        {
            return base.ToString() + "+";
        }

        protected override CharacterBrain getBrain()
        {
            return new RangedBrain(800,52);
        }

        protected override int getMeleeDamage()
        {
            return base.getRangedDamage();
        }
    }
}
