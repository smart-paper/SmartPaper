namespace SmartPaperLib
{
    public class SmartRecord
    {
        public string smartRecordType = SmartRecordType.others.ToString();
        public string smartRecordOutlineType = SmartRecordOutlineType.none.ToString();
        public double outlineWidth = 0;
        public List<SmartRecordLine> items = [];
        public string bgColor = "#FFFFFFFF";
    }

    public enum SmartRecordType : uint
    {
        allPapers = unchecked((uint)0xFFFFFFFF),
        orderSheet = unchecked((uint)0x00010000),
        orderReceipt = unchecked((uint)0x00020000),
        smartCoupon = unchecked((uint)0x00040000),
        smartTicket = unchecked((uint)0x00080000),
        numberTicket = unchecked((uint)0x00100000),
        others = unchecked((uint)0x80000000)
    }

    public static class SmartRecordTypeExtensions
    {
        public static int GetValue(this SmartRecordType type) => (int)type;

        public static int GetIndex(this SmartRecordType type) => GetIndexFromEnum(type);

        public static int Size => Enum.GetValues(typeof(SmartRecordType)).Length - 1;

        public static SmartRecordType ParseValue(int value)
        {
            return value switch
            {
                unchecked((int)0xFFFFFFFF) => SmartRecordType.allPapers,
                unchecked((int)0x00010000) => SmartRecordType.orderSheet,
                unchecked((int)0x00020000) => SmartRecordType.orderReceipt,
                unchecked((int)0x00040000) => SmartRecordType.smartCoupon,
                unchecked((int)0x00080000) => SmartRecordType.smartTicket,
                unchecked((int)0x00100000) => SmartRecordType.numberTicket,
                _ => SmartRecordType.others
            };
        }

        public static string GetString(SmartRecordType type) => GetStringFromValue(type.GetValue());

        public static SmartRecordType ParseName(string name)
        {
            return name switch
            {
                nameof(SmartRecordType.allPapers) => SmartRecordType.allPapers,
                nameof(SmartRecordType.orderSheet) => SmartRecordType.orderSheet,
                nameof(SmartRecordType.orderReceipt) => SmartRecordType.orderReceipt,
                nameof(SmartRecordType.smartCoupon) => SmartRecordType.smartCoupon,
                nameof(SmartRecordType.smartTicket) => SmartRecordType.smartTicket,
                nameof(SmartRecordType.numberTicket) => SmartRecordType.numberTicket,
                _ => SmartRecordType.others
            };
        }

        public static int GetIndexFromEnum(SmartRecordType type)
        {
            var types = (SmartRecordType[])Enum.GetValues(typeof(SmartRecordType));
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].GetValue() == type.GetValue()) return i;
            }
            return -1;
        }

        public static SmartRecordType Get(int index)
        {
            var types = (SmartRecordType[])Enum.GetValues(typeof(SmartRecordType));
            if (index < types.Length) return types[index];
            return SmartRecordType.others;
        }

        public static int GetBitIndex(SmartRecordType type)
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

    public enum SmartRecordOutlineType
    {
        none,
        solid
    }

    public static class SmartPaperOutlineTypeExtensions
    {
        public static SmartRecordOutlineType ParseName(string name)
        {
            return name == nameof(SmartRecordOutlineType.solid) ? SmartRecordOutlineType.solid : SmartRecordOutlineType.none;
        }
    }
}
