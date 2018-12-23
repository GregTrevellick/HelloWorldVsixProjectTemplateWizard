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
            Size = new System.Drawing.Size(155, 265);

            label1 = new Label();
            label1.Location = new System.Drawing.Point(10, 15);
            label1.Text = "Will open command prompt - ok?";
            Controls.Add(label1);

            button1 = new Button();
            button1.Location = new System.Drawing.Point(90, 25);
            button1.Size = new System.Drawing.Size(50, 25);
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

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(2, 97);
            this.label1.Name = "label1";
            this.label1.Size = new Size(125, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CMD will ask u questions";
            // 
            // UserInputForm
            // 
            this.ClientSize = new Size(284, 261);
            this.Controls.Add(label1);
            this.Name = "UserInputForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
