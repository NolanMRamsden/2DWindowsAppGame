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

        public void add(SpawnAttribute a)
        {
            meleeFactor += a.meleeFactor;
            rangeFactor += a.rangeFactor;
            aoeFactor += a.aoeFactor;
        }

        public void sub(SpawnAttribute a)
        {
            meleeFactor -= a.meleeFactor;
            rangeFactor -= a.rangeFactor;
            aoeFactor -= a.aoeFactor;
        }
    }

}
