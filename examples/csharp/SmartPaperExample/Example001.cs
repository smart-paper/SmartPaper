using SmartPaperLib;

namespace SmartPaperExample
{
    public class Example001
    {
        public static SmartPaper GeneratePaper(double paperWidth = 500)
        {
            SmartPaper smartPaper = new SmartPaper(paperWidth: paperWidth);
            smartPaper.smartPaperType = SmartPaperType.orderSheet.ToString();
            smartPaper.bizName = "PublicPlatform";
            SmartPaperItem smartPaperItem;
            PadString padString;
            List<PadString> padStringList = new List<PadString>();

            // bizName
            smartPaperItem = SmartPaperHelper.Text(smartPaper.bizName, SmartPaperItemAlignment.center,
                15.0, SmartPaperItemTextStyle.bold);
            smartPaper.items.Add(smartPaperItem);

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
            padString = new PadString(text: menuName, padFlex: flexProductName, textAlignment: SmartPaperItemAlignment.centerLeft);
            padStringList.Add(padString);
            padString = new PadString(text: unitMenuPrice.ToString(), padFlex: flexUniPrice, textAlignment: SmartPaperItemAlignment.center);
            padStringList.Add(padString);
            padString = new PadString(text: quantity.ToString(), padFlex: flexQuantity, textAlignment: SmartPaperItemAlignment.center);
            padStringList.Add(padString);
            padString = new PadString(text: totalMenuDC.ToString(), padFlex: flexDiscount, textAlignment: SmartPaperItemAlignment.center);
            padStringList.Add(padString);
            padString = new PadString(text: totalMenuPriceDC.ToString(), padFlex: flexAmount, textAlignment: SmartPaperItemAlignment.centerRight);
            padStringList.Add(padString);
            smartPaperItem = SmartPaperHelper.MakePadStringItem(padStringList);
            smartPaperItem.textStyle = SmartPaperItemTextStyle.normal.ToString();
            smartPaperItem.fontSize = 12.0;
            smartPaper.items.Add(smartPaperItem);

            smartPaperItem = SmartPaperHelper.Divider(dividerStyle: SmartPaperItemDividerStyle.hyphen, fontSize: 15.0);
            smartPaper.items.Add(smartPaperItem);

            smartPaperItem = SmartPaperHelper.Divider(dividerStyle: SmartPaperItemDividerStyle.equal, fontSize: 15.0);
            smartPaper.items.Add(smartPaperItem);

            smartPaperItem = SmartPaperHelper.Barcode(text: "126af11e3355", imageWidth: paperWidth, imageHeight: 100);
            smartPaper.items.Add(smartPaperItem);
            smartPaperItem = SmartPaperHelper.Divider(dividerStyle: SmartPaperItemDividerStyle.blank, fontSize: 15.0);
            smartPaper.items.Add(smartPaperItem);

            return smartPaper;
            // GeneratePaper: {"id":"126AF12D51CB","no":"","bizName":"PublicPlatform","fromName":"","fromPhone":"","fromAddress":"","fromComment":"","creationDatetime":"20250522112459","smartPaperType":"orderSheet","smartPaperOutlineType":"none","paymentMethod":"unknown","paperWidth":500,"outlineWidth":0,"groupId":0,"groupName":"","items":[{"type":"text","alignment":"center","textStyle":"bold","fontSize":15,"textMaxLines":null,"text":"PublicPlatform","textColor":null,"textBgColor":null,"dividerStyle":null,"imageWidth":null,"imageHeight":null,"imageSrc":null},{"type":"text","alignment":"none","textStyle":"normal","fontSize":12,"textMaxLines":null,"text":"Menu Name[|SFS|]3[|SFS|]centerLeft[|SEO|]1000[|SFS|]2[|SFS|]center[|SEO|]1[|SFS|]1[|SFS|]center[|SEO|]1000[|SFS|]2[|SFS|]center[|SEO|]0[|SFS|]2[|SFS|]centerRight[|SEO|]","textColor":null,"textBgColor":null,"dividerStyle":null,"imageWidth":null,"imageHeight":null,"imageSrc":null},{"type":"divider","alignment":"none","textStyle":null,"fontSize":15,"textMaxLines":null,"text":null,"textColor":null,"textBgColor":null,"dividerStyle":"hyphen","imageWidth":null,"imageHeight":null,"imageSrc":null},{"type":"divider","alignment":"none","textStyle":null,"fontSize":15,"textMaxLines":null,"text":null,"textColor":null,"textBgColor":null,"dividerStyle":"equal","imageWidth":null,"imageHeight":null,"imageSrc":null},{"type":"barcode","alignment":"none","textStyle":null,"fontSize":null,"textMaxLines":null,"text":"126af11e3355","textColor":null,"textBgColor":null,"dividerStyle":null,"imageWidth":500,"imageHeight":100,"imageSrc":null},{"type":"divider","alignment":"none","textStyle":null,"fontSize":15,"textMaxLines":null,"text":null,"textColor":null,"textBgColor":null,"dividerStyle":"blank","imageWidth":null,"imageHeight":null,"imageSrc":null}],"version":"202504101515"}
        }

        public static SmartPaper GenerateBorderPaper(double paperWidth = 500)
        {
            SmartPaper smartPaper = new SmartPaper(paperWidth);
            smartPaper.smartPaperType = SmartPaperType.numberTicket.ToString();
            smartPaper.smartPaperOutlineType = SmartPaperOutlineType.solid.ToString();
            smartPaper.outlineWidth = 2;
            smartPaper.bizName = "PublicPlatform";
            SmartPaperItem smartPaperItem;
            PadString padString;
            List<PadString> padStringList = new List<PadString>();

            smartPaperItem = SmartPaperHelper.Divider(SmartPaperItemDividerStyle.blank, 15.0);
            smartPaper.items.Add(smartPaperItem);

            // Waiting Number
            padStringList.Clear();
            padString = new PadString(text: "Waiting Number ", padFlex: 2, textAlignment: SmartPaperItemAlignment.centerRight);
            padStringList.Add(padString);
            padString = new PadString(text: "123", padFlex: 1, textAlignment: SmartPaperItemAlignment.centerLeft);
            padStringList.Add(padString);
            smartPaperItem = SmartPaperHelper.MakePadStringItem(padStringList, textStyle: SmartPaperItemTextStyle.normal, fontSize: 21.0, textColor: "#FFFFFFFF", textBgColor: "#FF000000");
            smartPaper.items.Add(smartPaperItem);

            // Waiting People Number
            padStringList.Clear();
            padString = new PadString(text: "Waiting People ", padFlex: 2, textAlignment: SmartPaperItemAlignment.centerRight);
            padStringList.Add(padString);
            padString = new PadString(text: "12", padFlex: 1, textAlignment: SmartPaperItemAlignment.centerLeft);
            padStringList.Add(padString);
            smartPaperItem = SmartPaperHelper.MakePadStringItem(padStringList, textStyle: SmartPaperItemTextStyle.normal, fontSize: 18.0);
            smartPaper.items.Add(smartPaperItem);

            smartPaperItem = SmartPaperHelper.Divider(SmartPaperItemDividerStyle.hyphen, 15.0);
            smartPaper.items.Add(smartPaperItem);

            smartPaperItem = SmartPaperHelper.Divider(dividerStyle: SmartPaperItemDividerStyle.hyphen, fontSize: 15.0);
            smartPaper.items.Add(smartPaperItem);

            smartPaperItem = SmartPaperHelper.Divider(dividerStyle: SmartPaperItemDividerStyle.equal, fontSize: 15.0);
            smartPaper.items.Add(smartPaperItem);

            smartPaperItem = SmartPaperHelper.Barcode(text: "126af11e3355", imageWidth: paperWidth, imageHeight: 100);
            smartPaper.items.Add(smartPaperItem);
            smartPaperItem = SmartPaperHelper.Divider(dividerStyle: SmartPaperItemDividerStyle.blank, fontSize: 15.0);
            smartPaper.items.Add(smartPaperItem);

            return smartPaper;
            // GenerateBorderPaper: {"id":"126AF12D5259","no":"","bizName":"PublicPlatform","fromName":"","fromPhone":"","fromAddress":"","fromComment":"","creationDatetime":"20250522112601","smartPaperType":"numberTicket","smartPaperOutlineType":"solid","paymentMethod":"unknown","paperWidth":500,"outlineWidth":2,"groupId":0,"groupName":"","items":[{"type":"divider","alignment":"none","textStyle":null,"fontSize":15,"textMaxLines":null,"text":null,"textColor":null,"textBgColor":null,"dividerStyle":"blank","imageWidth":null,"imageHeight":null,"imageSrc":null},{"type":"text","alignment":"none","textStyle":"normal","fontSize":21,"textMaxLines":null,"text":"Waiting Number [|SFS|]2[|SFS|]centerRight[|SEO|]123[|SFS|]1[|SFS|]centerLeft[|SEO|]","textColor":"#FFFFFFFF","textBgColor":"#FF000000","dividerStyle":null,"imageWidth":null,"imageHeight":null,"imageSrc":null},{"type":"text","alignment":"none","textStyle":"normal","fontSize":18,"textMaxLines":null,"text":"Waiting People [|SFS|]2[|SFS|]centerRight[|SEO|]12[|SFS|]1[|SFS|]centerLeft[|SEO|]","textColor":null,"textBgColor":null,"dividerStyle":null,"imageWidth":null,"imageHeight":null,"imageSrc":null},{"type":"divider","alignment":"none","textStyle":null,"fontSize":15,"textMaxLines":null,"text":null,"textColor":null,"textBgColor":null,"dividerStyle":"hyphen","imageWidth":null,"imageHeight":null,"imageSrc":null},{"type":"divider","alignment":"none","textStyle":null,"fontSize":15,"textMaxLines":null,"text":null,"textColor":null,"textBgColor":null,"dividerStyle":"hyphen","imageWidth":null,"imageHeight":null,"imageSrc":null},{"type":"divider","alignment":"none","textStyle":null,"fontSize":15,"textMaxLines":null,"text":null,"textColor":null,"textBgColor":null,"dividerStyle":"equal","imageWidth":null,"imageHeight":null,"imageSrc":null},{"type":"barcode","alignment":"none","textStyle":null,"fontSize":null,"textMaxLines":null,"text":"126af11e3355","textColor":null,"textBgColor":null,"dividerStyle":null,"imageWidth":500,"imageHeight":100,"imageSrc":null},{"type":"divider","alignment":"none","textStyle":null,"fontSize":15,"textMaxLines":null,"text":null,"textColor":null,"textBgColor":null,"dividerStyle":"blank","imageWidth":null,"imageHeight":null,"imageSrc":null}],"version":"202504101515"}
        }

        public static string? GenerateURL(string paperUrl, bool isAutoSave = false)
        {
            string? url = SecurityManager.GenerateUrl(paperUrl, isAutoSave);
            return url;
        }

        public static string? GenerateSecuredURL(string paperUrl, string pin, byte[] ivBytes, bool isAutoSave = false)
        {
            string? surl = SecurityManager.EncryptAndGenerateUrl(paperUrl, SecurityManager.GenerateDeterministicKeyFromPin(pin), ivBytes, isAutoSave);
            return surl;
        }
    }
}
