using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {

          
            string option, officialOption;

            try
            {

                do
                {
                    string quit;
                    bool isValid;

                    do
                    {
                        Console.WriteLine("Enter scrambled word(s) manually or as a file: F - file / M - manual");
                        option = Console.ReadLine() ?? throw new Exception("String is empty/null");

                        switch (option)
                        {
                            case "M":
                            case "m":
                                option = "M";
                                isValid = true;
                                break;
                            case "F":
                            case "f":
                                option = "F";
                                isValid = true;
                                break;
                            default:
                                option = null;
                                isValid = false;
                                break;
                        }

                    } while (isValid == false);

                    officialOption = option;

                    switch (officialOption.ToUpper())
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

                    do
                    {
                        Console.WriteLine("Would you like to continue? Y/N");
                        quit = Console.ReadLine() ?? throw new Exception("String is empty/null");

                        switch (quit)
                        {
                            case "Y":
                            case "y":
                                quit = "Y";
                                isValid = true;
                                break;
                            case "N":
                            case "n":
                                quit = "N";
                                isValid = true;
                                break;
                            default:
                                quit = null;
                                isValid = false;
                                break;
                        }
                    } while (isValid == false);

                    officialOption = quit;
                } while (officialOption.Contains("Y") || officialOption.Contains("y"));
            } 
            
            catch (Exception ex)
            {
                Console.WriteLine("The program will be terminated." + ex.Message);
            }

        }


        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            //get user's input - a comma separated string containing scrambled words
            string manualInput = Console.ReadLine();
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
                    Console.WriteLine("Match found for {0}: {1}" ,scrambleWords , matchedWord);
                }
            }
            else 
            {
                //No Matches have been found
                Console.WriteLine("No matches have been found");
                Console.ReadLine();
            }
        }
    }
}
