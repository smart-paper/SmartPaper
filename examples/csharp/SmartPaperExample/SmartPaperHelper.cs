using SmartPaperLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPaperExample
{
    public class SmartPaperHelper
    {
        public static SmartPaperItem PadStringItem(SmartPaperItemType type, string text)
        {
            SmartPaperItem item = new SmartPaperItem();
            item.type = type.ToString();
            item.text = text;
            return item;
        }

        public static SmartPaperItem Text(string text, SmartPaperItemAlignment alignment,
                double fontSize, SmartPaperItemTextStyle textStyle)
        {
            SmartPaperItem item = new SmartPaperItem();
            item.type = SmartPaperItemType.text.ToString();
            item.text = text;
            item.alignment = alignment.ToString();
            item.fontSize = fontSize;
            item.textStyle = textStyle.ToString();
            return item;
        }

        public static SmartPaperItem Divider(SmartPaperItemDividerStyle dividerStyle, double fontSize)
        {
            SmartPaperItem item = new SmartPaperItem();
            item.type = SmartPaperItemType.divider.ToString();
            item.dividerStyle = dividerStyle.ToString();
            item.fontSize = fontSize;
            return item;
        }

        public static SmartPaperItem Barcode(string text, double imageWidth, double imageHeight)
        {
            SmartPaperItem item = new SmartPaperItem();
            item.type = SmartPaperItemType.barcode.ToString();
            item.text = text;
            item.imageWidth = imageWidth;
            item.imageHeight = imageHeight;
            return item;
        }

        public static SmartPaperItem MakePadStringItem(dynamic data)
        {
            return PadStringItem(SmartPaperItemType.text, SmartPaperItem.MakePadString(data));
        }
    }
}
