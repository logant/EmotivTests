using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Emotiv;
using System.Threading;
using System.Threading.Tasks;

namespace Connect.Test01
{
    class Program
    {
        EmoEngine engine;
        static string filePath = null;
        static void Main(string[] args)
        {
            try
            {
                if (args.Count() > 0)
                {
                    filePath = args[0];
                    if (File.Exists(filePath))
                    {
                        Program program = new Program();
                        program.mainLoop();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        void mainLoop()
        {
            engine = EmoEngine.Instance;
            engine.EmoStateUpdated += new EmoEngine.EmoStateUpdatedEventHandler(emoEngine_EmoStateUpdated);
            engine.Connect();

            while (true)
            {
                engine.ProcessEvents(100);
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
            EmoState es = e.emoState;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            sb.AppendLine("<Emotiv>");
            sb.AppendLine("\t<State>Blink:" + es.ExpressivIsBlink().ToString() + "</State>");
            sb.AppendLine("\t<State>Left Wink:" + es.ExpressivIsLeftWink().ToString() + "</State>");
            sb.AppendLine("\t<State>Right Wink:" + es.ExpressivIsLeftWink().ToString() + "</State>");
            sb.AppendLine("\t<State>Looking Down:" + es.ExpressivIsLookingDown().ToString() + "</State>");
            sb.AppendLine("\t<State>Looking Left:" + es.ExpressivIsLookingLeft().ToString() + "</State>");
            sb.AppendLine("\t<State>Looking Right:" + es.ExpressivIsLookingRight().ToString() + "</State>");
            sb.AppendLine("\t<State>Looking Up:" + es.ExpressivIsLookingUp().ToString() + "</State>");
            sb.AppendLine("\t<State>Clench Extent:" + es.ExpressivGetClenchExtent().ToString() + "</State>");
            sb.AppendLine("\t<State>Eyebrow Extent:" + es.ExpressivGetEyebrowExtent().ToString() + "</State>");
            //sb.AppendLine("\t<State>:" + es.ExpressivGetEyelidState().ToString() + "</State>");
            //sb.AppendLine("\t<State>:" + es.ExpressivGetEyeLocation().ToString() + "</State>");
            sb.AppendLine("\t<State>Lower Face Action:" + es.ExpressivGetLowerFaceAction().ToString() + "</State>");
            sb.AppendLine("\t<State>Lower Face Power:" + es.ExpressivGetLowerFaceActionPower().ToString() + "</State>");
            sb.AppendLine("\t<State>Smile Extent:" + es.ExpressivGetSmileExtent().ToString() + "</State>");
            sb.AppendLine("\t<State>Upper Face Action:" + es.ExpressivGetUpperFaceAction().ToString() + "</State>");
            sb.AppendLine("\t<State>Upper Face Power:" + es.ExpressivGetUpperFaceActionPower().ToString() + "</State>");
            sb.AppendLine("</Emotiv>");

            try
            {
                File.WriteAllText(filePath, sb.ToString());
            }
            catch { }
        }
    }
}
