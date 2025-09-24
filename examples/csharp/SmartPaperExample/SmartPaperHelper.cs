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
            item.textAlignment = alignment.ToString();
            item.textStyle = textStyle.ToString();
            item.textSize = textSize;
            item.textColor = textColor;
            item.textBgColor = textBgColor;
            return item;
        }

        public static SmartRecordLine Image(string imageSrc, double imageWidth, double imageHeight, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.image.ToString();
            item.imageSrc = imageSrc;
            item.imageWidth = imageWidth;
            item.imageHeight = imageHeight;
            item.imageAlignment = alignment.ToString();
            return item;
        }

        public static SmartRecordLine Text(string text, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none, SmartRecordLineTextStyle textStyle = SmartRecordLineTextStyle.normal,
                double? textSize = null, int? textMaxLines = null, string? textColor = null, string? textBgColor = null)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.text.ToString();
            item.text = text;
            item.textAlignment = alignment.ToString();
            item.textSize = textSize;
            item.textMaxLines = textMaxLines;
            item.textColor = textColor;
            item.textBgColor = textBgColor;
            item.textStyle = textStyle.ToString();
            return item;
        }

        public static SmartRecordLine ImageAndText(string imageSrc, double imageWidth, double imageHeight, string text, SmartRecordLineAlignment imageAlignment = SmartRecordLineAlignment.none, SmartRecordLineAlignment textAlignment = SmartRecordLineAlignment.none,
            double? textSize = null, int? textMaxLines = null, string? textColor = null, string? textBgColor = null, SmartRecordLineTextStyle textStyle = SmartRecordLineTextStyle.normal)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.image.ToString();
            item.imageSrc = imageSrc;
            item.imageWidth = imageWidth;
            item.imageHeight = imageHeight;
            item.imageAlignment = imageAlignment.ToString();
            item.text = text;
            item.textAlignment = textAlignment.ToString();
            item.textSize = textSize;
            item.textMaxLines = textMaxLines;
            item.textColor = textColor;
            item.textBgColor = textBgColor;
            item.textStyle = textStyle.ToString();
            return item;
        }

        public static SmartRecordLine TextAndImage(string imageSrc, double imageWidth, double imageHeight, string text, SmartRecordLineAlignment imageAlignment = SmartRecordLineAlignment.none, SmartRecordLineAlignment textAlignment = SmartRecordLineAlignment.none,
            double? textSize = null, int? textMaxLines = null, string? textColor = null, string? textBgColor = null, SmartRecordLineTextStyle textStyle = SmartRecordLineTextStyle.normal)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.image.ToString();
            item.imageSrc = imageSrc;
            item.imageWidth = imageWidth;
            item.imageHeight = imageHeight;
            item.imageAlignment = imageAlignment.ToString();
            item.text = text;
            item.textAlignment = textAlignment.ToString();
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

        public static SmartRecordLine Barcode(string text, double imageWidth, double imageHeight, SmartRecordLineAlignment barcodeAlignment = SmartRecordLineAlignment.none, SmartRecordLineAlignment textAlignment = SmartRecordLineAlignment.none,
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
            item.imageWidth = imageWidth;
            item.imageHeight = imageHeight;
            item.imageAlignment = barcodeAlignment.ToString();
            item.textAlignment = textAlignment.ToString();
            return item;
        }

        public static SmartRecordLine QrCode(string text, double imageWidth, double imageHeight, SmartRecordLineAlignment qrCodeAlignment = SmartRecordLineAlignment.none, SmartRecordLineAlignment textAlignment = SmartRecordLineAlignment.none,
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
            item.imageWidth = imageWidth;
            item.imageHeight = imageHeight;
            item.imageAlignment = qrCodeAlignment.ToString();
            item.textAlignment = textAlignment.ToString();
            return item;
        }

        public static SmartRecordLine List(List<SmartRecordLine> listItems, string listTitle, ListType? listType = ListType.normal, double? listTitleSize = null, double? listWidth = null, double? listHeight = null, string? listTitleColor = null, string? listTitleBgColor = null, double? listTextSize = null, string? listTextColor = null, string? listTextBgColor = null, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.list.ToString();
            item.listItems = listItems;
            item.listType = listType?.ToString();
            item.listTitle = listTitle;
            item.listTitleSize = listTitleSize;
            item.listWidth = listWidth;
            item.listHeight = listHeight;
            item.listTitleColor = listTitleColor;
            item.listTitleBgColor = listTitleBgColor;
            item.listTextSize = listTextSize;
            item.listTextColor = listTextColor;
            item.listTextBgColor = listTextBgColor;
            item.listAlignment = alignment.ToString();
            return item;
        }

        public static SmartRecordLine Button(string buttonText, ActionType buttonAction, string? buttonRestfulApi = null, double? buttonWidth = null, double? buttonHeight = null, double? buttonTextSize = null, string? buttonTextColor = null, string? buttonTextBgColor = null, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.button.ToString();
            item.buttonText = buttonText;
            item.buttonTextSize = buttonTextSize;
            item.buttonAction = buttonAction.ToString();
            item.buttonRestfulApi = buttonRestfulApi;
            item.buttonWidth = buttonWidth;
            item.buttonHeight = buttonHeight;
            item.buttonTextColor = buttonTextColor;
            item.buttonTextBgColor = buttonTextBgColor;
            item.buttonAlignment = alignment.ToString();
            return item;
        }

        public static SmartRecordLine Timer(int timerInMillis, ActionType timerAction, TimerType timerType = TimerType.normal, string? timerText = null, string? timerRestfulApi = null, double? timerTextSize = null, string? timerTextColor = null, string? timerTextBgColor = null, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.timer.ToString();
            item.timerInMillis = timerInMillis;
            item.timerText = timerText;
            item.timerTextSize = timerTextSize;
            item.timerTextColor = timerTextColor;
            item.timerTextBgColor = timerTextBgColor;
            item.timerType = timerType.ToString();
            item.timerAction = timerAction.ToString();
            item.timerRestfulApi = timerRestfulApi;
            item.timerAlignment = alignment.ToString();
            return item;
        }

        public static SmartRecordLine Video(string videoSrc, double videoWidth, double videoHeight, string? videoTitle = null, double? videoTitleSize = null, string? videoTitleColor = null, string? videoTitleBgColor = null, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.video.ToString();
            item.videoSrc = videoSrc;
            item.videoWidth = videoWidth;
            item.videoHeight = videoHeight;
            item.videoTitle = videoTitle;
            item.videoTitleSize = videoTitleSize;
            item.videoTitleColor = videoTitleColor;
            item.videoTitleBgColor = videoTitleBgColor;
            item.videoAlignment = alignment.ToString();
            return item;
        }

        public static SmartRecordLine Audio(string audioSrc, string? audioTitle = null, double? audioTitleSize = null, string? audioTitleColor = null, string? audioTitleBgColor = null, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.audio.ToString();
            item.audioSrc = audioSrc;
            item.audioTitle = audioTitle;
            item.audioTitleSize = audioTitleSize;
            item.audioTitleColor = audioTitleColor;
            item.audioTitleBgColor = audioTitleBgColor;
            item.audioAlignment = alignment.ToString();
            return item;
        }

        public static SmartRecordLine Alarm(long alarmDatetime, string alarmTitle, double? alarmTitleSize = null, string? alarmTitleColor = null, string? alarmTitleBgColor = null, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.alarm.ToString();
            item.alarmDatetime = alarmDatetime;
            item.alarmTitle = alarmTitle;
            item.alarmTitleSize = alarmTitleSize;
            item.alarmTitleColor = alarmTitleColor;
            item.alarmTitleBgColor = alarmTitleBgColor;
            item.alarmAlignment = alignment.ToString();
            return item;
        }

        public static SmartRecordLine Document(string documentSrc, string? documentTitle = null, double? documentTitleSize = null, string? documentTitleColor = null, string? documentTitleBgColor = null, double? documentWidth = null, double? documentHeight = null, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.document.ToString();
            item.documentSrc = documentSrc;
            item.documentTitle = documentTitle;
            item.documentTitleSize = documentTitleSize;
            item.documentTitleColor = documentTitleColor;
            item.documentTitleBgColor = documentTitleBgColor;
            item.documentWidth = documentWidth;
            item.documentHeight = documentHeight;
            item.documentAlignment = alignment.ToString();
            return item;
        }

        public static SmartRecordLine Url(string url, string urlTitle, double? urlTitleSize = null, string? urlTitleColor = null, string? urlTitleBgColor = null, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.url.ToString();
            item.url = url;
            item.urlTitle = urlTitle;
            item.urlTitleSize = urlTitleSize;
            item.urlTitleColor = urlTitleColor;
            item.urlTitleBgColor = urlTitleBgColor;
            item.urlAlignment = alignment.ToString();
            return item;
        }
    }
}
