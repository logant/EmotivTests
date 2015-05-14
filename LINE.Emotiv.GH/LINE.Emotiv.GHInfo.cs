using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace LINE.Emotiv.GH
{
  public class GHInfo : GH_AssemblyInfo
  {
    public override string Name
    {
      get
      {
        return "Emotiv";
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
        return new Guid("ac5e5a1c-2ac0-44bf-8ac5-1c14f20f2593");
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
