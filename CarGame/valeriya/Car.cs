using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace valeriya
{
    class Car : Drawobject
    {
        #region Data
        float v;
        
        #endregion


        #region ctor

        public Car( Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation,
            Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth ,float v = 10) :
            base(texture, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth)
        {
            this.v = v;

        }
        #endregion

        #region public Funcs
        public void move()
        {
            if (G.ks.IsKeyDown(Keys.Left))
            {
                rotation -= 0.05f;
            }

            if (G.ks.IsKeyDown(Keys.Right))
            {
                rotation += 0.05f;
            }

            Matrix m = Matrix.CreateRotationZ(rotation);
            Vector2 drc = Vector2.Transform(Vector2.UnitX, m);

            if (G.ks.IsKeyDown(Keys.Up))
            {
                position += drc * v;
            }

            if (G.ks.IsKeyDown(Keys.Down))
            {
                position -= drc * v;
            }

        }

        #endregion
    }


}
