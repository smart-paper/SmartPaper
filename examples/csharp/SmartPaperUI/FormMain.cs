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
            Console.WriteLine(SmartPaper.toJson(smartPaper));
        }

        private void buttonGenerateNumberTicket_Click(object sender, EventArgs e)
        {
            SmartPaper smartPaper = Example001.GenerateBorderPaper();
            Console.WriteLine(SmartPaper.toJson(smartPaper));
        }
    }
}
