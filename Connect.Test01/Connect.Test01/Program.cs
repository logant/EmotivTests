using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emotiv;
using System.Threading;
using System.Threading.Tasks;

namespace Connect.Test01
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                EmoEngine emoEngine = EmoEngine.Instance;
                emoEngine.UserAdded += new EmoEngine.UserAddedEventHandler(emoEngine_UserAdded);
                emoEngine.EmoStateUpdated += new EmoEngine.EmoStateUpdatedEventHandler(emoEngine_EmoStateUpdated);
                emoEngine.UserRemoved += new EmoEngine.UserRemovedEventHandler(engine_UserRemoved);

                emoEngine.Connect();

                Thread.Sleep(15);
                Console.WriteLine("EngineGetNumUser: " + emoEngine.EngineGetNumUser().ToString());
                Profile profile = emoEngine.GetUserProfile(0);
                Console.WriteLine("Profile: " + profile.GetHandle());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void emoEngine_UserAdded(object sender, EmoEngineEventArgs e)
        {
            Console.WriteLine("Engine User added");

        }

        static void engine_UserRemoved(object sender, EmoEngineEventArgs e)
        {
        }

        static void emoEngine_EmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
        {
        }
    }
}
