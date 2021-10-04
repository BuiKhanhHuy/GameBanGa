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
    class BossThreaten:ThreatObject
    {
        public BossThreaten()
        {
            this.bullets = new List<BulletObject>();
            this.rect.X = 0;
            this.rect.Y = 0;
            this.rect.Width = ThreatObject.THREAT_WIDHT_BOSS;
            this.rect.Height =ThreatObject.THREAT_HEIGHT_BOSS;
            x_value = 40;
            y_value = 20;
            this.Energy = 200;
            this.obj = null; 
        }

        public override void Refresh_Position()
        {
            this.rect.X = Common_Function.SCREEN_WIDTH / 2 - this.rect.Width / 2;
            this.rect.Y = 0;
        }

        public override void Move(int screen_Width, int screen_Height)
        {
            this.rect.X += x_value;
            if (this.rect.X <= 0 || this.rect.Right >= Common_Function.SCREEN_WIDTH)
                x_value = -x_value;
        }

        public override void Init_bullet(BulletObject bullet, string path)
        {
            if (bullet != null)
            {
                bullet.Rect = new Rectangle(this.rect.X + this.rect.Width / 2 - BulletObject.BULLET_WIDTH_EGG / 2,
                    this.rect.Y + this.rect.Height, BulletObject.BULLET_WIDTH_EGG_BOSS,
                    BulletObject.BULLET_HEIGHT_EGG_BOSS);
                bullet.LoadImage(path);
                bullet.Type = BulletObject.BulletType.EGG;
                bullet.IsMove = true;
                bullets.Add(bullet);
            }
        }

        public override void Make_Bullet(Bitmap des, int width_limit, int height_limit)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Show(Common_Function.g_screen);
                if (bullets[i].IsMove)
                {
                    bullets[i].BulletMove_Egg_Boss(width_limit, height_limit);
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
        public override void Update_engergy()
        {
            this.energy = 200;
        }

    }
}
