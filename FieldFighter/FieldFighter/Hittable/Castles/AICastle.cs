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
        
        const int difficulty = 5;

        private int leftUpgradeDelay = 2000;
        private int rangeDelay = 600;
        private int counter = 0;
        

        public AICastle(FieldFighter.Hittable.CharacterEnums.EDirection facing, int Xco) : base(facing, Xco) { }
        public override void updateCharacters(Castle enemyCastle)
        {
            counter++;
            rangeDelay-=difficulty;
            if (leftUpgradeDelay > 0)
                leftUpgradeDelay-=difficulty;

            if (counter > thinkCount)
            {
                counter = 0;
                if (Math.Abs(enemyCastle.groundFrontTarget.getFrontLocationX() - getFrontLocationX()) < 1000)
                    spawn(ECharacterType.MELEE);
                if (rangeDelay < 0)
                {
                    spawn(ECharacterType.RANGED);
                    rangeDelay = 600;
                }
                if(leftUpgradeDelay == 0)
                {
                    upgradeLeft();
                    leftUpgradeDelay = -1;
                }

            }
            base.updateCharacters(enemyCastle);
        }
    }
}
