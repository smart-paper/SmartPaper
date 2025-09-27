using SmartPaperLib;

namespace SmartPaperExample
{
    public class SmartPaperHelper
    {
        public static SmartRecordLine MakePadStringLine(dynamic data, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none, SmartRecordLineTextStyle textStyle = SmartRecordLineTextStyle.normal, double? textSize = null, string? textColor = null, string? textBgColor = null)
        {
            return PadStringLine(text: SmartRecordLine.MakePadString(data), alignment: alignment, textStyle: textStyle, textSize: textSize, textColor: textColor, textBgColor: textBgColor);
        }

        public static SmartRecordLine PadStringLine(string text, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none, SmartRecordLineTextStyle? textStyle = null, 
            double? textSize = null, string? textColor = null, string? textBgColor = null)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.text.ToString();
            item.text = text;
            item.alignment = alignment.ToString();
            item.textStyle = textStyle.ToString();
            item.textSize = textSize;
            item.textColor = textColor;
            item.textBgColor = textBgColor;
            return item;
        }

        public static SmartRecordLine Image(string mediaSrc, double width, double height, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.image.ToString();
            item.mediaSrc = mediaSrc;
            item.width = width;
            item.height = height;
            item.alignment = alignment.ToString();
            return item;
        }

        public static SmartRecordLine Text(string text, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none, SmartRecordLineTextStyle textStyle = SmartRecordLineTextStyle.normal,
                double? textSize = null, int? textMaxLines = null, string? textColor = null, string? textBgColor = null)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.text.ToString();
            item.text = text;
            item.alignment = alignment.ToString();
            item.textSize = textSize;
            item.textMaxLines = textMaxLines;
            item.textColor = textColor;
            item.textBgColor = textBgColor;
            item.textStyle = textStyle.ToString();
            return item;
        }

        public static SmartRecordLine Divider(SmartRecordLineDividerStyle dividerStyle, double? textSize = null, double? blankRatio = null, string? textColor = null, string? textBgColor = null)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.divider.ToString();
            item.dividerStyle = dividerStyle.ToString();
            item.textSize = textSize;
            item.blankRatio = blankRatio;
            item.textColor = textColor;
            item.textBgColor = textBgColor;
            return item;
        }

        public static SmartRecordLine Barcode(string text, double width, double height, SmartRecordLineAlignment barcodeAlignment = SmartRecordLineAlignment.none, SmartRecordLineAlignment textAlignment = SmartRecordLineAlignment.none,
            double? textSize = null, int? textMaxLines = null, string? textColor = null, string? textBgColor = null, SmartRecordLineTextStyle textStyle = SmartRecordLineTextStyle.normal)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.barcode.ToString();
            item.text = text;
            item.textSize = textSize;
            item.textMaxLines = textMaxLines;
            item.textColor = textColor;
            item.textBgColor = textBgColor;
            item.textStyle = textStyle.ToString();
            item.width = width;
            item.height = height;
            item.alignment = barcodeAlignment.ToString();
            return item;
        }

        public static SmartRecordLine QrCode(string text, double width, double height, SmartRecordLineAlignment qrCodeAlignment = SmartRecordLineAlignment.none, SmartRecordLineAlignment textAlignment = SmartRecordLineAlignment.none,
            double? textSize = null, int? textMaxLines = null, string? textColor = null, string? textBgColor = null, SmartRecordLineTextStyle textStyle = SmartRecordLineTextStyle.normal)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.qrCode.ToString();
            item.text = text;
            item.textSize = textSize;
            item.textMaxLines = textMaxLines;
            item.textColor = textColor;
            item.textBgColor = textBgColor;
            item.textStyle = textStyle.ToString();
            item.width = width;
            item.height = height;
            item.alignment = qrCodeAlignment.ToString();
            return item;
        }

        public static SmartRecordLine List(List<SmartRecordLine> listItems, string listTitle, ListType? listType = ListType.normal, double? listTitleSize = null, double? width = null, double? height = null, string? listTitleColor = null, string? listTitleBgColor = null, double? listTextSize = null, string? listTextColor = null, string? listTextBgColor = null, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.list.ToString();
            item.listItems = listItems;
            item.listType = listType?.ToString();
            item.title = listTitle;
            item.titleSize = listTitleSize;
            item.width = width;
            item.height = height;
            item.titleColor = listTitleColor;
            item.titleBgColor = listTitleBgColor;
            item.textSize = listTextSize;
            item.textColor = listTextColor;
            item.textBgColor = listTextBgColor;
            item.alignment = alignment.ToString();
            return item;
        }

        public static SmartRecordLine Button(string buttonText, ActionType buttonAction, string? buttonActionUrl = null, double? width = null, double? height = null, double? buttonTextSize = null, string? buttonTextColor = null, string? buttonTextBgColor = null, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.button.ToString();
            item.text = buttonText;
            item.textSize = buttonTextSize;
            item.actionType = buttonAction.ToString();
            item.actionUrl = buttonActionUrl;
            item.width = width;
            item.height = height;
            item.textColor = buttonTextColor;
            item.textBgColor = buttonTextBgColor;
            item.alignment = alignment.ToString();
            return item;
        }

        public static SmartRecordLine Timer(int timerInMillis, ActionType timerAction, string? timerActionUrl = null, TimerType timerType = TimerType.normal, string? timerText = null, double? timerTextSize = null, string? timerTextColor = null, string? timerTextBgColor = null, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.timer.ToString();
            item.millis = timerInMillis;
            item.text = timerText;
            item.textSize = timerTextSize;
            item.textColor = timerTextColor;
            item.textBgColor = timerTextBgColor;
            item.type = timerType.ToString();
            item.actionType = timerAction.ToString();
            item.actionUrl = timerActionUrl;
            item.alignment = alignment.ToString();
            return item;
        }

        public static SmartRecordLine Video(string mediaSrc, bool? isVideoLooping, double width, double height, string? videoTitle = null, double? videoTitleSize = null, string? videoTitleColor = null, string? videoTitleBgColor = null, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.video.ToString();
            item.mediaSrc = mediaSrc;
            item.isLooping = isVideoLooping;
            item.width = width;
            item.height = height;
            item.title = videoTitle;
            item.titleSize = videoTitleSize;
            item.titleColor = videoTitleColor;
            item.titleBgColor = videoTitleBgColor;
            item.alignment = alignment.ToString();
            return item;
        }

        public static SmartRecordLine Audio(string mediaSrc, bool? isAudioLooping, string? audioTitle = null, double? audioTitleSize = null, string? audioTitleColor = null, string? audioTitleBgColor = null, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.audio.ToString();
            item.mediaSrc = mediaSrc;
            item.isLooping = isAudioLooping;
            item.title = audioTitle;
            item.titleSize = audioTitleSize;
            item.titleColor = audioTitleColor;
            item.titleBgColor = audioTitleBgColor;
            item.alignment = alignment.ToString();
            return item;
        }

        public static SmartRecordLine Alarm(long alarmDatetime, string alarmTitle, double? alarmTitleSize = null, string? alarmTitleColor = null, string? alarmTitleBgColor = null, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.alarm.ToString();
            item.datetime = alarmDatetime;
            item.title = alarmTitle;
            item.titleSize = alarmTitleSize;
            item.titleColor = alarmTitleColor;
            item.titleBgColor = alarmTitleBgColor;
            item.alignment = alignment.ToString();
            return item;
        }

        public static SmartRecordLine Document(string mediaSrc, string? documentTitle = null, double? documentTitleSize = null, string? documentTitleColor = null, string? documentTitleBgColor = null, double? width = null, double? height = null, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.document.ToString();
            item.mediaSrc = mediaSrc;
            item.title = documentTitle;
            item.titleSize = documentTitleSize;
            item.titleColor = documentTitleColor;
            item.titleBgColor = documentTitleBgColor;
            item.width = width;
            item.height = height;
            item.alignment = alignment.ToString();
            return item;
        }

        public static SmartRecordLine Url(string url, string urlTitle, double? urlTitleSize = null, string? urlTitleColor = null, string? urlTitleBgColor = null, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.url.ToString();
            item.url = url;
            item.title = urlTitle;
            item.titleSize = urlTitleSize;
            item.titleColor = urlTitleColor;
            item.titleBgColor = urlTitleBgColor;
            item.alignment = alignment.ToString();
            return item;
        }

        public static SmartRecordLine Group(List<SmartRecordLine> group, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.group.ToString();
            item.group = group;
            item.alignment = alignment.ToString();
            return item;
        }
    }
}
