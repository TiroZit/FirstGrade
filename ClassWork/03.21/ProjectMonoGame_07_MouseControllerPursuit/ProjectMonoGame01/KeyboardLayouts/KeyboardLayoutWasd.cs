using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectMonoGame01.KeyboardLayouts
{
    public class KeyboardLayoutWasd
        : KeyboardLayout
    {
        public KeyboardLayoutWasd()
        {
            KeyActions = new List<KeyAction>();
            KeyActions.Add(new KeyAction(Keys.W, Direction.Up));
            KeyActions.Add(new KeyAction(Keys.A, Direction.Left));
            KeyActions.Add(new KeyAction(Keys.S, Direction.Down));
            KeyActions.Add(new KeyAction(Keys.D, Direction.Right));
        }
    }
}
