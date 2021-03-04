using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectMonoGame01.Guns
{
    public class BulletsManager
    {
        protected List<Bullet> bullets;
        public BulletsManager()
        {
            bullets = new List<Bullet>();
        }
        public void AddBullet(Bullet bullet)
        {
            bullets.Add(bullet);
        }
        public void Update()
        {
            foreach (var b in bullets)
            {
                b.Update();
            }
        }
        public void Draw(SpriteBatch batch)
        {
            foreach (var b in bullets)
            {
                b.Draw(batch);
            }
        }
    }
}
