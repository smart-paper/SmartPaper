namespace SmartPaperLib
{
    public class SmartPaper
    {
        public const double defaultPaperWidth = 500;
        public static readonly string versionCode = "202506221515";
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
}
