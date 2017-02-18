using System.Windows.Forms;

namespace SCHOTT.WinForms.Dialogs
{
    /// <summary>
    /// A class to provide common dialogs from non gui threads. The user must set the ParentForm before dialogs can be displayed.
    /// </summary>
    public static class CrossThreadDialogs
    {
        private static Form _parentForm;

        /// <summary>
        /// Initialize CrossThreadDialogs for use.
        /// </summary>
        /// <param name="parentForm">ParentForm to use for syncing the GUI calls for forms.</param>
        public static void InitializeDialogs(Form parentForm)
        {
            _parentForm = parentForm;
        }

        private static CustomDialogBox _persistentDialog;

        /// <summary>
        /// Function to see if a persistent message box has been created.
        /// </summary>
        /// <returns>True = Persistent Message Box Exists</returns>
        public static bool MessageBoxPersistentExists()
        {
            return _persistentDialog != null;
        }

        private delegate void MessageBoxPersistentCreateCallback(DialogConfiguration configuration);

        /// <summary>
        /// Create a persistent message box. This is used when the application needs to update information on the dialog over time.
        /// will replace any existing persistent message box.
        /// </summary>
        /// <param name="configuration">The configuration of the message box.</param>
        public static void MessageBoxPersistentCreate(DialogConfiguration configuration)
        {
            if (_parentForm == null)
                return;

            if (_parentForm.InvokeRequired)
            {
                _parentForm.Invoke(new MessageBoxPersistentCreateCallback(MessageBoxPersistentCreate), configuration);
            }
            else
            {
                MessageBoxPersistentClose();
                _persistentDialog = new CustomDialogBox(_parentForm, configuration);
                _persistentDialog.Show();
            }
        }

        private delegate void MessageBoxPersistentUpdateMessageCallback(string newMessage);

        /// <summary>
        /// Update the message displayed in the current persistent message box.
        /// </summary>
        /// <param name="newMessage">Updated message to display.</param>
        public static void MessageBoxPersistentUpdateMessage(string newMessage)
        {
            if (_parentForm == null || _persistentDialog == null)
                return;

            if (_parentForm.InvokeRequired)
            {
                _parentForm.Invoke(new MessageBoxPersistentUpdateMessageCallback(MessageBoxPersistentUpdateMessage), newMessage);
            }
            else
            {
                _persistentDialog.MessageText = newMessage;
            }
        }

        private delegate void MessageBoxPersistentCloseCallback();

        /// <summary>
        /// Close any open persistent message boxes.
        /// </summary>
        public static void MessageBoxPersistentClose()
        {
            if (_parentForm == null || _persistentDialog == null)
                return;

            if (_parentForm.InvokeRequired)
            {
                _parentForm.Invoke(new MessageBoxPersistentCloseCallback(MessageBoxPersistentClose));
            }
            else
            {
                if (_persistentDialog == null)
                    return;

                _persistentDialog.Close();
                _persistentDialog = null;
            }
        }

        private delegate DialogResult MessageBoxBlockingCallback(DialogConfiguration configuration);

        /// <summary>
        /// Create a blocking message box. Will wait for user input to continue execution.
        /// </summary>
        /// <param name="configuration">The configuration for the message box.</param>
        /// <returns>User results.</returns>
        public static DialogResult MessageBoxBlocking(DialogConfiguration configuration)
        {
            if (_parentForm == null)
                return DialogResult.Cancel;

            if (_parentForm.InvokeRequired)
            {
                return (DialogResult)_parentForm.Invoke(new MessageBoxBlockingCallback(MessageBoxBlocking), configuration);
            }

            var dialog = new CustomDialogBox(_parentForm, configuration);
            configuration.Result = dialog.ShowDialog();
            configuration.ResultUserInput = dialog.ResultText;
            return configuration.Result;
        }

        private delegate void MessageBoxNonBlockingCallback(DialogConfiguration configuration);

        /// <summary>
        /// Create a non blocking message box. 
        /// </summary>
        /// <param name="configuration">The configuration for the message box.</param>
        public static void MessageBoxNonBlocking(DialogConfiguration configuration)
        {
            if (_parentForm == null)
                return;

            if (_parentForm.InvokeRequired)
            {
                _parentForm.Invoke(new MessageBoxNonBlockingCallback(MessageBoxNonBlocking), configuration);
            }
            else
            {
                new CustomDialogBox(_parentForm, configuration).Show();
                configuration.ResultUserInput = null;
            }
        }

        private delegate string OpenFilenameCallback(string filter);

        /// <summary>
        /// Opens a OpenFileDialog in a thread safe manner with the main form as the parent.
        /// </summary>
        /// <param name="filter">File type filter for the dialog.</param>
        /// <returns>Selected Filename if successful, empty string if failed.</returns>
        public static string OpenFilename(string filter = "All Files (*.*)|*.*")
        {
            if (_parentForm == null)
                return "";

            if (_parentForm.InvokeRequired)
            {
                return (string)_parentForm.Invoke(new OpenFilenameCallback(OpenFilename), filter);
            }

            var dialog = new OpenFileDialog {Filter = filter};
            return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : "";
        }

        private delegate string SaveAsFilenameCallback(string filter);

        /// <summary>
        /// Opens a SaveFileDialog in a thread safe manner with the main form as the parent.
        /// </summary>
        /// <param name="filter">File type filter for the dialog.</param>
        /// <returns>Selected Filename if successful, empty string if failed.</returns>
        public static string SaveAsFilename(string filter = "All Files (*.*)|*.*")
        {
            if (_parentForm == null)
                return "";

            if (_parentForm.InvokeRequired)
            {
                return (string)_parentForm.Invoke(new SaveAsFilenameCallback(SaveAsFilename), filter);
            }

            var dialog = new SaveFileDialog {Filter = filter};
            return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : "";
        }

    }
}
