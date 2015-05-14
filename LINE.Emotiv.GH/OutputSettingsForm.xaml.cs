using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LINE.Emotiv.GH
{
    /// <summary>
    /// Interaction logic for OutputSettingsForm.xaml
    /// </summary>
    public partial class OutputSettingsForm : Window
    {
        EmotivComponent _parent = null;
        LinearGradientBrush brush = null;
        Outputs outputs = null;

        public OutputSettingsForm(EmotivComponent parent)
        {
            _parent = parent;
            outputs = _parent.Outputs;
            InitializeComponent();

            try
            {
                // Expressiv
                blinkCheckBox.IsChecked = outputs.ShowBlink;
                lwinkCheckBox.IsChecked = outputs.ShowLeftWink;
                rwinkCheckBox.IsChecked = outputs.ShowRightWink;
                lookDownCheckBox.IsChecked = outputs.ShowLookDown;
                lookUpCheckBox.IsChecked = outputs.ShowLookUp;
                lookLeftCheckBox.IsChecked = outputs.ShowLookLeft;
                lookRightCheckBox.IsChecked = outputs.ShowLookRight;
                clenchCheckBox.IsChecked = outputs.ShowClench;
                eyebrowCheckBox.IsChecked = outputs.ShowEyebrow;
                lfActionCheckBox.IsChecked = outputs.ShowLowerFaceAction;
                lfPowerCheckBox.IsChecked = outputs.ShowLowerFacePower;
                ufActionCheckBox.IsChecked = outputs.ShowUpperFaceAction;
                ufPowerCheckBox.IsChecked = outputs.ShowUpperFacePower;
                smileCheckBox.IsChecked = outputs.ShowSmile;

                // Affectiv
                engagementCheckBox.IsChecked = outputs.ShowEngagement;
                exciteLongCheckBox.IsChecked = outputs.ShowExcitementLongTerm;
                exciteShortCheckBox.IsChecked = outputs.ShowExcitementShortTerm;
                frustrationCheckBox.IsChecked = outputs.ShowFrustration;
                meditationCheckBox.IsChecked = outputs.ShowMeditation;
                valanceCheckBox.IsChecked = outputs.ShowValance;

                // Cognativ
                cogActionCheckBox.IsChecked = outputs.ShowCognativAction;
                cogPowerCheckBox.IsChecked = outputs.ShowCognativPower;
                cogActiveCheckBox.IsChecked = outputs.ShowCognativActive;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("zError:\n" + ex.ToString());
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            outputs.ShowBlink = blinkCheckBox.IsChecked.Value;
            outputs.ShowLeftWink = lwinkCheckBox.IsChecked.Value;
            outputs.ShowRightWink = rwinkCheckBox.IsChecked.Value;
            outputs.ShowLookDown = lookDownCheckBox.IsChecked.Value;
            outputs.ShowLookUp = lookUpCheckBox.IsChecked.Value;
            outputs.ShowLookLeft = lookLeftCheckBox.IsChecked.Value;
            outputs.ShowLookRight = lookRightCheckBox.IsChecked.Value;
            outputs.ShowClench = clenchCheckBox.IsChecked.Value;
            outputs.ShowEyebrow = eyebrowCheckBox.IsChecked.Value;
            outputs.ShowLowerFaceAction = lfActionCheckBox.IsChecked.Value;
            outputs.ShowLowerFacePower = lfPowerCheckBox.IsChecked.Value;
            outputs.ShowUpperFaceAction = ufActionCheckBox.IsChecked.Value;
            outputs.ShowUpperFacePower = ufPowerCheckBox.IsChecked.Value;
            outputs.ShowSmile = smileCheckBox.IsChecked.Value;

            outputs.ShowEngagement = engagementCheckBox.IsChecked.Value;
            outputs.ShowExcitementLongTerm = exciteLongCheckBox.IsChecked.Value;
            outputs.ShowExcitementShortTerm = exciteShortCheckBox.IsChecked.Value;
            outputs.ShowFrustration = frustrationCheckBox.IsChecked.Value;
            outputs.ShowMeditation = meditationCheckBox.IsChecked.Value;
            outputs.ShowValance = valanceCheckBox.IsChecked.Value;

            outputs.ShowCognativAction = cogActionCheckBox.IsChecked.Value;
            outputs.ShowCognativPower = cogPowerCheckBox.IsChecked.Value;
            outputs.ShowCognativActive = cogActiveCheckBox.IsChecked.Value;

            outputs.Refresh();
            
            //_parent.Outputs = outputs;
            
            this.Close();
        }

        private void okButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (brush == null)
            {
                brush = EnterBrush();
            }
            okButtonRect.Fill = brush;
        }

        private void okButton_MouseLeave(object sender, MouseEventArgs e)
        {
            okButtonRect.Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 0, 0, 0));
        }

        private void closeButton_MouseLeave(object sender, MouseEventArgs e)
        {
            closeButtonRect.Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 0, 0, 0));
        }

        private void closeButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (brush == null)
            {
                brush = EnterBrush();
            }
            closeButtonRect.Fill = brush;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private LinearGradientBrush EnterBrush()
        {
            LinearGradientBrush b = new LinearGradientBrush();
            b.StartPoint = new System.Windows.Point(0, 0);
            b.EndPoint = new System.Windows.Point(0, 1);
            b.GradientStops.Add(new GradientStop(System.Windows.Media.Color.FromArgb(255, 195, 195, 195), 0.0));
            b.GradientStops.Add(new GradientStop(System.Windows.Media.Color.FromArgb(255, 245, 245, 245), 1.0));

            return b;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
