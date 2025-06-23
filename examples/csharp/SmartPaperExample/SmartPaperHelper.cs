using SmartPaperLib;

namespace SmartPaperExample
{
    public class SmartPaperHelper
    {
        public static SmartRecordLine PadStringLine(string text, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none, SmartRecordLineTextStyle? textStyle = null, 
            double? fontSize = null, String? textColor = null, String? textBgColor = null)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.text.ToString();
            item.text = text;
            item.textAlignment = alignment.ToString();
            item.textStyle = textStyle.ToString();
            item.fontSize = fontSize;
            item.textColor = textColor;
            item.textBgColor = textBgColor;
            return item;
        }

        public static SmartRecordLine Text(string text, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none,
                double? fontSize = null, SmartRecordLineTextStyle textStyle = SmartRecordLineTextStyle.normal)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.text.ToString();
            item.text = text;
            item.textAlignment = alignment.ToString();
            item.fontSize = fontSize;
            item.textStyle = textStyle.ToString();
            return item;
        }

        public static SmartRecordLine Divider(SmartRecordLineDividerStyle dividerStyle, double? fontSize = null)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.divider.ToString();
            item.dividerStyle = dividerStyle.ToString();
            item.fontSize = fontSize;
            return item;
        }

        public static SmartRecordLine Image(string imageSrc, double imageWidth, double imageHeight, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.image.ToString();
            item.imageSrc = imageSrc;
            item.imageWidth = imageWidth;
            item.imageHeight = imageHeight;
            item.textAlignment = alignment.ToString();
            return item;
        }

        public static SmartRecordLine ImageAndText(string imageSrc, double imageWidth, double imageHeight, string text, SmartRecordLineAlignment imageAlignment = SmartRecordLineAlignment.none, SmartRecordLineAlignment textAlignment = SmartRecordLineAlignment.none,
            double? fontSize = null, SmartRecordLineTextStyle textStyle = SmartRecordLineTextStyle.normal)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.image.ToString();
            item.imageSrc = imageSrc;
            item.imageWidth = imageWidth;
            item.imageHeight = imageHeight;
            item.imageAlignment = imageAlignment.ToString();
            item.text = text;
            item.textAlignment = textAlignment.ToString();
            item.fontSize = fontSize;
            item.textStyle = textStyle.ToString();
            return item;
        }

        public static SmartRecordLine TextAndImage(string imageSrc, double imageWidth, double imageHeight, string text, SmartRecordLineAlignment imageAlignment = SmartRecordLineAlignment.none, SmartRecordLineAlignment textAlignment = SmartRecordLineAlignment.none,
            double? fontSize = null, SmartRecordLineTextStyle textStyle = SmartRecordLineTextStyle.normal)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.image.ToString();
            item.imageSrc = imageSrc;
            item.imageWidth = imageWidth;
            item.imageHeight = imageHeight;
            item.imageAlignment = imageAlignment.ToString();
            item.text = text;
            item.textAlignment = textAlignment.ToString();
            item.fontSize = fontSize;
            item.textStyle = textStyle.ToString();
            return item;
        }

        public static SmartRecordLine Barcode(string text, double imageWidth, double imageHeight, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.barcode.ToString();
            item.text = text;
            item.imageWidth = imageWidth;
            item.imageHeight = imageHeight;
            item.imageAlignment = alignment.ToString();
            return item;
        }

        public static SmartRecordLine QrCode(string text, double imageWidth, double imageHeight, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none)
        {
            SmartRecordLine item = new SmartRecordLine();
            item.type = SmartRecordLineType.qrCode.ToString();
            item.text = text;
            item.imageWidth = imageWidth;
            item.imageHeight = imageHeight;
            item.imageAlignment = alignment.ToString();
            return item;
        }

        public static SmartRecordLine MakePadStringLine(dynamic data, SmartRecordLineAlignment alignment = SmartRecordLineAlignment.none, SmartRecordLineTextStyle textStyle = SmartRecordLineTextStyle.normal, double? fontSize = null, String? textColor = null, String? textBgColor = null)
        {
            return PadStringLine(text: SmartRecordLine.MakePadString(data), alignment: alignment, textStyle: textStyle, fontSize: fontSize, textColor: textColor, textBgColor: textBgColor);
        }
    }
}
