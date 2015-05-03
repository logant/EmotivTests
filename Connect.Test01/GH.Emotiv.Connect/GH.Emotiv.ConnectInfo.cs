using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace GH.Emotiv.Connect
{
  public class GHEmotivConnectInfo : GH_AssemblyInfo
  {
    public override string Name
    {
      get
      {
        return "GHEmotivConnect";
      }
    }
    public override Bitmap Icon
    {
      get
      {
        //Return a 24x24 pixel bitmap to represent this GHA library.
        return null;
      }
    }
    public override string Description
    {
      get
      {
        //Return a short string describing the purpose of this GHA library.
        return "";
      }
    }
    public override Guid Id
    {
      get
      {
        return new Guid("aae029a0-e36a-4e3f-98cb-d50001626352");
      }
    }

    public override string AuthorName
    {
      get
      {
        //Return a string identifying you or your company.
        return "";
      }
    }
    public override string AuthorContact
    {
      get
      {
        //Return a string representing your preferred contact details.
        return "";
      }
    }
  }
}
