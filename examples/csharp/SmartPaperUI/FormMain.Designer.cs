namespace SmartPaperForm
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonGenerateOrderSheet = new Button();
            buttonGenerateNumberTicket = new Button();
            SuspendLayout();
            // 
            // buttonGenerateOrderSheet
            // 
            buttonGenerateOrderSheet.Location = new Point(66, 41);
            buttonGenerateOrderSheet.Name = "buttonGenerateOrderSheet";
            buttonGenerateOrderSheet.Size = new Size(180, 32);
            buttonGenerateOrderSheet.TabIndex = 0;
            buttonGenerateOrderSheet.Text = "Generate OrderSheet";
            buttonGenerateOrderSheet.UseVisualStyleBackColor = true;
            buttonGenerateOrderSheet.Click += buttonGenerateOrderSheet_Click;
            // 
            // buttonGenerateNumberTicket
            // 
            buttonGenerateNumberTicket.Location = new Point(66, 104);
            buttonGenerateNumberTicket.Name = "buttonGenerateNumberTicket";
            buttonGenerateNumberTicket.Size = new Size(180, 32);
            buttonGenerateNumberTicket.TabIndex = 1;
            buttonGenerateNumberTicket.Text = "Generate NumberTicket";
            buttonGenerateNumberTicket.UseVisualStyleBackColor = true;
            buttonGenerateNumberTicket.Click += buttonGenerateNumberTicket_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 201);
            Controls.Add(buttonGenerateNumberTicket);
            Controls.Add(buttonGenerateOrderSheet);
            Name = "FormMain";
            Text = "SmartPaper";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonGenerateOrderSheet;
        private Button buttonGenerateNumberTicket;
    }
}
