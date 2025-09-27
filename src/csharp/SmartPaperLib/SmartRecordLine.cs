namespace SmartPaperLib
{
    public class SmartRecordLine
    {
        public static readonly string STRING_FORMAT_SEPARATOR = "[|SFS|]";
        public static readonly string PAD_TEXT_BLANK = " ";
        public static readonly string STRING_END_OF = "[|SEO|]";

        /// Common
        public string type = SmartRecordLineType.text.ToString();
        public string alignment = SmartRecordLineAlignment.none.ToString();
        public double? width;
        public double? height;
        /// Text
        public string? textStyle;
        public double? textSize;
        public int? textMaxLines;
        public string? text;
        public string? textColor;
        public string? textBgColor;
        /// Title
        public string? titleStyle;
        public double? titleSize;
        public int? titleMaxLines;
        public string? title;
        public string? titleColor;
        public string? titleBgColor;
        public string? mediaSrc;
        public bool? isLooping;
        public string? actionType;
        public int? millis;
        public long? datetime; // yyyyMMddHHmmss
        public string? actionUrl;
        public string? url;
        public double? blankRatio;
        public string? dividerStyle;
        /// Image
        /// List
        public string? listType;
        public List<SmartRecordLine>? listItems;
        /// Button
        // String? buttonType;
        /// Timer
        public string? timerType;
        /// Video
        /// Audio
        /// Alarm
        /// Document
        /// URL
        /// Group
        public List<SmartRecordLine>? group;
        /// Background Color
        public string bgColor = "#00000000";

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
        public SmartRecordLineAlignment Alignment { get; set; } = SmartRecordLineAlignment.none;

        public PadString(string text, double? width = null, TextPadType padType = TextPadType.leftPad, int padFlex = 1, string padText = defaultPadText, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
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
                   ((Alignment == SmartRecordLineAlignment.none && TextPadTypeExtensions.ValidType(PadType) && !string.IsNullOrEmpty(PadText) && PadWidth >= 0) || Alignment != SmartRecordLineAlignment.none);
        }

        public string MakePadString()
        {
            if (IsValid())
            {
                return Alignment != SmartRecordLineAlignment.none
                    ? $"{Text}{SmartRecordLine.STRING_FORMAT_SEPARATOR}{PadFlex}{SmartRecordLine.STRING_FORMAT_SEPARATOR}{Alignment.ToString()}{SmartRecordLine.STRING_END_OF}"
                    : $"{Text}{SmartRecordLine.STRING_FORMAT_SEPARATOR}{PadFlex}{SmartRecordLine.STRING_FORMAT_SEPARATOR}{PadType.ToString()}{SmartRecordLine.STRING_FORMAT_SEPARATOR}{PadWidth}{SmartRecordLine.STRING_FORMAT_SEPARATOR}{PadText}{SmartRecordLine.STRING_END_OF}";
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

    public enum SmartRecordLineType
    {
        image = 0x0000,
        text = 0x0001,
        divider = 0x0004,
        barcode = 0x0005,
        qrCode = 0x0006,
        list = 0x0007,
        button = 0x0008,
        timer = 0x0008,
        video = 0x000A,
        audio = 0x000B,
        alarm = 0x000C,
        document = 0x000D,
        url = 0x000E,
        group = 0x000F,
    }

    public enum SmartRecordLineAlignment
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

    public enum SmartRecordLineTextStyle
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

    public enum SmartRecordLineDividerStyle
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

    public static class SmartRecordLineDividerStyleExtensions
    {
        public static int GetValue(this SmartRecordLineDividerStyle style)
        {
            return (int)style;
        }

        public static SmartRecordLineDividerStyle ParseValue(int value)
        {
            return Enum.IsDefined(typeof(SmartRecordLineDividerStyle), value) ? (SmartRecordLineDividerStyle)value : SmartRecordLineDividerStyle.none;
        }

        public static SmartRecordLineDividerStyle ParseName(string name)
        {
            return Enum.TryParse<SmartRecordLineDividerStyle>(name, out var style) ? style : SmartRecordLineDividerStyle.none;
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

        public static bool ValidType(TextPadType textPadType)
        {
            return textPadType == TextPadType.leftPad || textPadType == TextPadType.rightPad;
        }
    }

    public enum ActionType
    {
        unknown = -1,
        ActionURL = 0,
        refresh = 1,
        autoRefresh = 2
    }

    public static class ActionTypeExtensions
    {
        public static int GetValue(this ActionType type)
        {
            return (int)type;
        }

        public static ActionType ParseValue(int value)
        {
            return Enum.IsDefined(typeof(ActionType), value) ? (ActionType)value : ActionType.unknown;
        }

        public static ActionType? ParseName(string? name)
        {
            if (name == null) return null;
            return name switch
            {
                nameof(ActionType.ActionURL) => ActionType.ActionURL,
                nameof(ActionType.refresh) => ActionType.refresh,
                nameof(ActionType.autoRefresh) => ActionType.autoRefresh,
                _ => ActionType.unknown
            };
        }

        public static bool ValidType(ActionType type)
        {
            return type >= ActionType.ActionURL && type <= ActionType.autoRefresh;
        }
    }

    public enum ListType
    {
        normal = 0,
        fold = 1,
        combobox = 2
    }

    public static class ListTypeExtensions
    {
        public static int GetValue(this ListType type)
        {
            return (int)type;
        }

        public static ListType ParseValue(int value)
        {
            return Enum.IsDefined(typeof(ListType), value) ? (ListType)value : ListType.normal;
        }

        public static ListType? ParseName(string? name)
        {
            if (name == null) return null;
            return name switch
            {
                nameof(ListType.fold) => ListType.fold,
                nameof(ListType.combobox) => ListType.combobox,
                _ => ListType.normal
            };
        }

        public static bool ValidType(ListType type)
        {
            return type >= ListType.normal && type <= ListType.combobox;
        }
    }

    public enum TimerType
    {
        normal = 0,
        validTime = 1,
        autoRefresh = 2
    }

    public static class TimerTypeExtensions
    {
        public static int GetValue(this TimerType type)
        {
            return (int)type;
        }

        public static TimerType ParseValue(int value)
        {
            return Enum.IsDefined(typeof(TimerType), value) ? (TimerType)value : TimerType.normal;
        }

        public static TimerType? ParseName(string? name)
        {
            if (name == null) return null;
            return name switch
            {
                nameof(TimerType.validTime) => TimerType.validTime,
                nameof(TimerType.autoRefresh) => TimerType.autoRefresh,
                _ => TimerType.normal
            };
        }

        public static bool ValidType(TimerType type)
        {
            return type >= TimerType.normal && type <= TimerType.autoRefresh;
        }
    }
}
