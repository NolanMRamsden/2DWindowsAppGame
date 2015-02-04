using FieldFighter.Hittable.CharacterLogic;
using FieldFighter.Hittable.Characters;
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
    public abstract class HittableCharacter : HittableTarget
    {
        public FieldFighter.Hittable.CharacterEnums.EType canAttackType;
        public SpawnAttribute spawnAttribute;
        protected CharacterBrain brain;
        protected AnimationSet animSet;
        private int splashRange;

        /** assign logic and init health */
        public HittableCharacter()
        {
            brain = getBrain();
            animSet = getAnimSet();
            splashRange = getSplashRange();
            healthBar = new HorizontalHealthBar(getHealthBarLocation());
            healthBar.setNew(getMaxHealth());
            spawnAttribute = getSpawnAttributes();
        }

        protected virtual SpawnAttribute getSpawnAttributes()
        {
            return new SpawnAttribute();
        }

        /**  how the character will be drawn */
        protected abstract AnimationSet getAnimSet();

        public void spawn(int xCo, FieldFighter.Hittable.CharacterEnums.EDirection facing)
        {
            this.facing = facing;
            if (facing == CharacterEnums.EDirection.RIGHT)
                this.xCoordinate = xCo - animSet.currentAnimation.width;
            else
                this.xCoordinate = xCo;
        }
        
        protected virtual int getSplashRange()
        {
            return 0;
        }
        /** handles delegation of charater actions based on assigned brain logic **/
        protected virtual CharacterBrain getBrain()
        {
            return new MeleeBrain(50);
        }
        public virtual void update(Castle enemy)
        {
            HittableTarget groundTarget = enemy.groundFrontTarget;
            HittableTarget airTarget = enemy.airFrontTarget;
            if (dead())
            {
                return;
            }
            switch(brain.determine(this, groundTarget, airTarget))
            {
                case CharacterEnums.ECharacterAction.WALKFORWARD:
                    walkForward();
                    break;
                case CharacterEnums.ECharacterAction.WALKBACKWARD:
                    walkBackward();
                    break;
                case CharacterEnums.ECharacterAction.MELEEATTACK:
                    attackTop(brain.myTarget, true, enemy);
                    break;
                case CharacterEnums.ECharacterAction.RANGEATTACK:
                    attackTop(brain.myTarget, false, enemy);
                    break;
            }
            animSet.currentAnimation.Update();
        }
        public override void draw(SpriteBatch batch)
        {
            if(myType == FieldFighter.Hittable.CharacterEnums.EType.AIR)
                animSet.currentAnimation.Draw(batch, new Vector2(xCoordinate, Constants.airHeight));
            else
                animSet.currentAnimation.Draw(batch, new Vector2(xCoordinate, Constants.groundHeight));         
            base.draw(batch);
        }
        public override Rectangle getLocation()
        {
            if(myType == CharacterEnums.EType.AIR)
                return new Rectangle(xCoordinate, Constants.airHeight - animSet.currentAnimation.height, animSet.currentAnimation.width, animSet.currentAnimation.height);
            else
                return new Rectangle(xCoordinate, Constants.groundHeight - animSet.currentAnimation.height, animSet.currentAnimation.width, animSet.currentAnimation.height);
                
        }

        /** override to alter character behaviour */
        protected virtual int getMeleeDamage()
        {
            return 0;
        }
        protected virtual int getRangedDamage()
        {
            return 0;
        }
        protected virtual int getWalkSpeed()
        {
            return 1;
        }
        protected virtual int getAttackCount()
        {
            return 100;
        }
        protected virtual int getMaxHealth()
        {
            return 100;
        }
        protected virtual ELocation getHealthBarLocation()
        {
            return ELocation.TOP;
        }
        public virtual int getSpawnCost()
        {
            return 50;
        }

        /** handles air and ground unit filtering and attack pacing */
        protected int attackCounter = 0;
        private void attackTop(HittableTarget target, Boolean isMelee, Castle enemy)
        {
            if (facing == CharacterEnums.EDirection.RIGHT)
            {
                if (isMelee)
                    animSet.currentAnimation = animSet.rightAttack;
                else
                    animSet.currentAnimation = animSet.rightAttackRange;
            }
            else
            {
                if (isMelee)
                    animSet.currentAnimation = animSet.leftAttack;
                else
                    animSet.currentAnimation = animSet.leftAttackRange;
            }
            attack(target, isMelee, enemy);
        }
        protected virtual void attack(HittableTarget target, Boolean isMelee, Castle enemy)
        {
            if (canAttackType == CharacterEnums.EType.BOTH || canAttackType == target.myType || target.myType == CharacterEnums.EType.BOTH)
            {
                attackCounter++;
                if (attackCounter >= getAttackCount())
                {
                    attackCounter = 0;
                    if (isMelee)
                    {
                        Logger.d(ToString() + " attacked " + target.ToString() + "(Melee " + getMeleeDamage() + " dmg)");
                        if (splashRange == 0)
                        {
                            target.getHit(getMeleeDamage());
                        }
                        else
                        {
                            enemy.hitForSplash(getMeleeDamage(), splashRange, canAttackType);
                        }
                    }
                    else
                    {
                        Logger.d(ToString() + " attacked " + target.ToString() + "(Ranged "+getRangedDamage() + " dmg)");
                        if (splashRange == 0)
                        {
                            target.getHit(getRangedDamage());
                        }
                        else
                        {
                            enemy.hitForSplash(getRangedDamage(), splashRange, canAttackType);
                        }
                    }
                }
            }
        }

        /** internal functions to move character */
        private int xCoordinate;
        private void walkForward()
        {
            walk(facing);
        }
        private void walkBackward()
        {
            walk(CharacterEnums.oppositeDir(facing));
        }
        private void walk(CharacterEnums.EDirection dir)
        {
            if (dir == CharacterEnums.EDirection.RIGHT)
            {
                xCoordinate += getWalkSpeed();
                animSet.currentAnimation = animSet.rightWalk;
            }else
            {
                xCoordinate -= getWalkSpeed();
                animSet.currentAnimation = animSet.leftWalk;
            }
        }
    }
}
