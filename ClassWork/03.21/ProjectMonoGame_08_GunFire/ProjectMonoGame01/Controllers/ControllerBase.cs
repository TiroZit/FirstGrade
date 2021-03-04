using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectMonoGame01.Events;
using ProjectMonoGame01.GameObjects;

namespace ProjectMonoGame01.Controllers
{
    public abstract class ControllerBase
    {
        public event EventFire Fire;
        protected GameObject slave;

        public void Attach(GameObject gameObject)
        {
            slave = gameObject;
        }

        public virtual void Update()
        {
            slave.Update();
        }
    }
}
