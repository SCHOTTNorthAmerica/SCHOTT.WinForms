using System;
using System.Drawing;
using System.Windows.Forms;

namespace SCHOTT.WinForms.Controls.TextBoxes
{
    /// <summary>
    /// A custom RichTextBox box with special write functions.
    /// </summary>
    public class AdvancedRichTextBox : RichTextBox
    {
        private int _lastLineLength;
        private string _waitingMessage = "";
        private int _waitingMessageIndex;

        private void CaretToEnd(bool scrollToCaret = true)
        {
            Select(Text.Length, 0);
            SelectionFont = Font;

            if (scrollToCaret)
            {
                ScrollToCaret();
            }
        }

        /// <summary>
        /// Clear the MessaAdvancedRichTextBox
        /// </summary>
        public void ClearMessages()
        {
            _lastLineLength = 0;
            _waitingMessage = "";
            _waitingMessageIndex = 0;
            _lastLineLength = 0;
            Clear();
        }
        
        /// <summary>
        /// Clear everything in the text box after the given msg.
        /// </summary>
        /// <param name="msg">Will clear everything in the message box after msg.</param>
        /// <returns>True = Found msg and clears after, False = msg not found.</returns>
        public bool ClearAfterString(string msg)
        {
            var index = Text.IndexOf(msg, StringComparison.Ordinal);

            if (index < 0)
                return false;

            _waitingMessage = "";
            _waitingMessageIndex = 0;

            Select(index, Text.Length - index);
            ReadOnly = false;
            SelectedText = "";
            ReadOnly = true;

            _lastLineLength = Text.LastIndexOf("\n", StringComparison.Ordinal);
            if (_lastLineLength + 1 == Text.Length)
            {
                _lastLineLength = Text.Substring(0, Text.Length - 1).LastIndexOf("\n", StringComparison.Ordinal) + 1;
            }
            else if (_lastLineLength < 0)
            {
                _lastLineLength = 0;
            }

            CaretToEnd();
            return true;
        }
        
        /// <summary>
        /// Write the line to the text box with the font options provided.
        /// </summary>
        /// <param name="msg">The message to write to the box.</param>
        /// <param name="bold">Bool for if the line will be printed in bold.</param>
        /// <param name="color">The color the line wil lbe printed in.</param>
        public void WriteLine(string msg = "", bool bold = false, Color? color = null)
        {
            _waitingMessage = "";
            _waitingMessageIndex = 0;
            _lastLineLength = Text.Length;

            AppendText($"{msg}{Environment.NewLine}");

            Select(_lastLineLength, msg.Length);
            SelectionFont = new Font(Font.FontFamily, Font.Size, bold ? FontStyle.Bold : FontStyle.Regular);
            SelectionColor = color ?? Color.Black;

            CaretToEnd();
        }

        /// <summary>
        /// Write a waiting message to the box with elipses.
        /// </summary>
        /// <param name="msg">The message to write to the box prior to the elipses.</param>
        /// <param name="count">The number of waiting messages that have been written.</param>
        /// <param name="referenceString">An extra message between the waiting label and the elipses.</param>
        /// <param name="bold">Bool for if the line will be printed in bold.</param>
        /// <param name="color">The color the line wil lbe printed in.</param>
        public void WriteWaitingMessage(string msg, int count, string referenceString = "", bool bold = false, Color? color = null)
        {
            if (msg != _waitingMessage)
            {
                _lastLineLength = Text.Length;
                _waitingMessage = msg;
                _waitingMessageIndex = Text.Length;
            }
            
            var dots = "•";
            for (var i = 0; i < count % 5; i++) { dots += "•"; }

            Select(_waitingMessageIndex, Text.Length - _waitingMessageIndex);
            ReadOnly = false;
            SelectedText = $"{msg}{referenceString}: {dots}";
            ReadOnly = true;

            Select(_lastLineLength, Text.Length - _lastLineLength);
            SelectionFont = new Font(Font.FontFamily, Font.Size, bold ? FontStyle.Bold : FontStyle.Regular);
            SelectionColor = color ?? Color.Black;

            CaretToEnd(false);
        }

        /// <summary>
        /// Clears the last line in the box, then writes a new message.
        /// </summary>
        /// <param name="msg">The line to write to the box.</param>
        /// <param name="bold">Bool for if the line will be printed in bold.</param>
        /// <param name="color">The color the line wil lbe printed in.</param>
        /// <param name="includeNewLine">Bool to define if a new line should be appended to the msg line.</param>
        public void WriteOverLine(string msg, bool bold = false, Color? color = null, bool includeNewLine = true)
        {
            _waitingMessage = "";
            _waitingMessageIndex = 0;

            Select(_lastLineLength, Text.Length - _lastLineLength);
            ReadOnly = false;
            SelectedText = "";
            ReadOnly = true;

            AppendText(includeNewLine ? $"{msg}{Environment.NewLine}" : msg);

            Select(_lastLineLength, msg.Length);
            SelectionFont = new Font(Font.FontFamily, Font.Size, bold ? FontStyle.Bold : FontStyle.Regular);
            SelectionColor = color ?? Color.Black;

            CaretToEnd(false);
        }
    }

}
