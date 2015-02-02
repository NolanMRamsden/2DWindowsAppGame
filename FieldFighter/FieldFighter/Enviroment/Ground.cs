using FieldFighter.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Enviroment
{
    class Ground : EnviromentObject
    {
        const int topSize = 60;
        const int pieces = 15;
        const int featureHeight = 40;
        const int treeMin = 100;
        const int treeMax = 250;
        const int treeWidth = 130;
        const int numTrees = 20;

        public static Texture2D textureTop,textureUnder,textureFeature, tree;
        private Point[] treeArray = new Point[numTrees];
        private int groundHeight;
        private int screenWidth;
        private int screenHeight;
        private int sliceSize;

        public Ground(int groundHeight, int screenWidth, int screenHeight) : base()
        {
            this.groundHeight = groundHeight;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            textureTop = AnimationLoader.pngToTexture("Environment/grassFlat.jpg");
            textureFeature = AnimationLoader.pngToTexture("Environment/grassUp.png");
            textureUnder = AnimationLoader.pngToTexture("Environment/sand.png");
            tree = AnimationLoader.pngToTexture("Environment/Tree1.png");
            sliceSize = screenWidth / pieces;
            Random r = new Random();
            for(int i=0; i<numTrees; i++)
            {
                treeArray[i].X = r.Next(0, screenWidth);
                treeArray[i].Y = r.Next(treeMin, treeMax);
            }
        }

        public override void update()
        {
            
        }

        public override void draw(SpriteBatch batch)
        {
            for (int i = 0; i < numTrees; i++ )
            {
                batch.Draw(tree, new Rectangle(treeArray[i].X, groundHeight - treeArray[i].Y, treeWidth, treeArray[i].Y), Color.White);
            }
            for (int i = 0; i < pieces; i++)
            {
                batch.Draw(textureFeature, new Rectangle(i * sliceSize, groundHeight - featureHeight, sliceSize, featureHeight), Color.White);
                batch.Draw(textureTop, new Rectangle(i * sliceSize, groundHeight, sliceSize, topSize), Color.White);
            }
            
            batch.Draw(textureUnder, new Rectangle(0, groundHeight + topSize, screenWidth, screenHeight - (groundHeight+topSize)), Color.White);
        }
    }
}
