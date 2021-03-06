﻿using FieldFighter.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Elements
{
    class Bullet : Projectile
    {
        private Texture2D text;
        private Vector2 location;
        protected HittableTarget target;
        private CharacterEnums.EDirection moving;
        protected Castle enemyCastle;
        protected int damage;
        private int speed;

        public Bullet(CharacterEnums.EDirection direction, Vector2 startLocation, int damage, HittableTarget target, Castle enemyCastle)
             : base(direction,startLocation,damage,target, enemyCastle)
        {
            location = startLocation;
            this.target = target;
            this.damage = damage;
            this.speed = getSpeed();
            this.moving = direction;
            this.enemyCastle = enemyCastle;
            if (moving == CharacterEnums.EDirection.LEFT)
                this.speed *= -1;
            text = getTexture();
        }
        
        protected virtual void hitTarget()
        {
             target.getHit(damage);
        }

        /** returns true when hit payload */
        public override Boolean update()
        {
            if (moving == CharacterEnums.EDirection.LEFT)
            {
                location.X -= getSpeed();
                if (location.X <= target.getFrontLocationX())
                {
                    hitTarget();
                    return true;
                }
            }
            else if (moving == CharacterEnums.EDirection.RIGHT)
            {
                location.X += getSpeed();
                if (location.X >= target.getFrontLocationX())
                {
                    hitTarget();
                    return true;
                }
            }
            return false;
        }
        public override void draw(SpriteBatch batch)
        {
            if(speed > 0)
                batch.Draw(text, new Rectangle((int)location.X, (int)location.Y, text.Width, text.Height), Color.White);
            else
                batch.Draw(text, new Rectangle((int)location.X, (int)location.Y, text.Width, text.Height), null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
        }

        /** movement speed of the bullet */
        protected virtual int getSpeed()
        {
            return 9;
        }
        /** what it looks like */
        protected virtual Texture2D getTexture()
        {
            return AnimationLoader.pngToTexture("Bullets/BulletGoldLarger.png");
        }
    }
}
