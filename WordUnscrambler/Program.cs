using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Enter scrambled word(s) manually or as a file: F - file / M - manual");

                string option = Console.ReadLine() ?? throw new Exception("String is empty/null");

                switch (option.ToUpper())
                {
                    case "F":
                        Console.WriteLine("Enter file path including the file name: ");
                        ExecuteScrambledWordsInFileScenario();
                        break;
                        
                    case "M":
                        Console.WriteLine("Enter word(s) manually (separated by commas if multiple)");
                        ExecuteScrambledWordsManualEntryScenario();
                        break;
                    default:
                        Console.WriteLine("The entered option was not recognized");
                        break;
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("The program will be terminated." + ex.Message);
            }
        }


        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            //get user's input - a comma separated string containing scrambled words
            string manualInput;
            //extract the words into a string[] - use Split()

            char[] seperators = {',',' '};
            string[] scrambledWords = manualInput.Split(seperators);

            //display the matched words
            DisplayMatchedUnscrambledWords(scrambledWords);
        }


        private static void ExecuteScrambledWordsInFileScenario()
        {
            //read the user's input - file with scrambled words
            var fileName = Console.ReadLine();

            //read words from file and store in string[] scrambledWords
            string[] scrambledWords = _fileReader.Read(fileName);

            //display the matched words
            DisplayMatchedUnscrambledWords(scrambledWords);
        }


        private static void DisplayMatchedUnscrambledWords(string[] scrambleWords)
        {
            //read the list of words in the wordlist.txt file (unscrambled words)
            string[] wordList = _fileReader.Read("wordlist.txt");

            //call a word matched method, to get a list of MatchedWord structs
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambleWords, wordList);

            //display the match - print to console

            if (matchedWords.Any())
            {
                //loop through matchedWords and print to console the contents of the structs
                //foreach

                foreach (var matchedWord in matchedWords)
                {
                    //write to console
                    //Match found for act: cat

                    Console.WriteLine($"Match found for {matchedWord}: {matchedWord}");
                }

            }
            else 
            {
                //No Matches have been found
                Console.WriteLine("No matches have been found");
            }
            
            
                
         
        }
    }
}
