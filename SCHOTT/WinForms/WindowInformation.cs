using System.Drawing;
using System.Windows.Forms;

namespace SCHOTT.WinForms
{
    /// <summary>
    /// A class for storing window information. This can be included in application settings objects to persist the window state.
    /// </summary>
    public class WindowInformation
    {
        /// <summary>
        /// Maximized/Minimized/Normal state of the window.
        /// </summary>
        public string WindowState { get; set; }

        /// <summary>
        /// Window Width
        /// </summary>
        public int WindowWidth { get; set; }

        /// <summary>
        /// Window Height
        /// </summary>
        public int WindowHeight { get; set; }

        /// <summary>
        /// Window Location
        /// </summary>
        public Point WindowPosition { get; set; }

        /// <summary>
        /// Create the windoWindowInformation object.
        /// </summary>
        public WindowInformation() { }

        /// <summary>
        /// Create the windoWindowInformation object with default settings.
        /// </summary>
        /// <param name="state">Maximized/Minimized/Normal state of the window.</param>
        /// <param name="width">Window Width</param>
        /// <param name="height">Window Height</param>
        /// <param name="position">Window Location</param>
        public WindowInformation(FormWindowState state, int width, int height, Point position)
        {
            WindowState = state.ToString();
            WindowHeight = height;
            WindowWidth = width;
            WindowPosition = position;
        }

        /// <summary>
        /// Store a forms window status into the windoWindowInformation object.
        /// </summary>
        /// <param name="fromForm">The form to save from.</param>
        public void SaveLocation(Form fromForm)
        {
            WindowState = fromForm.WindowState.ToString();

            // only update the window size and position if in normal mode
            if (WindowState == "Normal")
            {
                WindowWidth = fromForm.Width;
                WindowHeight = fromForm.Height;
                WindowPosition = fromForm.Location;
            }
        }

        /// <summary>
        /// Load the current windoWindowInformation object settings into the provided form
        /// </summary>
        /// <param name="intoForm"></param>
        public void LoadLocation(Form intoForm)
        {
            intoForm.Width = WindowWidth;
            intoForm.Height = WindowHeight;
            intoForm.Location = WindowPosition;
            intoForm.WindowState = WindowState == "Maximized" ? FormWindowState.Maximized : FormWindowState.Normal;
        }

    }
}
