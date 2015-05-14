# EmotivTests

This is a series of libraries and applicaitons built up around the Emotiv Epoc+ EEG headset.  These were built as part of the AEC Hackathon in Dallas, TX on 5/2/2015.

<h6>May 14, 2015</h6>
The current implementation has three parts, one console appliation (LINE.Emotiv.Connect) that actually connects to the Emotiv/Control Panel and writes the values to a SQLite database file, and two libraries to connect with both McNeel's Rhino/Grasshopper and Autodesk's Dynamo.

The Emotiv libraries used were 32bit so the console application is likewise 32bit and uses the 32bit libraries for the SQLite.Net and the Grasshopper and Dynamo implementations are 64bit so use the 64bit SQLite libraries.  Since the Emotiv SDK Lite is the only thing that's available free for download, that's all that's been included here.  In order to work with an Emotiv headset you'll need to replace the <b>edk.dll</b> file used in the LINE.Emotiv.Connect and found in the lib/emotiv_SDKlite folder with the full version.
<br>
<h6><em>Original Implementation - Outdated and removed:</em></h6>
The most prominent parts of these tests are the Connect.Test01 project to read the data stream from the Epoc+ headset and write it to an XML file, and the GH.Emotiv.Connect which is a Grasshopper component that reads the XML file and outputs the values.  Currently it's working with the Expressiv data from the headset as it was the most straight forward and easy to test during the Hackathon.

There is also a Dynamo.Emotiv component that works similarly to the GH.Emotiv.Connect project in that it reads the data from the XML and publishes the data to the Dynamo component's output.

Future experiments we will aim to write the data stream to a database that can be read in real-time from the other applications as well as recalling and playing back a datastream from an earlier scan.
