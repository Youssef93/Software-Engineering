namespace Final_Simulator_Project
{
    partial class AndGateContainer
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
            this.selectionRectangle1 = new Final_Simulator_Project.SelectionRectangle();
            this.selectionRectangle2 = new Final_Simulator_Project.SelectionRectangle();
            this.selectionRectangle3 = new Final_Simulator_Project.SelectionRectangle();
            this.SuspendLayout();
            // 
            // selectionRectangle1
            // 
            this.selectionRectangle1.BackColor = System.Drawing.Color.LightBlue;
            this.selectionRectangle1.Location = new System.Drawing.Point(38, 35);
            this.selectionRectangle1.Name = "selectionRectangle1";
            this.selectionRectangle1.Size = new System.Drawing.Size(150, 150);
            this.selectionRectangle1.TabIndex = 0;
            // 
            // selectionRectangle2
            // 
            this.selectionRectangle2.BackColor = System.Drawing.Color.LightBlue;
            this.selectionRectangle2.Location = new System.Drawing.Point(4, 35);
            this.selectionRectangle2.Name = "selectionRectangle2";
            this.selectionRectangle2.Size = new System.Drawing.Size(150, 150);
            this.selectionRectangle2.TabIndex = 1;
            // 
            // selectionRectangle3
            // 
            this.selectionRectangle3.BackColor = System.Drawing.Color.LightBlue;
            this.selectionRectangle3.Location = new System.Drawing.Point(38, -121);
            this.selectionRectangle3.Name = "selectionRectangle3";
            this.selectionRectangle3.Size = new System.Drawing.Size(150, 150);
            this.selectionRectangle3.TabIndex = 2;
            // 
            // AndGateContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selectionRectangle3);
            this.Controls.Add(this.selectionRectangle2);
            this.Controls.Add(this.selectionRectangle1);
            this.Name = "AndGateContainer";
            this.Load += new System.EventHandler(this.Container_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AndGateContainer_MouseClick);
            this.MouseEnter += new System.EventHandler(this.AndGateContainer_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.AndGateContainer_MouseLeave);
            this.MouseHover += new System.EventHandler(this.AndGateContainer_MouseHover);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AndGateContainer_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private SelectionRectangle selectionRectangle1;
        private SelectionRectangle selectionRectangle2;
        private SelectionRectangle selectionRectangle3;
    }
}
