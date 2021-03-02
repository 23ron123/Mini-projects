
#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion
#region Shortcuts
using GDM = Microsoft.Xna.Framework.GraphicsDeviceManager;
using GD = Microsoft.Xna.Framework.Graphics.GraphicsDevice;
using CM = Microsoft.Xna.Framework.Content.ContentManager;
using SB = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using V2 = Microsoft.Xna.Framework.Vector2;
using V3 = Microsoft.Xna.Framework.Vector3;
using MH = Microsoft.Xna.Framework.MathHelper;
using MX = Microsoft.Xna.Framework.Matrix;
using T2 = Microsoft.Xna.Framework.Graphics.Texture2D;
using F = System.Single;
using SE = Microsoft.Xna.Framework.Graphics.SpriteEffects;
using REC = Microsoft.Xna.Framework.Rectangle;
using KS = Microsoft.Xna.Framework.Input.KeyboardState;
using MS = Microsoft.Xna.Framework.Input.MouseState;
using C = Microsoft.Xna.Framework.Color;
using BSM = Microsoft.Xna.Framework.Graphics.BlendState;
using SSM = Microsoft.Xna.Framework.Graphics.SpriteSortMode;
#endregion

namespace online
{
    public class ControllableCharacter : Character
    {

        Keys l, r, u, d;
        float v;

        public ControllableCharacter(T2 tex, V2 pos, REC? rec, Color color,
              F rot, V2 org, V2 scale, SE flip, F layer, Keys l = Keys.Left, Keys r = Keys.Right, Keys u = Keys.Up, Keys d = Keys.Down, float v = 20)
            : base(tex, pos, rec, color, rot, org, scale, flip, layer)
        {
            this.l = l;
            this.r = r;
            this.u = u;
            this.d = d;
            this.v = v;
        }

        public override void update()
        {
            if (G.ks.IsKeyDown(l))
            {
                rot -= 0.05f;
            }

            if (G.ks.IsKeyDown(r))
            {
                rot += 0.05f;
            }

            if (G.ks.IsKeyDown(u))
            {
                pos += G.sovev_vector(rot) * v;
            }

            if (G.ks.IsKeyDown(d))
            {
                pos -= G.sovev_vector(rot) * v;
            }

            base.update();
        }


    }
}
