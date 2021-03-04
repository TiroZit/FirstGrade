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
    public class MouseControllerPursuit : MouseControllerWatch
    {
        protected bool isPursuit = false;
        public override void Update()
        {
            base.Update();

            if (ms.RightButton == ButtonState.Pressed)
            {
                isPursuit = true;
            }
            if (isPursuit)
            {
                Vector2 v = target / 10;
                slave.SetVelocity(v.X, v.Y);
                if (target.Length() <= 10)
                {
                    isPursuit = false;
                }
            }
        }
    }
}
