namespace SmartPaperLib
{
    public class SmartRecord
    {
        public string smartPaperType = SmartPaperType.others.ToString();
        public string smartPaperOutlineType = SmartPaperOutlineType.none.ToString();
        public double outlineWidth = 0;
        public List<SmartRecordLine> items = [];

    }
}
