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
        private static readonly Constants _constants = new Constants();

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
                        Console.WriteLine(_constants.IntroductionString());
                        option = Console.ReadLine() ?? throw new Exception(_constants.ExceptionString());

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
                            Console.WriteLine(_constants.FilePathString());
                            ExecuteScrambledWordsInFileScenario();
                            break;

                        case "M":
                            Console.WriteLine(_constants.ManualPathString());
                            ExecuteScrambledWordsManualEntryScenario();
                            break;
                        default:
                            Console.WriteLine(_constants.InvalidPathString());
                            break;
                    }

                    do
                    {
                        Console.WriteLine(_constants.QuitValidationString());
                        quit = Console.ReadLine() ?? throw new Exception(_constants.ExceptionString());

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
                Console.WriteLine(_constants.ProgramTerminationString() + ex.Message);
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
                    Console.WriteLine(_constants.MatchFoundString(), matchedWord.ScrambledWord, matchedWord.Word);
                }
            }
            else 
            {
                //No Matches have been found
                Console.WriteLine(_constants.NoMatchesFoundString());
            }
        }
    }
}
