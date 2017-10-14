using System;
using System.ComponentModel;
using System.Diagnostics;

namespace GetExternalProcessPath
{
    class Program
    {
        static void Main(string[] args)
        {
            int pit = -1
			Process process;
			try {
				var pid = Convert.ToInt32(args[0]);
				var process = Process.GetProcessById(pid);
				var env = process.ReadEnvironmentVariables();
				string path = env["PATH"];
				//Console.WriteLine("");
				Console.WriteLine(path);
				return 0;
			} catch (IndexOutOfRangeException e) {
				//Console.WriteLine("There should be one (and only one) parameter (PID)");
				return -1;
			} catch (FormatException e) {
				//Console.WriteLine("Parameter should be a PID");
				return -2;
			} catch (ArgumentException e) {
				//Console.WriteLine("No process found with PID {0}",pid);
				return -3;
			} catch (Win32Exception e) {
				//Console.WriteLine("Access to process with PID {0} is denied",pid);
				return -4;
			}
			
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
