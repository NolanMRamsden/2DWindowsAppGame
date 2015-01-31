using FieldFighter.Hittable.Characters.BaseCharacters;
using FieldFighter.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Characters.PlayableCharacters
{
    class SuicideJacket : SuicideCharacter
    {
        public SuicideJacket() : base()
        {
            myType = CharacterEnums.EType.GROUND;
            canAttackType = CharacterEnums.EType.GROUND;
        }

        private static LoaderPackage package = new LoaderPackage()
        {
            sourceString = "SuicideJacket",
            attackAnim = 6,
            attackSprites = 10,
            walkAnim = 7,
            walkSprites = 6
        };

        protected override AnimationSet getAnimSet()
        {
            return AnimationLoader.loadAnimation(package);
        }
    }
}
