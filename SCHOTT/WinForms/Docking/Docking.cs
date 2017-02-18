using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace SCHOTT.WinForms.Docking
{
    /// <summary>
    /// A class to perform docking operations.
    /// </summary>
    public class Docking
    {
        /// <summary>
        /// The dock panel to use for docking operations.
        /// </summary>
        public DockPanel DockingPanel;

        /// <summary>
        /// The MenuStrip to use for docking operations.
        /// </summary>
        public MenuStrip MenuStrip;

        /// <summary>
        /// The ParentForm that the DockingPanel belongs too.
        /// </summary>
        public Form ParentForm;

        /// <summary>
        /// The list of forms used in docking operations.
        /// </summary>
        public List<DockContent> DockedForms = new List<DockContent>();

        /// <summary>
        /// Create the new Docking object.
        /// </summary>
        /// <param name="parentForm">The ParentForm for docking operations.</param>
        /// <param name="dockingPanel">The DockPanel used for docking operations.</param>
        /// <param name="menuStrip">The MenuStrip to use for docking operations.</param>
        public Docking(Form parentForm, DockPanel dockingPanel, MenuStrip menuStrip)
        {
            ParentForm = parentForm;
            DockingPanel = dockingPanel;
            MenuStrip = menuStrip;
        }

        /// <summary>
        /// The string used for functions to report in docking settings files.
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public static string GetDockingString(DockContent form)
        {
            return $"{form.GetType()},{form.Text}";
        }
        
        private IDockContent GetContentFromPersistString(string persistString)
        {
            return DockedForms.FirstOrDefault(f => GetDockingString(f) == persistString);
        }

        /// <summary>
        /// Show a form in the Docking Panel.
        /// </summary>
        /// <param name="formName">The name to match in the DockedForms.</param>
        public void ShowDockedForm(string formName)
        {
            var form = DockedForms.Single(o => o.Text.Equals(formName));
            form.Show(DockingPanel);
        }

        /// <summary>
        /// Hide a form in the Docking Panel.
        /// </summary>
        /// <param name="formName">The name to match in the DockedForms.</param>
        public void HideDockedForm(string formName)
        {
            DockedForms.Single(o => o.Text.Equals(formName)).Close();
        }

        /// <summary>
        /// Add a form to the dock panel list.
        /// </summary>
        /// <param name="form">The name to match in the DockedForms.</param>
        public void AddForm(DockContent form)
        {
            DockedForms.Add(form);
        }

        /// <summary>
        /// Get a docked form from the list.
        /// </summary>
        /// <param name="formName">The name to match in the DockedForms.</param>
        /// <returns>The requested form from the list.</returns>
        public DockContent GetForm(string formName)
        {
            return DockedForms.Single(f => f.Text.Equals(formName));
        }

        /// <summary>
        /// Return list of all forms in object.
        /// </summary>
        /// <returns>List of all forms in object.</returns>
        public List<DockContent> GetAllForms()
        {
            return DockedForms;
        }

        /// <summary>
        /// Hide all forms in the list.
        /// </summary>
        public void HideAllForms()
        {
            DockedForms.ToList().ForEach(form => {
                form.Close();
            });
        }

        /// <summary>
        /// Save the current layout to the layout file.
        /// </summary>
        public void SaveLayout()
        {
            DockingPanel.SaveAsXml(Path.GetDirectoryName(Application.ExecutablePath) + "\\Settings\\ApplicationLayout.xml");
        }

        /// <summary>
        /// Undock all forms form the DockPanel.
        /// </summary>
        public void UndockAll()
        {
            Cursor.Current = Cursors.WaitCursor;
            DockedForms.ForEach(form => {
                form.DockPanel = null;
            });
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Reset all forms to the document section of the DockPanel.
        /// </summary>
        public void ResetLayout()
        {
            Cursor.Current = Cursors.WaitCursor;
            UndockAll();
            DockedForms.ForEach(form => {
                form.Show(DockingPanel, DockState.Document);
            });
            Cursor.Current = Cursors.Default;
        }
        
        /// <summary>
        /// Load the forms layout from the settings file.
        /// </summary>
        /// <param name="filename">A filename to load the layout from.</param>
        /// <returns></returns>
        public bool LoadLayout(string filename = "ApplicationLayout.xml")
        {
            filename = Path.GetDirectoryName(Application.ExecutablePath) + "\\Settings\\" + filename;
            if (!File.Exists(filename))
                return false;

            using (var fs = new FileStream(filename, FileMode.Open))
            {
                LoadLayout(fs);
            }

            return true;
        }

        /// <summary>
        /// Load the forms layout from the stream.
        /// </summary>
        /// <param name="filestream">A stream to load the layout from.</param>
        public void LoadLayout(Stream filestream)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            try
            {
                UndockAll();
                Application.DoEvents();
                DockingPanel.LoadFromXml(filestream, GetContentFromPersistString, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Load Layout Exception!");
                Console.WriteLine(ex.ToString());
            }

            Application.DoEvents();
            DockedForms.Where(f => f.IsHidden == false).ToList().ForEach(o => o.Show());
            Cursor.Current = Cursors.Default;
        }

    }
}
