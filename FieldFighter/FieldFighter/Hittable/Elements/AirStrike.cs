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
    class AirStrike : Projectile
    {
        HittableTarget target;
        Texture2D targetMarker;
        Texture2D payload;
        int damage;
        int projectileY = -50;
        int finalDestination;
        public AirStrike(CharacterEnums.EDirection direction, Vector2 startLocation, int damage, HittableTarget target)
             : base(direction,startLocation,damage,target)
        {
            this.target = target;
            this.damage = damage;
            targetMarker = getTargetMarker();
            payload = getPayload();
            if (target.myType == CharacterEnums.EType.AIR)
                finalDestination = Constants.airHeight;
            else
                finalDestination = Constants.groundHeight;
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
                target.getHit(damage);
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
}
