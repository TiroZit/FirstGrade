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
    public class KeyboardLayoutArrows 
        : KeyboardLayout
    {
        public KeyboardLayoutArrows()
        {
            KeyActions = new List<KeyAction>();
            KeyActions.Add(new KeyAction(Keys.Left,  Direction.Left));
            KeyActions.Add(new KeyAction(Keys.Right, Direction.Right));
            KeyActions.Add(new KeyAction(Keys.Up,    Direction.Up));
            KeyActions.Add(new KeyAction(Keys.Down,  Direction.Down));
        }
    }
}
