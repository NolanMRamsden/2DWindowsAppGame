using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FieldFighter.Hittable
{
    public class CharacterEnums
    {
        public enum EDirection
        {
            LEFT, RIGHT
        }

        public enum EType
        {
            GROUND, AIR, BOTH, NONE
        }

        public enum ECharacterAction
        {
            WALKFORWARD, WALKBACKWARD, MELEEATTACK, RANGEATTACK, IDLE
        }

        public static EDirection oppositeDir(EDirection dir)
        {
            if (dir == EDirection.LEFT)
                return EDirection.RIGHT;
            else
                return EDirection.LEFT;
        }
    }
}
