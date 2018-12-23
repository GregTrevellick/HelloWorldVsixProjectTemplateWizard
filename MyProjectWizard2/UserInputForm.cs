using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace MyProjectWizard2
{
    public partial class UserInputForm : Form
    {
        private Label label1;
        private Button button1;

        public UserInputForm()
        {
            Size = new Size(200, 150);

            label1 = new Label();
            label1.Location = new Point(10, 10);
            label1.Text = "Will open cmd";
            Controls.Add(label1);

            button1 = new Button();
            button1.Location = new Point(10, 50);
            button1.Size = new Size(50, 25);
            button1.Click += button1_Click;
            Controls.Add(button1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InvokeCommand(@"C:\_git\HelloWorldVsixProjectTemplateWizardYeoman\yo.bat");
            Close();
        }

        private static void InvokeCommand(string batchFileToBeOpened)
        {
            var start = new ProcessStartInfo()
            {
                CreateNoWindow = false,
                FileName = batchFileToBeOpened,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Normal,
            };

            try
            {
                using (Process.Start(start)) { }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //private void InitializeComponent()
        //{
        //    SuspendLayout();
        //    ClientSize = new Size(284, 261);
        //    Name = "UserInputForm";
        //    ResumeLayout(false);
        //    PerformLayout();
        //}
    }
}
