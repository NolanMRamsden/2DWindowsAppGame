using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Utilities
{
    public class AnimationSet
    {
        public Animation leftWalk;
        public Animation rightWalk;
        public Animation leftAttack;
        public Animation rightAttack;
        public Animation leftDie;
        public Animation rightDie;
        public Animation currentAnimation;
        public int spriteHeight;
        public int spriteWidth;

        public void Update()
        {
            currentAnimation.Update();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            currentAnimation.Draw(spriteBatch, location);
        }

        public AnimationSet Clone()
        {
            AnimationSet set = new AnimationSet();
            set.leftAttack = this.leftAttack.Clone();
            set.rightAttack = this.rightAttack.Clone();
            set.rightDie = this.rightDie.Clone();
            set.leftDie = this.leftDie.Clone();
            set.rightWalk = this.rightWalk.Clone();
            set.leftWalk = this.leftWalk.Clone();
            return set;
        }
    }
    public class Animation
    {
        public Texture2D Texture { get; set; }
        public int totalFrames;
        public int minFrame = 0;
        private int currentFrame;
        public int width;
        public int height;
        private int row;
        private int updateCountMax;
        private int updateCount = 0;
        private int totalSpritesPerRow;

        public Animation(Texture2D texture, int xSprites, int ySprites, int rowIndex, int updateCount)
        {
            Texture = texture;
            currentFrame = 0;
            totalSpritesPerRow = totalFrames = xSprites;
            width = Texture.Width / totalFrames;
            height = Texture.Height / ySprites;
            row = rowIndex - 1;
            this.updateCountMax = updateCount;
        }

        public void setFrameSpan(int startFrame, int span)
        {
            this.currentFrame = startFrame;
            this.minFrame = startFrame;
            this.totalFrames = startFrame + span - 1;
        }

        public void Update()
        {
            if (updateCount++ == updateCountMax)
            {
                updateCount = 0;
                currentFrame++;
                if (currentFrame >= totalFrames)
                    currentFrame = minFrame;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int column = currentFrame % totalFrames;
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y - height, width, height);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
        public Animation Clone()
        {
            Animation sp = new Animation(Texture, totalSpritesPerRow, Texture.Height / height, row + 1, updateCountMax);
            sp.totalFrames = this.totalFrames;
            sp.minFrame = this.minFrame;
            return sp;
        }
    }
}
