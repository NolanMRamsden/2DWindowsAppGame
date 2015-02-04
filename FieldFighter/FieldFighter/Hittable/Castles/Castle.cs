using FieldFighter.Hittable;
using FieldFighter.Hittable.Castles;
using FieldFighter.Hittable.Characters.BaseCharacters;
using FieldFighter.Hittable.Elements;
using FieldFighter.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable
{
    public class Castle : HittableTarget
    {
        const int TurretOffset = 200;
        /** broadcast the targets for opposing enemies */
        public HittableTarget airFrontTarget;
        public HittableTarget groundFrontTarget;
        public Texture2D castleTexture;

        protected CastleUpgrader upgrader;
        protected List<HittableCharacter> characters = new List<HittableCharacter>();
        protected TurretCharacter turret;
        protected int xCoordinate;

        private double money = Constants.startingMoney;

        public Castle(FieldFighter.Hittable.CharacterEnums.EDirection facing, int Xco)
        {
            upgrader = CastleUpgrader.set1;
            myType = CharacterEnums.EType.BOTH;
            castleTexture = upgrader.texture;
            this.facing = facing;
            if (facing == CharacterEnums.EDirection.LEFT)
            {
                this.xCoordinate = Xco - castleTexture.Width;
                this.healthBar = new VerticalHealthBar(ELocation.RIGHT);
            }
            else
            {
                this.xCoordinate = Xco;
                this.healthBar = new VerticalHealthBar(ELocation.LEFT);
            }
            healthBar.setNew(getMaxHealth());
            groundFrontTarget = this;
            airFrontTarget = this;
        }

        /** accessable methods from the buttons */
        public void spawn(ECharacterType type)
        {
            spawn(upgrader.spawn(type));
        }
        public void spawnTurret()
        {
            if (getMoney() - upgrader.getTurret().getSpawnCost() < 0)
                return;
            this.turret = upgrader.getTurret();
            int turretLocation = getFrontLocationX();
            if (facing == CharacterEnums.EDirection.RIGHT)
            {
                turretLocation += TurretOffset;                
            } else
            {
                turretLocation -= TurretOffset;
            }

            turret.spawn(turretLocation, facing);

        }
        private void spawn(HittableCharacter c)
        {
            if(getMoney() - c.getSpawnCost() < 0)
            {
                Logger.i(ToString() + " couldn't afford " + c.ToString() + " ($" + (getMoney() - c.getSpawnCost()) + ")");
                return;
            }else
            {
                money -= c.getSpawnCost();
                Logger.i(ToString() + " spawned " + c.ToString() + " ($"+getMoney()+")");
            }
            if(facing == CharacterEnums.EDirection.RIGHT)
                c.spawn(xCoordinate+castleTexture.Width+1, facing);
            else
                c.spawn(xCoordinate-1, facing);
            characters.Insert(0, c);
        }
        public void upgradeLeft()
        {
            upgrade(upgrader.left);
        }
        public void upgradeRight()
        {
            upgrade(upgrader.right);
        }
        public int getMoney()
        {
            return (int)money;
        }
        /** method for enemyCastle to pay out when a character dies, needs to be done better */
        public void pay(int amount)
        {
            Logger.d(ToString() + " got $" + amount);
            money += amount;
        }

        /** updates the front target and held characters */
        public void updateCharacters(Castle enemyCastle)
        {
            if(turret != null)
            {
                turret.update(enemyCastle);
            }
            money += Constants.moneyEarnRate;
            groundFrontTarget = this;
            airFrontTarget = this;
            for (int i = characters.Count - 1; i >= 0; i--)
            {
                if (characters[i].dead())
                {
                    enemyCastle.pay(characters[i].getSpawnCost() / 2);
                    characters.RemoveAt(i);
                }
                else
                {
                    characters[i].update(enemyCastle);
                    if (characters[i].myType == CharacterEnums.EType.BOTH)
                    {
                        groundFrontTarget = inFront(characters[i], groundFrontTarget);
                        airFrontTarget = inFront(characters[i], airFrontTarget);
                    }
                    else if (characters[i].myType == CharacterEnums.EType.AIR)
                        airFrontTarget = inFront(characters[i], airFrontTarget);
                    else
                        groundFrontTarget = inFront(characters[i], groundFrontTarget);
                }
            }
        }

        /** determines the init health of castle */
        public virtual int getMaxHealth()
        {
            return 1000;
        }

        /** draws castle as well as its characters, calls base to get healthbar */
        public override void draw(SpriteBatch batch)
        {
            
            base.draw(batch);
            if(facing == CharacterEnums.EDirection.RIGHT)
                batch.Draw(castleTexture, getLocation(), null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            else
                batch.Draw(castleTexture, getLocation(), Color.White);

            foreach (HittableCharacter c in characters)
                c.draw(batch);
            //redraw front targets so their healthbars are visible over others
            if(this != groundFrontTarget)
                groundFrontTarget.draw(batch);
            if(this != airFrontTarget)
                airFrontTarget.draw(batch);
            if (turret != null)
            {
                turret.draw(batch);
            }
        }

        /** occupied space */
        public override Rectangle getLocation()
        {
            return new Rectangle(xCoordinate, Constants.groundHeight - castleTexture.Height, castleTexture.Width, castleTexture.Height);
        }

        /** handle new health on upgrade */
        private void upgrade(CastleUpgrader g)
        {
            if (g != null)
            {
                if(money - g.upgradeCost < 0)
                {
                    Logger.i("Cannot upgrade " + ToString() + " ($" + (getMoney() - g.upgradeCost) + ")");
                    return;
                }
                money -= g.upgradeCost;
                Logger.i(ToString() + " upgraded to: " + g.ToString() + " ($" + getMoney() + ")");
                upgrader = g;
                double p = healthBar.getPercentage();
                p += Constants.upgradeHealthBoost; if (p > 1) p = 1;
                healthBar.maxHealth = g.maxHealth;
                healthBar.sethealth((int)(p * healthBar.maxHealth));
                castleTexture = upgrader.texture;
            }
        }

        public override string ToString()
        {
            return upgrader.ToString() + " facing "+facing;
        }
        public string details()
        {
            String details = ToString();
            details += "\n\tMoney: $"+getMoney()+" Health: "+(int)(healthBar.health)+"hp";
            details += "\n\tfront air target: " + airFrontTarget.ToString();
            details += "\n\tfront ground target: " + groundFrontTarget.ToString();
            details += "\n\tmelee: " + upgrader.spawn(ECharacterType.MELEE).ToString();
            details += "\n\trange: " + upgrader.spawn(ECharacterType.RANGED).ToString();
            details += "\n\tair  : " + upgrader.spawn(ECharacterType.SPECIAL).ToString();
            return details;
        }
    }
}
