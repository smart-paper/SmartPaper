using SmartPaperExample;
using SmartPaperLib;

namespace SmartPaperForm
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonGenerateOrderSheet_Click(object sender, EventArgs e)
        {
            // SmartPaper - Normal Paper
            SmartPaper smartPaper = Example001.GeneratePaper();
            string json = SmartPaper.toJson(smartPaper);
            Console.WriteLine(json);
        }

        private void buttonGenerateNumberTicket_Click(object sender, EventArgs e)
        {
            // SmartPaper - Border Paper
            SmartPaper smartPaper = Example001.GenerateBorderPaper();
            string json = SmartPaper.toJson(smartPaper);
            Console.WriteLine(json);
        }

        private void buttonGenerateURLs_Click(object sender, EventArgs e)
        {
            // Generate URLs
            string? url = Example001.GenerateURL("https://smart-paper.github.io/SmartPaper/samples/number_ticket_001.json", true);
            string? surl = Example001.GenerateSecuredURL("https://smart-paper.github.io/SmartPaper/samples/secure/order_receipt_001.paper",
                "1234", new byte[] { 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F }, true);
        }
    }
}
