using System;
using System.Drawing;
using System.Windows.Forms;

namespace SCHOTT.WinForms.Controls.Labels
{
    /// <summary>
    /// A custom label that will chagne its size based on the text in the label.
    /// </summary>
    public class GrowLabel : Label
    {
        private bool _mGrowing;

        /// <summary>
        /// Create a new GrowLabel.
        /// </summary>
        public GrowLabel()
        {
            AutoSize = false;
        }

        /// <summary>
        /// Allow access to the base AutoSize event.
        /// </summary>
        public sealed override bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }

        /// <summary>
        /// Resize the label based on the text.
        /// </summary>
        public void ResizeLabel()
        {
            if (_mGrowing) return;
            try
            {
                _mGrowing = true;
                var sz = new Size(Width, int.MaxValue);
                sz = TextRenderer.MeasureText(Text, Font, sz, TextFormatFlags.WordBreak);
                Height = sz.Height;
            }
            finally
            {
                _mGrowing = false;
            }
        }

        /// <summary>
        /// Override the OnTextChanged to resize the label.
        /// </summary>
        /// <param name="e">Event Args</param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            ResizeLabel();
        }

        /// <summary>
        /// Override the OnFontChanged to resize the label.
        /// </summary>
        /// <param name="e">Event Args</param>
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            ResizeLabel();
        }

        /// <summary>
        /// Override the OnFontChangedOnSizeChanged to resize the label.
        /// </summary>
        /// <param name="e">Event Args</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ResizeLabel();
        }
    }

}
