using System;
using System.Drawing;
using System.Windows.Forms;

namespace SCHOTT.WinForms.Dialogs
{
    /// <summary>
    /// A custom dialog format for use with SCHOTT libraries.
    /// </summary>
    public partial class CustomDialogBox : Form
    {
        private readonly DialogResult _cancelResult;
        private readonly DialogResult _okResult;

        /// <summary>
        /// Create a custom dialog.
        /// </summary>
        /// <param name="ownerForm"></param>
        /// <param name="configuration"></param>
        public CustomDialogBox(Form ownerForm, DialogConfiguration configuration)
        {
            InitializeComponent();
            imagePanel.Visible = false;

            MessageAlignment = configuration.MessageAlignment;
            
            Owner = ownerForm;
            
            Text = configuration.Title;
            Message.Text = configuration.Message;
            Width = configuration.DialogWidth;

            if (configuration.UserEntryFieldIsVisible)
            {
                textField.Focus();
                textField.UseSystemPasswordChar = configuration.UserEntryFieldIsPassword;
            }
            else
            {
                ok.Select();
                textField.Visible = false;
                textField.Enabled = false;
            }

            if (configuration.ButtonIsVisible)
            {
                switch (configuration.ButtonOptions)
                {
                    case MessageBoxButtons.YesNo:
                        ok.Text = "Yes";
                        cancel.Text = "No";
                        _okResult = DialogResult.Yes;
                        _cancelResult = DialogResult.No;
                        break;

                    case MessageBoxButtons.OK:
                        ok.Text = "OK";
                        cancel.Visible = false;
                        mainLayoutPanel.SetCellPosition(ok, new TableLayoutPanelCellPosition(0, 4));
                        mainLayoutPanel.SetColumnSpan(ok, 2);
                        _okResult = DialogResult.OK;
                        _cancelResult = DialogResult.Cancel;
                        break;

                    case MessageBoxButtons.OKCancel:
                        _okResult = DialogResult.OK;
                        _cancelResult = DialogResult.Cancel;
                        break;

                    case MessageBoxButtons.RetryCancel:
                        ok.Text = "Retry";
                        _okResult = DialogResult.Retry;
                        _cancelResult = DialogResult.Cancel;
                        break;
                        
                    default:
                        break;
                }
            }
            else
            {
                mainLayoutPanel.RowStyles[4].SizeType = SizeType.Absolute;
                mainLayoutPanel.RowStyles[4].Height = 0;
            }
            
            foreach ( Control c in mainLayoutPanel.Controls)
            {
                c.Font = new Font(Owner.Font.FontFamily, Owner.Font.Size, 
                    c.Name == "blankError" ? FontStyle.Bold : FontStyle.Regular);
            }
            
            if (!configuration.UserEntryFieldIsPassword)
            {
                var height = textField.Height;
                textField.Multiline = true;
                textField.Height = height * (configuration.UserEntryFieldIsMultiline ? 6 : 1);
            }

            ResizeBox();

            if (configuration.DialogImage != null)
            {
                imagePanel.Visible = true;
                var ratio = configuration.DialogImage.Width / (double)configuration.DialogImage.Height;
                imagePanel.Width = Math.Min((int)(imagePanel.Height* ratio),400);
                imagePanel.BackgroundImage = configuration.DialogImage;
                Width += imagePanel.Width + 6;
                Height += mainLayoutPanel.Height + 6;
            }

            ResizeBox();
        }

        /// <summary>
        /// Form Title
        /// </summary>
        public sealed override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void ResizeBox()
        {
            Message.ResizeLabel();
            blankError.ResizeLabel();

            Height = mainLayoutPanel.Height + 40;
        }

        /// <summary>
        /// Text from the user input box.
        /// </summary>
        public string ResultText => textField.Text;

        /// <summary>
        /// The displayed message text.
        /// </summary>
        public string MessageText
        {
            get { return Message.Text; }
            set
            {
                Message.Text = value;
                ResizeBox();
            }
        }

        /// <summary>
        /// The displayed message alignment
        /// </summary>
        public ContentAlignment MessageAlignment
        {
            get { return Message.TextAlign; }
            set { Message.TextAlign = value; }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = _cancelResult;
            Close();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            DialogResult = _okResult;
            Close();
        }

        private void formDialogBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == _cancelResult || !textField.Visible || textField.Text.Length != 0)
                return;

            blankError.Visible = true;
            ResizeBox();
            e.Cancel = true;
        }

        private void textField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char) Keys.Tab && e.KeyChar != (char) Keys.Return)
                return;

            DialogResult = _okResult;
            e.Handled = true;
        }

        private void textField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Tab && e.KeyCode != Keys.Return)
                return;

            DialogResult = _okResult;
            e.Handled = true;
        }
    }

    /// <summary>
    /// Configuration object for the custom message box.
    /// </summary>
    public class DialogConfiguration
    {
        /// <summary>
        /// The dialog result.
        /// </summary>
        public DialogResult Result { get; set; }

        /// <summary>
        /// The string entered by the user.
        /// </summary>
        public string ResultUserInput { get; set; }

        /// <summary>
        /// The message to display.
        /// </summary>
        public string Message { get; set; } = "";

        /// <summary>
        /// The message title.
        /// </summary>
        public string Title { get; set; } = "";

        /// <summary>
        /// The message text alignment
        /// </summary>
        public ContentAlignment MessageAlignment { get; set; } = ContentAlignment.MiddleCenter;

        /// <summary>
        /// Bool for button visiblity.
        /// </summary>
        public bool ButtonIsVisible { get; set; } = true;

        /// <summary>
        /// Which button options to display.
        /// </summary>
        public MessageBoxButtons ButtonOptions { get; set; } = MessageBoxButtons.OK;

        /// <summary>
        /// User entry field is visible.
        /// </summary>
        public bool UserEntryFieldIsVisible { get; set; }

        /// <summary>
        /// User entry field allows multiline.
        /// </summary>
        public bool UserEntryFieldIsMultiline { get; set; }

        /// <summary>
        /// User entry field is for passwords (display astericks)
        /// </summary>
        public bool UserEntryFieldIsPassword { get; set; }

        /// <summary>
        /// The width of the dialog.
        /// </summary>
        public int DialogWidth { get; set; } = 500;

        /// <summary>
        /// The displayed image in the dialog.
        /// </summary>
        public Image DialogImage { get; set; }
    }

}