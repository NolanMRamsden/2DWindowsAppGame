using FieldFighter.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Elements
{
    class SniperBullet : Bullet
    {
        public SniperBullet(CharacterEnums.EDirection direction, Vector2 startLocation, int damage, HittableTarget target)
            : base(direction, startLocation, damage, target) { }

        protected override Microsoft.Xna.Framework.Graphics.Texture2D getTexture()
        {
            return AnimationLoader.pngToTexture("Bullets/SniperBullet.png");
        }

        protected override int getSpeed()
        {
            return 60;
        }
    }

    class RocketBullet : Bullet
    {
        public RocketBullet(CharacterEnums.EDirection direction, Vector2 startLocation, int damage, HittableTarget target)
            : base(direction, startLocation, damage, target) { }

        private double xMagnitude = 0;
        private double xAccel = 1.65;
        
        protected override Microsoft.Xna.Framework.Graphics.Texture2D getTexture()
        {
            return AnimationLoader.pngToTexture("Bullets/Rocket2.png");
        }

        protected override int getSpeed()
        {
            xMagnitude += xAccel;
            return (1 + (int)xMagnitude);
        }
    }

    class TankBullet : Bullet
    {
        public TankBullet(CharacterEnums.EDirection direction, Vector2 startLocation, int damage, HittableTarget target)
            : base(direction, startLocation, damage, target) { }

        protected override Microsoft.Xna.Framework.Graphics.Texture2D getTexture()
        {
            return AnimationLoader.pngToTexture("Bullets/TankBullet.png");
        }

        protected override int getSpeed()
        {
            return 30;
        }
    }
}
