using System;

namespace UPPGIFT_2___ARABISKA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Skriv in antal ord meningen innehåller: ");
            Console.ReadLine(); //Amount of words not needed inside program
            Console.Write("Skriv en mening du vill se på arabiska: ");
            string sentence = Console.ReadLine();
            sentence = ModifyString(sentence);
            Console.WriteLine("På arabiska hade meningen blivit: " + sentence);
        }

        static string ModifyString(string sentence){
            //Remove vocals
            string modifiedSentence = "";
            for(int i = 0; i < sentence.Length; i++){
                char letter = sentence[i];

                if(CheckVocal(letter.ToString())){

                    if(i < sentence.Length - 2) //Dont do anything if there is only one letter left
                    {
                        string lettersAfterVocal = sentence[i + 1].ToString() + sentence[i + 2].ToString();

                        if(CheckLettersAfterVocal(lettersAfterVocal))
                            continue;
                    }
                }

                //Add letter to start of modified sentence;
                modifiedSentence = modifiedSentence.Insert(0, letter.ToString());
            }
            return modifiedSentence;
        }

        static bool CheckLettersAfterVocal(string twoLetters){
            if(CheckVocal(twoLetters[0].ToString(), true))
                return false;

            if(CheckVocal(twoLetters[1].ToString(), true))
                return false;
            return true;
        }

        static bool CheckVocal(string letter, bool countBlankspace = false){
            switch (letter){
                case "a":
                    return true;
                case "e":
                    return true;
                case "i":
                    return true;
                case "o":
                    return true;
                case "u":
                    return true;
                case "y":
                    return true;  
            }

            //Counts blankspace as a vocal
            if(countBlankspace){
                if(letter == " ")
                    return true;
            }

            return false;
        }
    }
}
