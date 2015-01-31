﻿using FieldFighter.Hittable.CharacterLogic;
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

        protected CharacterBrain brain;
        protected AnimationSet animSet;

        /** assign logic and init health */
        public HittableCharacter()
        {
            brain = getBrain();
            animSet = getAnimSet();
            healthBar = new HorizontalHealthBar(getHealthBarLocation());
            healthBar.setNew(getMaxHealth());
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

        /** handles delegation of charater actions based on assigned brain logic **/
        protected virtual CharacterBrain getBrain()
        {
            return new MeleeBrain(50);
        }
        public virtual void update(HittableTarget groundTarget, HittableTarget airTarget)
        {
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
                    attack(brain.myTarget, true);
                    break;
                case CharacterEnums.ECharacterAction.RANGEATTACK:
                    attack(brain.myTarget, false);
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
        protected virtual void attack(HittableTarget target, Boolean isMelee)
        {
            if (facing == CharacterEnums.EDirection.RIGHT)
                animSet.currentAnimation = animSet.rightAttack;
            else
                animSet.currentAnimation = animSet.leftAttack;

            if (canAttackType == CharacterEnums.EType.BOTH || canAttackType == target.myType || target.myType == CharacterEnums.EType.BOTH)
            {
                attackCounter++;
                if (attackCounter >= getAttackCount())
                {
                    attackCounter = 0;
                    if (isMelee)
                    {
                        Logger.d(ToString() + " attacked " + target.ToString() + "(Melee " + getMeleeDamage() + " dmg)");
                        target.getHit(getMeleeDamage());
                    }
                    else
                    {
                        Logger.d(ToString() + " attacked " + target.ToString() + "(Ranged "+getRangedDamage() + " dmg)");
                        target.getHit(getRangedDamage());
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
