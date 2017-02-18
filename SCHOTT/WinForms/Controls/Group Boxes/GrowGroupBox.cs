using System;
using System.Windows.Forms;

namespace SCHOTT.WinForms.Controls.Group_Boxes
{
    /// <summary>
    /// A groupbox that can automatically size itself based on internal labels.
    /// </summary>
    public class GrowGroupbox : GroupBox
    {
        /// <summary>
        /// Create a new GrowGroupbox.
        /// </summary>
        public GrowGroupbox()
        {
            AutoSize = false;
        }

        /// <summary>
        /// Allows the GrowGroupbox to AutoSize.
        /// </summary>
        public sealed override bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }

        /// <summary>
        /// Force a resize on the GrowGroupbox.
        /// </summary>
        public void ResizeGroupBox()
        {
            foreach (Control c in Controls)
            {
                if (c is TableLayoutPanel)
                {
                    Height = c.Height + 35;
                }
            }
        }

        /// <summary>
        /// Add ResizeGroupBox to the base box.
        /// </summary>
        /// <param name="e">Event Args of the Resize Event</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ResizeGroupBox();
        }
    }

}
