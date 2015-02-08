using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Hittable.Elements
{
    public class SpawnAttribute
    {
        public int meleeFactor = 0;
        public int rangeFactor = 0;
        public int aoeFactor = 0;
        public int speedFactor = 0;

        public void add(SpawnAttribute a)
        {
            meleeFactor += a.meleeFactor;
            rangeFactor += a.rangeFactor;
            aoeFactor += a.aoeFactor;
            speedFactor += a.speedFactor;
        }

        public void sub(SpawnAttribute a)
        {
            meleeFactor -= a.meleeFactor;
            rangeFactor -= a.rangeFactor;
            aoeFactor -= a.aoeFactor;
            speedFactor -= a.speedFactor;
        }

        public int getMaxIndex()
        {
            if (meleeFactor > rangeFactor && meleeFactor > aoeFactor)
                return 1;
            if (rangeFactor > aoeFactor)
                return 2;
            return 3;
        }

        public int sum()
        {
            return meleeFactor + rangeFactor + speedFactor + aoeFactor;
        }

        public override string ToString()
        {
            return "mel: "+meleeFactor+" rang: "+rangeFactor+" aoe: "+aoeFactor;
        }
    }

}
