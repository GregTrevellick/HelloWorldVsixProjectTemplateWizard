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
                Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");

                var userInputForm = new UserInputForm();
                userInputForm.ShowDialog();

                // (1) within a few milli-seconds:
                // the regular new project (in our case literally just an empty folder due to MyProjectTemplate.vstemplate having empty 'TemplateContent' node)

                // (2) within 15+ seconds (requires user input & downloads):
                InvokeCommand(@"C:\_git\HelloWorldVsixProjectTemplateWizardYeoman\yo.bat");

                // This is the only point in code we hit where we can try to move/delete the regular project
                // We can now move/delete the regular project safe in the knowledge that enough time has passed to gaurantee it was created successfully
                Console.WriteLine("BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");
                Console.WriteLine("$safeprojectname$");
                //TODO InvokeCommand(@"C:\_git\HelloWorldVsixProjectTemplateWizardYeoman\MoveTheRegularProjectToCTemp.bat -None8");
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
            //this breakpoint is never when we create an empty directory only as our project
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
