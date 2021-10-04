using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GameBanGa.Functions
{
    class Common_Function
    {
        public const int SCREEN_WIDTH = 1600;
        public const int SCREEN_HEIGHT = 900;
        public static string path;
        public static Bitmap g_screen;
        public static Bitmap g_background;
        public static Random rand;
        private static int ground = 1;
        private static int level = 1;

        public static int Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }
        public static int Ground
        {
            get
            {
                return ground;
            }

            set
            {
                ground = value;
            }
        }

        // khởi tạo ban đầu
        public static void Init()
        {
            Common_Function.g_screen = new Bitmap(Common_Function.SCREEN_WIDTH, Common_Function.SCREEN_HEIGHT);
        }

        // load hình ảnh
        public static Bitmap LoadImage(string fileName)
        {
            Bitmap bitmap = new Bitmap(path + fileName);
            return bitmap;
        }

        // vẽ ảnh lên bitmap
        public static void ApplyBitmap(Bitmap src, Bitmap des, int x, int y, int x_bmp, int y_bmp, int width_bmp, int height_bmp)
        {
            Graphics g = Graphics.FromImage(des);
            g.DrawImage(src, x, y, new Rectangle(x_bmp, y_bmp, width_bmp, height_bmp),GraphicsUnit.Pixel);
            g.Dispose();
        }

        // kiểm tra va chạm
        public static bool ISCollision(Rectangle rect1, Rectangle rect2)
        {
            if (rect1.Left > rect2.Left && rect1.Left < rect2.Right)
            {
                if (rect1.Top > rect2.Top && rect1.Top < rect2.Bottom)
                {
                    return true;
                }
            }

            if (rect1.Left > rect2.Left && rect1.Left < rect2.Right)
            {
                if (rect1.Bottom > rect2.Top && rect1.Bottom < rect2.Bottom)
                {
                    return true;
                }
            }

            if (rect1.Right > rect2.Left && rect1.Right < rect2.Right)
            {
                if (rect1.Top > rect2.Top && rect1.Top < rect2.Bottom)
                {
                    return true;
                }
            }

            if (rect1.Right > rect2.Left && rect1.Right < rect2.Right)
            {
                if (rect1.Bottom > rect2.Top && rect1.Bottom < rect2.Bottom)
                {
                    return true;
                }
            }



            if (rect2.Left > rect1.Left && rect2.Left < rect1.Right)
            {
                if (rect2.Top > rect1.Top && rect2.Top < rect1.Bottom)
                {
                    return true;
                }
            }

            if (rect2.Left > rect1.Left && rect2.Left < rect1.Right)
            {
                if (rect2.Bottom > rect1.Top && rect2.Bottom < rect1.Bottom)
                {
                    return true;
                }
            }

            if (rect2.Right > rect1.Left && rect2.Right < rect1.Right)
            {
                if (rect2.Top > rect1.Top && rect2.Top < rect1.Bottom)
                {
                    return true;
                }
            }

            if (rect2.Right > rect1.Left && rect2.Right < rect1.Right)
            {
                if (rect2.Bottom > rect1.Top && rect2.Bottom < rect1.Bottom)
                {
                    return true;
                }
            }

            if (rect1.Left == rect2.Left && rect1.Right == rect2.Right &&
                rect1.Top == rect2.Top && rect1.Bottom == rect2.Bottom)
                return true;
            return false;
        }

        // giải phóng
        public static void CleanUp()
        {
            g_background = null;
        }
    }
}
