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
    class Explosion : BaseObject
    {
        private int frame_x;
        private int frame_y;

        public Explosion()
        {
            frame_x = 0;
            frame_y = 0;
            this.rect.X = 0;
            this.rect.Y = 0;
            this.rect.Width = 0;
            this.rect.Height = 0;
            this.obj = null;
        }

        public void ShowAnimation(Bitmap des)
        {
            Common_Function.ApplyBitmap(obj, des, rect.X, rect.Y, frame_x, frame_y, this.rect.Width, this.rect.Height);
            frame_x += 100;
            if (frame_x == 800)
            {
                frame_x = 0;
                frame_y += 100;
                if (frame_y == 700)
                    frame_y = 0;
            }
            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 7; j++)
            //    {
            //        Common_Function.ApplyBitmap(obj, des, rect.X, rect.Y, frame_x, frame_y, this.rect.Width, this.rect.Height);
            //        frame_x += 100;
            //    }
            //    frame_x = 0;
            //    frame_y += 100;
            //}
            //frame_x = 0;
            //frame_y += 0;
        }

        public override void Show(Bitmap des)
        {
            Common_Function.ApplyBitmap(obj, des, rect.X, rect.Y, 0, 0, this.rect.Width*2, this.rect.Height*2);
        }



    }
}
