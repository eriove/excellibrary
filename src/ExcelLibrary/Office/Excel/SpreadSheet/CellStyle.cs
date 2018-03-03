#if FEATURE_SYSTEMDRAWING
using System.Drawing;
#else
using Color=SkiaSharp.SKColor;
#endif
using ExcelLibrary.BinaryFileFormat;

namespace ExcelLibrary.SpreadSheet
{
    public class CellStyle
    {
        public Color BackColor = PredefinedColors.White;
        public RichTextFormat RichTextFormat;
    }
}
