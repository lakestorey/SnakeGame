namespace SnakeGame
{
    partial class StartScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.startScreenTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // startScreenTimer
            // 
            this.startScreenTimer.Interval = 32;
            this.startScreenTimer.Tick += new System.EventHandler(this.startScreenTimer_Tick);
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Name = "StartScreen";
            this.Size = new System.Drawing.Size(468, 338);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.StartScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StartScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.StartScreen_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer startScreenTimer;
    }
}
