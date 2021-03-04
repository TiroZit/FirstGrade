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
    public class KeyboardControllerRotate : ControllerBase
    {
        public override void Update()
        {
            float speed = 10.0f;
            Vector2 delta = new Vector2(0, 0);
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Left))
            {
                subject.Rotate(-4);
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                subject.Rotate(+4);
            }
            if (ks.IsKeyDown(Keys.Down))
            {
                delta.X = (float)(-speed * Math.Cos(subject.Angle));
                delta.Y = (float)(-speed * Math.Sin(subject.Angle));
            }
            if (ks.IsKeyDown(Keys.Up))
            {
                delta.X = (float)(+speed * Math.Cos(subject.Angle));
                delta.Y = (float)(+speed * Math.Sin(subject.Angle));
            }
            subject.Move(delta);
            base.Update();
        }
    }
}
