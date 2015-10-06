using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace CompressFiles
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //CreateRar();
            ExtractRar();
            Environment.Exit(0);
        }

     
        public void CreateRar()
        {

            string sourcePath = GetCurrentDirectory();
            string desPath = sourcePath + @"\MyCompress.rar";
            string dirName = new DirectoryInfo(sourcePath).Name;
            string fileName = dirName + "\\" + Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);

            System.Diagnostics.Process Process1 = new System.Diagnostics.Process();
            Process1.StartInfo.FileName = "Winrar.exe";
            Process1.StartInfo.CreateNoWindow = true;

            Process1.StartInfo.Arguments = " a -r -ep1 -ibck " + desPath + " " + sourcePath;
            Process1.Start();
            Process1.WaitForExit();

            Process1.StartInfo.Arguments = " d " + desPath + " " + fileName;
            Process1.Start();
            Process1.WaitForExit();
        }

        public void ExtractRar()
        {
            string sourcePath = GetCurrentDirectory();
            string desPath = sourcePath + @"\*.rar";
            string dirName = new DirectoryInfo(sourcePath).Name;

            System.Diagnostics.Process Process1 = new System.Diagnostics.Process();
            Process1.StartInfo.FileName = "Winrar.exe";
            Process1.StartInfo.CreateNoWindow = true;

            sourcePath = sourcePath + "\\" + "MyExtract\\";
            if (System.IO.Directory.Exists(sourcePath) == false)
            {
                Directory.CreateDirectory(sourcePath);
            }

            Process1.StartInfo.Arguments = " x -d -ep2 -ibck " + desPath + " " + sourcePath;
            Process1.Start();
            Process1.WaitForExit();
        }

        public string GetCurrentDirectory()
        {
            return System.IO.Directory.GetCurrentDirectory();
        }

        public bool CheckWinrarExist()
        {

            return false;
        }
    }
}
