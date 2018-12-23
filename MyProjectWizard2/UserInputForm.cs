using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MyProjectWizard2
{
    public partial class UserInputForm : Form
    {
        /////////////////////////////private static string customMessage;
        /////////////////////////private TextBox textBox1;
        private Label label1;
        private Button button1;

        public UserInputForm()
        {
            this.Size = new System.Drawing.Size(155, 265);

            label1 = new Label();
            label1.Location = new System.Drawing.Point(10, 15);
            label1.Text = "Will open command prompt - ok?";
            this.Controls.Add(label1);

            button1 = new Button();
            button1.Location = new System.Drawing.Point(90, 25);
            button1.Size = new System.Drawing.Size(50, 25);
            button1.Click += button1_Click;
            this.Controls.Add(button1);

            ////////////textBox1 = new TextBox();
            ////////////textBox1.Location = new System.Drawing.Point(10, 25);
            ////////////textBox1.Size = new System.Drawing.Size(70, 20);
            ////////////this.Controls.Add(textBox1);
        }

        //////////////public static string CustomMessage
        //////////////{
        //////////////    get
        //////////////    {
        //////////////        return customMessage;
        //////////////    }
        //////////////    set
        //////////////    {
        //////////////        customMessage = value;
        //////////////    }
        //////////////}

        private void button1_Click(object sender, EventArgs e)
        {
            InvokeCommand(@"C:\_git\HelloWorldVsixProjectTemplateWizardYeoman\yo.bat");//////////////////////////////////////////////////, false);
            ///////////////////////////////customMessage = textBox1.Text;
            this.Close();
        }

        public static void InvokeCommand(string batchFileToBeOpened)////////////////////////////////////////, bool useShellExecute)
        {
            var start = new ProcessStartInfo()
            {
                ///////////////////////////////////////////////Arguments,
                CreateNoWindow = false,
                FileName = batchFileToBeOpened,
                UseShellExecute = false,//////////////////////////////////////useShellExecute,//i.e. open exe within its working directory
                WindowStyle = ProcessWindowStyle.Normal,
                //////////////////////////////////WorkingDirectory
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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CMD will ask u questions";
            // 
            // UserInputForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Name = "UserInputForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
