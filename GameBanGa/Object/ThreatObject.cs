using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using GameBanGa.Functions;

namespace GameBanGa.Object
{
    class ThreatObject : BaseObject
    {
        public const int THREAT_WIDHT_SOLDIER = 100;
        public const int THREAT_HEIGHT_SOLDIER = 100;
        public const int THREAT_WIDHT_COMMAND = 200;
        public const int THREAT_HEIGHT_COMMAND = 200;
        public const int THREAT_WIDHT_BOSS = 300;
        public const int THREAT_HEIGHT_BOSS = 300;
        protected int x_value;
        protected int y_value;
        protected List<BulletObject> bullets;
        protected int energy;

        public ThreatObject()
        {
        }

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

        internal List<BulletObject> Bullets
        {
            get
            {
                return bullets;
            }

            set
            {
                bullets = value;
            }
        }

        public int Energy
        {
            get
            {
                return energy;
            }

            set
            {
                energy = value;
            }
        }

        public virtual void Refresh_Position()
        {
            this.rect.X = Common_Function.rand.Next(0, 1500);
            this.rect.Y = Common_Function.rand.Next(-Common_Function.SCREEN_HEIGHT, -this.rect.Height);
        }

        // khởi tạo vị trí của threat
        public virtual void Move(int screen_Width, int screen_Height)
        {
            this.rect.Y += y_value;
            if (this.rect.Y > Common_Function.SCREEN_HEIGHT)
            {
                this.Refresh_Position();
                this.Update_engergy();
            }

        }

        // tạo viên đạn cho threat
        public virtual void Init_bullet(BulletObject bullet, string path)
        {
            if (bullet != null)
            {
                bullet.Rect = new Rectangle(this.rect.X + this.rect.Width / 2 - BulletObject.BULLET_WIDTH_EGG / 2,
                    this.rect.Y + this.rect.Height, BulletObject.BULLET_WIDTH_EGG,
                    BulletObject.BULLET_HEIGHT_EGG);
                bullet.LoadImage(path);
                bullet.Type = BulletObject.BulletType.EGG;
                bullet.IsMove = true;
                bullets.Add(bullet);
            }
        }

        // vẽ và di chuyển viên đạn của threat
        public virtual void Make_Bullet(Bitmap des, int width_limit, int height_limit)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Show(Common_Function.g_screen);
                if (bullets[i].IsMove)
                {
                    bullets[i].BulletMove_Egg(width_limit, height_limit);
                }
                else
                {
                    bullets[i].Rect = new Rectangle(this.rect.X + this.rect.Width / 2 - BulletObject.BULLET_WIDTH_EGG / 2,
                  this.rect.Y + this.rect.Height, BulletObject.BULLET_WIDTH_EGG,
                  BulletObject.BULLET_HEIGHT_EGG);
                    bullets[i].IsMove = true;
                }
            }
        }

        // cập nhật lại năng lượng 
        public virtual void Update_engergy()
        {
            this.energy = 1;
        }

    }
}
