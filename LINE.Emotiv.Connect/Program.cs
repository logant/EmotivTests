using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Emotiv;
using SQLite = System.Data.SQLite;

namespace LINE.Emotiv.Connect
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

                    else
                    {
                        Program program = new Program();
                        program.mainLoop();
                    }
                }

                else
                {
                    string tempFilePath = typeof(Program).Assembly.Location;
                    FileInfo fi = new FileInfo(tempFilePath);
                    filePath = tempFilePath.Replace(fi.Name, "emotiv.db");
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

        void emoEngine_EmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
        {
            // Connect to the sqlite database
            DateTime time = DateTime.Now;
            if (!File.Exists(filePath))
                DBConnect();

            try
            {
                SQLite.SQLiteConnection db = new SQLite.SQLiteConnection("Data Source=" + filePath + ";Version=3;"); ;
                db.Open();

                EmoState es = e.emoState;

                int eBlink = 0;
                int eLWink = 0;
                int eRWink = 0;
                int eLookDown = 0;
                int eLookUp = 0;
                int eLookLeft = 0;
                int eLookRight = 0;
                double eClench = 0;
                double eEyebrow = 0;
                string eLFAction = string.Empty;
                double eLFPower = 0;
                string eUFAction = string.Empty ;
                double eUFPower = 0;
                double eSmile = 0;
                string cAction = "NEUTRAL";
                double cPower = 0;
                int cActive = 0;
                double aEngageBore = 0;
                double aExciteLong = 0;
                double aExciteShort = 0;
                double aFrustration = 0;
                double aMeditation = 0;
                double aValance = 0;
                
                try { eBlink = Convert.ToInt32(es.ExpressivIsBlink()); }
                catch { }
                try { eLWink = Convert.ToInt32(es.ExpressivIsLeftWink()); }
                catch { }
                try { eRWink = Convert.ToInt32(es.ExpressivIsRightWink()); }
                catch { }
                try { eLookDown = Convert.ToInt32(es.ExpressivIsLookingDown()); }
                catch { }
                try { eLookUp = Convert.ToInt32(es.ExpressivIsLookingUp()); }
                catch { }
                try { eLookLeft = Convert.ToInt32(es.ExpressivIsLookingLeft()); }
                catch { }
                try { eLookRight = Convert.ToInt32(es.ExpressivIsLookingRight()); }
                catch { }
                try { eClench = es.ExpressivGetClenchExtent(); }
                catch { }
                try { eEyebrow = es.ExpressivGetEyebrowExtent(); }
                catch { }
                try { eLFAction = es.ExpressivGetLowerFaceAction().ToString(); }
                catch { }
                try { eLFPower = es.ExpressivGetLowerFaceActionPower(); }
                catch { }
                try { eUFAction = es.ExpressivGetUpperFaceAction().ToString(); }
                catch { }
                try { eUFPower = es.ExpressivGetUpperFaceActionPower(); }
                catch { }
                try { eSmile = es.ExpressivGetSmileExtent(); }
                catch { }
                try { cAction = es.CognitivGetCurrentAction().ToString(); }
                catch { }
                try { cPower = es.CognitivGetCurrentActionPower(); }
                catch { }
                try { cActive = Convert.ToInt32(es.CognitivIsActive()); }
                catch { }
                try { aEngageBore = es.AffectivGetEngagementBoredomScore(); }
                catch { }
                try { aExciteLong = es.AffectivGetExcitementLongTermScore(); }
                catch { }
                try { aExciteShort = es.AffectivGetExcitementShortTermScore(); }
                catch { }
                try { aFrustration = es.AffectivGetFrustrationScore(); }
                catch { }
                try { aMeditation = es.AffectivGetMeditationScore(); }
                catch { }
                try { aValance = es.AffectivGetValenceScore(); }
                catch { }
                
                string data = string.Format("INSERT INTO emotiv (timestamp, expressivBlink, expressivLeftWink, expressivRightWink, expressivLookDown, expressivLookUp, expressivLookLeft, " +
                    "expressivLookRight, expressivClench, expressivEyebrow, expressivLowerFaceAction, expressivLowerFacePower, expressivUpperFaceAction, expressivUpperFacePower, " +
                    "expressivSmile, cognativAction, cognativPower, cognativActive, affectivEngageBore, affectivExciteLong, affectivExciteShort, affectivFrustration, affectivMeditation, affectivValance) " +
                    "VALUES ( '{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, '{10}', {11}, '{12}', {13}, {14}, '{15}', {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23})", time, eBlink, eLWink, eRWink,
                    eLookDown, eLookUp, eLookLeft, eLookRight, eClench, eEyebrow, eLFAction, eLFPower, eUFAction, eUFPower, eSmile, cAction, cPower, cActive, aEngageBore, aExciteLong, aExciteShort, aFrustration, aMeditation, aValance);

                SQLite.SQLiteCommand command = new SQLite.SQLiteCommand(data, db);
                command.ExecuteNonQuery();
                db.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        void DBConnect()
        {
            SQLite.SQLiteConnection connection = null;
            try
            {
                SQLite.SQLiteConnection.CreateFile(filePath);
                connection = new SQLite.SQLiteConnection("Data Source=" + filePath + ";Version=3;");
                connection.Open();
                SQLite.SQLiteCommand command = new SQLite.SQLiteCommand("CREATE TABLE emotiv (timestamp timestamp, expressivBlink boolean, expressivLeftWink boolean, expressivRightWink boolean, " +
                    "expressivLookDown boolean, expressivLookUp boolean, expressivLookLeft boolean, expressivLookRight boolean, expressivClench float, " +
                    "expressivEyebrow float, expressivLowerFaceAction varchar(100), expressivLowerFacePower float, expressivUpperFaceAction varchar(100), expressivUpperFacePower float, " +
                    "expressivSmile float, cognativAction varchar(100), cognativPower float, cognativActive boolean, affectivEngageBore float, affectivExciteLong float, " +
                    "affectivExciteShort float, affectivFrustration float, affectivMeditation float, affectivValance float);", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
