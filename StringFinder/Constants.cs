using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringFinder
{
    internal class Constants
    {

        internal static string OutputFile = @"c:\unused_strings.txt";
        internal static List<string> IgnoreWords = new List<string>(new string[] {"Strings", "Designer"});
        internal static List<string> FileExtensions = new List<string>(new string[] { ".cs", ".js", ".cshtml" });
    }
}
