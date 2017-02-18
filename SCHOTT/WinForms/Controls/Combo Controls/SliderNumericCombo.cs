using SCHOTT.WinForms.Controls.Trackbar;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SCHOTT.WinForms.Controls.Combo_Controls
{
    /// <summary>
    /// A custom control that combines a Slider with a numeric control.
    /// </summary>
    public partial class SliderNumericCombo : UserControl
    {
        private bool ProgramaticChangeInProgress { get; set; }
        private bool UserChangeInProgress { get; set; }
        
        /// <summary>
        /// The event delegate for OnValueChanged
        /// </summary>
        /// <param name="control">The control that changed.</param>
        /// <param name="value">The new value of the control.</param>
        public delegate void ValueChanged(SliderNumericCombo control, int value);

        /// <summary>
        /// The ValueChange event for subscription
        /// </summary>
        public event ValueChanged OnValueChanged;

        private void UpdateValueListeners()
        {
            OnValueChanged?.Invoke(this, slider.Value);
        }

        /// <summary>
        /// Create a new SliderNumericCombo
        /// </summary>
        public SliderNumericCombo()
        {
            InitializeComponent();
            base.AutoScaleMode = AutoScaleMode.None;

            slider.ValueChanged += Slider_ValueChanged;
            slider.GotFocus += ControlGotFocus;
            slider.LostFocus += ControlLostFocus;
            slider.MouseUp += Slider_MouseUp;

            numeric.ValueChanged += Numeric_ValueChanged;
            numeric.GotFocus += ControlGotFocus;
            numeric.LostFocus += ControlLostFocus;
        }

        private void Slider_MouseUp(object sender, MouseEventArgs e)
        {
            tableLayoutPanel1.Focus();
        }

        /// <summary>
        /// A integer to store channel information in.
        /// </summary>
        public int Channel { get; set; }
        
        private void ControlGotFocus(object sender, EventArgs e)
        {
            UserChangeInProgress = true;
        }

        private void ControlLostFocus(object sender, EventArgs e)
        {
            UserChangeInProgress = false;
        }

        private void Numeric_ValueChanged(object sender, EventArgs e)
        {
            if (ProgramaticChangeInProgress)
                return;

            ProgramaticChangeInProgress = true;
            slider.Value = (int)((double)numeric.Value * IncrimentDiv);
            UpdateValueListeners();
            ProgramaticChangeInProgress = false;
        }

        private void Slider_ValueChanged(object sender, EventArgs e)
        {
            if (ProgramaticChangeInProgress)
                return;

            ProgramaticChangeInProgress = true;
            numeric.Value = (decimal)(slider.Value * Incriment);
            UpdateValueListeners();
            ProgramaticChangeInProgress = false;
        }

        /// <summary>
        /// The number of decimal places displayed in the control.
        /// </summary>
        public int DecimalPlaces
        {
            get { return numeric.DecimalPlaces; }
            set
            {
                ProgramaticChangeInProgress = true;
                numeric.DecimalPlaces = value;
                Incriment = Math.Pow(0.1, value);
                numeric.Maximum = (decimal)(Maximum * Incriment);
                numeric.Minimum = (decimal)(Minimum * Incriment);
                ProgramaticChangeInProgress = false;
            }
        }

        private double IncrimentDiv { get; set; } = 1;

        private double Incriment
        {
            get { return (double)numeric.Increment; }
            set
            {
                numeric.Increment = (decimal)value;
                IncrimentDiv = 1.0 / value;
            }
        }

        /// <summary>
        /// Sets the Maximum value of the SliderNumericCombo.
        /// </summary>
        public int Maximum
        {
            get { return slider.Maximum; }
            set
            {
                ProgramaticChangeInProgress = true;
                slider.Maximum = value;
                Incriment = Math.Pow(0.1, DecimalPlaces);
                numeric.Maximum = (decimal)(value * Incriment);
                numeric.Minimum = (decimal)(Minimum * Incriment);
                ProgramaticChangeInProgress = false;
            }
        }

        /// <summary>
        /// Sets the Minimum value of the SliderNumericCombo.
        /// </summary>
        public int Minimum
        {
            get { return slider.Minimum; }
            set
            {
                ProgramaticChangeInProgress = true;
                slider.Minimum = value;
                Incriment = Math.Pow(0.1, DecimalPlaces);
                numeric.Minimum = (decimal)(value * Incriment);
                numeric.Maximum = (decimal)(Maximum * Incriment);
                ProgramaticChangeInProgress = false;
            }
        }

        /// <summary>
        /// Change the font size of the SliderNumericCombo.
        /// </summary>
        public float FontSize
        {
            get { return numeric.Font.SizeInPoints; }
            set { numeric.Font = new Font(numeric.Font.FontFamily, value, FontStyle.Regular); }
        }

        /// <summary>
        /// The value of the SliderNumericCombo.
        /// </summary>
        public int Value
        {
            get { return slider.Value; }
            set
            {
                if (UserChangeInProgress || ProgramaticChangeInProgress)
                    return;

                ProgramaticChangeInProgress = true;
                slider.Value = Math.Min(Math.Max(value, slider.Minimum), slider.Maximum);
                numeric.Value = (decimal)(slider.Value * Incriment);
                ProgramaticChangeInProgress = false;
            }
        }

        /// <summary>
        /// Gives access to the slider control
        /// </summary>
        public PrettyTrack SliderControl => slider;
    }
}
