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
    public class AirStrike : Projectile
    {
        protected HittableTarget target;
        protected Texture2D targetMarker;
        protected Texture2D payload;
        protected Castle enemyCastle;
        protected int damage;
        
        private int projectileY = -50;
        private int finalDestination;
        public AirStrike(CharacterEnums.EDirection direction, Vector2 startLocation, int damage, HittableTarget target, Castle enemyCastle)
             : base(direction,startLocation,damage,target, enemyCastle)
        {
            this.target = target;
            this.damage = damage;
            this.enemyCastle = enemyCastle;
            targetMarker = getTargetMarker();
            payload = getPayload();
            if (target.myType == CharacterEnums.EType.AIR)
                finalDestination = Constants.airHeight;
            else
                finalDestination = Constants.groundHeight;
        }

        public override bool isSplash()
        {
            return true;
        }

        public virtual Texture2D getTargetMarker()
        {
            return AnimationLoader.pngToTexture("Bullets/TargetMarker.png");
        }

        public virtual Texture2D getPayload()
        {
            return AnimationLoader.pngToTexture("Bullets/AirstrikeRocket.png");
        }
        private double xMagnitude = 0;
        private double xAccel = 1.65;
        public override Boolean update()
        {
            xMagnitude += xAccel;
            projectileY += 20 + (int)xMagnitude;

            if (projectileY + 100 >= finalDestination)
            {
                enemyCastle.hitForSplash(damage, 125, target.myType);
                return true;
            }
            return false;
        }

        public override void draw(SpriteBatch batch)
        {
            Rectangle r = target.getLocation();
            int distance = (r.Width)-(projectileY - finalDestination)/6;
            batch.Draw(targetMarker, new Rectangle( r.Center.X-distance/2,r.Bottom-distance/12,distance  ,distance/6), Color.White);
            batch.Draw(payload, new Rectangle((int)(r.Center.X - payload.Width / 2), projectileY, payload.Width, payload.Height), Color.White);
        }
    }

    public class SateliteStrike : AirStrike
    {
        const int widthFactor = 8;

        public SateliteStrike(CharacterEnums.EDirection direction, Vector2 startLocation, int damage, HittableTarget target, Castle enemyCastle)
             : base(direction,startLocation,damage,target,enemyCastle)
        {}

        public override Texture2D getPayload()
        {
            return AnimationLoader.pngToTexture("Bullets/Lazer.png");
        }

        public override bool update()
        {
            int damageNow = damage - 5;
            if (damageNow < 0)
                return true;
            target.getHit(5);
            damage = damageNow;
            return false;
        }

        public override void draw(SpriteBatch batch)
        {
            Rectangle r = target.getLocation();
            int width = (int)Math.Sqrt(damage*widthFactor);
            batch.Draw(targetMarker, new Rectangle( r.Center.X-r.Width/2,r.Bottom-r.Width/12,r.Width  ,r.Width/6), Color.White);
            batch.Draw(payload, new Rectangle(r.Center.X - width / 2, 0, width, r.Bottom), Color.White);
        }
    }
}
