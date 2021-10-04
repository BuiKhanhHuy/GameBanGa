using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBanGa.Object
{
    class BulletObject : BaseObject
    {
        public const int BULLET_WIDTH_LASER = 10;
        public const int BULLET_HEIGHT_LASER = 20;
        public const int BULLET_WIDTH_ROCKET = 30;
        public const int BULLET_HEIGHT_ROCKET = 50;
        public const int BULLET_WIDTH_EGG = 20;
        public const int BULLET_HEIGHT_EGG = 30;
        public const int BULLET_WIDTH_EGG_BOSS = 40;
        public const int BULLET_HEIGHT_EGG_BOSS = 50;
        private bool isMove;
        private BulletType type;

       public enum BulletType
        {
            LASER, ROCKET, EGG

        }

        public bool IsMove
        {
            get
            {
                return isMove;
            }

            set
            {
                isMove = value;
            }
        }

        public BulletType Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public BulletObject()
        {
            this.rect.X = 0;
            this.rect.Y = 0;
            this.rect.Width = 0;
            this.rect.Height = 0;
        }

        public void BulletMove(int screen_Width, int screen_Height)
        {
            this.rect.Y -= 40;
            if (this.rect.Y + this.rect.Height < 0) 
                this.isMove = false;
        }

        public void BulletMove_Egg(int width_limit, int height_limit)
        {
            this.rect.Y += 20;
            if(this.rect.Y > height_limit)
            {
                this.isMove = false;
            }
        }

        public void BulletMove_Egg_Boss(int width_limit, int height_limit)
        {
            this.rect.Y += 20;
            if (this.rect.Y > height_limit)
            {
                this.isMove = false;
            }
        }
    }
}
