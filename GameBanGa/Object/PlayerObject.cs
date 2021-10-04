using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameBanGa.Functions;
using System.Collections;
using System.Drawing;

namespace GameBanGa.Object
{
    class PlayerObject : BaseObject
    {
        public const int PLAYER_WIDTH = 100;
        public const int PLAYER_HEIGHT = 100;

        private int x_value;
        private int y_value;
        private bool left, right, down, up;
        private bool fire;
        private bool isRocket;
        private List<BulletObject> listBullet;

        public int X_value
        {
            get
            {
                return x_value;
            }

            set
            {
                x_value = value;
            }
        }

        public int Y_value
        {
            get
            {
                return y_value;
            }

            set
            {
                y_value = value;
            }
        }

        public bool LEFT
        {
            get
            {
                return left;
            }

            set
            {
                left = value;
            }
        }

        public bool RIGHT
        {
            get
            {
                return right;
            }

            set
            {
                right = value;
            }
        }

        public bool DOWN
        {
            get
            {
                return down;
            }

            set
            {
                down = value;
            }
        }

        public bool UP
        {
            get
            {
                return up;
            }

            set
            {
                up = value;
            }
        }

        public bool Fire
        {
            get
            {
                return fire;
            }

            set
            {
                fire = value;
            }
        }

        internal List<BulletObject> ListBullet
        {
            get
            {
                return listBullet;
            }

            set
            {
                listBullet = value;
            }
        }

        public bool IsRocket
        {
            get
            {
                return isRocket;
            }

            set
            {
                isRocket = value;
            }
        }

        public PlayerObject(int x, int y)
        {
            rect.X = x;
            rect.Y = y; 
            rect.Width = PLAYER_WIDTH;
            rect.Height = PLAYER_HEIGHT;
            x_value = PLAYER_WIDTH/2 ;
            y_value = PLAYER_HEIGHT /2;
            ListBullet = new List<BulletObject>();
        }

        public void HandleMove()
        {
            if (left)
            {
                if (rect.X > 0)
                    rect.X -= x_value;
            }
            if (right)
            {
                if (rect.X < Common_Function.SCREEN_WIDTH - rect.Width)
                    rect.X += x_value;
            }
            if (down)
            {
                if (rect.Y < Common_Function.SCREEN_HEIGHT - rect.Height)
                    rect.Y += y_value;
            }
            if (up)
            {
                if (rect.Y > 0)
                    rect.Y -= y_value;
            }
        }

        public void HandleFire()
        {
            if (fire)
            {
                BulletObject bullet = new BulletObject();
                if (!IsRocket)
                {
                    bullet.Type = BulletObject.BulletType.LASER;
                    bullet.Rect = new Rectangle(this.rect.X + this.rect.Width / 2 - BulletObject.BULLET_WIDTH_LASER/2,
                        this.rect.Y - BulletObject.BULLET_HEIGHT_LASER, 10, 20);
                    bullet.LoadImage(Common_Function.path + "Dan2.png");
                    bullet.IsMove = true;
                }
                else
                {
                    
                    bullet.Type = BulletObject.BulletType.ROCKET;
                    bullet.Rect = new Rectangle(this.rect.X + this.rect.Width / 2 - BulletObject.BULLET_WIDTH_ROCKET/2,
                        this.rect.Y - BulletObject.BULLET_HEIGHT_ROCKET, 30, 50);
                    bullet.LoadImage(Common_Function.path + "Rocket.png");
                    bullet.IsMove = true;
                }
                listBullet.Add(bullet);
                Console.WriteLine("List: " + listBullet.Count);
            }
            fire = false;
        }

    }
}
