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
    static class G
    {
        public static KeyboardState ks;
        public static void update()
        {
            ks = Keyboard.GetState();
        }

    }
}
