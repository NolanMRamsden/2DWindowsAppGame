using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Elements
{
    public abstract class Projectile
    {
        public Projectile(CharacterEnums.EDirection direction, Vector2 startLocation, int damage, HittableTarget target) { }
        public abstract Boolean update();
        public abstract void draw(SpriteBatch batch);
    }
}
