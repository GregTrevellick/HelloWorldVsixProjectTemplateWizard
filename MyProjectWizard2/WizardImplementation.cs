using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Process = System.Diagnostics.Process;

namespace MyProjectWizard2
{
    public class WizardImplementation : IWizard
    {
        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            //1
            try
            {
                var userInputForm = new UserInputForm();
                userInputForm.ShowDialog();
                //when user presses "ok" in dialog 2 things happens asynchronously
                // (1) the regular new project (in our case literally just an empty folder due to MyProjectTemplate.vstemplate having empty 'TemplateContent' node)
                //     this takes a few seconds
                // (2) we run the invoke command below 
                //     this takes multiple seconds
                InvokeCommand(@"C:\_git\HelloWorldVsixProjectTemplateWizardYeoman\yo.bat");
            }
            catch (Exception ex)
            {
                //gregt do some vsix logging here
                MessageBox.Show(ex.ToString());
            }
        }

        private void InvokeCommand(string batchFileToBeOpened)
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
                //gregt do some vsix logging here
                throw (ex);
            }
        }

        // This method is called before opening any item that has the OpenInEditor attribute.  
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
            //3
            //could potentially delete the newly created project here
            Console.WriteLine("$safeprojectname$");
            InvokeCommand(@"C:\_git\HelloWorldVsixProjectTemplateWizardYeoman\MoveTheRegularProjectToCTemp.bat");
        }

        // This method is called after the project is created.  
        public void RunFinished()
        {
            //4
        }

        // This method is only called for item templates, not for project templates.  
        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
        }

        // This method is only called for item templates, not for project templates.  
        public bool ShouldAddProjectItem(string filePath)
        {
            //2
            return true;
        }
    }
}
