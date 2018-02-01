﻿using System;
using System.Windows.Forms;
using BubbleGit.Runner.IssueTracker;

namespace BubbleGit.Runner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new InsertIssueView());
            
            new IssueTrackerApplication(args, new ControllersFactory()).Run();
        }
    }
}
