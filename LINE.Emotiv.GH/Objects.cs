using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINE.Emotiv.GH
{
    public class Outputs
    {

        public bool ShowBlink { get; set; }
        public bool ShowLeftWink { get; set; }
        public bool ShowRightWink { get; set; }
        public bool ShowLookDown { get; set; }
        public bool ShowLookUp { get; set; }
        public bool ShowLookLeft { get; set; }
        public bool ShowLookRight { get; set; }
        public bool ShowClench { get; set; }
        public bool ShowEyebrow { get; set; }
        public bool ShowLowerFaceAction { get; set; }
        public bool ShowLowerFacePower { get; set; }
        public bool ShowUpperFaceAction { get; set; }
        public bool ShowUpperFacePower { get; set; }
        public bool ShowSmile { get; set; }
        public bool ShowEngagement { get; set; }
        public bool ShowExcitementLongTerm { get; set; }
        public bool ShowExcitementShortTerm { get; set; }
        public bool ShowFrustration { get; set; }
        public bool ShowMeditation { get; set; }
        public bool ShowValance { get; set; }
        public bool ShowCognativAction { get; set; }
        public bool ShowCognativPower { get; set; }
        public bool ShowCognativActive { get; set; }

        public int ParameterCount { get; set; }
        public List<string> ParameterNames { get; set; }

        public Outputs()
        {
            ShowBlink = false;
            ShowLeftWink = false;
            ShowRightWink = false;
            ShowLookDown = false;
            ShowLookUp = false;
            ShowLookLeft = false;
            ShowLookRight = false;
            ShowClench = false;
            ShowEyebrow = false;
            ShowLowerFaceAction = false;
            ShowLowerFacePower = false;
            ShowUpperFaceAction = false;
            ShowUpperFacePower = false;
            ShowSmile = false;
            ShowEngagement = false;
            ShowExcitementLongTerm = false;
            ShowExcitementShortTerm = false;
            ShowFrustration = false;
            ShowMeditation = false;
            ShowValance = false;
            ShowCognativAction = false;
            ShowCognativPower = false;
            ShowCognativActive = false;

            ParameterCount = 2;
            ParameterNames = new List<string>();
        }

        public void Refresh()
        {
            int count = 2;
            List<string> paramNames = new List<string>();
            if (ShowBlink)
            {
                paramNames.Add("Blink");
                count++;
            }
            if (ShowLeftWink)
            {
                paramNames.Add("LeftWink");
                count++;
            }
            if (ShowRightWink)
            {
                paramNames.Add("RightWink");
                count++;
            }
            if (ShowLookDown)
            {
                paramNames.Add("LookDown");
                count++;
            }
            if (ShowLookUp)
            {
                paramNames.Add("LookUp");
                count++;
            }
            if (ShowLookLeft)
            {
                paramNames.Add("LookLeft");
                count++;
            }
            if (ShowLookRight)
            {
                paramNames.Add("LookRight");
                count++;
            }
            if (ShowClench)
            {
                paramNames.Add("Clench");
                count++;
            }
            if (ShowEyebrow)
            {
                paramNames.Add("Eyebrow");
                count++;
            }
            if (ShowLowerFaceAction)
            {
                paramNames.Add("LowerFaceAction");
                count++;
            }
            if (ShowLowerFacePower)
            {
                paramNames.Add("LowerFacePower");
                count++;
            }
            if (ShowUpperFaceAction)
            {
                paramNames.Add("UpperFaceAction");
                count++;
            }
            if (ShowUpperFacePower)
            {
                paramNames.Add("UpperFacePower");
                count++;
            }
            if (ShowSmile)
            {
                paramNames.Add("Smile");
                count++;
            }
            if (ShowEngagement)
            {
                paramNames.Add("Engagement");
                count++;
            }
            if (ShowExcitementLongTerm)
            {
                paramNames.Add("ExcitementLongTerm");
                count++;
            }
            if (ShowExcitementShortTerm)
            {
                paramNames.Add("ExcitementShortTerm");
                count++;
            }
            if (ShowFrustration)
            {
                paramNames.Add("Frustration");
                count++;
            }
            if (ShowMeditation)
            {
                paramNames.Add("Meditation");
                count++;
            }
            if (ShowValance)
            {
                paramNames.Add("Valance");
                count++;
            }
            if (ShowCognativAction)
            {
                paramNames.Add("Action");
                count++;
            }
            if (ShowCognativPower)
            {
                paramNames.Add("Power");
                count++;
            }
            if (ShowCognativActive)
            {
                paramNames.Add("Active");
                count++;
            }

            ParameterCount = count - 1;
            ParameterNames = paramNames;
        }
    }
}
