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
    public class Gun
    {
        protected Texture2D texBullet;
        protected GameObject owner;
        protected BulletsManager manager;
        public Gun(GameObject owner, BulletsManager bulletsManager)
        {
            this.owner = owner;
            this.manager = bulletsManager;
            texBullet = new Texture2D(GameConstants.Graphics.GraphicsDevice, 1, 1);
            texBullet.SetData<Color>(new Color[] { Color.White });
        }
        public void Fire(Vector2 target)
        {
            Vector2 v1 = owner.Position;
            Vector2 v2 = target;
            Vector2 v3 = v2 - v1;
            v3.Normalize();
            v3 *= 5;
            Bullet bullet = new Bullet(texBullet, owner);
            bullet.SetVelocity(v3.X, v3.Y);
            bullet.SetScale(10);
            bullet.Position = v1;
            manager.AddBullet(bullet);
        }
    }
}
