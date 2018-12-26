using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace MyProjectWizard2
{
    public partial class UserInputForm : Form
    {
        //public string DestinationDirectory { get; set; }
        private Label label1;
        private Button btnOk;
        private Button btnCancel;

        //public UserInputForm()
        //{
        //    //Size = new Size(200, 150);

        //    //var label1 = new Label();
        //    //label1.Location = new Point(10, 10);
        //    //label1.Text = $"Will open cmd" + Environment.NewLine 
        //    //    +
        //    //    $"Click OK to proceed.";
        //    //Controls.Add(label1);

        //    //var button1 = new Button();
        //    //button1.Location = new Point(10, 50);
        //    //button1.Size = new Size(50, 25);
        //    //button1.Text = "OK";
        //    //button1.Click += button1_Click;
        //    //Controls.Add(button1);

        //    //var button2 = new Button();
        //    //button2.Location = new Point(10, 50);
        //    //button2.Size = new Size(50, 25);
        //    //button2.Text = "CANCEL";
        //    //button2.Click += button1_Click;
        //    //Controls.Add(button2);

        //}

        public UserInputForm(string destinationDirectory, string tempDirectory)
        {
        //}

        //public UserInputForm()
        //{
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text =
                $"The following will happen:" + Environment.NewLine +
                $" - An empty folder will be created at {destinationDirectory}{Environment.NewLine}" +
                $" - A command prompt window will open and run the following commands{Environment.NewLine}" +
                $"    - npm install -g yo generator-angular-basic{Environment.NewLine}" +
                $"    - yo angular-basic {Environment.NewLine}" +
                $" - The empty folder {destinationDirectory} will be moved to {tempDirectory}{Environment.NewLine}" +
                $"{Environment.NewLine}Click OK to proceed.";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(464, 202);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(559, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // UserInputForm
            // 
            this.ClientSize = new System.Drawing.Size(646, 237);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Name = "UserInputForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
