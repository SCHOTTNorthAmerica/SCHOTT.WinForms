using SCHOTT.Core.Threading;
using SCHOTT.Core.Utilities;
using SCHOTT.WinForms.Dialogs;
using System.Drawing;

namespace SCHOTT.Core.Extensions
{
    /// <summary>
    /// A class to support closing the SCHOTT Threaded Workers provided in this library and others.
    /// </summary>
    public static class ClosingWorkerExtensions
    {
        /// <summary>
        /// A function that blocks until all threads in the supplied closing worker are complete and closed.
        /// This function will display status in a persistent dialog.
        /// </summary>
        /// <param name="closingWorker">The ClosingWorker to perform the actions on.</param>
        public static void WaitForThreadsToCloseDialogOutput(this ClosingWorker closingWorker)
        {
            // run the closing worker until all child threads are closed
            ClosingInfo status;
            var cycles = 0;
            while ((status = closingWorker.ShutdownThreads()).ShutdownReady == false)
            {
                if (++cycles % 6 == 0)
                {
                    if (!CrossThreadDialogs.MessageBoxPersistentExists())
                    {
                        CrossThreadDialogs.MessageBoxPersistentCreate(new DialogConfiguration
                        {
                            Message = status.Message,
                            Title = "CV-LS Dashboard Closing Status",
                            ButtonIsVisible = false,
                            DialogWidth = 600,
                            MessageAlignment = ContentAlignment.MiddleLeft
                        });
                    }
                    else
                    {
                        CrossThreadDialogs.MessageBoxPersistentUpdateMessage(status.Message);
                    }
                }
                TimeFunctions.Wait(50);
            }

            CrossThreadDialogs.MessageBoxPersistentClose();
        }
    }
}
