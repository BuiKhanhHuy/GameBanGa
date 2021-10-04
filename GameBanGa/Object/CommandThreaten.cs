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
    class CommandThreaten : ThreatObject
    {
        public CommandThreaten()
        {
            this.bullets = new List<BulletObject>();
            this.rect.X = 0;
            this.rect.Y = 0;
            this.rect.Width = ThreatObject.THREAT_WIDHT_COMMAND;
            this.rect.Height = ThreatObject.THREAT_HEIGHT_COMMAND;
            x_value = 10;
            y_value = 10;
            this.Energy = 4;
            this.obj = null;
        }

        // cập nhật lại năng lượng 
        public override void Update_engergy()
        {
            this.energy = 4;
        }

        // khởi tạo viên đạn cho commandThreaten
        public override void Init_bullet(BulletObject bullet, string path)
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

    }
}
