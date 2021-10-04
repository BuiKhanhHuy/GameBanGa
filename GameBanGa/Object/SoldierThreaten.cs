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
    class SoldierThreaten : ThreatObject
    {
        public SoldierThreaten()
        {
            this.bullets = new List<BulletObject>();
            this.rect.X = 0;
            this.rect.Y = 0;
            this.rect.Width = ThreatObject.THREAT_WIDHT_SOLDIER;
            this.rect.Height = ThreatObject.THREAT_HEIGHT_SOLDIER;
            x_value = 10;
            y_value = 10;
            this.Energy = 1;
            this.obj = null;
        }
    }
}
