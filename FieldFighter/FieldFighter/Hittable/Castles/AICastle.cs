using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Castles
{

    class AICastle : Castle
    {
        const int thinkCount = 100;

        private int counter = 0;
        public AICastle(FieldFighter.Hittable.CharacterEnums.EDirection facing, int Xco) : base(facing, Xco) { }
        public override void updateCharacters(Castle enemyCastle)
        {
            counter++;
            if (counter > thinkCount)
            {
                counter = 0;
                if (Math.Abs(enemyCastle.groundFrontTarget.getFrontLocationX() - getFrontLocationX()) < 1000)
                    spawn(ECharacterType.MELEE);
            }
            base.updateCharacters(enemyCastle);
        }
    }
}
