using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing.Drawing2D;

namespace Launcher
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer? rainbowTimer;
        private float rainbowOffset = 0f;

        private void RainbowBackgroundOfFOrm1()
        {
            if (rainbowTimer == null)
            {
                rainbowTimer = new System.Windows.Forms.Timer();
                rainbowTimer.Interval = 30;
                rainbowTimer.Tick += RainbowTimer_Tick;
                rainbowTimer.Start();
            }
            DrawRainbowBackground(rainbowOffset);
        }

        private void RainbowTimer_Tick(object? sender, EventArgs e)
        {
            rainbowOffset += 0.01f;
            if (rainbowOffset > 1f) rainbowOffset -= 1f;
            DrawRainbowBackground(rainbowOffset);
        }

        private void DrawRainbowBackground(float offset)
        {
            var colors = new Color[]
            {
                    Color.Red,
                    Color.Orange,
                    Color.Yellow,
                    Color.Green,
                    Color.Blue,
                    Color.Indigo,
                    Color.Violet
            };

            int w = this.Width > 0 ? this.Width : 1;
            int h = this.Height > 0 ? this.Height : 1;
            Bitmap bmp = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Rectangle rect = new Rectangle(0, 0, w, h);
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    rect,
                    Color.Red,
                    Color.Violet,
                    LinearGradientMode.Horizontal))
                {
                    ColorBlend blend = new ColorBlend();
                    blend.Colors = colors;
                    blend.Positions = new float[]
                    {
                            0.0f,
                            0.16f,
                            0.33f,
                            0.5f,
                            0.66f,
                            0.83f,
                            1.0f
                    };

                    float[] shiftedPositions = new float[blend.Positions.Length];
                    for (int i = 0; i < blend.Positions.Length; i++)
                    {
                        shiftedPositions[i] = (blend.Positions[i] + offset) % 1f;
                    }
                    blend.Positions = shiftedPositions;
                    brush.InterpolationColors = blend;
                    g.FillRectangle(brush, rect);
                }
            }
            this.BackgroundImage?.Dispose();
            this.BackgroundImage = bmp;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            rainbowTimer?.Stop();
            rainbowTimer?.Dispose();
            base.OnFormClosed(e);
        }
    }
}


