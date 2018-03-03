#if FEATURE_SYSTEMDRAWING
using System.Drawing;
#else
using Color=SkiaSharp.SKColor;
#endif

namespace ExcelLibrary.BinaryFileFormat
{
    internal static class PredefinedColors
    {
#if FEATURE_SYSTEMDRAWING
        public static Color Black => Color.Black;
        public static Color White => Color.White;
        public static Color Red => Color.Red;
        public static Color Green => Color.Green;
        public static Color Blue => Color.Blue;
        public static Color Yellow => Color.Yellow;
        public static Color Magenta => Color.Magenta;
        public static Color Cyan => Color.Cyan;

        public static Color Window=>SystemColors.Window;
        public static Color WindowText=>SystemColors.WindowText;
        public static Color WindowFrame=>SystemColors.WindowFrame;//dialogue background colour
        public static Color ControlText=>SystemColors.ControlText;//text colour for chart border lines
        public static Color Control=>SystemColors.Control; //background colour for chart areas
        public static Color Info=>SystemColors.Info;
        public static Color InfoText=>SystemColors.InfoText;
#else
            public static Color Black => new Color(255,0,0,0);
            public static Color White => new Color(255,255,255,255);
            public static Color Red => new Color(255,255,0,0);
            public static Color Green => new Color(255,0,128,0);
            public static Color Blue => new Color(255,0,0,255);
            public static Color Yellow =>new Color(255,255,255,0);
            public static Color Magenta => new Color(255,255,0,255);
            public static Color Cyan => new Color(255,0,255,255);
            public static Color Window=> new Color(255,255,255,255);
            public static Color WindowText=>new Color(255,0,0,0);
            public static Color WindowFrame=> new Color(255,100,100,100);
            public static Color ControlText=>new Color(255,0,0,0);//text colour for chart border lines
            public static Color Control=>new Color(255,240,240,240); //background colour for chart areas
            public static Color Info=>new Color(255,255,255,255);
            public static Color InfoText=>new Color(255,0,0,0);
#endif
    }
}