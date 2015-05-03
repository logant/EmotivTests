using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using Emotiv;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GH.Emotiv.Connect
{
    public class EmotivDataReadComponent : GH_Component
    {
        bool blink = false;
        bool lWink = false;
        bool rWink = false;
        bool lookingDown = false;
        bool lookingLeft = false;
        bool lookingRight = false;
        bool lookingUp = false;
        string clenchExtent = string.Empty;
        string eyebrowExtent = string.Empty;
        string lowerFace = string.Empty;
        string lowerFacePower = string.Empty;
        string smileExtent = string.Empty;
        string upperFace = string.Empty;
        string upperFacePower = string.Empty;

        public EmotivDataReadComponent()
            : base("EmotivData", "Emotiv",
                "Connect to a data stream from an Emotiv Epoch Headset",
                "Extra", "Subcategory")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Read", "R", "read data stream from an Emotiv Epoc headset", GH_ParamAccess.item, false);
            pManager.AddTextParameter("File Paht", "F", "File path to the emotiv stream", GH_ParamAccess.item, string.Empty);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {

            pManager.AddBooleanParameter("Blink", "Blink", "Capture blinks", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Left Wink", "lWink", "Capture left winks", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Right Wink", "rWink", "Capture right winks", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Looking Down", "lookDown", "Looking Down", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Looking Left", "lookLeft", "looking left", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Looking Right", "lookRight", "Looking Right", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Looking Up", "lookingUp", "Looking Up", GH_ParamAccess.item);
            pManager.AddTextParameter("Clench", "clench", "Clench", GH_ParamAccess.item);
            pManager.AddTextParameter("Eyebrow", "eyebrow", "eyebrow", GH_ParamAccess.item);
            pManager.AddTextParameter("lowerFace", "lowerFace", "lowerFace", GH_ParamAccess.item);
            pManager.AddTextParameter("lowerFacePower", "lowerPwr", "ower face power", GH_ParamAccess.item);
            pManager.AddTextParameter("Smile Extent", "smile", "Smile Extent", GH_ParamAccess.item);
            pManager.AddTextParameter("UpperFace", "upperFace", "UpperFace", GH_ParamAccess.item);
            pManager.AddTextParameter("UpperFacePower", "upperPwr", "Upper Face Power", GH_ParamAccess.item);

            //pManager.AddTextParameter("Test", "Test", "Test", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            bool read = false;
            string path = string.Empty;

            DA.GetData(0, ref read);
            DA.GetData(1, ref path);

            string test = "No read or no path";
            if (read && System.IO.File.Exists(path))
            {
                // Get the data
                XmlDocument xmlDoc = new XmlDocument();
                try
                {
                    string data = string.Empty;
                    byte[] buffer;
                    using (FileStream fsSource = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        XmlReader xR = XmlReader.Create(fsSource);
                        xmlDoc.Load(xR);
                        // Read the source file into a byte array. 
                        byte[] bytes = new byte[fsSource.Length];
                        int numBytesToRead = (int)fsSource.Length;
                        int numBytesRead = 0;
                        while (numBytesToRead > 0)
                        {
                            // Read may return anything from 0 to numBytesToRead. 
                            int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                            // Break when the end of the file is reached. 
                            if (n == 0)
                                break;

                            numBytesRead += n;
                            numBytesToRead -= n;
                        }
                        numBytesToRead = bytes.Length;
                        buffer = bytes;
                    }
                    //data = System.Text.Encoding.UTF8.GetString(buffer);
                    //System.Windows.Forms.MessageBox.Show(data.ToString());
                    //XmlTextReader reader = new XmlTextReader(
                    //xmlDoc.LoadXml(data);
                }
                catch (Exception ex)
                {
                    xmlDoc = null;
                    test = "Error: " + ex.Message;
                }
                if (xmlDoc != null)
                {
                    
                     // Get the button info
                    XmlNodeList stateNodes = xmlDoc.SelectNodes("Emotiv/State");
                    test = "Found " + stateNodes.Count.ToString() + " state nodes in the file";

                    foreach (XmlNode n in stateNodes)
                    {
                        string innerText = n.InnerText;
                        string[] textData = innerText.Split(new char[] { ':' });
                        if (textData.Count() == 2)
                        {
                            if (textData[0] == "Blink")
                                bool.TryParse(textData[1], out blink);
                            if (textData[0] == "Left Wink")
                                bool.TryParse(textData[1], out lWink);
                            if (textData[0] == "Right Wink")
                                bool.TryParse(textData[1], out rWink);
                            if (textData[0] == "Looking Down")
                                bool.TryParse(textData[1], out lookingDown);
                            if (textData[0] == "Looking Left")
                                bool.TryParse(textData[1], out lookingDown);
                            if (textData[0] == "Looking Right")
                                bool.TryParse(textData[1], out lookingDown);
                            if (textData[0] == "Looking Up")
                                bool.TryParse(textData[1], out lookingDown);
                            if (textData[0] == "Clench Extent")
                                clenchExtent = textData[1];
                            if (textData[0] == "Eyebrow Extent")
                                eyebrowExtent = textData[1];
                            if (textData[0] == "Lower Face Action")
                                lowerFace = textData[1];
                            if (textData[0] == "Lower Face Power")
                                lowerFacePower = textData[1];
                            if (textData[0] == "Smile Extent")
                                smileExtent = textData[1];
                            if (textData[0] == "Upper Face Action")
                                upperFace = textData[1];
                            if (textData[0] == "Upper Face Power")
                                upperFacePower = textData[1];
                        }
                    }
                }
            }

            DA.SetData(0, blink);
            DA.SetData(1, lWink);
            DA.SetData(2, rWink);
            DA.SetData(3, lookingDown);
            DA.SetData(4, lookingLeft);
            DA.SetData(5, lookingRight);
            DA.SetData(6, lookingUp);
            DA.SetData(7, clenchExtent);
            DA.SetData(8, eyebrowExtent);
            DA.SetData(9, lowerFace);
            DA.SetData(10, lowerFacePower);
            DA.SetData(11, smileExtent);
            DA.SetData(12, upperFace);
            DA.SetData(13, upperFacePower);
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("15622b12-e722-4971-9b4d-1ab666e337da"); }
        }
    }

    public class GHEmotivConnectComponent : GH_Component
    {
        List<string> results = new List<string>();
        static EmoEngine engine = null;
        static int update = 0;
        int blinkCount = 0;
        int leftWink = 0;
        int rightWink = 0;
        int noBlink = 0;
        bool keepRunning = false;
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public GHEmotivConnectComponent()
            : base("GH.Emotiv.Connect", "Connect",
                "Connect to an Emotiv Epoch Headset",
                "Extra", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Connect", "C", "Connect to the Emotiv Epoch", GH_ParamAccess.item, false);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Results", "R", "Results", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            bool connect = false;
            DA.GetData(0, ref connect);
            
            if (connect && keepRunning)
            {
                //DA.SetDataList(0, (new string[] {"testing"}).ToList());
                try
                {
                    if (engine == null)
                    {
                        engine = EmoEngine.Instance;
                        engine.EmoStateUpdated += new EmoEngine.EmoStateUpdatedEventHandler(emoEngine_EmoStateUpdated);
                        engine.Connect();
                        IntPtr eEvent = EdkDll.EE_EmoEngineEventCreate();
                        EdkDll.EE_EngineGetNextEvent(eEvent);
                        System.Threading.Thread.Sleep(100);
                        //DA.SetDataList(0, results);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error: \n" + ex.Message);
                }
            }
            else if (connect)
            {
                try
                {
                    if (engine == null)
                    {
                        engine = EmoEngine.Instance;
                        engine.EmoStateUpdated += new EmoEngine.EmoStateUpdatedEventHandler(emoEngine_EmoStateUpdated);
                        engine.Connect();
                        IntPtr eEvent = EdkDll.EE_EmoEngineEventCreate();
                        EdkDll.EE_EngineGetNextEvent(eEvent);
                        System.Threading.Thread.Sleep(200);
                        engine.ProcessEvents(100);
                        System.Threading.Thread.Sleep(2000);
                        //results.Add("EngineGetNumUser: " + engine.EngineGetNumUser().ToString());
                        //try
                        //{
                        //    Profile profile = engine.GetUserProfile(0);
                        //    results.Add("Profile: " + profile.GetHandle().ToString());
                        //}
                        //catch
                        //{
                        //    results.Add("Could not get user profile.");
                        //}
                        //engine.ProcessEvents();
                    }
                    //keepRunning = true;
                    engine.Disconnect();
                    engine = null;
                    DA.SetDataList(0, results);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error: \n" + ex.Message);
                }
            }
            else
            {
                blinkCount = 0;
                noBlink = 0;
                leftWink = 0;
                rightWink = 0;
            }
            //else
            //{
            //    keepRunning = false;
            //    try
            //    {
            //        engine.UserAdded -= new EmoEngine.UserAddedEventHandler(emoEngine_UserAdded);
            //        engine.EmoStateUpdated -= new EmoEngine.EmoStateUpdatedEventHandler(emoEngine_EmoStateUpdated);
            //        engine.UserRemoved -= new EmoEngine.UserRemovedEventHandler(engine_UserRemoved);
            //        engine.Disconnect();
            //        engine = null;
            //    }
            //    catch
            //    {
            //        engine = null;
            //    }
            //}

        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("{4ed51ae9-a39b-4b47-a226-f10f27e0903b}"); }
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
            EmoState es = e.emoState;
            results = new List<string>();
            if (es.ExpressivIsBlink())
            {
                blinkCount++;
            }
            else if (es.ExpressivIsLeftWink())
            {
                leftWink++;
               
            }
            else if (es.ExpressivIsRightWink())
            {
                rightWink++;
            }
            else
            {
                noBlink++;
            }
            results.Add("Blink " + blinkCount.ToString());
            results.Add("Left Blink " + leftWink.ToString());
            results.Add("Right Wink " + rightWink.ToString());
            results.Add("Not Blinking " + noBlink.ToString());
            results.Add("Excitement: " + es.AffectivGetEngagementBoredomScore().ToString());
            //update++;
            //results.Add("Update: " + update.ToString());
   
        }
    }
}
