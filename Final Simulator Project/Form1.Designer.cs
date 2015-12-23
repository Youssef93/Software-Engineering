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
            this.AndGate_PictureBox = new System.Windows.Forms.PictureBox();
            this.AndGate_PictureBox2 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new Final_Simulator_Project.MyPanel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AndGate_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AndGate_PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AndGate_PictureBox);
            this.groupBox1.Controls.Add(this.AndGate_PictureBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 420);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "gates";
            // 
            // AndGate_PictureBox
            // 
            this.AndGate_PictureBox.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.AndGate_PictureBox.Location = new System.Drawing.Point(6, 19);
            this.AndGate_PictureBox.Name = "AndGate_PictureBox";
            this.AndGate_PictureBox.Size = new System.Drawing.Size(100, 50);
            this.AndGate_PictureBox.TabIndex = 1;
            this.AndGate_PictureBox.TabStop = false;
            this.AndGate_PictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.AndGate_PictureBox.MouseHover += new System.EventHandler(this.AndGate_PictureBox_MouseHover);
            this.AndGate_PictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.AndGate_PictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            this.AndGate_PictureBox.ParentChanged += new System.EventHandler(this.AndGate_PictureBox_ParentChanged);
            // 
            // AndGate_PictureBox2
            // 
            this.AndGate_PictureBox2.Location = new System.Drawing.Point(6, 19);
            this.AndGate_PictureBox2.Name = "AndGate_PictureBox2";
            this.AndGate_PictureBox2.Size = new System.Drawing.Size(100, 50);
            this.AndGate_PictureBox2.TabIndex = 2;
            this.AndGate_PictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(172, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 396);
            this.panel1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 647);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AndGate_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AndGate_PictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox AndGate_PictureBox;
        private System.Windows.Forms.PictureBox AndGate_PictureBox2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private MyPanel panel1;
    }
}

