namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program1
    {
        static void Main1(string[] args)
        {
            // number of words to show
            int n = 25;
            string text = "White in tigers in live mostly in India Wild lions live mostly in Africa dds";
            // string filePath = "C:/Users/lykos/Downloads/sample.txt";
            // string text = File.ReadAllText(filePath);

            int textLength = 0;
            try
            {
                int i = 0;
            begin1:
                char c = text[i];
                textLength = i + 1;
                i++;
                goto begin1;
            }
            catch (Exception)
            {
            }


            int wordsArrayLength = 1000000;
            string[] words = new string[wordsArrayLength];

            // split alternative
            int emptyWordIndexTemp = 0;
            int i1 = 0;
        outer1:
            if (i1 < textLength)
            {
                if (text[i1] >= 65 && text[i1] <= 90 || text[i1] >= 97 && text[i1] <= 122)
                {
                    string word = "";
                    if (text[i1] >= 65 && text[i1] <= 90)
                    {
                        word += (char)(text[i1] + 32);
                    }
                    else
                    {
                        word += text[i1];
                    }
                    int k = i1 + 1;
                inner1:
                    if (k < textLength)
                    {
                        if (text[k] >= 97 && text[k] <= 122)
                        {
                            word += text[k];
                        }
                        else if (text[k] >= 65 && text[k] <= 90)
                        {
                            word += (char)(text[k] + 32);
                        }
                        else
                        {
                            i1 = k;
                            goto innerEnd1;
                        }
                        k++;
                        goto inner1;
                    }
                innerEnd1:
                    words[emptyWordIndexTemp] = word;
                    emptyWordIndexTemp++;
                }
                i1++;
                goto outer1;
            }

            string[] identicalWords = new string[wordsArrayLength];
            int[] wordNumbers = new int[wordsArrayLength];

            int i2 = 0;
        outer2:
            if (i2 < wordsArrayLength)
            {
                if (words[i2] == null)
                {
                    goto outerEnd2;
                }
                int j2 = 0;
            inner2:
                if (j2 < wordsArrayLength)
                {
                    if (identicalWords[j2] == words[i2])
                    {
                        wordNumbers[j2] = wordNumbers[j2] + 1;
                        goto outerContinue2;
                    }
                    else if (identicalWords[j2] == null)
                    {
                        // get length of desired word to add
                        int identicalWordLength = 0;
                        try
                        {
                            int ii = 0;
                        begin2:
                            char c = words[i2][ii];
                            identicalWordLength = ii + 1;
                            ii++;
                            goto begin2;
                        }
                        catch (Exception)
                        {
                        }
                        // if it is less than 4, don't add
                        if (identicalWordLength > 3)
                        {
                            identicalWords[j2] = words[i2];
                            wordNumbers[j2] = 1;
                        }
                        goto outerContinue2;
                    }
                    j2++;
                    goto inner2;
                }
            outerContinue2:
                i2++;
                goto outer2;
            }
        outerEnd2:
            int temp;
            string tempStr;
            int identicalWordsLength = 0;
            int write = 0;
        outer3:
            if (write < wordsArrayLength)
            {
                if (wordNumbers[write] == 0) goto outerEnd3;
                int sort = 0;
            inner3:
                if (sort < wordsArrayLength - 1)
                {
                    if (wordNumbers[sort + 1] == 0)
                    {
                        identicalWordsLength = sort + 1;
                        goto innerEnd3;
                    }
                    if (wordNumbers[sort] > wordNumbers[sort + 1])
                    {
                        temp = wordNumbers[sort + 1];
                        wordNumbers[sort + 1] = wordNumbers[sort];
                        wordNumbers[sort] = temp;
                        tempStr = identicalWords[sort + 1];
                        identicalWords[sort + 1] = identicalWords[sort];
                        identicalWords[sort] = tempStr;
                    }
                    sort++;
                    goto inner3;
                }
            innerEnd3:
                write++;
                goto outer3;
            }
        outerEnd3:
            int i4 = identicalWordsLength - 1;
        outer4:
            if (i4 >= (identicalWordsLength - n >= 0 ? identicalWordsLength - n : 0))
            {
                Console.WriteLine(identicalWords[i4] + " - " + wordNumbers[i4]);
                i4--;
                goto outer4;
            }
        }
    }
}