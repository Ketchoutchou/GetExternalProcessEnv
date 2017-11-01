using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;

namespace GetExternalProcessEnv
{
    class Program
    {
        static int Main(string[] args)
        {
			const int WRONG_PARAM_COUNT = -1;
			const int PROCESS_ID_NOT_FOUND = -2;
			const int PROCESS_ID_INVALID = -3;
			const int ACCESS_DENIED = -4;
            if (args.Length == 0 | args.Length > 2)
			{
				Console.WriteLine("Usage: GetExternalProcessEnv [<Process id> [<Variable>]]");
				return WRONG_PARAM_COUNT;
			}
			int pid;
			Process process;
			if (args.Length > 0 && int.TryParse(args[0], out pid))
			{
				try
				{
					process = Process.GetProcessById(pid);
				}
				catch (ArgumentException)
				{
					Console.WriteLine("No process found with PID {0}", pid);
					return PROCESS_ID_NOT_FOUND;
				}
			}
			else
			{
				Console.WriteLine("{0} is not a valid process id", args[0]);
				return PROCESS_ID_INVALID;
			}
			StringDictionary env;
			try
			{
				env = process.ReadEnvironmentVariables();
			}
			catch (Win32Exception)
			{
				Console.WriteLine("Access to process {0} (PID {1}) is denied", process.ProcessName, process.Id);
				return ACCESS_DENIED;
			}
			var envVar = "PATH";
			if (args.Length == 2)
			{
				envVar = args[1];
			}
			string path = env[envVar];
			Console.WriteLine(path);
			return 0;
        }
    }
}
