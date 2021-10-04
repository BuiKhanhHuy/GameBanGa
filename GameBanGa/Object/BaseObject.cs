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
    class BaseObject
    {
        protected Bitmap obj;
        protected Rectangle rect;

        public Bitmap Obj
        {
            get
            {
                return obj;
            }

            set
            {
                obj = value;
            }
        }

        public Rectangle Rect
        {
            get
            {
                return rect;
            }

            set
            {
                rect = value;
            }
        }
           
        public  BaseObject()
        {
            rect.X = 0;
            rect.Y = 0;
            obj = null;
        }

        public virtual bool LoadImage(string path)
        {

            obj = new Bitmap(path);
            if (obj != null)
                return true;
            return false;   
        }
        public virtual void Show(Bitmap des )
        {
            Common_Function.ApplyBitmap(obj, des, rect.X, rect.Y, 0, 0, this.rect.Width, this.rect.Height);
            
        }

    }
}
