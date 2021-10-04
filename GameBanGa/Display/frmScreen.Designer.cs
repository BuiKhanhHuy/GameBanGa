namespace GameBanGa.Display
{
    partial class frmScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrGameLoop = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrGameLoop
            // 
            this.tmrGameLoop.Enabled = true;
            this.tmrGameLoop.Interval = 30;
            this.tmrGameLoop.Tick += new System.EventHandler(this.tmrGameLoop_Tick);
            // 
            // frmScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmScreen";
            this.Load += new System.EventHandler(this.frmScreen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmScreen_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmScreen_KeyUp);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmScreen_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrGameLoop;
    }
}