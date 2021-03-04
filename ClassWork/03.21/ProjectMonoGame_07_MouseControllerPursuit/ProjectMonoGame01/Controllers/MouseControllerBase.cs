using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace ProjectMonoGame01.Controllers
{
    public abstract class MouseControllerBase : ControllerBase
    {
        protected MouseState ms;
        public override void Update()
        {
            if (slave == null) return;
            ms = Mouse.GetState();

            base.Update();
        }
    }
}
