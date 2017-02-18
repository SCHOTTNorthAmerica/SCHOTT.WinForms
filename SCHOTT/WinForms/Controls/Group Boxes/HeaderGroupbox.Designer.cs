namespace SCHOTT.WinForms.Controls.Group_Boxes
{
    partial class HeaderGroupbox
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.headerBox = new System.Windows.Forms.GroupBox();
            this.headerTable = new System.Windows.Forms.TableLayoutPanel();
            this.headerImage = new System.Windows.Forms.PictureBox();
            this.headerCheckbox = new System.Windows.Forms.CheckBox();
            this.headerLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.headerSpacer = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.headerBox.SuspendLayout();
            this.headerTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerImage)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.AutoSize = true;
            this.groupBox5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox5.Controls.Add(this.headerBox);
            this.groupBox5.Controls.Add(this.tableLayoutPanel5);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(368, 52);
            this.groupBox5.TabIndex = 71;
            this.groupBox5.TabStop = false;
            // 
            // headerBox
            // 
            this.headerBox.AutoSize = true;
            this.headerBox.Controls.Add(this.headerTable);
            this.headerBox.Location = new System.Drawing.Point(6, -6);
            this.headerBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.headerBox.Name = "headerBox";
            this.headerBox.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.headerBox.Size = new System.Drawing.Size(149, 39);
            this.headerBox.TabIndex = 71;
            this.headerBox.TabStop = false;
            // 
            // headerTable
            // 
            this.headerTable.AutoSize = true;
            this.headerTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.headerTable.ColumnCount = 3;
            this.headerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.headerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.headerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.headerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.headerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.headerTable.Controls.Add(this.headerImage, 1, 0);
            this.headerTable.Controls.Add(this.headerLabel, 2, 0);
            this.headerTable.Controls.Add(this.headerCheckbox, 0, 0);
            this.headerTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerTable.Location = new System.Drawing.Point(3, 13);
            this.headerTable.Name = "headerTable";
            this.headerTable.RowCount = 1;
            this.headerTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.headerTable.Size = new System.Drawing.Size(143, 23);
            this.headerTable.TabIndex = 73;
            // 
            // headerImage
            // 
            this.headerImage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.headerImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.headerImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerImage.Location = new System.Drawing.Point(24, 3);
            this.headerImage.MinimumSize = new System.Drawing.Size(20, 2);
            this.headerImage.Name = "headerImage";
            this.headerImage.Size = new System.Drawing.Size(20, 17);
            this.headerImage.TabIndex = 5;
            this.headerImage.TabStop = false;
            // 
            // headerCheckbox
            // 
            this.headerCheckbox.AutoSize = true;
            this.headerCheckbox.Checked = true;
            this.headerCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.headerCheckbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerCheckbox.Location = new System.Drawing.Point(3, 3);
            this.headerCheckbox.Name = "headerCheckbox";
            this.headerCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.headerCheckbox.Size = new System.Drawing.Size(15, 17);
            this.headerCheckbox.TabIndex = 68;
            this.headerCheckbox.UseVisualStyleBackColor = true;
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerLabel.Location = new System.Drawing.Point(50, 3);
            this.headerLabel.Margin = new System.Windows.Forms.Padding(3);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(90, 17);
            this.headerLabel.TabIndex = 69;
            this.headerLabel.Text = "USB Connection";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.headerSpacer, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(362, 25);
            this.tableLayoutPanel5.TabIndex = 73;
            // 
            // headerSpacer
            // 
            this.headerSpacer.AutoSize = true;
            this.headerSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerSpacer.ForeColor = System.Drawing.SystemColors.Control;
            this.headerSpacer.Location = new System.Drawing.Point(3, 3);
            this.headerSpacer.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.headerSpacer.Name = "headerSpacer";
            this.headerSpacer.Size = new System.Drawing.Size(356, 13);
            this.headerSpacer.TabIndex = 73;
            this.headerSpacer.Text = "Filler Label";
            this.headerSpacer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HeaderGroupbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox5);
            this.Name = "HeaderGroupbox";
            this.Size = new System.Drawing.Size(368, 58);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.headerBox.ResumeLayout(false);
            this.headerBox.PerformLayout();
            this.headerTable.ResumeLayout(false);
            this.headerTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerImage)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox headerBox;
        private System.Windows.Forms.TableLayoutPanel headerTable;
        private System.Windows.Forms.PictureBox headerImage;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.CheckBox headerCheckbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label headerSpacer;
    }
}
