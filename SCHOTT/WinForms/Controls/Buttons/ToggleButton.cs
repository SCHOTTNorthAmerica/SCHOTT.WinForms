using System.Drawing;
using System.Windows.Forms;

namespace SCHOTT.WinForms.Controls.Buttons
{
    /// <summary>
    /// A button with toggle functionality.
    /// </summary>
    public class ToggleButton : Button
    {
        /// <summary>
        /// The text to use when the button is in the enabled state.
        /// </summary>
        public string ToggleEnabledText { get; set; } = "Enabled";

        /// <summary>
        /// The color to use when the button is in the enabled state.
        /// </summary>
        public Color ToggleEnabledColor { get; set; } = SystemColors.Control;

        /// <summary>
        /// The text to use when the button is in the disabled state.
        /// </summary>
        public string ToggleDisabledText { get; set; } = "Disabled";

        /// <summary>
        /// The color to use when the button is in the disabled state.
        /// </summary>
        public Color ToggleDisabledColor { get; set; } = SystemColors.Control;

        /// <summary>
        /// A integer to store channel information in.
        /// </summary>
        public int Channel { get; set; }

        /// <summary>
        /// Enable the toggle button.
        /// </summary>
        /// <returns>Returns true to represent the button state.</returns>
        public bool ToggleEnable()
        {
            Text = ToggleEnabledText;
            if (ToggleEnabledColor != SystemColors.Control)
            {
                BackColor = ToggleEnabledColor;
            }
            return true;
        }

        /// <summary>
        /// Disable the toggle button.
        /// </summary>
        /// <returns>Returns false to represent the button state.</returns>
        public bool ToggleDisable()
        {
            Text = ToggleDisabledText;
            if (ToggleDisabledColor != SystemColors.Control)
            {
                BackColor = ToggleDisabledColor;
            }
            return false;
        }

        /// <summary>
        /// Toggle the current state of the button.
        /// </summary>
        /// <returns>Return the state of the button after the toggle.</returns>
        public bool Toggle()
        {
            return ToggleGet() ? ToggleDisable() : ToggleEnable();
        }

        /// <summary>
        /// Set the toggle to a particular state.
        /// </summary>
        /// <param name="enabled">The state to set.</param>
        /// <returns>Return the state of the button after the toggle.</returns>
        public bool ToggleSet(bool enabled)
        {
            return enabled ? ToggleEnable() : ToggleDisable();
        }

        /// <summary>
        /// Gets the current state of the toggle.
        /// </summary>
        /// <returns>The current state of the toggle.</returns>
        public bool ToggleGet()
        {
            if (ToggleEnabledColor != SystemColors.Control && ToggleDisabledColor != SystemColors.Control)
            {
                return BackColor == ToggleEnabledColor;
            }

            return Text == ToggleEnabledText;
        }
    }

}
