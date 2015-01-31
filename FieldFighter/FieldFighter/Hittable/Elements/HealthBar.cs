using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Elements
{
    public abstract class HealthBar
    {
        public static GraphicsDevice device;

        protected const int skinnyPart = 8;
        protected const int longPart = 50;
        protected const int lineThickness = 2;

        protected Texture2D outLine;
        protected Texture2D filler;
        protected ELocation location;
        protected Color innerColor = Color.Green;
        protected int hitColorCount = 0;

        public double maxHealth;
        public double health;

        public HealthBar(ELocation location)
        {
            this.location = location;
            outLine = new Texture2D(device, 1, 1);
            outLine.SetData(new[] { Color.Black });
            filler = new Texture2D(device, 1, 1);
            filler.SetData(new[] { Color.White });
        }
        public HealthBar(ELocation location, Color fillerColor)
        {
            this.location = location;
            outLine = new Texture2D(device, 1, 1);
            outLine.SetData(new[] { Color.Black });
            filler = new Texture2D(device, 1, 1);
            filler.SetData(new[] { fillerColor });
        }

        public void setNew(int maxHealth)
        {
            this.maxHealth = this.health = maxHealth;
        }
        public void sethealth(int health)
        {
            this.health = health;
        }
        /** returns true if the hit killed the healthbar */
        public Boolean hitForDamage(int damage)
        {
            if (damage == 0) return false;
            health -= damage;
            innerColor = Color.Red;
            hitColorCount = 5;
            if (health <= 0)
            {
                health = 0;
                return true;
            }
            return false;
        }
        public double getPercentage()
        {
            return health / maxHealth;
        }

        public virtual void draw(SpriteBatch batch, Rectangle rect)
        {
            hitColorCount--;
            if (hitColorCount <= 1)
            {
                hitColorCount = 1;
                innerColor = Color.LightGreen;
            }
        }
    }

    public class HorizontalHealthBar : HealthBar
    {
        private const int vertOffset = lineThickness * 2 + skinnyPart;
        private const int vertOffInner = lineThickness + skinnyPart;

        public HorizontalHealthBar(ELocation location) : base(location){}
        public HorizontalHealthBar(ELocation location, Color fillerColor) : base(location, fillerColor){}

        public override void draw(SpriteBatch batch, Rectangle rect)
        {
            int height1, height2;
            if(location == ELocation.TOP)
            {
                height1 = rect.Top - vertOffset;
                height2 = rect.Top - vertOffInner;
            }else
            {
                height1 = rect.Bottom - vertOffset;
                height2 = rect.Bottom - vertOffInner;
            }

            batch.Draw(outLine,new Rectangle(rect.Left-lineThickness,height1,rect.Width+lineThickness*2,vertOffset),Color.Black);
            batch.Draw(filler,new Rectangle(rect.Left,height2,(int)(rect.Width*getPercentage()),skinnyPart), innerColor);
            base.draw(batch, rect);
        }
    }

    public class VerticalHealthBar : HealthBar
    {
        private const int vertOffset = lineThickness * 2 + skinnyPart;
        private const int vertOffInner = lineThickness + skinnyPart;

        public VerticalHealthBar(ELocation location) : base(location) { }
        public VerticalHealthBar(ELocation location, Color fillerColor) : base(location, fillerColor) { }

        public override void draw(SpriteBatch batch, Rectangle rect)
        {
            int horiz1,horiz2;
            if (location == ELocation.LEFT)
            {
                horiz1 = rect.Left - vertOffset;
                horiz2 = rect.Left - vertOffInner;
            }
            else
            {
                horiz1 = rect.Right;
                horiz2 = rect.Right + lineThickness;
            }

            batch.Draw(outLine, new Rectangle(horiz1, rect.Top - lineThickness, vertOffset, rect.Height+lineThickness), Color.Black);
            batch.Draw(filler, new Rectangle(horiz2, rect.Top + (int)(rect.Height * (1-getPercentage())), skinnyPart, (int)(rect.Height * getPercentage())), innerColor);
            base.draw(batch, rect);
        }
    }

    public enum ELocation
    {
        TOP, BOTTOM, LEFT, RIGHT 
    }
}
