using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectMonoGame01.Guns;
using ProjectMonoGame01.GameObjects;

namespace ProjectMonoGame01.GameObjects
{
    public class Player : GameObject
    {
        protected Gun gun;
        public void Fire(GameObject source, Vector2 target)
        {
            gun.Fire(target);
        }
        public Player(Texture2D texture) : base(texture)
        {
            gun = new Gun(this, GameConstants.BulletsManager);
        }
    }
}
