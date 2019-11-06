namespace EcosytemGamesCS
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.moveLeftTmr = new System.Windows.Forms.Timer(this.components);
            this.lion = new System.Windows.Forms.PictureBox();
            this.moveRightTmr = new System.Windows.Forms.Timer(this.components);
            this.moveUpTmr = new System.Windows.Forms.Timer(this.components);
            this.moveDownTmr = new System.Windows.Forms.Timer(this.components);
            this.moveLapinTmr = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lion)).BeginInit();
            this.SuspendLayout();
            // 
            // moveLeftTmr
            // 
            this.moveLeftTmr.Interval = 5;
            this.moveLeftTmr.Tick += new System.EventHandler(this.moveLeftTmr_Tick);
            // 
            // lion
            // 
            this.lion.BackColor = System.Drawing.Color.Transparent;
            this.lion.Image = ((System.Drawing.Image)(resources.GetObject("lion.Image")));
            this.lion.Location = new System.Drawing.Point(584, 364);
            this.lion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lion.Name = "lion";
            this.lion.Size = new System.Drawing.Size(92, 63);
            this.lion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lion.TabIndex = 0;
            this.lion.TabStop = false;
            this.lion.Click += new System.EventHandler(this.lion_Click);
            // 
            // moveRightTmr
            // 
            this.moveRightTmr.Interval = 5;
            this.moveRightTmr.Tick += new System.EventHandler(this.moveRightTmr_Tick);
            // 
            // moveUpTmr
            // 
            this.moveUpTmr.Interval = 5;
            this.moveUpTmr.Tick += new System.EventHandler(this.moveUpTmr_Tick);
            // 
            // moveDownTmr
            // 
            this.moveDownTmr.Interval = 5;
            this.moveDownTmr.Tick += new System.EventHandler(this.moveDownTmr_Tick);
            // 
            // moveLapinTmr
            // 
            this.moveLapinTmr.Enabled = true;
            this.moveLapinTmr.Tick += new System.EventHandler(this.moveLapinTmr_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(1309, 804);
            this.Controls.Add(this.lion);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1327, 851);
            this.Name = "Form1";
            this.Text = "ECOSYSTEM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.lion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer moveLeftTmr;
        private System.Windows.Forms.PictureBox lion;
        private System.Windows.Forms.Timer moveRightTmr;
        private System.Windows.Forms.Timer moveUpTmr;
        private System.Windows.Forms.Timer moveDownTmr;
        private System.Windows.Forms.Timer moveLapinTmr;
    }
}

