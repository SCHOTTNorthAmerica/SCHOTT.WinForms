
using System.Windows.Forms;

namespace SCHOTT.WinForms.Controls.Buttons
{
    /// <summary>
    /// A button that displays focus cues.
    /// </summary>
    public class FocusButton : Button
    {
        /// <summary>
        /// Display focus cues.
        /// </summary>
        protected override bool ShowFocusCues => true;
    }

}
