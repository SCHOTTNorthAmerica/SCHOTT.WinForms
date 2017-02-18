using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SCHOTT.WinForms.Controls.Labels
{
    /// <summary>
    /// A class to create a transparent label
    /// </summary>
    public class TransparentLabel : Label
    {
        private int _opacity;
        private Color _transparentBackColor;

        /// <summary>
        /// Create a new transparent label.
        /// </summary>
        public TransparentLabel()
        {
            this._transparentBackColor = Color.Blue;
            this._opacity = 50;
            this.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Overrides the OnPaint method to create the transparent effect.
        /// </summary>
        /// <param name="e">Paint Event Args</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Parent == null)
                return;

            using (var bmp = new Bitmap(Parent.Width, Parent.Height))
            {
                Parent.Controls.Cast<Control>()
                    .Where(c => Parent.Controls.GetChildIndex(c) > Parent.Controls.GetChildIndex(this))
                    .Where(c => c.Bounds.IntersectsWith(this.Bounds))
                    .OrderByDescending(c => Parent.Controls.GetChildIndex(c))
                    .ToList()
                    .ForEach(c => c.DrawToBitmap(bmp, c.Bounds));


                e.Graphics.DrawImage(bmp, -Left, -Top);
                using (var b = new SolidBrush(Color.FromArgb(this.Opacity, this.TransparentBackColor)))
                {
                    e.Graphics.FillRectangle(b, this.ClientRectangle);
                }
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, Color.Transparent, TextFormatFlags.WordBreak | TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        /// <summary>
        /// The opacity to set the transparent label too. 0 = Transparent, 255 = Opaque
        /// </summary>
        public int Opacity
        {
            get { return _opacity; }
            set
            {
                if (value >= 0 && value <= 255)
                    _opacity = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// The background color of the control. This is the color that will be made transparent.
        /// </summary>
        public Color TransparentBackColor
        {
            get { return _transparentBackColor; }
            set
            {
                _transparentBackColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Force the standard non transparent background to be transparent.
        /// </summary>
        [Browsable(false)]
        public sealed override Color BackColor => Color.Transparent;
    }
}
