using SCHOTT.WinForms.Controls.Trackbar;

namespace SCHOTT.WinForms.Controls.Combo_Controls
{
    partial class SliderNumericCombo
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numeric = new System.Windows.Forms.NumericUpDown();
            this.slider = new SCHOTT.WinForms.Controls.Trackbar.PrettyTrack();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.numeric, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.slider, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(262, 26);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // numeric
            // 
            this.numeric.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numeric.AutoSize = true;
            this.numeric.DecimalPlaces = 1;
            this.numeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numeric.Location = new System.Drawing.Point(209, 3);
            this.numeric.Name = "numeric";
            this.numeric.Size = new System.Drawing.Size(50, 20);
            this.numeric.TabIndex = 12;
            this.numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // slider
            // 
            this.slider.BackColor = System.Drawing.Color.Transparent;
            this.slider.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.slider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slider.Location = new System.Drawing.Point(3, 3);
            this.slider.Maximum = 1000;
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size(200, 20);
            this.slider.TabIndex = 11;
            this.slider.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            // 
            // SliderNumericCombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SliderNumericCombo";
            this.Size = new System.Drawing.Size(262, 26);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown numeric;
        private PrettyTrack slider;
    }
}
