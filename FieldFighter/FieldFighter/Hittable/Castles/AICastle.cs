using FieldFighter.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Castles
{

    class AICastle : Castle
    {
        const int thinkCount = 1200;
        const int panicDistance = 500;
        const int settleDistance = 1000;
        private int counter = 0;

        ECharacterType speedyChoice;
        ECharacterType cheapChoice;
        ECharacterType meleeChoice;
        ECharacterType rangeChoice;
        ECharacterType aoeChoice;
        int maxAoe = 0;
        int maxRange = 0;
        int maxSpeed = 0;
        int maxMelee = 0;
        int minCost = 10000;
        int lastHealth;
        Random r;

        public AICastle(FieldFighter.Hittable.CharacterEnums.EDirection facing, int Xco) : base(facing, Xco) 
        {
            lastHealth = (int)healthBar.maxHealth;
            r = new Random(Xco);
            determineChoices();
        }
        public override void updateCharacters(Castle enemyCastle)
        {
            //were pushing the pace, save up money to upgrade
            if (Math.Abs(enemyCastle.getFrontLocationX() - groundFrontTarget.getFrontLocationX()) < settleDistance && upgrader.left != null)
            {
                base.updateCharacters(enemyCastle);
                return;
            }
            counter += r.Next(1, 6);
            // they havent spawned any, chill out a lil
            if(enemyCastle.characterTotals.sum() == 0)
            {
                counter -= 2;
            }
            //we got hit, speed up the thinking process
            if(lastHealth != healthBar.health)
            {
                counter += 50;
            }
            //enemies are close and we dont have any spawned, think now
            if(Math.Abs(enemyCastle.groundFrontTarget.getFrontLocationX() - getFrontLocationX()) < panicDistance
                  && characterTotals.sum() == 0)
            {
                counter = thinkCount + 1;
            }
            if (counter > thinkCount)
            {
                counter = 0;
                int startCount = characters.Count;
                // we have a guy past half way, and can afford upgrade, do it
                if (upgrader.canUpgrade(getMoney()) && Math.Abs(groundFrontTarget.getFrontLocationX() - enemyCastle.getFrontLocationX()) < 1500)
                {
                    int up = r.Next(0, 2);
                    if (up == 0)
                        upgradeLeft();
                    else
                        upgradeRight();
                }
                //enemycastle is low on money and no one spawned go speedy
                if(enemyCastle.getMoney() < 200 || enemyCastle.characterTotals.sum() == 0)
                {
                    spawn(speedyChoice);
                }
                //enemy is heavy on range or enemy is in too close, spawn melee
                if (enemyCastle.characterTotals.getMaxIndex() == 2 ||
                    Math.Abs(enemyCastle.groundFrontTarget.getFrontLocationX() - getFrontLocationX()) < panicDistance/2)
                    spawn(meleeChoice);
                //enemy is heavy on melee, spawn aoe
                else if (enemyCastle.characterTotals.getMaxIndex() == 1)
                    spawn(aoeChoice);
                //enemy is heavy on aoe, spawn range
                else if (enemyCastle.characterTotals.getMaxIndex() == 3)
                    spawn(rangeChoice);
                //we didnt spawn anything (couldnt afford) try cheep
                if (startCount == characters.Count && Math.Abs(enemyCastle.groundFrontTarget.getFrontLocationX() - getFrontLocationX()) < settleDistance)
                    spawn(cheapChoice);
            }
            lastHealth = (int)healthBar.health;
            base.updateCharacters(enemyCastle);
        }

        protected override void upgrade(CastleUpgrader g)
        {
            base.upgrade(g);
            determineChoices();
        }

        private void determineChoices()
        {
            maxAoe = 0;
            maxRange = 0;
            maxSpeed = 0;
            maxMelee = 0;
            minCost = 100000;
            check(ECharacterType.MELEE);
            check(ECharacterType.SPECIAL);
            check(ECharacterType.RANGED);
            Logger.d("New Speedy choice: " + upgrader.spawn(speedyChoice).ToString());
            Logger.d("New Melee choice: " + upgrader.spawn(meleeChoice).ToString());
            Logger.d("New Range choice: " + upgrader.spawn(rangeChoice).ToString());
            Logger.d("New aoe choice: " + upgrader.spawn(aoeChoice).ToString());
            Logger.d("New cheap choice: " + upgrader.spawn(cheapChoice).ToString());
        }

        private void check(ECharacterType type)
        {
            HittableCharacter c = upgrader.spawn(type);
            if (c.getSpawnCost() < minCost)
            {
                minCost = c.getSpawnCost();
                cheapChoice = type;
            }if (c.spawnAttribute.speedFactor >= maxSpeed)
            {
                maxSpeed = c.spawnAttribute.speedFactor;
                speedyChoice = type;
            }if (c.spawnAttribute.meleeFactor >= maxMelee)
            {
                maxMelee = c.spawnAttribute.meleeFactor;
                meleeChoice = type;
            } if (c.spawnAttribute.rangeFactor >= maxRange)
            {
                maxRange = c.spawnAttribute.rangeFactor;
                rangeChoice = type;
            } if (c.spawnAttribute.aoeFactor >= maxAoe)
            {
                maxAoe = c.spawnAttribute.aoeFactor;
                aoeChoice = type;
            }
        }
    }
}
