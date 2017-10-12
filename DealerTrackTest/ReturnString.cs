﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace DealerTrackTest
{
    public class ReturnString
    {

        /// <summary>
        ///Write a method that modifies a string using the following rules:
        ///1. Each word in the input string is replaced with the following: 

        ///* the first letter of the word
        ///* the count of distinct letters between the first and last letter

        ///* the last letter of the word.

        ///For example, "Automotive" would be replaced by "A6e".

        ///2. A "word" is defined as a sequence of alphabetic characters, delimited by any non-alphabetic
        ///characters.

        ///3. Any non-alphabetic character in the input string should appear in the output string in its
        /// original relative location.
        ///</summary>
        private static readonly Regex ValidCharacters = new Regex("^[a-zA-Z]*$");

        public static void Main(string[] args)
        {
            Console.WriteLine(PassMeAStringAnyString("Hello's, and goodbyes are a thing"));
            Console.ReadKey();
        }

        public static string PassMeAStringAnyString(string anyString)
        {
            var modifiedStringBuilder = new StringBuilder();

            if (!string.IsNullOrEmpty(anyString))
            {
                var wordsArray = anyString.Split(' ');
                const int firstPositionForInsertion = 1;
                
                int countValidChars;
                foreach (var word in wordsArray)
                {
                    var validCharactersToCount = new List<char>();
                    countValidChars = 0;
                    var finalDictWord = new Dictionary<int, string>();
                    //If the word is less than 3 letters it will contain unique letters
                    if (word.Length > 2)
                    {
                        var firstLetterLocation = GetFirstOrLastLetterInWord(word, true);
                        var lastLetterLocation = GetFirstOrLastLetterInWord(word, false);

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
                        finalDictWord.Add(firstPositionForInsertion, countValidChars.ToString());
                        finalDictWord.Add(firstLetterLocation.Key, firstLetterLocation.Value);
                        finalDictWord.Add(lastLetterLocation.Key, lastLetterLocation.Value);
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
            return modifiedStringBuilder.ToString();
        }

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