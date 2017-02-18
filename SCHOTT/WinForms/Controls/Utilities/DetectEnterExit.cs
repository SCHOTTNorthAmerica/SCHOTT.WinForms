using System.Windows.Forms;

namespace SCHOTT.WinForms.Controls.Utilities
{
    /// <summary>
    /// Class to detect when the mouse enters or exits a given control
    /// </summary>
    public class DetectEnterExit : IMessageFilter
    {
        /// <summary>
        /// The delegate for the ControlEnter event.
        /// </summary>
        /// <param name="control">The control that is entered.</param>
        public delegate void ControlEntered(Control control);

        /// <summary>
        /// Event to subscribe to when the control is entered.
        /// </summary>
        public event ControlEntered ControlEnter;

        /// <summary>
        /// The delegate for the ControlExit event.
        /// </summary>
        /// <param name="control">The control that is exited.</param>
        public delegate void ControlExited(Control control);

        /// <summary>
        /// Event to subscribe to when the control is exited.
        /// </summary>
        public event ControlExited ControlExit;

        private readonly Control _control;
        private bool _inPanel;

        /// <summary>
        /// Subsribe a control to events.
        /// </summary>
        /// <param name="control"></param>
        public DetectEnterExit(Control control)
        {
            _control = control;
            Application.AddMessageFilter(this);
        }

        private const int WmMousemove = 0x200;

        bool IMessageFilter.PreFilterMessage(ref Message m)
        {
            if (m.Msg != WmMousemove)
                return false;

            if (_control == null)
                return false;

            if (_control.RectangleToScreen(_control.ClientRectangle).Contains(Cursor.Position))
            {
                if (_inPanel)
                    return false;

                _inPanel = true;
                ControlEnter?.Invoke(_control);
            }
            else
            {
                if (!_inPanel)
                    return false;

                _inPanel = false;
                ControlExit?.Invoke(_control);
            }

            return false;
        }

    }
}
