using FieldFighter.Enviroment;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FieldFighter.Hittable.Elements;
using Microsoft.Xna.Framework.Graphics;
using FieldFighter.Utilities;

namespace FieldFighter.Hittable
{
    public abstract class HittableTarget
    {
        public FieldFighter.Hittable.CharacterEnums.EDirection facing;
        public FieldFighter.Hittable.CharacterEnums.EType myType;

        protected HealthBar healthBar;

        /** returns the relative position for opposing players */
        public int getFrontLocationX()
        {
            if (facing == CharacterEnums.EDirection.RIGHT)
            {
                return getLocation().Right;
            }else if(facing == CharacterEnums.EDirection.LEFT)
            {
                return getLocation().Left;
            }
            return 0;
        }

        /** self explanatory lol */
        public bool dead()
        {
            return (healthBar.health == 0);
        }

        /** drawing all elements, base will need to be called */
        public virtual void draw(SpriteBatch batch)
        {
            healthBar.draw(batch, getLocation());
        }

        /** top level method to get hit */
        public virtual void getHit(int damage)
        {
            if (healthBar.hitForDamage(damage))
                Logger.i(ToString() + " died");
            else
                Logger.d(ToString() + " at " + Math.Round(healthBar.getPercentage()*100) + "% health");
        }

        /** returns the rectangle of space the player is occupying */
        public abstract Rectangle getLocation();

        /** determine which hittable target is the front target */
        public HittableTarget inFront(HittableTarget a, HittableTarget b)
        {
            if (facing == CharacterEnums.EDirection.LEFT)
            {
                if (a.getFrontLocationX() < b.getFrontLocationX())
                    return a;
                return b;
            }
            else
            {
                if (a.getFrontLocationX() > b.getFrontLocationX())
                    return a;
                return b;
            }
        }

    }
}
