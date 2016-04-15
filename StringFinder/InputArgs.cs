using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringFinder
{

    internal class InvalidInputException : Exception
    {
        internal InvalidInputException()
            : base("Invalid Input")
        {            
        }
    }

    internal class InputArgs
    {

        private string root_path = string.Empty;
        private string resx_file = string.Empty;
        private string output_file = string.Empty;

        internal string Root { get { return root_path; } }
        internal string ResourceFile { get { return resx_file; } }
        internal string OutputFile { get { return output_file; } }
        
        internal InputArgs(string[] args){

            if (args.Length < 4) {
                throw new InvalidInputException();                
            }

            for(int i = 0; i < args.Length; i++) {

                if (args[i].ToLowerInvariant().Equals("-root"))
                {
                    root_path = args[i++];
                }
                else if (args[i].ToLowerInvariant().Equals("-resx"))
                {
                    resx_file = args[i++];
                }
                else if (args[i].ToLowerInvariant().Equals("-output"))
                {
                    output_file = args[i++];
                }
            }

            if (string.IsNullOrEmpty(output_file))
            {
                output_file = Constants.OutputFile;
            }

            if (string.IsNullOrEmpty(output_file) && string.IsNullOrEmpty(output_file))
            {
                throw new InvalidInputException();
            }
        }

        internal static void PrintHelp(){

            Console.WriteLine("\n Please provice the resource file and root path to search.\n");
            Console.WriteLine(" StringFinder -root <root_file_path> -resx <resource file path>");
            Console.WriteLine("  -output <optional_output_file> defaults to c:\\unused_strings.txt");
        }

    }
}
