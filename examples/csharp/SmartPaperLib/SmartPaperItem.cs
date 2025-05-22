namespace SmartPaperLib
{
    public class SmartPaperItem
    {
        public static readonly string STRING_FORMAT_SEPARATOR = "[|SFS|]";
        public static readonly string PAD_TEXT_BLANK = " ";
        public static readonly string STRING_END_OF = "[|SEO|]";

        public string type = SmartPaperItemType.text.ToString();
        public string alignment = SmartPaperItemAlignment.none.ToString();
        public string? textStyle;
        public double? fontSize;
        public int? textMaxLines;
        public string? text;
        public string? textColor;
        public string? textBgColor;
        public string? dividerStyle;
        public double? imageWidth;
        public double? imageHeight;
        public string? imageSrc;

        public static string MakePadString(dynamic data)
        {
            string resultString = string.Empty;
            if (data is PadString || data is List<PadString>)
            {
                List<PadString> padStringList = data is List<PadString> ? data : new List<PadString> { data };
                foreach (PadString padString in padStringList)
                {
                    if (padString.IsValid())
                    {
                        resultString += padString.MakePadString();
                    }
                }
            }
            return resultString;
        }
    }

    public class PadString
    {
        private const string defaultPadText = "";
        public string Text { get; set; }
        public double? Width { get; set; }
        public TextPadType PadType { get; set; } = TextPadType.leftPad;
        public int PadWidth { get; set; } = 0;
        public int PadFlex { get; set; } = 1;
        public string PadText { get; set; } = defaultPadText;
        public SmartPaperItemAlignment Alignment { get; set; } = SmartPaperItemAlignment.none;

        public PadString(string text, double? width = null, TextPadType padType = TextPadType.leftPad, int padFlex = 1, string padText = defaultPadText, SmartPaperItemAlignment alignment = SmartPaperItemAlignment.none)
        {
            Text = text;
            Width = width;
            PadType = padType;
            PadFlex = padFlex;
            PadText = padText;
            Alignment = alignment;
        }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Text) &&
                   ((Alignment == SmartPaperItemAlignment.none && TextPadTypeExtensions.ValidTextPadType(PadType) && !string.IsNullOrEmpty(PadText) && PadWidth >= 0) || Alignment != SmartPaperItemAlignment.none);
        }

        public string MakePadString()
        {
            if (IsValid())
            {
                return Alignment != SmartPaperItemAlignment.none
                    ? $"{Text}{SmartPaperItem.STRING_FORMAT_SEPARATOR}{PadFlex}{SmartPaperItem.STRING_FORMAT_SEPARATOR}{Alignment.ToString()}{SmartPaperItem.STRING_END_OF}"
                    : $"{Text}{SmartPaperItem.STRING_FORMAT_SEPARATOR}{PadFlex}{SmartPaperItem.STRING_FORMAT_SEPARATOR}{PadType.ToString()}{SmartPaperItem.STRING_FORMAT_SEPARATOR}{PadWidth}{SmartPaperItem.STRING_FORMAT_SEPARATOR}{PadText}{SmartPaperItem.STRING_END_OF}";
            }
            else
            {
                return string.Empty;
            }
        }

        public static string MakePadStringList(List<PadString> padStringList)
        {
            string resultString = string.Empty;
            foreach (PadString padString in padStringList)
            {
                resultString += padString.MakePadString();
            }
            return resultString;
        }
    }

    public enum SmartPaperItemType
    {
        image = 0,
        text = 1,
        imageAndText = 2,
        textAndImage = 3,
        divider = 4,
        barcode = 5,
        qrCode = 6
    }

    public enum SmartPaperItemAlignment
    {
        topLeft = 0x11,
        topCenter = 0x110,
        topRight = 0x12,
        centerLeft = 0x101,
        center = 0x100,
        centerRight = 0x102,
        bottomLeft = 0x21,
        bottomCenter = 0x120,
        bottomRight = 0x22,
        none = 0
    }

    public enum SmartPaperItemTextStyle
    {
        // FontStyle
        normal = 0x00000001, italic = 0x00000002,
        // FontWeight
        bold = 0x00000100,
        // TextDecoration
        underline = 0x00010000, Overline = 0x00020000, lineThrough = 0x00040000,
        // FontStyle & FontWeight
        normalAndBold = 0x00000101, italicAndBold = 0x00000102,
        // FontStyle & TextDecoration
        normalAndUnderline = 0x00010001, normalAndOverline = 0x00020001, normalAndLineThrough = 0x00040001,
        italicAndUnderline = 0x00010002, italicAndOverline = 0x00020002, italicAndLineThrough = 0x00040002,
        // FontStyle & FontWeight & TextDecoration
        normalAndBoldAndUnderline = 0x00010101, normalAndBoldAndOverline = 0x00020101, normalAndBoldAndLineThrough = 0x00040101,
        italicAndBoldAndUnderline = 0x00010102, italicAndBoldAndOverline = 0x00020102, italicAndBoldAndLineThrough = 0x00040102
    }

    public enum SmartPaperItemDividerStyle
    {
        pipe = 0,
        slash = 1,
        backSlash = 2,
        hyphen = 3,
        sharp = 4,
        plus = 5,
        star = 6,
        exclamation = 7,
        at = 8,
        dollar = 9,
        percent = 10,
        caret = 11,
        ampersand = 12,
        blank = 13,
        equal = 14,
        underscore = 15,
        dot = 16,
        comma = 17,
        custom = 99,
        none = -1
    }

    public static class SmartPaperItemDividerStyleExtensions
    {
        public static int GetValue(this SmartPaperItemDividerStyle style)
        {
            return (int)style;
        }

        public static SmartPaperItemDividerStyle ParseValue(int value)
        {
            return Enum.IsDefined(typeof(SmartPaperItemDividerStyle), value) ? (SmartPaperItemDividerStyle)value : SmartPaperItemDividerStyle.none;
        }

        public static SmartPaperItemDividerStyle ParseName(string name)
        {
            return Enum.TryParse<SmartPaperItemDividerStyle>(name, out var style) ? style : SmartPaperItemDividerStyle.none;
        }

        public static string GetDivider(int value)
        {
            return value switch
            {
                0 => "|",
                1 => "/",
                2 => "\\",
                3 => "-",
                4 => "#",
                5 => "+",
                6 => "*",
                7 => "!",
                8 => "@",
                9 => "$",
                10 => "%",
                11 => "^",
                12 => "&",
                13 => " ",
                14 => "=",
                15 => "_",
                16 => ".",
                17 => ",",
                _ => string.Empty,
            };
        }
    }

    public enum TextPadType
    {
        leftPad = 0,
        rightPad = 1
    }

    public static class TextPadTypeExtensions
    {
        public static int GetValue(this TextPadType type)
        {
            return (int)type;
        }

        public static TextPadType ParseValue(int value)
        {
            return Enum.IsDefined(typeof(TextPadType), value) ? (TextPadType)value : TextPadType.leftPad;
        }

        public static TextPadType ParseName(string name)
        {
            return name == nameof(TextPadType.rightPad) ? TextPadType.rightPad : TextPadType.leftPad;
        }

        public static bool ValidTextPadType(TextPadType textPadType)
        {
            return textPadType == TextPadType.leftPad || textPadType == TextPadType.rightPad;
        }
    }
}
