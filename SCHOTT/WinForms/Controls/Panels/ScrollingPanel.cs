using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SCHOTT.WinForms.Controls.Panels
{
    /// <summary>
    /// A custom scroll panel that forces the scroll bar to be active.
    /// </summary>
    public class ScrollingPanel : Panel
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);

        /// <summary>
        /// Create a new ScrollingPanel.
        /// </summary>
        public ScrollingPanel()
        {
            ShowScrollBar(Handle, (int)ScrollBarDirection.SbVert, true);
        }

        private enum ScrollBarDirection
        {
            SbHorz = 0,
            SbVert = 1,
            SbCtl = 2,
            SbBoth = 3
        }

        /// <summary>
        /// Override the OnResize event to create the scroll bars.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            AdjustFormScrollbars();
            AdjustFormScrollbars();
        }

        /// <summary>
        /// Adjust the scroll bars.
        /// </summary>
        public void AdjustFormScrollbars()
        {
            AutoScroll = false;
            VerticalScroll.Visible = true;
            if (Controls.Count > 0)
            {
                AutoScrollMinSize = new Size(0, Controls[0].Height);
            }
            AutoScroll = true;
        }
    }

}
