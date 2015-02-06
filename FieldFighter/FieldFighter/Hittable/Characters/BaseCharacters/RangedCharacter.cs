using FieldFighter.Hittable.Elements;
using FieldFighter.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Characters.BaseCharacters
{
    /** altered character class that usees projectiles at a certain range */
    public abstract class RangedCharacter : HittableCharacter
    {
        public RangedCharacter() : base() { }

        protected List<Projectile> projectiles = new List<Projectile>();

        public override void update(Castle enemy)
        {
            HittableTarget groundTarget = enemy.groundFrontTarget;
            HittableTarget airTarget = enemy.airFrontTarget;
            for (int i = 0; i < projectiles.Count; i++)
                if (projectiles[i].update())
                {
                    projectiles.RemoveAt(i);
                }
            base.update(enemy);
        }

        public override void draw(SpriteBatch batch)
        {
            foreach (Projectile b in projectiles)
                b.draw(batch);
            base.draw(batch);
        }

        /** altered attack method to spawn projectiles on ranged attack */
        protected override void attack(HittableTarget target, Boolean isMelee, Castle enemy)
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
                        target.getHit(getMeleeDamage());
                    }
                    else
                    {
                        Rectangle r = getLocation();
                        int bulletHeight = (int)(r.Center.Y + r.Height / getOffSetDivisor());
                        Logger.d(ToString() + " attacked " + target.ToString() + "(Ranged " + getRangedDamage() + " dmg)");
                        if(getFrontLocationX() > target.getFrontLocationX())
                            projectiles.Add((Projectile)Activator.CreateInstance(getProjectileType(), 
                                         new object[]{CharacterEnums.EDirection.LEFT,new Vector2(getFrontLocationX(), bulletHeight),
                                         getRangedDamage(),target,enemy}));
                        else
                            projectiles.Add((Projectile)Activator.CreateInstance(getProjectileType(),
                                         new object[]{CharacterEnums.EDirection.RIGHT,new Vector2(getFrontLocationX(), bulletHeight),
                                         getRangedDamage(),target,enemy}));
                    }
                }
            }
        }
        /** the factor of the characters heigh to offset the bullet from the middle (aesthetic)*/
        protected virtual int getOffSetDivisor()
        {
            return 5;
        }
        /** override to change the projectile, defaults to base bullet */
        protected virtual Type getProjectileType()
        {
            return typeof(Bullet);
        }
        /** factor projectile type into spawn attribute */
        protected override SpawnAttribute getSpawnAttributes()
        {
            Projectile p = (Projectile)Activator.CreateInstance(getProjectileType(),
                                         new object[]{CharacterEnums.EDirection.RIGHT,new Vector2(0,0),
                                         getRangedDamage(),this,null});
            int aoe = 0;
            if (p.isSplash())
                aoe = getRangedDamage();
            return new SpawnAttribute()
            {
                meleeFactor = getMeleeDamage(),
                rangeFactor = getRangedDamage(),
                aoeFactor = aoe
            };
        }
    }
}
