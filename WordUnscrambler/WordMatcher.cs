using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            foreach (var scrambledWord in scrambledWords)
            {
                foreach (var word in wordList)
                {

                    //scrambledWord already matches word
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                    }
                    else
                    {
                        char[] scrambledWordArray = scrambledWord.ToCharArray();
                        char[] scrambledWordArray2 = word.ToCharArray();

                        Array.Sort(scrambledWordArray);
                        Array.Sort(scrambledWordArray2);

                        string scramble = new string(scrambledWordArray);
                        string scramble2 = new string(scrambledWordArray2);

                        if (scramble.Equals(scramble2))
                        {
                            matchedWords.Add(BuildMatchedWord(scramble, scramble2));
                        }

                        //convert strings into character arrays

                        //sort both character arrays (Array.sort())
                        //act -> sort -> act
                        //cat -> sort -> act

                        //convert character arrays back to a string

                        //compare the two strings 
                        //if they are equal, add to matchedWords list
                    }

                }
            }

            MatchedWord BuildMatchedWord(string scrambledWord, string word)
            {
                MatchedWord matchedWord = new MatchedWord
                {
                    ScrambledWord = scrambledWord,
                    Word = word
                };

                return matchedWord;
            }

            return matchedWords;
        }

    }
}
