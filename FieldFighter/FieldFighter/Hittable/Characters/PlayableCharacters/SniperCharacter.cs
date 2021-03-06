﻿using FieldFighter.Hittable.CharacterLogic;
using FieldFighter.Hittable.Elements;
using FieldFighter.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Characters.BaseCharacters
{
    class SniperCharacter : GunSoldier
    {
        private static LoaderPackage package = new LoaderPackage()
        {
            sourceString = "SniperWithGillie",
            attackAnim = 25,
            attackSprites = 7,
            walkAnim = 10,
            walkSprites = 6
        };

        protected override Utilities.AnimationSet getAnimSet()
        {
            return AnimationLoader.loadAnimation(package);
            //return RectangleGenerator.getRectangleAnimSet(30,10);
        }

        public override string ToString()
        {
            return "Sniper";
        }

        protected override int getMaxHealth()
        {
            return 55;
        }

        protected override int getWalkSpeed()
        {
            return 1;
        }

        protected override CharacterBrain getBrain()
        {
            return new RangedHiderBrain(1000,100);
        }

        protected override int getMeleeDamage()
        {
            return 1;
        }

        protected override int getRangedDamage()
        {
            return 350;
        }

        protected override int getAttackCount()
        {
            return 160;
        }

        protected override Type getProjectileType()
        {
            return typeof(SniperBullet);
        }

        protected override int getOffSetDivisor()
        {
            return 10;
        }

        public override int getSpawnCost()
        {
            return 1000;
        }
    }

    class RocketLauncherCharacter : SniperCharacter
    {
        private static LoaderPackage package = new LoaderPackage()
        {
            sourceString = "RocketMan",
            attackAnim = 50,
            attackSprites = 6,
            walkAnim = 10,
            walkSprites = 6
        };

        public override string ToString()
        {
            return "Rocket Launcher";
        }

        protected override int getAttackCount()
        {
            return base.getAttackCount()*2;
        }

        protected override AnimationSet getAnimSet()
        {
            return AnimationLoader.loadAnimation(package);
        }

        protected override Type getProjectileType()
        {
            return typeof(RocketBullet);
        }

        protected override CharacterBrain getBrain()
        {
            return new RangedBrain(800, 100);
        }

        protected override int getOffSetDivisor()
        {
            return -6;
        }

        public override int getSpawnCost()
        {
            return 1500;
        }

    }

    class MachineGunCharacter : GunSoldier
    {
        Boolean high;
        public MachineGunCharacter() : base()
        {
            high = false;
        }

        private static LoaderPackage package = new LoaderPackage()
        {
            sourceString = "MachineGunner",
            attackAnim = 4,
            attackSprites = 6,
            walkAnim = 10,
            walkSprites = 6
        };

        public override string ToString()
        {
            return "Machine Gunner";
        }

        protected override int getWalkSpeed()
        {
            return 2;
        }

        protected override int getAttackCount()
        {
            return 8;
        }

        protected override int getRangedDamage()
        {
            return 15;
        }

        protected override Utilities.AnimationSet getAnimSet()
        {
            return AnimationLoader.loadAnimation(package);
        }

        protected override Type getProjectileType()
        {
            return typeof(Bullet);
        }

        protected override int getOffSetDivisor()
        {
            high = !high;
            if (high)
                return 5;
            else
                return 6;
        }

        public override int getSpawnCost()
        {
            return 700;
        }

    }
     
}
