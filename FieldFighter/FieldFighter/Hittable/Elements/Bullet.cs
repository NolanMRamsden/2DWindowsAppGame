using FieldFighter.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Elements
{
    class Bullet
    {
        private Texture2D text;
        private Vector2 location;
        private HittableTarget target;
        private CharacterEnums.EDirection moving;
        private int damage;
        private int speed;

        public Bullet(CharacterEnums.EDirection direction, Vector2 startLocation, int damage, HittableTarget target)
        {
            location = startLocation;
            this.target = target;
            this.damage = damage;
            this.speed = getSpeed();
            this.moving = direction;
            if (moving == CharacterEnums.EDirection.LEFT)
                this.speed *= -1;
            text = getTexture();
        }
        
        /** returns true when hit payload */
        public Boolean update()
        {
            if (moving == CharacterEnums.EDirection.LEFT)
            {
                location.X -= getSpeed();
                if (location.X <= target.getFrontLocationX())
                {
                    target.getHit(damage);
                    return true;
                }
            }
            else if (moving == CharacterEnums.EDirection.RIGHT)
            {
                location.X += getSpeed();
                if (location.X >= target.getFrontLocationX())
                {
                    target.getHit(damage);
                    return true;
                }
            }
            return false;
        }
        public void draw(SpriteBatch batch)
        {
            batch.Draw(text, new Rectangle((int)location.X, (int)location.Y, text.Width, text.Height), Color.White);
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
            return RectangleGenerator.filled(10, 10);
        }
    }
}
