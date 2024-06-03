public class FormatText()
{
    // Convert first characters of a word to uppercase (capital letter)

    public string FirstCharacterToUpper(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            return string.Empty;
        }
        else
        {
            return $"{word[0].ToString().ToUpper()}{word.Substring(1)}";
        }
    }

    // Convert every first latter of a sentence into capital letters
    public string TitleCase(string sentence)
    {
        /*Convert the first characters of each word in a sentence to uppercase*/
        if (string.IsNullOrEmpty(sentence))
        {
            return string.Empty;
        }
        else
        {
            string newSentence = "";
            string[] words = sentence.Split(" ");
            int count = 1;
            foreach (string word in words)
            {
                string newWord = FirstCharacterToUpper(word);
                if (count < words.Length)
                {
                    newSentence += $"{newWord} ";
                    count++;
                }
                else
                {
                    newSentence += $"{newWord}";
                }
            }

            return newSentence;
        }
    }

    // Convert every first latter of a sentence after a full-stop "." i.e a dot.
    public string Capitalize(string sentence)
    {
        // Convert every first latter of a sentence after a full-stop "." i.e a dot.
        if (string.IsNullOrEmpty(sentence))
        {
            return string.Empty;
        }
        else
        {
            string newSentence = "";
            /*Convert the first characters of each word in a sentence to uppercase*/
            string[] words = sentence.Split(". ");
            int count = 1;
            foreach (string word in words)
            {
                string newWord = FirstCharacterToUpper(word);
                if (count < words.Length)
                {
                    newSentence += $"{newWord}. ";
                    count++;
                }
                else
                {
                    newSentence += $"{newWord}";
                }
            }

            return newSentence;
        }
    }
}