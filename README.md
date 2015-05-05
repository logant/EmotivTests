# EmotivTests

This is a series of libraries and applicaitons built up around the Emotiv Epoc EEG headset.  These were built as part of the AEC Hackathon in Dallas, TX on 5/2/2015.

The most prominent parts of these tests are the Connect.Test01 project to read the data stream from the Epoc+ headset and write it to an XML file, and the GH.Emotiv.Connect which is a Grasshopper component that reads the XML file and outputs the values.  Currently it's working with the Expressiv data from the headset as it was the most straight forward and easy to test during the Hackathon.

There is also a Dynamo.Emotiv component that works similarly to the GH.Emotiv.Connect project in that it reads the data from the XML and publishes the data to the Dynamo component's output.

Future experiments we will aim to write the data stream to a database that can be read in real-time from the other applications as well as recalling and playing back a datastream from an earlier scan.
