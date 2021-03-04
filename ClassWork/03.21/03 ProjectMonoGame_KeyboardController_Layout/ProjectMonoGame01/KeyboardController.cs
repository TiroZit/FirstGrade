using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectMonoGame01.KeyboardLayouts;

namespace ProjectMonoGame01
{
    public class KeyboardController
    {
        protected KeyboardLayout layout;
        protected GameObject slave;

        public void ChangeKeyboardLayout(KeyboardLayout layout)
        {
            this.layout = layout;
        }

        public KeyboardController()
        {
            layout = new KeyboardLayoutArrows();
        }

        public KeyboardController(KeyboardLayout layout)
        {
            this.layout = layout;
        }

        public void Attach(GameObject gameObject)
        {
            slave = gameObject;
        }

        public void Update()
        {
            float speed = 2.5f;
            Vector2 delta = new Vector2(0, 0);
            // управление с клавиатуры
            KeyboardState ks = Keyboard.GetState();
            foreach (var item in layout.KeyActions)
            {
                if (ks.IsKeyDown(item.Key))
                {
                    switch (item.Direction)
                    {
                        case Direction.Left:
                            delta.X = -speed;
                            break;
                        case Direction.Right:
                            delta.X = +speed;
                            break;
                        case Direction.Up:
                            delta.Y = -speed;
                            break;
                        case Direction.Down:
                            delta.Y = +speed;
                            break;
                    }
                }
            }
            slave.Move(delta);
            slave.Update();
        }
    }
}
