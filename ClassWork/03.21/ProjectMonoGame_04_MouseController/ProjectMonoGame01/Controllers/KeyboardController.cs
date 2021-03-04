using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using ProjectMonoGame01.Controllers;

namespace ProjectMonoGame01.Controllers
{
    public class KeyboardController : ControllerBase
    {
        public override void Update()
        {
            float speed = 10.0f;
            Vector2 delta = new Vector2(0, 0);
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Left))
            {
                delta.X = -speed;
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                delta.X = +speed;
            }
            if (ks.IsKeyDown(Keys.Down))
            {
                delta.Y = +speed;
            }
            if (ks.IsKeyDown(Keys.Up))
            {
                delta.Y = -speed;
            }
            subject.Move(delta);
            base.Update();
        }
    }
}
