using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Constants
    {
        //all the constant string that are present inside 
        string[] constant = { "Enter scrambled word(s) manually or as a file: F - file / M - manual", 
            "Enter file path including the file name: ", 
            "Enter word(s) manually (separated by commas if multiple)", 
            "The entered option was not recognized", 
            "Would you like to continue? Y/N",
            "Match found for {0}: {1}", 
            "String is empty/null",
        "The program will be terminated.",
        "No matches have been found"};


        public string IntroductionString() 
        {
            return constant[0];
        }

        public string FilePathString() 
        {
            return constant[1];
        }

        public string ManualPathString() 
        {
            return constant[2];
        }

        public string InvalidPathString()
        {
            return constant[3];
        }

        public string QuitValidationString() 
        {
            return constant[4];
        }

        public string MatchFoundString() 
        {
            return constant[5];
        }

        public string ExceptionString()
        {
            return constant[6];
        }

        public string ProgramTerminationString() 
        {
            return constant[7];
        }

        public string NoMatchesFoundString() 
        {
            return constant[8];
        }
    }
}
