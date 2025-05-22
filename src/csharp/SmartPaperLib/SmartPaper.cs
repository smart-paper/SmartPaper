namespace SmartPaperLib
{
    public class SmartPaper
    {
        public static readonly string versionCode = "202504101515";
        public string id = DatetimeManager.GetCurrentTimeHexId();
        public string no = "";
        public string bizName = "";
        public string fromName = "";
        public string fromPhone = "";
        public string fromAddress = "";
        public string fromComment = "";
        public string creationDatetime = DatetimeManager.GetCurrentTimeString();
        public string smartPaperType = SmartPaperType.others.ToString();
        public string smartPaperOutlineType = SmartPaperOutlineType.none.ToString();
        public string paymentMethod = PaymentMethod.unknown.ToString();
        public double paperWidth = 0;
        public double outlineWidth = 0;
        public int groupId = 0;
        public string groupName = "";
        public List<SmartPaperItem> items = [];
        public string version = SmartPaper.versionCode;

        public SmartPaper(double paperWidth)
        {
            this.paperWidth = paperWidth;
        }

        public static String toJson(SmartPaper smartPaper)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(smartPaper, Newtonsoft.Json.Formatting.Indented);
        }

        public static SmartPaper? fromJson(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SmartPaper>(json);
        }

    }

    public enum SmartPaperType : uint
    {
        allPapers = unchecked((uint)0xFFFFFFFF),
        orderSheet = unchecked((uint)0x00010000),
        orderReceipt = unchecked((uint)0x00020000),
        smartCoupon = unchecked((uint)0x00040000),
        smartTicket = unchecked((uint)0x00080000),
        numberTicket = unchecked((uint)0x00100000),
        others = unchecked((uint)0x80000000)
    }

    public static class SmartPaperTypeExtensions
    {
        public static int GetValue(this SmartPaperType type) => (int)type;

        public static int GetIndex(this SmartPaperType type) => GetIndexFromEnum(type);

        public static int Size => Enum.GetValues(typeof(SmartPaperType)).Length - 1;

        public static SmartPaperType ParseValue(int value)
        {
            return value switch
            {
                unchecked((int)0xFFFFFFFF) => SmartPaperType.allPapers,
                unchecked((int)0x00010000) => SmartPaperType.orderSheet,
                unchecked((int)0x00020000) => SmartPaperType.orderReceipt,
                unchecked((int)0x00040000) => SmartPaperType.smartCoupon,
                unchecked((int)0x00080000) => SmartPaperType.smartTicket,
                unchecked((int)0x00100000) => SmartPaperType.numberTicket,
                _ => SmartPaperType.others
            };
        }

        public static string GetString(SmartPaperType type) => GetStringFromValue(type.GetValue());

        public static SmartPaperType ParseName(string name)
        {
            return name switch
            {
                nameof(SmartPaperType.allPapers) => SmartPaperType.allPapers,
                nameof(SmartPaperType.orderSheet) => SmartPaperType.orderSheet,
                nameof(SmartPaperType.orderReceipt) => SmartPaperType.orderReceipt,
                nameof(SmartPaperType.smartCoupon) => SmartPaperType.smartCoupon,
                nameof(SmartPaperType.smartTicket) => SmartPaperType.smartTicket,
                nameof(SmartPaperType.numberTicket) => SmartPaperType.numberTicket,
                _ => SmartPaperType.others
            };
        }

        public static int GetIndexFromEnum(SmartPaperType type)
        {
            var types = (SmartPaperType[])Enum.GetValues(typeof(SmartPaperType));
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].GetValue() == type.GetValue()) return i;
            }
            return -1;
        }

        public static SmartPaperType Get(int index)
        {
            var types = (SmartPaperType[])Enum.GetValues(typeof(SmartPaperType));
            if (index < types.Length) return types[index];
            return SmartPaperType.others;
        }

        public static int GetBitIndex(SmartPaperType type)
        {
            for (int i = 0; i < sizeof(int) * 8; i++)
            {
                if ((type.GetValue() & (1 << i)) != 0)
                {
                    return i;
                }
            }
            return -1;
        }

        private static string GetStringFromValue(int value)
        {
            // Implement this method based on your requirements
            return value.ToString("X");
        }
    }

    public enum SmartPaperOutlineType
    {
        none,
        solid
    }

    public static class SmartPaperOutlineTypeExtensions
    {
        public static SmartPaperOutlineType ParseName(string name)
        {
            return name == nameof(SmartPaperOutlineType.solid) ? SmartPaperOutlineType.solid : SmartPaperOutlineType.none;
        }
    }

    public enum PaymentMethod
    {
        prepaid = 0x00010000,
        postpaid = 0x00020000,
        downPayment = 0x00040000,
        offline = 0x00080000,
        downPaymentAndHall = 0x00040004,
        unknown = 0
    }

    public static class PaymentMethodExtensions
    {
        public static int GetValue(this PaymentMethod method)
        {
            return (int)method;
        }

        public static string GetName(this PaymentMethod method)
        {
            return method.ToString();
        }

        public static int GetIndex(this PaymentMethod method)
        {
            return GetIndexFromEnum(method);
        }

        public static int Size => Enum.GetValues(typeof(PaymentMethod)).Length - 1;

        public static PaymentMethod ParseValue(int value)
        {
            return value switch
            {
                0x00010000 => PaymentMethod.prepaid,
                0x00020000 => PaymentMethod.postpaid,
                0x00040000 => PaymentMethod.downPayment,
                0x00080000 => PaymentMethod.offline,
                _ => PaymentMethod.unknown,
            };
        }

        public static PaymentMethod ParseName(string name)
        {
            return name switch
            {
                nameof(PaymentMethod.prepaid) => PaymentMethod.prepaid,
                nameof(PaymentMethod.postpaid) => PaymentMethod.postpaid,
                nameof(PaymentMethod.downPayment) => PaymentMethod.downPayment,
                nameof(PaymentMethod.offline) => PaymentMethod.offline,
                _ => PaymentMethod.unknown,
            };
        }

        public static int GetIndexFromEnum(PaymentMethod type)
        {
            var types = (PaymentMethod[])Enum.GetValues(typeof(PaymentMethod));
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].GetValue() == type.GetValue()) return i;
            }
            return -1;
        }

        public static int GetBitIndex(PaymentMethod paymentMethod)
        {
            for (int i = 0; i < sizeof(int) * 8; i++)
            {
                if ((paymentMethod.GetValue() & (1 << i)) != 0)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
