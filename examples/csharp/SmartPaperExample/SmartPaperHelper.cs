using SmartPaperLib;

namespace SmartPaperExample
{
    public class SmartPaperHelper
    {
        public static SmartPaperItem PadStringItem(string text, SmartPaperItemAlignment alignment = SmartPaperItemAlignment.none, SmartPaperItemTextStyle? textStyle = null, 
            double? fontSize = null, String? textColor = null, String? textBgColor = null)
        {
            SmartPaperItem item = new SmartPaperItem();
            item.type = SmartPaperItemType.text.ToString();
            item.text = text;
            item.alignment = alignment.ToString();
            item.textStyle = textStyle.ToString();
            item.fontSize = fontSize;
            item.textColor = textColor;
            item.textBgColor = textBgColor;
            return item;
        }

        public static SmartPaperItem Text(string text, SmartPaperItemAlignment alignment = SmartPaperItemAlignment.none,
                double? fontSize = null, SmartPaperItemTextStyle textStyle = SmartPaperItemTextStyle.normal)
        {
            SmartPaperItem item = new SmartPaperItem();
            item.type = SmartPaperItemType.text.ToString();
            item.text = text;
            item.alignment = alignment.ToString();
            item.fontSize = fontSize;
            item.textStyle = textStyle.ToString();
            return item;
        }

        public static SmartPaperItem Divider(SmartPaperItemDividerStyle dividerStyle, double? fontSize = null)
        {
            SmartPaperItem item = new SmartPaperItem();
            item.type = SmartPaperItemType.divider.ToString();
            item.dividerStyle = dividerStyle.ToString();
            item.fontSize = fontSize;
            return item;
        }

        public static SmartPaperItem Image(string imageSrc, double imageWidth, double imageHeight, SmartPaperItemAlignment alignment = SmartPaperItemAlignment.none)
        {
            SmartPaperItem item = new SmartPaperItem();
            item.type = SmartPaperItemType.image.ToString();
            item.imageSrc = imageSrc;
            item.imageWidth = imageWidth;
            item.imageHeight = imageHeight;
            item.alignment = alignment.ToString();
            return item;
        }

        public static SmartPaperItem ImageAndText(string imageSrc, double imageWidth, double imageHeight, string text, SmartPaperItemAlignment alignment = SmartPaperItemAlignment.none,
            double? fontSize = null, SmartPaperItemTextStyle textStyle = SmartPaperItemTextStyle.normal)
        {
            SmartPaperItem item = new SmartPaperItem();
            item.type = SmartPaperItemType.image.ToString();
            item.imageSrc = imageSrc;
            item.imageWidth = imageWidth;
            item.imageHeight = imageHeight;
            item.text = text;
            item.alignment = alignment.ToString();
            item.fontSize = fontSize;
            item.textStyle = textStyle.ToString();
            return item;
        }

        public static SmartPaperItem TextAndImage(string imageSrc, double imageWidth, double imageHeight, string text, SmartPaperItemAlignment alignment = SmartPaperItemAlignment.none,
            double? fontSize = null, SmartPaperItemTextStyle textStyle = SmartPaperItemTextStyle.normal)
        {
            SmartPaperItem item = new SmartPaperItem();
            item.type = SmartPaperItemType.image.ToString();
            item.imageSrc = imageSrc;
            item.imageWidth = imageWidth;
            item.imageHeight = imageHeight;
            item.text = text;
            item.alignment = alignment.ToString();
            item.fontSize = fontSize;
            item.textStyle = textStyle.ToString();
            return item;
        }

        public static SmartPaperItem Barcode(string text, double imageWidth, double imageHeight, SmartPaperItemAlignment alignment = SmartPaperItemAlignment.none)
        {
            SmartPaperItem item = new SmartPaperItem();
            item.type = SmartPaperItemType.barcode.ToString();
            item.text = text;
            item.imageWidth = imageWidth;
            item.imageHeight = imageHeight;
            item.alignment = alignment.ToString();
            return item;
        }

        public static SmartPaperItem QrCode(string text, double imageWidth, double imageHeight, SmartPaperItemAlignment alignment = SmartPaperItemAlignment.none)
        {
            SmartPaperItem item = new SmartPaperItem();
            item.type = SmartPaperItemType.qrCode.ToString();
            item.text = text;
            item.imageWidth = imageWidth;
            item.imageHeight = imageHeight;
            item.alignment = alignment.ToString();
            return item;
        }

        public static SmartPaperItem MakePadStringItem(dynamic data, SmartPaperItemAlignment alignment = SmartPaperItemAlignment.none, SmartPaperItemTextStyle textStyle = SmartPaperItemTextStyle.normal, double? fontSize = null, String? textColor = null, String? textBgColor = null)
        {
            return PadStringItem(text: SmartPaperItem.MakePadString(data), alignment: alignment, textStyle: textStyle, fontSize: fontSize, textColor: textColor, textBgColor: textBgColor);
        }
    }
}
