using SCHOTT.WinForms.Controls.Buttons;
using SCHOTT.WinForms.Controls.Labels;

namespace SCHOTT.WinForms.Dialogs
{
    partial class CustomDialogBox
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
            this.ok = new FocusButton();
            this.textField = new System.Windows.Forms.TextBox();
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cancel = new FocusButton();
            this.Message = new GrowLabel();
            this.blankError = new GrowLabel();
            this.imagePanel = new System.Windows.Forms.Panel();
            this.mainLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.AutoSize = true;
            this.ok.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ok.BackColor = System.Drawing.Color.LimeGreen;
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Dock = System.Windows.Forms.DockStyle.Top;
            this.ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok.Location = new System.Drawing.Point(312, 80);
            this.ok.MinimumSize = new System.Drawing.Size(0, 30);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(300, 30);
            this.ok.TabIndex = 0;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = false;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // textField
            // 
            this.textField.AcceptsReturn = true;
            this.textField.AcceptsTab = true;
            this.mainLayoutPanel.SetColumnSpan(this.textField, 2);
            this.textField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textField.Location = new System.Drawing.Point(6, 54);
            this.textField.Name = "textField";
            this.textField.Size = new System.Drawing.Size(606, 20);
            this.textField.TabIndex = 0;
            this.textField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textField_KeyDown);
            this.textField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textField_KeyPress);
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.AutoSize = true;
            this.mainLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainLayoutPanel.ColumnCount = 3;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mainLayoutPanel.Controls.Add(this.cancel, 0, 4);
            this.mainLayoutPanel.Controls.Add(this.textField, 0, 3);
            this.mainLayoutPanel.Controls.Add(this.Message, 0, 0);
            this.mainLayoutPanel.Controls.Add(this.ok, 1, 4);
            this.mainLayoutPanel.Controls.Add(this.blankError, 0, 1);
            this.mainLayoutPanel.Controls.Add(this.imagePanel, 2, 0);
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.Padding = new System.Windows.Forms.Padding(3);
            this.mainLayoutPanel.RowCount = 5;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayoutPanel.Size = new System.Drawing.Size(725, 116);
            this.mainLayoutPanel.TabIndex = 3;
            // 
            // cancel
            // 
            this.cancel.AutoSize = true;
            this.cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancel.BackColor = System.Drawing.Color.Red;
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Dock = System.Windows.Forms.DockStyle.Top;
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.Location = new System.Drawing.Point(6, 80);
            this.cancel.MinimumSize = new System.Drawing.Size(0, 30);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(300, 30);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.BackColor = System.Drawing.SystemColors.Control;
            this.mainLayoutPanel.SetColumnSpan(this.Message, 2);
            this.Message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Message.Location = new System.Drawing.Point(6, 6);
            this.Message.Margin = new System.Windows.Forms.Padding(3);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(606, 13);
            this.Message.TabIndex = 3;
            this.Message.Text = "Message";
            this.Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // blankError
            // 
            this.blankError.AutoSize = true;
            this.blankError.BackColor = System.Drawing.SystemColors.Control;
            this.mainLayoutPanel.SetColumnSpan(this.blankError, 2);
            this.blankError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blankError.Location = new System.Drawing.Point(6, 25);
            this.blankError.Margin = new System.Windows.Forms.Padding(3);
            this.blankError.Name = "blankError";
            this.blankError.Size = new System.Drawing.Size(606, 13);
            this.blankError.TabIndex = 4;
            this.blankError.Text = "Text field cannot be left blank.";
            this.blankError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.blankError.Visible = false;
            // 
            // imagePanel
            // 
            this.imagePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagePanel.Location = new System.Drawing.Point(618, 6);
            this.imagePanel.Name = "imagePanel";
            this.mainLayoutPanel.SetRowSpan(this.imagePanel, 5);
            this.imagePanel.Size = new System.Drawing.Size(101, 104);
            this.imagePanel.TabIndex = 5;
            // 
            // CustomDialogBox
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(731, 127);
            this.ControlBox = false;
            this.Controls.Add(this.mainLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CustomDialogBox";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GraphTitle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formDialogBox_FormClosing);
            this.mainLayoutPanel.ResumeLayout(false);
            this.mainLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FocusButton ok;
        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private GrowLabel Message;
        private FocusButton cancel;
        private GrowLabel blankError;
        private System.Windows.Forms.TextBox textField;
        private System.Windows.Forms.Panel imagePanel;
    }
}