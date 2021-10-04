using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameBanGa.Functions;
using GameBanGa.Object;

namespace GameBanGa.Display
{
    public partial class frmScreen : Form
    {
        private PlayerObject player;
        private Graphics graphic;
        private List<ThreatObject> threats;
        private Explosion explosion;
        private int threat_number = 0;

        public frmScreen()
        {
            InitializeComponent();
        }

        private void frmScreen_Load(object sender, EventArgs e)
        {
            Common_Function.Init();
            Common_Function.path = Application.StartupPath + @"\Images\";
            Common_Function.g_background = Common_Function.LoadImage("Background1.png");
            Common_Function.rand = new Random();
            // khởi tạo graphic cho from
            graphic = this.CreateGraphics();
            // player 
            player = new PlayerObject(700, 800);
            player.LoadImage(Common_Function.path + "PhiThuyen_1.png");
            // Threat
            threats = new List<ThreatObject>();
            // tạo threat
            Init_threat(1, 1);
            // vụ nổ
            explosion = new Explosion();
            explosion.LoadImage(Common_Function.path + "Explosion_2.bmp");
        }

        private void Init_threat(int round, int level)
        {
            threats.Clear();
            switch (level)
            {
                case 1:
                    threat_number = 6;
                    player.LoadImage(Common_Function.path + "PhiThuyen_" + round + ".png");
                    for (int i = 0; i < threat_number; i++)
                    {
                        BulletObject bullet = new BulletObject();
                        ThreatObject threat = new SoldierThreaten();
                        threat.Refresh_Position();
                        threat.LoadImage(Common_Function.path + "KeDich_" + round + level + ".png");
                        threat.Init_bullet(bullet, Common_Function.path + "egg_" + round + level + ".png");
                        threats.Add(threat);
                    }
                    break;
                case 2:
                    threat_number = 6;
                    player.LoadImage(Common_Function.path + "PhiThuyen_" + round + ".png");
                    for (int i = 0; i < threat_number; i++)
                    {
                        BulletObject bullet = new BulletObject();
                        ThreatObject threat = new CommandThreaten();
                        threat.Refresh_Position();
                        threat.LoadImage(Common_Function.path + "KeDich_" + round + level + ".png");
                        threat.Init_bullet(bullet,
                            Common_Function.path + "egg_" + round + level + ".png");
                        threats.Add(threat);
                    }
                    break;
                case 3:
                    threat_number = 1;
                    player.LoadImage(Common_Function.path + "PhiThuyen_" + round + ".png");
                    for (int i = 0; i < threat_number; i++)
                    {
                        BulletObject bullet = new BulletObject();
                        ThreatObject threat = new BossThreaten();
                        threat.Refresh_Position();
                        threat.LoadImage(Common_Function.path + "KeDich_" + round + level + ".png");
                        threat.Init_bullet(bullet,
                        Common_Function.path + "egg_" + round + level + ".png");
                        threats.Add(threat);
                    }
                    break;
            }
        }

        int pixel_bg = 13000;
        private void tmrGameLoop_Tick(object sender, EventArgs e)
        {
            // vẽ background
            pixel_bg -= 2;
            // chuyển level
            switch (pixel_bg)
            {
                case /*15000*/12800:
                    Init_threat(Common_Function.Ground, ++Common_Function.Level);
                    Console.Write("Chuyển level 2");
                    break;
                case /*10000*/12600:
                    Init_threat(Common_Function.Ground, ++Common_Function.Level);
                    Console.Write("Chuyển level 3");
                    break;
                case /*7000*/12400:
                    pixel_bg = 13000;
                    Common_Function.Level = 1;
                    Common_Function.Ground++;
                    Init_threat(Common_Function.Ground, Common_Function.Level);
                    Console.Write("Chuyển ground");
                    break;
            }
            this.Text = pixel_bg.ToString();
            Common_Function.ApplyBitmap(Common_Function.g_background, Common_Function.g_screen, 0, 0, 0, pixel_bg, 1600, 900);

            // vẽ playe5
            player.Show(Common_Function.g_screen);
            // Bắn đạn
            player.HandleFire();

            // kẻ địch
            for (int i = 0; i < threat_number; i++)
            {
                threats[i].Show(Common_Function.g_screen);
                threats[i].Move(Common_Function.SCREEN_WIDTH, Common_Function.SCREEN_HEIGHT);
                threats[i].Make_Bullet(Common_Function.g_screen, Common_Function.SCREEN_WIDTH, Common_Function.SCREEN_HEIGHT);
                // kiểm tra bullet của threat có chạm bullet của player không
                for (int j = 0; j < threats[i].Bullets.Count; j++)
                {
                    if (Common_Function.ISCollision(player.Rect, threats[i].Bullets[j].Rect))
                    {
                        Console.WriteLine("Ta trúng đạn của địch!");
                        //tmrGameLoop.Stop();
                    }
                    //for (int k = 0; k < player.ListBullet.Count; k++)
                    //{
                    //    if (Common_Function.ISCollision(threats[i].Bullets[j].Rect, player.ListBullet[k].Rect))
                    //    {
                    //        // đạn ta va chạm đạn địch
                    //        Console.WriteLine("Đạn của ta trúng đạn của địch.");
                    //        threats[i].Bullets[j].IsMove = false;
                    //        player.ListBullet[k].IsMove = false;

                    //    }
                    //}
                }
            }

            // vẽ và di chuyển đạn layer
            for (int i = 0; i < player.ListBullet.Count; i++)
            {
                if (player.ListBullet[i].IsMove)
                {
                    for (int j = 0; j < threats.Count; j++)
                    {
                        if (Common_Function.ISCollision(player.ListBullet[i].Rect, threats[j].Rect))
                        {
                            // đạn của ta trúng địch
                            // nếu là đạn laser trừ 1 năng lượng rocket trừ 4
                            if (player.ListBullet[i].Type == BulletObject.BulletType.LASER)
                                threats[j].Energy -= 1;
                            else
                                  if (player.ListBullet[i].Type == BulletObject.BulletType.ROCKET
                                )
                                threats[j].Energy -= 4;
                            player.ListBullet[i].IsMove = false;
                            Console.WriteLine("Ta bắn trúng địch! Năng lượng địch: " + threats[j].Energy);
                            // địch phát nổ
                            explosion.Rect = new Rectangle(player.ListBullet[i].Rect.X - 100,
                               player.ListBullet[i].Rect.Y - 100, 200, 200);
                            explosion.Show(Common_Function.g_screen);
                            if (threats[j].Energy <= 0)
                            {
                                threats[j].Refresh_Position();
                                // nếu địch chết sẽ cập nhật lại năng lượng
                                threats[j].Update_engergy();
                            }
                        }
                    }
                    player.ListBullet[i].Show(Common_Function.g_screen);
                    player.ListBullet[i].BulletMove(Common_Function.SCREEN_WIDTH, Common_Function.SCREEN_HEIGHT);
                }
                else
                {
                    player.ListBullet[i] = null;
                    player.ListBullet.RemoveAt(i);
                }
            }


            // kiểm tra va chạm với địch
            for (int i = 0; i < threats.Count; i++)
            {
                if (Common_Function.ISCollision(player.Rect, threats[i].Rect))
                {
                    // ta va chạm với địch
                    Console.WriteLine("Ta va chạm với địch");
                    //tmrGameLoop.Stop();
                }
            }

            // Nhận phím di chuyển
            player.HandleMove();
            // vẽ lại toàn bộ lên screen
            graphic.DrawImageUnscaled(Common_Function.g_screen, 0, 0);
        }

        // nhấn phím di chuyển
        private void frmScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                player.LEFT = true;
            }
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                player.RIGHT = true;
            }
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                player.UP = true;
            }
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                player.DOWN = true;
            }
        }

        // nhả phím để dừng di chuyển
        private void frmScreen_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                player.LEFT = false;
            }
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                player.RIGHT = false;
            }
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                player.UP = false;
            }
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                player.DOWN = false;
            }
        }

        // click chuột để bắn đạn
        private void frmScreen_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                player.Fire = true;
                Console.WriteLine("Fire: " + player.Fire);
            }
            else
                if (e.Button == MouseButtons.Right)
            {
                player.IsRocket = (player.IsRocket == false) ? true : false;
                Console.WriteLine("Rocket: " + player.IsRocket);
            }
        }

    }
}
