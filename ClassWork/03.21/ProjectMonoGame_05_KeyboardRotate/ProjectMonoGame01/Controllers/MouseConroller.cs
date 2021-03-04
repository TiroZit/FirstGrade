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
    public class MouseConroller : ControllerBase
    {
        public override void Update()
        {
            MouseState ms = Mouse.GetState();
            subject.SetPosition(ms.X, ms.Y);
            base.Update();
        }
    }
}
