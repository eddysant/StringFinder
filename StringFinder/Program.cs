using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Collections;
using System.IO;

namespace StringFinder
{
	class Program
	{

		static void Main(string[] args)
		{
            InputArgs input = null;
            try
            {
                input = new InputArgs(args);
            }
            catch
            {
                InputArgs.PrintHelp();
                return;
            }

            /* load resource file */
			var rsxr = new ResXResourceReader(input.ResourceFile);

			using (System.IO.StreamWriter outFile = new System.IO.StreamWriter(input.OutputFile))
			{
                /* loop through each entry in the resource and look for it */
				foreach (DictionaryEntry entry in rsxr)
				{
					if (FindInDirectory(input.Root, ((string)entry.Key)))
						continue;
					else
						outFile.WriteLine(((string)entry.Key));
				}
			}
		}        

		private static bool FindInDirectory(string path, string value)
		{

			var dir = new DirectoryInfo(path);
			foreach (var di in dir.GetDirectories())
			{
				if (FindInDirectory(di.FullName, value))
					return true;
			}

			foreach (var fi in dir.GetFiles().Where(s => Constants.FileExtensions.Any( f => s.FullName.EndsWith(f) )))                                
			{
				if (FindInFile(fi.FullName, value))
					return true;
			}
			return false;
		}

		private static bool FindInFile(string path, string value)
		{
			if (Constants.IgnoreWords.Any(s => path.Contains(s)))
				return false;

			string line;
			using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
			{
				while ((line = reader.ReadLine()) != null)
				{
					if (line.Contains(value))
					{
						Console.WriteLine(line);
						return true;
					}
				}
				return false;
			}
		}

	}
}
