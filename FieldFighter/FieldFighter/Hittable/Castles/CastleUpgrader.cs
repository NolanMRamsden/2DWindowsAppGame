﻿using FieldFighter.Hittable.CharacterLogic;
using FieldFighter.Hittable.Characters.BaseCharacters;
using FieldFighter.Hittable.Characters.PlayableCharacters;
using FieldFighter.Utilities;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Castles
{
    /** handles upgrade path and which characters are spawned */
    public class CastleUpgrader
    {
        public Texture2D texture     {get; set;}
        public int maxHealth         {get; set;}
        public CastleUpgrader left   {get; set;}
        public CastleUpgrader right  {get; set;}
        public int upgradeCost       {get; set;}
        Type meleeCharacter    {get; set;}
        Type rangedCharacter   {get; set;}
        Type specialCharacter  {get; set;}
        Type turret            {get; set;}
        String signatureString {get; set;}

        public static CastleUpgrader set7 = new CastleUpgrader()
        {
            maxHealth = 1000,
            upgradeCost = 5000,
            texture = RectangleGenerator.filled(200, 400),
            turret = typeof(MachineTurret),
            meleeCharacter = typeof(SuicideJacket),
            rangedCharacter = typeof(SniperCharacter),
            specialCharacter = typeof(Tank),
            signatureString = "Castle 1-2-2"
        };

        public static CastleUpgrader set6 = new CastleUpgrader()
        {
            maxHealth = 1000,
            upgradeCost = 5000,
            texture = RectangleGenerator.filled(200, 400),
            turret = typeof(MachineTurret),
            meleeCharacter = typeof(GunSoldierPlus),
            rangedCharacter = typeof(RocketLauncherCharacter),
            specialCharacter = typeof(Tank),
            signatureString = "Castle 1-2-1"
        };

        public static CastleUpgrader set5 = new CastleUpgrader()
        {
            maxHealth = 1000,
            upgradeCost = 5000,
            texture = RectangleGenerator.filled(200, 400),
            turret = typeof(MachineTurret),
            meleeCharacter = typeof(RiotMan),
            rangedCharacter = typeof(PhoneGuy),
            specialCharacter = typeof(Tank),
            signatureString = "Castle 1-1-2"
        };

        public static CastleUpgrader set4 = new CastleUpgrader()
        {
            maxHealth = 1000,
            upgradeCost = 5000,
            texture = RectangleGenerator.filled(200, 400),
            turret = typeof(MachineTurret),
            meleeCharacter = typeof(RiotMan),
            rangedCharacter = typeof(MachineGunCharacter),
            specialCharacter = typeof(Tank),
            signatureString = "Castle 1-1-1"
        };

        public static CastleUpgrader set3 = new CastleUpgrader()
        {
            maxHealth = 8000,
            upgradeCost = 3000,
            texture = RectangleGenerator.filled(200, 300),
            left = set6,
            right = set7,
            turret = typeof(MachineTurret),
            meleeCharacter = typeof(FlameThrower),
            rangedCharacter = typeof(SniperCharacter),
            specialCharacter = typeof(PhoneGuyLazor),
            signatureString = "Castle 1-2"
        };

        public static CastleUpgrader set2 = new CastleUpgrader()
        {
            maxHealth = 7500,
            upgradeCost = 3000,
            texture = RectangleGenerator.filled(200, 300),
            left = set4,
            right = set5,
            turret = typeof(MachineTurret),
            meleeCharacter = typeof(RiotMan),
            rangedCharacter = typeof(MachineGunCharacter),
            specialCharacter = typeof(PhoneGuyLazor),
            signatureString = "Castle 1-1"
        };

        public static CastleUpgrader set1 = new CastleUpgrader()
        {
            maxHealth = 5000,
            texture = AnimationLoader.pngToTexture("Bases/TentL.png"),
            left = set2,
            right = set3,
            turret = typeof(MachineTurret),
            meleeCharacter = typeof(RiotMan),
            rangedCharacter = typeof(PhoneGuy),
            specialCharacter = typeof(Tank),
            signatureString = "Castle 1"
        };

        private static List<CastleUpgrader> castles = new List<CastleUpgrader>();

        public static List<CastleUpgrader> getCastles()
        {
            constructTree(set1);
            return castles;
        }

        private static void constructTree(CastleUpgrader set)
        {
            if(set == null)
                return;
            castles.Add(set1);
            if (set.left != null)
                constructTree(set.left);
            if (set.right != null)
                constructTree(set.right);
        }

        public HittableCharacter spawn(ECharacterType character)
        {
            switch(character)
            {
                case ECharacterType.MELEE:
                    return (HittableCharacter)Activator.CreateInstance(meleeCharacter);
                case ECharacterType.RANGED:
                    return (HittableCharacter)Activator.CreateInstance(rangedCharacter);
                case ECharacterType.SPECIAL:
                    return (HittableCharacter)Activator.CreateInstance(specialCharacter);
            }         
            return (HittableCharacter)Activator.CreateInstance(meleeCharacter);
        }

        public TurretCharacter getTurret()
        {
            return (TurretCharacter)Activator.CreateInstance(turret);
        }

        public bool canUpgrade(int money)
        {
            if (left != null && right != null)
                if (money - left.upgradeCost > 0)
                    return true;
            return false;
        }
        public override string ToString()
        {
            return signatureString;
        }
    }

    public enum ECharacterType
    {
        MELEE, RANGED, SPECIAL
    }
}
