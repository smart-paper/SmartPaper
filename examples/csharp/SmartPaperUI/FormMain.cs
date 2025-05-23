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
            SmartPaper smartPaper = Example001.GeneratePaper();
            string json = SmartPaper.toJson(smartPaper);
            Console.WriteLine(json);
        }

        private void buttonGenerateNumberTicket_Click(object sender, EventArgs e)
        {
            SmartPaper smartPaper = Example001.GenerateBorderPaper();
            string json = SmartPaper.toJson(smartPaper);
            Console.WriteLine(json);
        }
    }
}
