using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectMonoGame01.GameObjects;

namespace ProjectMonoGame01.Guns
{
    public class Bullet : GameObject
    {
        protected GameObject owner;
        public Bullet(Texture2D texture, GameObject owner) : base(texture)
        {
            this.owner = owner;
        }
    }
}
