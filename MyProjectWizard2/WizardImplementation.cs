using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Process = System.Diagnostics.Process;

namespace MyProjectWizard2
{
    public class WizardImplementation : IWizard
    {
        private const string generatorName = "angular-basic";

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            //1
            try
            {
                var solutionDirectory = replacementsDictionary["$solutiondirectory$"];
                var tempDirectory = Path.GetTempPath();

                var userInputForm = new UserInputForm(solutionDirectory, tempDirectory, generatorName);
                userInputForm.ShowDialog();

                // (1) within a few milli-seconds:
                // the regular new project (in our case literally just an empty folder due to MyProjectTemplate.vstemplate having empty 'TemplateContent' node)

                // (2) within 15+ seconds (requires user input & downloads):
                var assemblyLocation = Assembly.GetExecutingAssembly().Location;
                var yoBatchFile = $@"{Path.GetDirectoryName(assemblyLocation)}\yo.bat";
                var args = $"-{generatorName}";
                InvokeCommand(yoBatchFile, args);
                
                // (3) within 15+ seconds: 
                // this is the only point in code we hit where we can try to move/delete the regular project
                // we can now move/delete the regular project safe in the knowledge that enough time has passed to gaurantee it was created successfully
                var solutionDirectoryInfo = new DirectoryInfo(solutionDirectory);
                Directory.Move(solutionDirectory, $"{tempDirectory}\\{solutionDirectoryInfo.Name}");
            }
            catch (Exception ex)
            {
                //gregt do some vsix logging here
                MessageBox.Show(ex.ToString());
            }
        }

        private void InvokeCommand(string batchFileToBeOpened, string args)
        {
            var start = new ProcessStartInfo()
            {
                Arguments = args,
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
