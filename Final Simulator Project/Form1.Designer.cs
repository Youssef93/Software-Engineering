namespace Final_Simulator_Project
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NorPictureBox_ = new System.Windows.Forms.PictureBox();
            this.OrPictureBox_ = new System.Windows.Forms.PictureBox();
            this.NotpictureBox2 = new System.Windows.Forms.PictureBox();
            this.AndGate_PictureBox2 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.Input_pictureBox = new System.Windows.Forms.PictureBox();
            this.Input_pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new Final_Simulator_Project.MyPanel();
            this.XOrPictureBox_ = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NorPictureBox_)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrPictureBox_)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotpictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AndGate_PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_pictureBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XOrPictureBox_)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.XOrPictureBox_);
            this.groupBox1.Controls.Add(this.NorPictureBox_);
            this.groupBox1.Controls.Add(this.OrPictureBox_);
            this.groupBox1.Controls.Add(this.NotpictureBox2);
            this.groupBox1.Controls.Add(this.AndGate_PictureBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 420);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "gates";
            // 
            // NorPictureBox_
            // 
            this.NorPictureBox_.Location = new System.Drawing.Point(6, 226);
            this.NorPictureBox_.Name = "NorPictureBox_";
            this.NorPictureBox_.Size = new System.Drawing.Size(100, 50);
            this.NorPictureBox_.TabIndex = 5;
            this.NorPictureBox_.TabStop = false;
            // 
            // OrPictureBox_
            // 
            this.OrPictureBox_.Location = new System.Drawing.Point(6, 158);
            this.OrPictureBox_.Name = "OrPictureBox_";
            this.OrPictureBox_.Size = new System.Drawing.Size(100, 50);
            this.OrPictureBox_.TabIndex = 4;
            this.OrPictureBox_.TabStop = false;
            // 
            // NotpictureBox2
            // 
            this.NotpictureBox2.Location = new System.Drawing.Point(6, 88);
            this.NotpictureBox2.Name = "NotpictureBox2";
            this.NotpictureBox2.Size = new System.Drawing.Size(100, 50);
            this.NotpictureBox2.TabIndex = 3;
            this.NotpictureBox2.TabStop = false;
            // 
            // AndGate_PictureBox2
            // 
            this.AndGate_PictureBox2.Location = new System.Drawing.Point(6, 19);
            this.AndGate_PictureBox2.Name = "AndGate_PictureBox2";
            this.AndGate_PictureBox2.Size = new System.Drawing.Size(100, 50);
            this.AndGate_PictureBox2.TabIndex = 2;
            this.AndGate_PictureBox2.TabStop = false;
            // 
            // Input_pictureBox
            // 
            this.Input_pictureBox.ImageLocation = "C:\\\\Users\\\\roman\\\\Documents\\\\Visual Studio 2015\\\\Projects\\\\Final Simulator Projec" +
    "t\\\\Final Simulator Project\\\\Gate Pictures\\\\Input.JPG";
            this.Input_pictureBox.Location = new System.Drawing.Point(39, 23);
            this.Input_pictureBox.Name = "Input_pictureBox";
            this.Input_pictureBox.Size = new System.Drawing.Size(74, 41);
            this.Input_pictureBox.TabIndex = 3;
            this.Input_pictureBox.TabStop = false;
            this.Input_pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Input_pictureBox_MouseDown);
            this.Input_pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Input_pictureBox_MouseMove);
            this.Input_pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Input_pictureBox_MouseUp);
            // 
            // Input_pictureBox2
            // 
            this.Input_pictureBox2.Location = new System.Drawing.Point(39, 23);
            this.Input_pictureBox2.Name = "Input_pictureBox2";
            this.Input_pictureBox2.Size = new System.Drawing.Size(74, 41);
            this.Input_pictureBox2.TabIndex = 4;
            this.Input_pictureBox2.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Input_pictureBox);
            this.groupBox2.Controls.Add(this.Input_pictureBox2);
            this.groupBox2.Location = new System.Drawing.Point(12, 505);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(119, 70);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(172, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 572);
            this.panel1.TabIndex = 4;
            // 
            // XOrPictureBox_
            // 
            this.XOrPictureBox_.Location = new System.Drawing.Point(6, 304);
            this.XOrPictureBox_.Name = "XOrPictureBox_";
            this.XOrPictureBox_.Size = new System.Drawing.Size(100, 50);
            this.XOrPictureBox_.TabIndex = 6;
            this.XOrPictureBox_.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 647);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NorPictureBox_)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrPictureBox_)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotpictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AndGate_PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_pictureBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XOrPictureBox_)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox AndGate_PictureBox2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private MyPanel panel1;
        private System.Windows.Forms.PictureBox Input_pictureBox2;
        private System.Windows.Forms.PictureBox Input_pictureBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox NotpictureBox2;
        private System.Windows.Forms.PictureBox OrPictureBox_;
        private System.Windows.Forms.PictureBox NorPictureBox_;
        private System.Windows.Forms.PictureBox XOrPictureBox_;
    }
}

