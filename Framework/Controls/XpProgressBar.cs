// Decompiled with JetBrains decompiler
// Type: Framework.Controls.XpProgressBar
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Framework.Controls
{
    public class XpProgressBar : Control
    {
        private const string CategoryName = "Xp ProgressBar";
        private Color mColor1 = Color.FromArgb(170, 240, 170);
        private Color mColor2 = Color.FromArgb(10, 150, 10);
        private Color mColorBackGround = Color.White;
        private Color mColorText = Color.Black;
        private Image mDobleBack;
        private GradientMode mGradientStyle = GradientMode.VerticalCenter;
        private int mMax = 100;
        private int mMin;
        private int mPosition = 50;
        private byte mSteepDistance = 2;
        private byte mSteepWidth = 6;
        private bool mTextShadow = true;
        private byte mTextShadowAlpha = 150;
        private Rectangle innerRect;
        private LinearGradientBrush mBrush1;
        private LinearGradientBrush mBrush2;
        private Pen mPenIn = new Pen(Color.FromArgb(239, 239, 239));
        private Pen mPenOut = new Pen(Color.FromArgb(104, 104, 104));
        private Pen mPenOut2 = new Pen(Color.FromArgb(190, 190, 190));
        private Rectangle mSteepRect1;
        private Rectangle mSteepRect2;
        private Rectangle outnnerRect;
        private Rectangle outnnerRect2;

        protected override void Dispose(bool disposing)
        {
            if (this.IsDisposed)
                return;
            if (this.mDobleBack != null)
                this.mDobleBack.Dispose();
            if (this.mBrush1 != null)
                this.mBrush1.Dispose();
            if (this.mBrush2 != null)
                this.mBrush2.Dispose();
            base.Dispose(disposing);
        }

        [Description("The Back Color of the Progress Bar")]
        [Category("Xp ProgressBar")]
        public Color ColorBackGround
        {
            get => this.mColorBackGround;
            set
            {
                this.mColorBackGround = value;
                this.InvalidateBuffer(true);
            }
        }

        [Description("The Border Color of the gradient in the Progress Bar")]
        [Category("Xp ProgressBar")]
        public Color ColorBarBorder
        {
            get => this.mColor1;
            set
            {
                this.mColor1 = value;
                this.InvalidateBuffer(true);
            }
        }

        [Category("Xp ProgressBar")]
        [Description("The Center Color of the gradient in the Progress Bar")]
        public Color ColorBarCenter
        {
            get => this.mColor2;
            set
            {
                this.mColor2 = value;
                this.InvalidateBuffer(true);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(false)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description("Set to TRUE to reset all colors like the Windows XP Progress Bar ?")]
        [Category("Xp ProgressBar")]
        public bool ColorsXP
        {
            get => false;
            set
            {
                this.ColorBarBorder = Color.FromArgb(170, 240, 170);
                this.ColorBarCenter = Color.FromArgb(10, 150, 10);
                this.ColorBackGround = Color.White;
            }
        }

        [Category("Xp ProgressBar")]
        [Description("The Color of the text displayed in the Progress Bar")]
        public Color ColorText
        {
            get => this.mColorText;
            set
            {
                this.mColorText = value;
                if (!(this.Text != string.Empty))
                    return;
                this.Invalidate();
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description("The Current Position of the Progress Bar")]
        [Category("Xp ProgressBar")]
        public int Position
        {
            get => this.mPosition;
            set
            {
                this.mPosition = value <= this.mMax ? (value >= this.mMin ? value : this.mMin) : this.mMax;
                this.Invalidate();
            }
        }

        [Description("The Max Position of the Progress Bar")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Xp ProgressBar")]
        public int PositionMax
        {
            get => this.mMax;
            set
            {
                if (value <= this.mMin)
                    return;
                this.mMax = value;
                if (this.mPosition > this.mMax)
                    this.Position = this.mMax;
                this.InvalidateBuffer(true);
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description("The Min Position of the Progress Bar")]
        [Category("Xp ProgressBar")]
        public int PositionMin
        {
            get => this.mMin;
            set
            {
                if (value >= this.mMax)
                    return;
                this.mMin = value;
                if (this.mPosition < this.mMin)
                    this.Position = this.mMin;
                this.InvalidateBuffer(true);
            }
        }

        [Category("Xp ProgressBar")]
        [Description("The number of Pixels between two Steeps in Progress Bar")]
        [DefaultValue(2)]
        public byte SteepDistance
        {
            get => this.mSteepDistance;
            set
            {
                if (value < (byte)0)
                    return;
                this.mSteepDistance = value;
                this.InvalidateBuffer(true);
            }
        }

        [DefaultValue(GradientMode.VerticalCenter)]
        [Category("Xp ProgressBar")]
        [Description("The Style of the gradient bar in Progress Bar")]
        public GradientMode GradientStyle
        {
            get => this.mGradientStyle;
            set
            {
                if (this.mGradientStyle == value)
                    return;
                this.mGradientStyle = value;
                this.CreatePaintElements();
                this.Invalidate();
            }
        }

        [Description("The number of Pixels of the Steeps in Progress Bar")]
        [DefaultValue(6)]
        [Category("Xp ProgressBar")]
        public byte SteepWidth
        {
            get => this.mSteepWidth;
            set
            {
                if (value <= (byte)0)
                    return;
                this.mSteepWidth = value;
                this.InvalidateBuffer(true);
            }
        }

        [Category("Xp ProgressBar")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public override Image BackgroundImage
        {
            get => base.BackgroundImage;
            set
            {
                base.BackgroundImage = value;
                this.InvalidateBuffer();
            }
        }

        [DefaultValue("")]
        [Category("Xp ProgressBar")]
        [Description("The Text displayed in the Progress Bar")]
        public override string Text
        {
            get => base.Text;
            set
            {
                if (!(base.Text != value))
                    return;
                base.Text = value;
                this.Invalidate();
            }
        }

        [Category("Xp ProgressBar")]
        [Description("Set the Text shadow in the Progress Bar")]
        [DefaultValue(true)]
        public bool TextShadow
        {
            get => this.mTextShadow;
            set
            {
                this.mTextShadow = value;
                this.Invalidate();
            }
        }

        [DefaultValue(150)]
        [Category("Xp ProgressBar")]
        [Description("Set the Alpha Channel of the Text shadow in the Progress Bar")]
        public byte TextShadowAlpha
        {
            get => this.mTextShadowAlpha;
            set
            {
                if ((int)this.mTextShadowAlpha == (int)value)
                    return;
                this.mTextShadowAlpha = value;
                this.TextShadow = true;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.IsDisposed)
                return;
            int num1 = (int)this.mSteepWidth + (int)this.mSteepDistance;
            float num2 = (float)(this.Width - 6 + (int)this.mSteepDistance);
            if (this.mDobleBack == null)
            {
                num2 = (float)(this.Width - 6 + (int)this.mSteepDistance);
                int num3 = (int)((double)num2 / (double)num1);
                this.Width = 6 + num1 * num3;
                this.mDobleBack = (Image)new Bitmap(this.Width, this.Height);
                Graphics graphics = Graphics.FromImage(this.mDobleBack);
                this.CreatePaintElements();
                graphics.Clear(this.mColorBackGround);
                if (this.BackgroundImage != null)
                {
                    TextureBrush textureBrush = new TextureBrush(this.BackgroundImage, WrapMode.Tile);
                    graphics.FillRectangle((Brush)textureBrush, 0, 0, this.Width, this.Height);
                    textureBrush.Dispose();
                }
                graphics.DrawRectangle(this.mPenOut2, this.outnnerRect2);
                graphics.DrawRectangle(this.mPenOut, this.outnnerRect);
                graphics.DrawRectangle(this.mPenIn, this.innerRect);
                graphics.Dispose();
            }
            Image image = (Image)new Bitmap(this.mDobleBack);
            Graphics graphics1 = Graphics.FromImage(image);
            int num4 = (int)(((double)this.mPosition - (double)this.mMin) / (double)(this.mMax - this.mMin) * (double)num2 / (double)num1);
            for (int number = 0; number < num4; ++number)
                this.DrawSteep(graphics1, number);
            if (this.Text != string.Empty)
            {
                graphics1.TextRenderingHint = TextRenderingHint.AntiAlias;
                this.DrawCenterString(graphics1, this.ClientRectangle);
            }
            e.Graphics.DrawImage(image, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle, GraphicsUnit.Pixel);
            image.Dispose();
            graphics1.Dispose();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (this.IsDisposed)
                return;
            if (this.Height < 12)
                this.Height = 12;
            base.OnSizeChanged(e);
            this.InvalidateBuffer(true);
        }

        protected override Size DefaultSize => new Size(100, 29);

        private void DrawSteep(Graphics g, int number)
        {
            g.FillRectangle((Brush)this.mBrush1, 4 + number * ((int)this.mSteepDistance + (int)this.mSteepWidth), this.mSteepRect1.Y + 1, (int)this.mSteepWidth, this.mSteepRect1.Height);
            g.FillRectangle((Brush)this.mBrush2, 4 + number * ((int)this.mSteepDistance + (int)this.mSteepWidth), this.mSteepRect2.Y + 1, (int)this.mSteepWidth, this.mSteepRect2.Height - 1);
        }

        private void InvalidateBuffer() => this.InvalidateBuffer(false);

        private void InvalidateBuffer(bool InvalidateControl)
        {
            if (this.mDobleBack != null)
            {
                this.mDobleBack.Dispose();
                this.mDobleBack = (Image)null;
            }
            if (!InvalidateControl)
                return;
            this.Invalidate();
        }

        private void DisposeBrushes()
        {
            if (this.mBrush1 != null)
            {
                this.mBrush1.Dispose();
                this.mBrush1 = (LinearGradientBrush)null;
            }
            if (this.mBrush2 == null)
                return;
            this.mBrush2.Dispose();
            this.mBrush2 = (LinearGradientBrush)null;
        }

        private void DrawCenterString(Graphics gfx, Rectangle box)
        {
            SizeF sizeF = gfx.MeasureString(this.Text, this.Font);
            float x = (float)box.X + (float)(((double)box.Width - (double)sizeF.Width) / 2.0);
            float y = (float)box.Y + (float)(((double)box.Height - (double)sizeF.Height) / 2.0);
            if (this.mTextShadow)
            {
                SolidBrush solidBrush = new SolidBrush(Color.FromArgb((int)this.mTextShadowAlpha, Color.Black));
                gfx.DrawString(this.Text, this.Font, (Brush)solidBrush, x + 1f, y + 1f);
                solidBrush.Dispose();
            }
            SolidBrush solidBrush1 = new SolidBrush(this.mColorText);
            gfx.DrawString(this.Text, this.Font, (Brush)solidBrush1, x, y);
            solidBrush1.Dispose();
        }

        private void CreatePaintElements()
        {
            this.DisposeBrushes();
            switch (this.mGradientStyle)
            {
                case GradientMode.Vertical:
                    this.mSteepRect1 = new Rectangle(0, 3, (int)this.mSteepWidth, this.Height - 7);
                    this.mBrush1 = new LinearGradientBrush(this.mSteepRect1, this.mColor1, this.mColor2, LinearGradientMode.Vertical);
                    this.mSteepRect2 = new Rectangle(-100, -100, 1, 1);
                    this.mBrush2 = new LinearGradientBrush(this.mSteepRect2, this.mColor2, this.mColor1, LinearGradientMode.Horizontal);
                    break;
                case GradientMode.VerticalCenter:
                    this.mSteepRect1 = new Rectangle(0, 2, (int)this.mSteepWidth, this.Height / 2 + (int)((double)this.Height * 0.05));
                    this.mBrush1 = new LinearGradientBrush(this.mSteepRect1, this.mColor1, this.mColor2, LinearGradientMode.Vertical);
                    this.mSteepRect2 = new Rectangle(0, this.mSteepRect1.Bottom - 1, (int)this.mSteepWidth, this.Height - this.mSteepRect1.Height - 4);
                    this.mBrush2 = new LinearGradientBrush(this.mSteepRect2, this.mColor2, this.mColor1, LinearGradientMode.Vertical);
                    break;
                case GradientMode.Horizontal:
                    this.mSteepRect1 = new Rectangle(0, 3, (int)this.mSteepWidth, this.Height - 7);
                    this.mBrush1 = new LinearGradientBrush(this.ClientRectangle, this.mColor1, this.mColor2, LinearGradientMode.Horizontal);
                    this.mSteepRect2 = new Rectangle(-100, -100, 1, 1);
                    this.mBrush2 = new LinearGradientBrush(this.mSteepRect2, Color.Red, Color.Red, LinearGradientMode.Horizontal);
                    break;
                case GradientMode.HorizontalCenter:
                    this.mSteepRect1 = new Rectangle(0, 3, (int)this.mSteepWidth, this.Height - 7);
                    this.mBrush1 = new LinearGradientBrush(this.ClientRectangle, this.mColor1, this.mColor2, LinearGradientMode.Horizontal);
                    this.mBrush1.SetBlendTriangularShape(0.5f);
                    this.mSteepRect2 = new Rectangle(-100, -100, 1, 1);
                    this.mBrush2 = new LinearGradientBrush(this.mSteepRect2, Color.Red, Color.Red, LinearGradientMode.Horizontal);
                    break;
                case GradientMode.Diagonal:
                    this.mSteepRect1 = new Rectangle(0, 3, (int)this.mSteepWidth, this.Height - 7);
                    this.mBrush1 = new LinearGradientBrush(this.ClientRectangle, this.mColor1, this.mColor2, LinearGradientMode.ForwardDiagonal);
                    this.mSteepRect2 = new Rectangle(-100, -100, 1, 1);
                    this.mBrush2 = new LinearGradientBrush(this.mSteepRect2, Color.Red, Color.Red, LinearGradientMode.Horizontal);
                    break;
                default:
                    this.mBrush1 = new LinearGradientBrush(this.mSteepRect1, this.mColor1, this.mColor2, LinearGradientMode.Vertical);
                    this.mBrush2 = new LinearGradientBrush(this.mSteepRect2, this.mColor2, this.mColor1, LinearGradientMode.Vertical);
                    break;
            }
            this.innerRect = new Rectangle(this.ClientRectangle.X + 2, this.ClientRectangle.Y + 2, this.ClientRectangle.Width - 4, this.ClientRectangle.Height - 4);
            this.outnnerRect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
            this.outnnerRect2 = new Rectangle(this.ClientRectangle.X + 1, this.ClientRectangle.Y + 1, this.ClientRectangle.Width, this.ClientRectangle.Height);
        }
    }
}
