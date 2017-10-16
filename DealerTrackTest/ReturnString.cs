using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTest
{
    public class ReturnString
    {
        private static readonly System.Text.RegularExpressions.Regex ValidCharacters =
            new System.Text.RegularExpressions.Regex("^[a-zA-Z]*$");
        
        public static void Main(string[] args)
        {
            Console.WriteLine(PassMeAStringAnyString("H'ello's, and goodbyes are a thi*ng!"));
            Console.ReadKey();
        }

        public static string PassMeAStringAnyString(string anyString)
        {
            var modifiedStringBuilder = new System.Text.StringBuilder();
            //var modifiedStringBuilder = new StringBuilder();

            if (!string.IsNullOrEmpty(anyString))
            {
                var wordsArray = anyString.Split(' ');
                
                
                int countValidChars;
                foreach (var word in wordsArray)
                {
                    int firstPositionForInsertion = 1;
                    var validCharactersToCount = new List<char>();
                    //countValidChars = 0;
                    var finalDictWord = new Dictionary<int, string>();
                    //If the word is less than 3 letters it will contain unique letters so just return the word
                    //Loop through each word in the sentence, since a sentence is delimitted by a space
                    if (word.Length > 2)
                    {
                        var firstLetterLocation = GetFirstOrLastLetterInWord(word, true);
                        var lastLetterLocation = GetFirstOrLastLetterInWord(word, false);
                        
                        //Loop through each character in the word
                        for (int character = 0; character < word.Length; character++)
                        {
                            finalDictWord.Add(character, word[character].ToString());
                            if (ValidCharacters.IsMatch(word[character].ToString()))
                            {
                                validCharactersToCount.Add(word[character]);
                                finalDictWord.Remove(character);
                            }

                            if (character == firstLetterLocation.Key || character == lastLetterLocation.Key)
                            {
                                validCharactersToCount.Remove(word[character]);
                            }
                        }

                        countValidChars = validCharactersToCount.Distinct().Count();
                        if (finalDictWord.ContainsKey(firstPositionForInsertion))
                        {
                            firstPositionForInsertion++;
                        }

                        finalDictWord.Add(firstPositionForInsertion, countValidChars.ToString());
                        finalDictWord.Add(firstLetterLocation.Key, firstLetterLocation.Value);

                        if (finalDictWord.ContainsKey(lastLetterLocation.Key))
                        {
                            var letterLocation = lastLetterLocation.Key;
                            var letterValue = lastLetterLocation.Value;
                            finalDictWord.Remove(lastLetterLocation.Key);
                            letterLocation++;
                            finalDictWord.Add(letterLocation, letterValue);
                        }
                        else
                        {
                            finalDictWord.Add(lastLetterLocation.Key, lastLetterLocation.Value);
                        }
                        
                        var orderedKeys = finalDictWord.Keys.ToList();
                        orderedKeys.Sort();
                        foreach (var key in orderedKeys)
                        {
                            modifiedStringBuilder.Append(finalDictWord[key]);
                        }
                    }
                    else
                    {
                        modifiedStringBuilder.Append(word);
                        modifiedStringBuilder.Append(' ');
                        continue;
                    }
                    modifiedStringBuilder.Append(' ');
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
            return modifiedStringBuilder.ToString().TrimEnd();
        }

        /// <summary>
        /// This method takes in a word and a bool to determine if you want the first or last word
        /// it then returns the location and the character in the word
        /// </summary>
        /// <param name="word">The word you want to find the first or last character</param>
        /// <param name="first">bool to specify if is the first letter</param>
        /// <returns>returns a keyvaluepair that contains the location and the character</returns>
        private static KeyValuePair<int, string> GetFirstOrLastLetterInWord(string word, bool first)
        {
            var finalWordLocation = new Dictionary<int, string>();
            for(var character = 0; character < word.Length; character++)
            {
                if(ValidCharacters.IsMatch(word[character].ToString()))
                {
                    finalWordLocation.Add(character, word[character].ToString());
                }
            }
            return first ? finalWordLocation.First() : finalWordLocation.Last();
        }
    }
}
