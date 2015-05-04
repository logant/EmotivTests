using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dynamo.Emotiv
{
    public class EmotivReader
    {
        public static double ReadSmile(bool read, string path)
        {
            double val = 0;
            string test = string.Empty;
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

                            if (textData[0] == "Smile Extent")
                            {
                                try
                                {
                                    val = Convert.ToDouble(textData[1]);
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
            return val;
        }
    }
}
