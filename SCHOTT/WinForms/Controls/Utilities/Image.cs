using System.Drawing;
using System.Windows.Forms;

namespace SCHOTT.WinForms.Controls.Utilities
{
    /// <summary>
    /// Static class to provide functions for changing control images.
    /// </summary>
    public static class ControlImage
    {
        /// <summary>
        /// Update the background image of the picturebox.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="image"></param>
        public static void UpdatePictureBoxImage(PictureBox control, Image image)
        {
            control.Image = image;
            control.SizeMode = PictureBoxSizeMode.Zoom;
            control.BackColor = SystemColors.Control;
        }

    }
}
