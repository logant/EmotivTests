using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Parameters;
using Grasshopper.Kernel.Types;
using GH_IO;
using Rhino.Geometry;

namespace LINE.Emotiv.GH
{
    public class EmotivComponent : GH_Component
    {
        // Emotiv Parameters
        string time;
        bool eBlink;
        bool eLWink;
        bool eRWink;
        bool eLookDown;
        bool eLookUp;
        bool eLookLeft;
        bool eLookRight;
        double eClench;
        double eEyebrow;
        string eLFAction;
        double eLFPower;
        string eUFAction;
        double eUFPower;
        double eSmile;
        string cAction;
        double cPower;
        bool cActive;
        double aEngageBore;
        double aExciteLong;
        double aExciteShort;
        double aFrustration;
        double aMeditation;
        double aValance;

        Outputs outputs = new Outputs();

        public Outputs Outputs 
        {
            get { return outputs; }
            set { outputs = value; }
        }

        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public EmotivComponent()
            : base("Emotiv", "Emotiv",
                "Emotiv data stream.",
                Properties.Settings.Default.TabName, Properties.Settings.Default.PanelName)
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("File", "F", "File path for the SQLite database the data is being written to", GH_ParamAccess.item, string.Empty);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Message", "msg", "Connection Message", GH_ParamAccess.item);
            pManager.AddTextParameter("Timestamp", "time", "Timestamp from emotiv data acquisition", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Read the most current data from the input database.
            string databaseFilePath = string.Empty;
            DA.GetData(0, ref databaseFilePath);

            string outMessage = "Database Not Found";

            if (System.IO.File.Exists(databaseFilePath))
            {
                // read the data from the file.
                System.Data.SQLite.SQLiteConnection db = new System.Data.SQLite.SQLiteConnection("Data Source=" + databaseFilePath + ";Version=3;");
                db.Open();
                
                string connectionStr = "Data Source=" + databaseFilePath + ";Version=3;";
                string commandStr = "SELECT * FROM emotiv ORDER BY timestamp DESC LIMIT 1;";
                using (System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(commandStr, db))
                {
                    using (System.Data.SQLite.SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            time = reader.GetString(0);
                            eBlink = reader.GetBoolean(1);
                            eLWink = reader.GetBoolean(2);
                            eRWink = reader.GetBoolean(3);
                            eLookDown = reader.GetBoolean(4);
                            eLookUp = reader.GetBoolean(5);
                            eLookLeft = reader.GetBoolean(6);
                            eLookRight = reader.GetBoolean(7);
                            eClench = reader.GetDouble(8);
                            eEyebrow = reader.GetDouble(9);
                            eLFAction = reader.GetString(10);
                            eLFPower = reader.GetDouble(11);
                            eUFAction = reader.GetString(12);
                            eUFPower = reader.GetDouble(13);
                            eSmile = reader.GetDouble(14);
                            cAction = reader.GetString(15);
                            cPower = reader.GetDouble(16);
                            cActive = reader.GetBoolean(17);
                            aEngageBore = reader.GetDouble(18);
                            aExciteLong = reader.GetDouble(19);
                            aExciteShort = reader.GetDouble(20);
                            aFrustration = reader.GetDouble(21);
                            aMeditation = reader.GetDouble(22);
                            aValance = reader.GetDouble(23);
                        }
                        outMessage = "Data acquired from database file.";
                    }
                }
                db.Close();
                //object data = System.Data.SQLite.SQLiteCommand.Execute(commandStr, System.Data.SQLite.SQLiteExecuteType.Default, connectionStr, null);
                DA.SetData(0, outMessage);
                if (time != null)
                {
                    DA.SetData(1, time);
                }
                
                // Assign parameter values
                if (Params.Output.Count > 2)
                {
                    for (int i = 2; i < Params.Output.Count; i++)
                    {
                        switch (Params.Output[i].NickName)
                        {
                            case "Blink":
                                DA.SetData(i, eBlink);
                                break;
                            case "LeftWink":
                                DA.SetData(i, eLWink);
                                break;
                            case "RightWink":
                                DA.SetData(i, eRWink);
                                break;
                            case "LookDown":
                                DA.SetData(i, eLookDown);
                                break;
                            case "LookUp":
                                DA.SetData(i, eLookUp);
                                break;
                            case "LookLeft":
                                DA.SetData(i, eLookLeft);
                                break;
                            case "LookRight":
                                DA.SetData(i, eLookRight);
                                break;
                            case "Clench":
                                DA.SetData(i, eClench);
                                break;
                            case "Eyebrow":
                                DA.SetData(i, eEyebrow);
                                break;
                            case "LowerFaceAction":
                                DA.SetData(i, eLFAction);
                                break;
                            case "LowerFacePower":
                                DA.SetData(i, eLFPower);
                                break;
                            case "UpperFaceAction":
                                DA.SetData(i, eUFAction);
                                break;
                            case "UpperFacePower":
                                DA.SetData(i, eUFPower);
                                break;
                            case "Smile":
                                DA.SetData(i, eSmile);
                                break;
                            case "Engagement":
                                DA.SetData(i, aEngageBore);
                                break;
                            case "ExcitementLongTerm":
                                DA.SetData(i, aExciteLong);
                                break;
                            case "ExcitementShortTerm":
                                DA.SetData(i, aExciteShort);
                                break;
                            case "Frustration":
                                DA.SetData(i, aFrustration);
                                break;
                            case "Meditation":
                                DA.SetData(i, aMeditation);
                                break;
                            case "Valance":
                                DA.SetData(i, aValance);
                                break;
                            case "Action":
                                DA.SetData(i, cAction);
                                break;
                            case "Power":
                                DA.SetData(i, cPower);
                                break;
                            case "Active":
                                DA.SetData(i, cActive);
                                break;
                            default:
                                DA.SetData(i, null);
                                break;

                        }
                    }
                }
            }

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
            get { return new Guid("{ec98dd8f-d193-473d-be12-2dfaaea85e14}"); }
        }

        public override void AppendAdditionalMenuItems(System.Windows.Forms.ToolStripDropDown menu)
        {
            Menu_AppendItem(menu, "UI Integration", Menu_UIClicked);
            Menu_AppendItem(menu, "Select Outputs", SelectOutputs);
        }

        private void SelectOutputs(object sender, EventArgs e)
        {
            try
            {
                OutputSettingsForm form = new OutputSettingsForm(this);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error:\n" + ex.Message);
            }
            SyncOutputs();
        }

        private void Menu_UIClicked(object sender, EventArgs e)
        {
            UISettingsForm form = new UISettingsForm();
            form.ShowDialog();
        }

        private void SyncOutputs()
        {
            if (Params.Output.Count < Outputs.ParameterCount)
            {
                // add paramteres
                for (int i = Params.Output.Count - 1; i < Outputs.ParameterCount; i++)
                {
                    try
                    {
                        IGH_Param param = new Param_GenericObject();
                        Params.RegisterOutputParam(param);
                    }
                    catch { }
                }
            }
            else if (Params.Output.Count > Outputs.ParameterCount)
            {
                // remove parameters
                while (Params.Output.Count > Outputs.ParameterCount)
                {
                    IGH_Param param = Params.Output[Params.Output.Count - 1];
                    Params.UnregisterOutputParameter(param);
                }
            }
            RefreshOutputs();
            ExpireSolution(true);
        }

        private void RefreshOutputs()
        {
            for (int i = 0; i < Params.Output.Count; i++)
            {
                try
                {
                    IGH_Param param = Params.Output[i + 2];
                    param.NickName = Outputs.ParameterNames[i];
                }
                catch { }
            }
        }

        public override bool Read(GH_IO.Serialization.GH_IReader reader)
        {
            // Read the show parameter data
            outputs.ShowBlink = reader.GetBoolean("ShowBlink");
            outputs.ShowLeftWink = reader.GetBoolean("ShowLeftWink");
            outputs.ShowRightWink = reader.GetBoolean("ShowRightWink");
            outputs.ShowLookDown = reader.GetBoolean("ShowLookDown");
            outputs.ShowLookUp = reader.GetBoolean("ShowLookUp");
            outputs.ShowLookLeft = reader.GetBoolean("ShowLookLeft");
            outputs.ShowLookRight = reader.GetBoolean("ShowLookRight");
            outputs.ShowClench = reader.GetBoolean("ShowClench");
            outputs.ShowEyebrow = reader.GetBoolean("ShowEyebrow");
            outputs.ShowLowerFaceAction = reader.GetBoolean("ShowLowerFaceAction");
            outputs.ShowLowerFacePower = reader.GetBoolean("ShowLowerFacePower");
            outputs.ShowUpperFaceAction = reader.GetBoolean("ShowUpperFaceAction");
            outputs.ShowUpperFacePower = reader.GetBoolean("ShowUpperFacePower");
            outputs.ShowSmile = reader.GetBoolean("ShowSmile");
            outputs.ShowEngagement = reader.GetBoolean("ShowEngagement");
            outputs.ShowExcitementLongTerm = reader.GetBoolean("ShowExcitementLong");
            outputs.ShowExcitementShortTerm = reader.GetBoolean("ShowExcitementShort");
            outputs.ShowFrustration = reader.GetBoolean("ShowFrustration");
            outputs.ShowMeditation = reader.GetBoolean("ShowMeditation");
            outputs.ShowValance = reader.GetBoolean("ShowValance");
            outputs.ShowCognativAction = reader.GetBoolean("ShowAction");
            outputs.ShowCognativPower = reader.GetBoolean("ShowPower");
            outputs.ShowCognativActive = reader.GetBoolean("ShowActive");
            outputs.Refresh();

            // read the current db values
            time = reader.GetString("Time");
            eBlink = reader.GetBoolean("Blink");
            eLWink = reader.GetBoolean("LWink");
            eRWink = reader.GetBoolean("RWink");
            eLookDown = reader.GetBoolean("LookDown");
            eLookUp = reader.GetBoolean("LookUp");
            eLookLeft = reader.GetBoolean("LookLeft");
            eLookRight = reader.GetBoolean("LookRight");
            eClench = reader.GetDouble("Clench");
            eEyebrow = reader.GetDouble("Eyebrow");
            eLFAction = reader.GetString("LFAction");
            eLFPower = reader.GetDouble("LFPower");
            eUFAction = reader.GetString("UFAction");
            eUFPower = reader.GetDouble("UFPower");
            eSmile = reader.GetDouble("Smile");
            aEngageBore = reader.GetDouble("Engagement");
            aExciteLong = reader.GetDouble("ExcitementLong");
            aExciteShort = reader.GetDouble("ExcitementShort");
            aFrustration = reader.GetDouble("Frustration");
            aMeditation = reader.GetDouble("Meditation");
            aValance = reader.GetDouble("Valance");
            cAction  = reader.GetString("Action");
            cPower = reader.GetDouble("Power");
            cActive = reader.GetBoolean("Active");

            SyncOutputs();

            return base.Read(reader);
        }

        

        public override bool Write(GH_IO.Serialization.GH_IWriter writer)
        {
            // Write the show parameter data
            writer.SetBoolean("ShowBlink", outputs.ShowBlink);
            writer.SetBoolean("ShowLeftWink", outputs.ShowLeftWink);
            writer.SetBoolean("ShowRightWink", outputs.ShowRightWink);
            writer.SetBoolean("ShowLookDown", outputs.ShowLookDown);
            writer.SetBoolean("ShowLookUp", outputs.ShowLookUp);
            writer.SetBoolean("ShowLookLeft", outputs.ShowLookLeft);
            writer.SetBoolean("ShowLookRight", outputs.ShowLookRight);
            writer.SetBoolean("ShowClench", outputs.ShowClench);
            writer.SetBoolean("ShowEyebrow", outputs.ShowEyebrow);
            writer.SetBoolean("ShowLowerFaceAction", outputs.ShowLowerFaceAction);
            writer.SetBoolean("ShowLowerFacePower", outputs.ShowLowerFacePower);
            writer.SetBoolean("ShowUpperFaceAction", outputs.ShowUpperFaceAction);
            writer.SetBoolean("ShowUpperFacePower", outputs.ShowUpperFacePower);
            writer.SetBoolean("ShowSmile", outputs.ShowSmile);
            writer.SetBoolean("ShowEngagement", outputs.ShowEngagement);
            writer.SetBoolean("ShowExcitementLong", outputs.ShowExcitementLongTerm);
            writer.SetBoolean("ShowExcitementShort", outputs.ShowExcitementShortTerm);
            writer.SetBoolean("ShowFrustration", outputs.ShowFrustration);
            writer.SetBoolean("ShowMeditation", outputs.ShowMeditation);
            writer.SetBoolean("ShowValance", outputs.ShowValance);
            writer.SetBoolean("ShowAction", outputs.ShowCognativAction);
            writer.SetBoolean("ShowPower", outputs.ShowCognativPower);
            writer.SetBoolean("ShowActive", outputs.ShowCognativActive);
            
            // write the current db values
            writer.SetString("Time", time);
            writer.SetBoolean("Blink", eBlink);
            writer.SetBoolean("LWink", eLWink);
            writer.SetBoolean("RWink", eRWink);
            writer.SetBoolean("LookDown", eLookDown);
            writer.SetBoolean("LookUp", eLookUp);
            writer.SetBoolean("LookLeft", eLookLeft);
            writer.SetBoolean("LookRight", eLookRight);
            writer.SetDouble("Clench", eClench);
            writer.SetDouble("Eyebrow", eEyebrow);
            writer.SetString("LFAction", eLFAction);
            writer.SetDouble("LFPower", eLFPower);
            writer.SetString("UFAction", eUFAction);
            writer.SetDouble("UFPower", eUFPower);
            writer.SetDouble("Smile", eSmile);
            writer.SetDouble("Engagement", aEngageBore);
            writer.SetDouble("ExcitementLong", aExciteLong);
            writer.SetDouble("ExcitementShort", aExciteShort);
            writer.SetDouble("Frustration", aFrustration);
            writer.SetDouble("Meditation", aMeditation);
            writer.SetDouble("Valance", aValance);
            writer.SetString("Action", cAction);
            writer.SetDouble("Power", cPower);
            writer.SetBoolean("Active", cActive);

            return base.Write(writer);
        }
    }
}
