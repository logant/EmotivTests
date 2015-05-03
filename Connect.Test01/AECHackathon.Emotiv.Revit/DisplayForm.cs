using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emotiv;

using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace AECHackathon.Emotiv.Revit
{
    public partial class DisplayForm : System.Windows.Forms.Form
    {
        EmoEngine engine = null;

        public DisplayForm()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            engine = EmoEngine.Instance;
            engine.UserAdded += new EmoEngine.UserAddedEventHandler(emoEngine_UserAdded);
            engine.EmoStateUpdated += new EmoEngine.EmoStateUpdatedEventHandler(emoEngine_EmoStateUpdated);
            engine.UserRemoved += new EmoEngine.UserRemovedEventHandler(engine_UserRemoved);
            engine.Connect();
            System.Threading.Thread.Sleep(100);
            engine.ProcessEvents(100);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            engine.UserAdded -= new EmoEngine.UserAddedEventHandler(emoEngine_UserAdded);
            engine.EmoStateUpdated -= new EmoEngine.EmoStateUpdatedEventHandler(emoEngine_EmoStateUpdated);
            engine.UserRemoved -= new EmoEngine.UserRemovedEventHandler(engine_UserRemoved);
            engine.Disconnect();

        }

        void emoEngine_UserAdded(object sender, EmoEngineEventArgs e)
        {

        }

        void engine_UserRemoved(object sender, EmoEngineEventArgs e)
        {

        }

        void emoEngine_EmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
        {
            label2.Text = e.emoState.ToString();
        }
    }
}
