using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
#pragma warning disable 1591

namespace SCHOTT.WinForms.Controls.Trackbar
{
    /// <summary>
    /// A pretty trackbar control for Winforms.
    /// </summary>
    [ToolboxBitmap(typeof(TrackBar))]
    [DefaultEvent("Scroll")]
    [DefaultProperty("BarInnerColor")]
    public class PrettyTrack : Control
    {

        #region Variables

        private Rectangle _barHalfRect;
        private int _barMaximum = 100;
        private int _barMinimum = 0;
        private Orientation _barOrientation = Orientation.Horizontal;
        private Color _barInnerColor = Color.DarkSlateBlue;
        private Color _barOuterColor = Color.SkyBlue;
        private Color _barPenColor = Color.Gainsboro;
        private Rectangle _barRect;
        private Size _borderRoundRectSize = new Size(8, 8);
        private bool _drawFocusRectangle = true;
        private bool _drawSemitransparentThumb = true;
        private Color _elapsedInnerColor = Color.DarkSlateBlue;
        private Color _elapsedOuterColor = Color.SkyBlue;
        private Rectangle _elapsedRect;
        private bool _mouseEffects = true;
        private bool _mouseInRegion;
        private bool _mouseInThumbRegion;
        private int _mouseWheelBarPartitions = 10;
        private Rectangle _thumbHalfRect;
        private Color _thumbInnerColor = Color.WhiteSmoke;
        private Color _thumbOuterColor = Color.White;
        private Color _thumbPenColor = Color.Silver;
        private Size _thumbRoundRectSize = new Size(8, 8);
        private int _thumbSize = 20;
        private int _trackerValue = 50;

        #endregion

        #region Initializers

        /// <summary>
        /// A nice looking Trackbar to use in WinForms
        /// </summary>
        /// <param name="min">Min Value of the Trackbar</param>
        /// <param name="max">Max Value of the Trackbar</param>
        /// <param name="value">The initial Value of the Trackbar</param>
        public PrettyTrack(int min, int max, int value)
        {
            InitializeComponent();
            SetStyle(
                ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable |
                ControlStyles.UserMouse | ControlStyles.SupportsTransparentBackColor |
                ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            BackColor = Color.Transparent;
            Minimum = min;
            Maximum = max;
            Value = value;
        }

        /// <summary>
        /// A nice looking Trackbar to use in WinForms
        /// </summary>
        public PrettyTrack()
            : this(0, 100, 50)
        {
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            Size = new Size(200, 30);
            ResumeLayout(false);
        }

        #endregion

        #region Proporties

        [Browsable(false)]
        public Rectangle ThumbRect { get; private set; }

        [Description("Set Slider thumb size")]
        [Category("ColorSlider")]
        [DefaultValue(20)]
        public int ThumbSize
        {
            get { return _thumbSize; }
            set
            {
                if (!((value > 0) & (value < (_barOrientation == Orientation.Horizontal ? ClientRectangle.Width : ClientRectangle.Height))))
                    throw new ArgumentOutOfRangeException("TrackSize has to be greather than zero and lower than half of Slider width");

                _thumbSize = value;
                Invalidate();
            }
        }

        [Description("Set Slider's thumb round rectangle size")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(Size), "8; 8")]
        public Size ThumbRoundRectSize
        {
            get { return _thumbRoundRectSize; }
            set
            {
                _thumbRoundRectSize = new Size(Math.Max(value.Width, 1), Math.Max(value.Height, 1));
                Invalidate();
            }
        }

        [Description("Set Slider's border round rectangle size")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(Size), "8; 8")]
        public Size BorderRoundRectSize
        {
            get { return _borderRoundRectSize; }
            set
            {
                _borderRoundRectSize = new Size(Math.Max(value.Width, 1), Math.Max(value.Height, 1));
                Invalidate();
            }
        }

        [Description("Set Slider orientation")]
        [Category("ColorSlider")]
        [DefaultValue(Orientation.Horizontal)]
        public Orientation Orientation
        {
            get { return _barOrientation; }
            set
            {
                if (_barOrientation == value)
                    return;

                _barOrientation = value;
                var width = Width;
                Width = Height;
                Height = width;
                Invalidate();
            }
        }

        [Description("Set Slider value")]
        [Category("ColorSlider")]
        [DefaultValue(50)]
        public int Value
        {
            get { return _trackerValue; }
            set
            {
                _trackerValue = Math.Max(Math.Min(value, _barMaximum), _barMinimum);
                ValueChanged?.Invoke(this, new EventArgs());

                Invalidate();
            }
        }

        [Description("Set Slider minimal point")]
        [Category("ColorSlider")]
        [DefaultValue(0)]
        public int Minimum
        {
            get { return _barMinimum; }
            set
            {
                if (value >= _barMaximum)
                    throw new ArgumentOutOfRangeException("Minimal value is greather than maximal one");

                _barMinimum = value;
                if (_trackerValue < _barMinimum)
                {
                    _trackerValue = _barMinimum;
                    ValueChanged?.Invoke(this, new EventArgs());
                }
                Invalidate();
            }
        }

        [Description("Set Slider maximal point")]
        [Category("ColorSlider")]
        [DefaultValue(100)]
        public int Maximum
        {
            get { return _barMaximum; }
            set
            {
                if (value <= _barMinimum)
                    throw new ArgumentOutOfRangeException("Maximal value is lower than minimal one");

                _barMaximum = value;
                if (_trackerValue > _barMaximum)
                {
                    _trackerValue = _barMaximum;
                    ValueChanged?.Invoke(this, new EventArgs());
                }
                Invalidate();
            }
        }

        [Description("Set trackbar's small increment")]
        [Category("ColorSlider")]
        [DefaultValue(1)]
        public uint SmallIncrement { get; set; } = 1;

        [Description("Set trackbar's large increment")]
        [Category("ColorSlider")]
        [DefaultValue(5)]
        public uint LargeIncrement { get; set; } = 5;

        [Description("Set whether to draw focus rectangle")]
        [Category("ColorSlider")]
        [DefaultValue(true)]
        public bool DrawFocusRectangle
        {
            get { return _drawFocusRectangle; }
            set
            {
                _drawFocusRectangle = value;
                Invalidate();
            }
        }

        [Description("Set whether to draw semitransparent thumb")]
        [Category("ColorSlider")]
        [DefaultValue(true)]
        public bool DrawSemitransparentThumb
        {
            get { return _drawSemitransparentThumb; }
            set
            {
                _drawSemitransparentThumb = value;
                Invalidate();
            }
        }

        [Description("Set whether mouse entry and exit actions have impact on how control look")]
        [Category("ColorSlider")]
        [DefaultValue(true)]
        public bool MouseEffects
        {
            get { return _mouseEffects; }
            set
            {
                _mouseEffects = value;
                Invalidate();
            }
        }

        [Description("Set to how many parts is bar divided when using mouse wheel")]
        [Category("ColorSlider")]
        [DefaultValue(10)]
        public int MouseWheelBarPartitions
        {
            get { return _mouseWheelBarPartitions; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("MouseWheelBarPartitions has to be greather than zero");

                _mouseWheelBarPartitions = value;
            }
        }

        [Description("Set Slider thumb outer color")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(Color), "White")]
        public Color ThumbOuterColor
        {
            get { return _thumbOuterColor; }
            set
            {
                _thumbOuterColor = value;
                Invalidate();
            }
        }

        [Description("Set Slider thumb inner color")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(Color), "WhiteSmoke")]
        public Color ThumbInnerColor
        {
            get { return _thumbInnerColor; }
            set
            {
                _thumbInnerColor = value;
                Invalidate();
            }
        }

        [Description("Set Slider thumb pen color")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(Color), "Silver")]
        public Color ThumbPenColor
        {
            get { return _thumbPenColor; }
            set
            {
                _thumbPenColor = value;
                Invalidate();
            }
        }

        [Description("Set Slider bar outer color")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(Color), "SkyBlue")]
        public Color BarOuterColor
        {
            get { return _barOuterColor; }
            set
            {
                _barOuterColor = value;
                Invalidate();
            }
        }

        [Description("Set Slider bar inner color")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(Color), "DarkSlateBlue")]
        public Color BarInnerColor
        {
            get { return _barInnerColor; }
            set
            {
                _barInnerColor = value;
                Invalidate();
            }
        }

        [Description("Set Slider bar pen color")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(Color), "Gainsboro")]
        public Color BarPenColor
        {
            get { return _barPenColor; }
            set
            {
                _barPenColor = value;
                Invalidate();
            }
        }

        [Description("Set Slider's elapsed part outer color")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(Color), "SkyBlue")]
        public Color ElapsedOuterColor
        {
            get { return _elapsedOuterColor; }
            set
            {
                _elapsedOuterColor = value;
                Invalidate();
            }
        }

        [Description("Set Slider's elapsed part inner color")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(Color), "DarkSlateBlue")]
        public Color ElapsedInnerColor
        {
            get { return _elapsedInnerColor; }
            set
            {
                _elapsedInnerColor = value;
                Invalidate();
            }
        }

        #endregion

        #region Events

        [Description("Event fires when the Value property changes")]
        [Category("Action")]
        public event EventHandler ValueChanged;

        [Description("Event fires when the Slider position is changed")]
        [Category("Behavior")]
        public event ScrollEventHandler Scroll;

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!Enabled)
            {
                Color[] colorArray = DesaturateColors(_thumbOuterColor, _thumbInnerColor, _thumbPenColor,
                    _barOuterColor, _barInnerColor, _barPenColor, _elapsedOuterColor, _elapsedInnerColor);
                DrawColorSlider(e, colorArray[0], colorArray[1], colorArray[2], colorArray[3], colorArray[4],
                    colorArray[5], colorArray[6], colorArray[7]);
            }
            else if (_mouseEffects && _mouseInRegion)
            {
                Color[] colorArray = LightenColors(_thumbOuterColor, _thumbInnerColor, _thumbPenColor,
                    _barOuterColor, _barInnerColor, _barPenColor, _elapsedOuterColor, _elapsedInnerColor);
                DrawColorSlider(e, colorArray[0], colorArray[1], colorArray[2], colorArray[3], colorArray[4],
                    colorArray[5], colorArray[6], colorArray[7]);
            }
            else
                DrawColorSlider(e, _thumbOuterColor, _thumbInnerColor, _thumbPenColor, _barOuterColor, _barInnerColor,
                    _barPenColor, _elapsedOuterColor, _elapsedInnerColor);
        }

        private void DrawColorSlider(PaintEventArgs e, Color thumbOuterColorPaint, Color thumbInnerColorPaint,
            Color thumbPenColorPaint, Color barOuterColorPaint, Color barInnerColorPaint, Color barPenColorPaint,
            Color elapsedOuterColorPaint, Color elapsedInnerColorPaint)
        {
            try
            {
                _barRect = ClientRectangle;

                LinearGradientMode linearGradientMode;
                if (_barOrientation == Orientation.Horizontal)
                {
                    ThumbRect = new Rectangle(
                           (_trackerValue - _barMinimum) * (ClientRectangle.Width - _thumbSize) / (_barMaximum - _barMinimum), 1,
                           _thumbSize - 1, ClientRectangle.Height - 3);

                    _thumbHalfRect = ThumbRect;
                    _thumbHalfRect.Height >>= 1;

                    _barRect.Inflate(-1, -_barRect.Height / 3);
                    _barHalfRect = _barRect;
                    _barHalfRect.Height >>= 1;

                    linearGradientMode = LinearGradientMode.Vertical;

                    _elapsedRect = _barRect;
                    _elapsedRect.Width = ThumbRect.Left + (_thumbSize >> 1);
                }
                else
                {
                    ThumbRect = new Rectangle(1, (_trackerValue - _barMinimum) * (ClientRectangle.Height - _thumbSize) / (_barMaximum - _barMinimum),
                       ClientRectangle.Width - 3, _thumbSize - 1);

                    _thumbHalfRect = ThumbRect;
                    _thumbHalfRect.Width >>= 1;

                    _barRect.Inflate(-_barRect.Width / 3, -1);
                    _barHalfRect = _barRect;
                    _barHalfRect.Width >>= 1;

                    linearGradientMode = LinearGradientMode.Horizontal;

                    _elapsedRect = _barRect;
                    _elapsedRect.Height = ThumbRect.Top + (_thumbSize >> 1);
                }

                GraphicsPath path = CreateRoundRectPath(ThumbRect, _thumbRoundRectSize); 

                using (var linearGradientBrush1 = new LinearGradientBrush(_barHalfRect, barOuterColorPaint, barInnerColorPaint, linearGradientMode))
                {
                    linearGradientBrush1.WrapMode = WrapMode.TileFlipXY;
                    e.Graphics.FillRectangle(linearGradientBrush1, _barRect);

                    using (var linearGradientBrush2 = new LinearGradientBrush(_barHalfRect, elapsedOuterColorPaint, elapsedInnerColorPaint, linearGradientMode))
                    {
                        linearGradientBrush2.WrapMode = WrapMode.TileFlipXY;
                        if (Capture && _drawSemitransparentThumb)
                        {
                            var region = new Region(_elapsedRect);
                            region.Exclude(path);
                            e.Graphics.FillRegion(linearGradientBrush2, region);
                        }
                        else
                        {
                            e.Graphics.FillRectangle(linearGradientBrush2, _elapsedRect);
                        }
                    }

                    using (var pen = new Pen(barPenColorPaint, 0.5f))
                    {
                        e.Graphics.DrawRectangle(pen, _barRect);
                    }
                }

                var color1 = thumbOuterColorPaint;
                var color2 = thumbInnerColorPaint;

                if (Capture && _drawSemitransparentThumb)
                {
                    color1 = Color.FromArgb(175, thumbOuterColorPaint);
                    color2 = Color.FromArgb(175, thumbInnerColorPaint);
                }

                using (var linearGradientBrush = new LinearGradientBrush(_thumbHalfRect, color1, color2, linearGradientMode))
                {
                    linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(linearGradientBrush, path);
                    var color = thumbPenColorPaint;

                    if (_mouseEffects && (Capture || _mouseInThumbRegion))
                        color = ControlPaint.Dark(color);

                    using (var pen = new Pen(color))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }

                if (!(Focused & _drawFocusRectangle))
                    return;

                using (var pen = new Pen(Color.FromArgb(200, barPenColorPaint)))
                {
                    pen.DashStyle = DashStyle.Dot;
                    var clientRectangle = ClientRectangle;
                    clientRectangle.Width -= 2;
                    clientRectangle.Height--;
                    clientRectangle.X++;

                    using (GraphicsPath roundRectPath = CreateRoundRectPath(clientRectangle, _borderRoundRectSize))
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.DrawPath(pen, roundRectPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DrawBackGround Error in " + Name + ":" + ex.Message);
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _mouseInRegion = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _mouseInRegion = false;
            _mouseInThumbRegion = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left)
                return;

            Capture = true;
            Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.ThumbTrack, _trackerValue));
            ValueChanged?.Invoke(this, new EventArgs());
            OnMouseMove(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            _mouseInThumbRegion = IsPointInRect(e.Location, ThumbRect);
            if (Capture & (e.Button == MouseButtons.Left))
            {
                var type = ScrollEventType.ThumbPosition;

                var mouseLocation = _barOrientation == Orientation.Horizontal ? e.Location.X : e.Location.Y;
                var barLength = _barOrientation == Orientation.Horizontal ? ClientSize.Width : ClientSize.Height;
                var ticksPerPx = (double) ((_barMaximum - _barMinimum)/(float) (barLength - _thumbSize));
                var tickLocation = mouseLocation - (_thumbSize >> 1);

                _trackerValue = (int)(tickLocation * ticksPerPx) + _barMinimum;

                if (_trackerValue <= _barMinimum)
                {
                    _trackerValue = _barMinimum;
                    type = ScrollEventType.First;
                }
                else if (_trackerValue >= _barMaximum)
                {
                    _trackerValue = _barMaximum;
                    type = ScrollEventType.Last;
                }

                Scroll?.Invoke(this, new ScrollEventArgs(type, _trackerValue));
                ValueChanged?.Invoke(this, new EventArgs());
            }
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            Capture = false;
            _mouseInThumbRegion = IsPointInRect(e.Location, ThumbRect);

            Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.EndScroll, _trackerValue));
            ValueChanged?.Invoke(this, new EventArgs());

            Invalidate();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            Value = Value + e.Delta / 120 * (_barMaximum - _barMinimum) / _mouseWheelBarPartitions;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            switch (e.KeyCode)
            {
                case Keys.Prior:
                    Value += (int) LargeIncrement;
                    Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.LargeIncrement, Value));
                    break;
                case Keys.Next:
                    Value -= (int)LargeIncrement;
                    Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.LargeDecrement, Value));
                    break;
                case Keys.End:
                    Value = _barMaximum;
                    break;
                case Keys.Home:
                    Value = _barMinimum;
                    break;
                case Keys.Left:
                case Keys.Down:
                    Value -= (int)SmallIncrement;
                    Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.SmallDecrement, Value));
                    break;
                case Keys.Up:
                case Keys.Right:
                    Value += (int)SmallIncrement;
                    Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.SmallIncrement, Value));
                    break;
            }

            if (Scroll != null)
            {
                if (Value == _barMinimum)
                    Scroll(this, new ScrollEventArgs(ScrollEventType.First, Value));
                if (Value == _barMaximum)
                    Scroll(this, new ScrollEventArgs(ScrollEventType.Last, Value));
            }

            var client = PointToClient(Cursor.Position);
            OnMouseMove(new MouseEventArgs(MouseButtons.None, 0, client.X, client.Y, 0));
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if ((keyData == Keys.Tab) | (ModifierKeys == Keys.Shift))
                return base.ProcessDialogKey(keyData);
            OnKeyDown(new KeyEventArgs(keyData));
            return true;
        }

        #endregion

        #region Utilities
        
        public static GraphicsPath CreateRoundRectPath(Rectangle rectangle, Size size)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddLine(rectangle.Left + (size.Width >> 1), rectangle.Top, rectangle.Right - (size.Width >> 1), rectangle.Top);
            graphicsPath.AddArc(rectangle.Right - size.Width, rectangle.Top, size.Width, size.Height, (float)270.0, (float)90.0);
            graphicsPath.AddLine(rectangle.Right, rectangle.Top + (size.Height >> 1), rectangle.Right, rectangle.Bottom - (size.Width >> 1));
            graphicsPath.AddArc(rectangle.Right - size.Width, rectangle.Bottom - size.Height, size.Width, size.Height, (float)0.0, (float)90.0);
            graphicsPath.AddLine(rectangle.Right - (size.Width >> 1), rectangle.Bottom, rectangle.Left + (size.Width >> 1), rectangle.Bottom);
            graphicsPath.AddArc(rectangle.Left, rectangle.Bottom - size.Height, size.Width, size.Height, (float)90.0, (float)90.0);
            graphicsPath.AddLine(rectangle.Left, rectangle.Bottom - (size.Height >> 1), rectangle.Left, rectangle.Top + (size.Height >> 1));
            graphicsPath.AddArc(rectangle.Left, rectangle.Top, size.Width, size.Height, (float)180.0, (float)90.0);
            return graphicsPath;
        }
        
        public static Color[] DesaturateColors(params Color[] colorsToDesaturate)
        {
            var colorArray = new Color[colorsToDesaturate.Length];
            for (var index = 0; index < colorsToDesaturate.Length; ++index)
            {
                var num = (int)(colorsToDesaturate[index].R * 0.3 + colorsToDesaturate[index].G * 0.6 + colorsToDesaturate[index].B * 0.1);
                colorArray[index] = Color.FromArgb(-65793 * (byte.MaxValue - num) - 1);
            }
            return colorArray;
        }
        
        public static Color[] LightenColors(params Color[] colorsToLighten)
        {
            var colorArray = new Color[colorsToLighten.Length];
            for (var index = 0; index < colorsToLighten.Length; ++index)
                colorArray[index] = ControlPaint.Light(colorsToLighten[index]);
            return colorArray;
        }
        
        private static bool IsPointInRect(Point pt, Rectangle rect)
        {
            return (pt.X > rect.Left) && (pt.X < rect.Right) && (pt.Y > rect.Top) && (pt.Y < rect.Bottom);
        }

        #endregion

    }
}