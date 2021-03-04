using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectMonoGame01
{
    public class GameObject
    {
        // для корабля
        protected Texture2D texture;
        protected Vector2 position;
        protected Vector2 velocity;
        protected float scale;
        protected float angle;
        protected Vector2 origin;

        public float Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        public void Move(Vector2 delta)
        {
            position += delta;
        }

        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public void SetScale(float scale)
        {
            this.scale = scale;
        }

        public void Rotate(int degrees)
        {
            angle += (float)(degrees * (Math.PI / 180));
        }

        public void SetVelocity(float vx, float vy)
        {
            velocity.X = vx;
            velocity.Y = vy;
        }

        public void SetPosition(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }

        public GameObject(Texture2D texture)
        {
            this.texture = texture;
            position = new Vector2(0, 0);
            velocity = new Vector2(0f, 0f);
            scale = 1f;
            angle = 0;
            origin = new Vector2(
                texture.Width / 2,
                texture.Height / 2
                );
        }

        public void Update()
        {
            // физика прямолинейного движения
            position += velocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // spriteBatch.Draw(texSpaceship, position, Color.White);
            spriteBatch.Draw(
                texture, // картинка
                position, // координаты
                null, // прямоугольник - вырезание из картиника
                Color.White, // цвет смешивания
                angle, // угол поворота
                origin, // точка поворота
                scale, // коэф масшт
                SpriteEffects.None, // эффекты
                1 // слой
                );
        }
    }
}
