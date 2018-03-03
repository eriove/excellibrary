using System;
using System.Collections.Generic;
using System.Text;
#if FEATURE_SYSTEMDRAWING
using System.Drawing;
#else
using Color=SkiaSharp.SKColor;
#endif
namespace ExcelLibrary.BinaryFileFormat
{
    public class ColorPalette
    {
        public Dictionary<int, Color> Palette = new Dictionary<int, Color>();

        public ColorPalette()
        {
            Palette.Add(0, PredefinedColors.Black);
            Palette.Add(1, PredefinedColors.White);
            Palette.Add(2, PredefinedColors.Red);
            Palette.Add(3, PredefinedColors.Green);
            Palette.Add(4, PredefinedColors.Blue);
            Palette.Add(5, PredefinedColors.Yellow);
            Palette.Add(6, PredefinedColors.Magenta);
            Palette.Add(7, PredefinedColors.Cyan);
            // 0x08-0x3F: default color table
            Palette.Add(0x08, FromArgb(0, 0, 0));
            Palette.Add(0x09, FromArgb(0xFF, 0xFF, 0xFF));
            Palette.Add(0x0A, FromArgb(0xFF, 0, 0));

            Palette.Add(0x1F, FromArgb(0xCC, 0xCC, 0xFF));

            Palette.Add(0x38, FromArgb(0x00, 0x33, 0x66));
            Palette.Add(0x39, FromArgb(0x33, 0x99, 0x66));
            Palette.Add(0x3A, FromArgb(0x00, 0x33, 0x00));
            Palette.Add(0x3B, FromArgb(0x33, 0x33, 0x00));
            Palette.Add(0x3C, FromArgb(0x99, 0x33, 0x00));
            Palette.Add(0x3D, FromArgb(0x99, 0x33, 0x66));
            Palette.Add(0x3E, FromArgb(0x33, 0x33, 0x99));
            Palette.Add(0x3F, FromArgb(0x33, 0x33, 0x33));

            Palette.Add(0x40, PredefinedColors.Window);
            Palette.Add(0x41, PredefinedColors.WindowText);
            Palette.Add(0x43, PredefinedColors.WindowFrame);//dialogue background colour
            Palette.Add(0x4D, PredefinedColors.ControlText);//text colour for chart border lines
            Palette.Add(0x4E, PredefinedColors.Control); //background colour for chart areas
            Palette.Add(0x4F, PredefinedColors.Black); //Automatic colour for chart border lines
            Palette.Add(0x50, PredefinedColors.Info);
            Palette.Add(0x51, PredefinedColors.InfoText);
            Palette.Add(0x7FFF, PredefinedColors.WindowText);
        }

        private static Color FromArgb(byte red, byte green, byte blue)
        {
#if FEATURE_SYSTEMDRAWING
            return Color.FromArgb(red, green, blue);
#else
            return new Color(red,green,blue);
#endif

        }

        public Color this[int index]
        {
            get
            {
                if (Palette.ContainsKey(index))
                {
                    return Palette[index];
                }
                return PredefinedColors.White;
            }
            set
            {
                Palette[index] = value;
            }
        }
    }
}
