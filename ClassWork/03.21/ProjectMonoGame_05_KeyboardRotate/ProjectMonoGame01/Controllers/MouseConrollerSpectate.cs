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
    public class MouseConrollerSpectate : ControllerBase
    {
        public override void Update()
        {
            MouseState ms = Mouse.GetState();
            Vector2 first = subject.Position;
            Vector2 second = new Vector2(ms.X, ms.Y);
            Vector2 target = second - first;
            float alpha = (float)Math.Atan2(target.Y, target.X);
            subject.Angle = alpha;
            base.Update();
        }
    }
}
