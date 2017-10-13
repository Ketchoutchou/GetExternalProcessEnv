using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace GetExternalProcessPath
{
    class Program
    {
        static void Main(string[] args)
        {
            var pid = Convert.ToInt32(args[0]);
			var process = Process.GetProcessById(pid);
			var env = process.ReadEnvironmentVariables();
			string path = env["PATH"];
			Console.WriteLine(path);
			
			/*
			var processes = Process.GetProcessesByName("devenv");

            if (processes.Length == 0)
                Console.WriteLine("Process with a given name not found. Please modify the code and specify the existing process name.");
            
            foreach (var process in processes)
            {
                Console.WriteLine();
                Console.WriteLine("Process with ID {0} has a PATH environment variable:", process.Id);
            }
			*/
        }
    }
}
