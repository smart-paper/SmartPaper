using SmartPaperLib;

namespace SmartPaperExample
{
    public class Example001
    {
        public static readonly string TEST_PIN = "1234";
        //public static readonly byte[] TEST_SMART_PAPER_NONCE = SmartPaperManager.GenerateRandomBytes(12);
        public static readonly byte[] TEST_SMART_PAPER_NONCE = [0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1a, 0x1b];
        public static SmartPaper GeneratePaper(double paperWidth = 500)
        {
            SmartPaper smartPaper = new SmartPaper(paperWidth: paperWidth);
            SmartRecord smartRecord = new SmartRecord();
            smartRecord.smartRecordType = SmartRecordType.orderSheet.ToString();
            smartPaper.bizName = "PublicPlatform";
            SmartRecordLine smartRecordLine;
            PadString padString;
            List<PadString> padStringList = new List<PadString>();

            // bizName
            smartRecordLine = SmartPaperHelper.Text(smartPaper.bizName, SmartRecordLineAlignment.center,
                15.0, SmartRecordLineTextStyle.bold);
            smartRecord.items.Add(smartRecordLine);

            // Body
            int flexProductName = 3;
            int flexUniPrice = 2;
            int flexQuantity = 1;
            int flexDiscount = 2;
            int flexAmount = 2;

            // MenuList Item
            string menuName;
            int quantity;
            double unitMenuPrice;
            double totalMenuPrice;
            double totalMenuPriceDC;
            double totalMenuDC;
            menuName = "Menu Name";
            quantity = 1;
            unitMenuPrice = 1000;
            totalMenuPrice = 1000;
            totalMenuPriceDC = 0;
            totalMenuDC = totalMenuPrice - totalMenuPriceDC;

            padStringList.Clear();
            padString = new PadString(text: menuName, padFlex: flexProductName, textAlignment: SmartRecordLineAlignment.centerLeft);
            padStringList.Add(padString);
            padString = new PadString(text: unitMenuPrice.ToString(), padFlex: flexUniPrice, textAlignment: SmartRecordLineAlignment.center);
            padStringList.Add(padString);
            padString = new PadString(text: quantity.ToString(), padFlex: flexQuantity, textAlignment: SmartRecordLineAlignment.center);
            padStringList.Add(padString);
            padString = new PadString(text: totalMenuDC.ToString(), padFlex: flexDiscount, textAlignment: SmartRecordLineAlignment.center);
            padStringList.Add(padString);
            padString = new PadString(text: totalMenuPriceDC.ToString(), padFlex: flexAmount, textAlignment: SmartRecordLineAlignment.centerRight);
            padStringList.Add(padString);
            smartRecordLine = SmartPaperHelper.MakePadStringLine(padStringList);
            smartRecordLine.textStyle = SmartRecordLineTextStyle.normal.ToString();
            smartRecordLine.fontSize = 12.0;
            smartRecord.items.Add(smartRecordLine);

            smartRecordLine = SmartPaperHelper.Divider(dividerStyle: SmartRecordLineDividerStyle.hyphen, fontSize: 15.0);
            smartRecord.items.Add(smartRecordLine);

            smartRecordLine = SmartPaperHelper.Divider(dividerStyle: SmartRecordLineDividerStyle.equal, fontSize: 15.0);
            smartRecord.items.Add(smartRecordLine);

            smartRecordLine = SmartPaperHelper.Barcode(text: "126af11e3355", imageWidth: paperWidth, imageHeight: 100);
            smartRecord.items.Add(smartRecordLine);
            smartRecordLine = SmartPaperHelper.Divider(dividerStyle: SmartRecordLineDividerStyle.blank, fontSize: 15.0);
            smartRecord.items.Add(smartRecordLine);

            smartPaper.smartRecordList.Add(smartRecord);

            return smartPaper;
        }

        public static SmartPaper GenerateBorderPaper(double paperWidth = 500)
        {
            SmartPaper smartPaper = new(paperWidth);
            SmartRecord smartRecord = new();
            smartRecord.smartRecordType = SmartRecordType.numberTicket.ToString();
            smartRecord.smartRecordOutlineType = SmartRecordOutlineType.solid.ToString();
            smartRecord.outlineWidth = 2;
            smartPaper.bizName = "PublicPlatform";
            SmartRecordLine smartPaperItem;
            PadString padString;
            List<PadString> padStringList = new List<PadString>();

            smartPaperItem = SmartPaperHelper.Divider(SmartRecordLineDividerStyle.blank, 15.0);
            smartRecord.items.Add(smartPaperItem);

            // Waiting Number
            padStringList.Clear();
            padString = new PadString(text: "Waiting Number ", padFlex: 2, textAlignment: SmartRecordLineAlignment.centerRight);
            padStringList.Add(padString);
            padString = new PadString(text: "123", padFlex: 1, textAlignment: SmartRecordLineAlignment.centerLeft);
            padStringList.Add(padString);
            smartPaperItem = SmartPaperHelper.MakePadStringLine(padStringList, textStyle: SmartRecordLineTextStyle.normal, fontSize: 21.0, textColor: "#FFFFFFFF", textBgColor: "#FF000000");
            smartRecord.items.Add(smartPaperItem);

            // Waiting People Number
            padStringList.Clear();
            padString = new PadString(text: "Waiting People ", padFlex: 2, textAlignment: SmartRecordLineAlignment.centerRight);
            padStringList.Add(padString);
            padString = new PadString(text: "12", padFlex: 1, textAlignment: SmartRecordLineAlignment.centerLeft);
            padStringList.Add(padString);
            smartPaperItem = SmartPaperHelper.MakePadStringLine(padStringList, textStyle: SmartRecordLineTextStyle.normal, fontSize: 18.0);
            smartRecord.items.Add(smartPaperItem);

            smartPaperItem = SmartPaperHelper.Divider(SmartRecordLineDividerStyle.hyphen, 15.0);
            smartRecord.items.Add(smartPaperItem);

            smartPaperItem = SmartPaperHelper.Divider(dividerStyle: SmartRecordLineDividerStyle.hyphen, fontSize: 15.0);
            smartRecord.items.Add(smartPaperItem);

            smartPaperItem = SmartPaperHelper.Divider(dividerStyle: SmartRecordLineDividerStyle.equal, fontSize: 15.0);
            smartRecord.items.Add(smartPaperItem);

            smartPaperItem = SmartPaperHelper.Barcode(text: "126af11e3355", imageWidth: paperWidth, imageHeight: 100);
            smartRecord.items.Add(smartPaperItem);
            smartPaperItem = SmartPaperHelper.Divider(dividerStyle: SmartRecordLineDividerStyle.blank, fontSize: 15.0);
            smartRecord.items.Add(smartPaperItem);

            smartPaper.smartRecordList.Add(smartRecord);

            return smartPaper;
        }

        public static string? GenerateURL(string paperUrl, bool isAutoSave = false)
        {
            return SmartPaperManager.GenerateUrl(paperUrl, isAutoSave);
        }

        public static string? GenerateSecuredURL(string paperUrl, string pin, byte[] nonceBytes, bool isAutoSave = false)
        {
            return SmartPaperManager.EncryptAndGenerateUrl(paperUrl, SmartPaperManager.GenerateDeterministicKeyFromPin(pin), nonceBytes, isAutoSave);
        }

        public static string EncryptJsonData(string data, string pin, byte[] nonceBytes)
        {
            return SmartPaperManager.EncryptData(data, SmartPaperManager.GenerateDeterministicKeyFromPin(pin), nonceBytes);
        }
    }
}
