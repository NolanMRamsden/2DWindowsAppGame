using FieldFighter.Hittable;
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
    public class Board
    {
        const int boardWidth = 600;
        const int boardHeight = 300;


        private Castle castle;
        private FieldFighter.Hittable.CharacterEnums.EDirection dir;
        private Texture2D board;
        private Point location;

        public Board(Castle castle, Point location)
        {
            this.castle = castle;
            this.location = location;
            this.dir = castle.facing;
            board = AnimationLoader.pngToTexture("Environment/ScoreFrame.png");
        }

        public void update()
        {

        }

        public void draw(SpriteBatch batch)
        {
            if(dir == FieldFighter.Hittable.CharacterEnums.EDirection.RIGHT)
            {
                batch.Draw(board, new Rectangle(location.X, location.Y, boardWidth, boardHeight), Color.White);
                batch.Draw(castle.castleTexture, new Rectangle(location.X + boardHeight / 4, location.Y + boardHeight / 4, boardHeight / 2, boardHeight / 2), Color.White);
                NumberDrawer.drawNumber(batch, castle.getMoney(), location.X + boardWidth / 2, location.Y + boardHeight / 4);
            }
            else
            {
                batch.Draw(board, new Rectangle(location.X, location.Y, boardWidth, boardHeight), null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            }
        }
    }
}
