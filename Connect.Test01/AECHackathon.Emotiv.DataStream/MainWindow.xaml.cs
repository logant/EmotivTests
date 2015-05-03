using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;
using Emotiv;

namespace AECHackathon.Emotiv.DataStream
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmoEngine engine;
        List<string> data;
        Thread dataThread;
        Thread formThread;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void openButton_Click_1(object sender, RoutedEventArgs e)
        {
            Connect();

        }

        public void Connect()
        {
            dataThread = new Thread(DataThread);
            dataThread.Start();
            
        }

        private void closeButton_Click_1(object sender, RoutedEventArgs e)
        {
            
            engine.UserAdded -= new EmoEngine.UserAddedEventHandler(emoEngine_UserAdded);
            engine.EmoStateUpdated -= new EmoEngine.EmoStateUpdatedEventHandler(emoEngine_EmoStateUpdated);
            engine.UserRemoved -= new EmoEngine.UserRemovedEventHandler(engine_UserRemoved);
            engine.Disconnect();
            Close();
        }

        private void DataThread(object data)
        {
            engine = EmoEngine.Instance;
            engine.EmoStateUpdated += new EmoEngine.EmoStateUpdatedEventHandler(emoEngine_EmoStateUpdated);
            engine.Connect();

            while (true)
            {
                engine.ProcessEvents(1000);
            }
        }

        void emoEngine_UserAdded(object sender, EmoEngineEventArgs e)
        {

        }

        void engine_UserRemoved(object sender, EmoEngineEventArgs e)
        {

        }

        void emoEngine_EmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
        {
            if (e.emoState.ExpressivIsEyesOpen())
                data.Add("Eyes Open");
            else if (e.emoState.ExpressivIsBlink())
                data.Add("Blink");
            else if (e.emoState.ExpressivIsLeftWink())
                data.Add("Left Wink");
            else if (e.emoState.ExpressivIsRightWink())
                data.Add("Right Wink");
            else
                data.Add("Normal State/No Eye Movement");
            dataListBox.ItemsSource = data;
        }
    }
}
