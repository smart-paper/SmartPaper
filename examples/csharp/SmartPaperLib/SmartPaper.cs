namespace SmartPaperLib
{
    public class SmartPaper
    {
        public const double defaultPaperWidth = 500;
        public static readonly string versionCode = "202507071515";
        public string id = DatetimeManager.GetCurrentTimeHexId();
        public string no = "";
        public string bizName = "";
        public string fromName = "";
        public string fromPhone = "";
        public string fromAddress = "";
        public string fromComment = "";
        public string creationDatetime = DatetimeManager.GetCurrentTimeString();
        public string paymentMethod = PaymentMethod.unknown.ToString();
        public double paperWidth = 0;
        public int groupId = 0;
        public string groupName = "";
        public List<SmartRecord> smartRecordList = [];
        public SmartRecordLine? smartRecordDivider;
        public SupportedLocales? supportedLocales;
        public string version = SmartPaper.versionCode;

        public SmartPaper(double paperWidth = defaultPaperWidth)
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

    // SmartPaperImageType enum definition for C#
    public enum SmartPaperImageType : uint
    {
        /*BoxFit equivalents*/
        none = 0x00000001,
        cover = 0x00000002,
        contain = 0x00000003,
        fill = 0x00000004, /*stretch*/
        fitWidth = 0x00000005,
        fitHeight = 0x00000006,
        scaleDown = 0x00000007,

        /*ImageRepeat equivalents*/
        repeat = 0x00000100,
        repeatX = 0x00000200,
        repeatY = 0x00000300,
        unknown = 0x00000000
    }

    // Extension methods for SmartPaperImageType
    public static class SmartPaperImageTypeExtensions
    {
        public static uint GetValue(this SmartPaperImageType type) => (uint)type;
        public static string GetName(this SmartPaperImageType type) => type.ToString();

        public static SmartPaperImageType ParseName(string name)
        {
            // Case-insensitive parsing
            foreach (SmartPaperImageType type in Enum.GetValues(typeof(SmartPaperImageType)))
            {
                if (type.ToString().Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return type;
                }
            }
            return SmartPaperImageType.unknown;
        }

        public static bool IsBoxFitType(this SmartPaperImageType type)
        {
            return type.GetValue() >= (uint)SmartPaperImageType.none &&
                   type.GetValue() <= (uint)SmartPaperImageType.scaleDown;
        }

        public static bool IsImageRepeatType(this SmartPaperImageType type)
        {
            return type.GetValue() >= (uint)SmartPaperImageType.repeat &&
                   type.GetValue() <= (uint)SmartPaperImageType.repeatY;
        }
    }
}
