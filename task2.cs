namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program2
    {
        static void Main2(string[] args)
        {
            string[] lines = File.ReadAllLines("C:/Users/lykos/Downloads/sample.txt");
            int lineHeight = 45;

            string[] pages = new string[1000000];
            string textTemp = "";
            int pageIndexTemp = 0;
            int i1 = 0;
        outer1:
            if (i1 < lines.Length)
            {
                if (i1 % lineHeight == 0 && i1 != 0)
                {
                    pages[pageIndexTemp] = textTemp;
                    pageIndexTemp++;
                    textTemp = "";
                }
                textTemp += lines[i1] + " ";
                i1++;
                goto outer1;
            }

            string[] words = new string[1000000];
            int pageLimit = 100;
            int[][] pageNumbers = new int[1000000][];
            int i2 = 0;
        outer2:
            if (i2 < 1000000)
            {
                pageNumbers[i2] = new int[pageLimit + 1];
                i2++;
                goto outer2;
            }

            int i3 = 0;
        outer3:
            if (i3 < 1000000)
            {
                string pageText = pages[i3];
                if (pageText == null) goto outerEnd3;
                string[] pageWords = new string[1000000];

                // split alternative
                int textLength = pageText.Length;
                int emptyWordIndexTemp = 0;
                int j3_1 = 0;
            inner3_1:
                if (j3_1 < textLength)
                {
                    if (pageText[j3_1] >= 65 && pageText[j3_1] <= 90 || pageText[j3_1] >= 97 && pageText[j3_1] <= 122)
                    {
                        string word = "";
                        word += pageText[j3_1];
                        int k = j3_1 + 1;
                    innerInner3_1:
                        if (k < textLength)
                        {
                            if ((pageText[k] >= 65 && pageText[k] <= 90 || pageText[k] >= 97 && pageText[k] <= 122))
                            {
                                word += pageText[k];
                            }
                            else
                            {
                                j3_1 = k;
                                goto innerInnerEnd3_1;
                            }
                            k++;
                            goto innerInner3_1;
                        }
                    innerInnerEnd3_1:
                        pageWords[emptyWordIndexTemp] = word;
                        emptyWordIndexTemp++;
                    }
                    j3_1++;
                    goto inner3_1;
                }

                // main logic
                int j3_2 = 0;
            inner3_2:
                if (j3_2 < pageWords.Length)
                {
                    if (pageWords[j3_2] == null) goto innerEnd3_2;
                    int k3 = 0;
                innerInner3_2:
                    if (k3 < words.Length)
                    {
                        if (words[k3] == pageWords[j3_2])
                        {
                            int l3 = 0;
                        innerInnerInner3_2:
                            if (l3 < pageLimit + 1)
                            {
                                if (pageNumbers[k3][l3] == i3 + 1) goto innerInnerInnerEnd3_2;
                                if (pageNumbers[k3][l3] == 0)
                                {
                                    pageNumbers[k3][l3] = i3 + 1;
                                    goto innerInnerInnerEnd3_2;
                                }
                                l3++;
                                goto innerInnerInner3_2;
                            }
                        innerInnerInnerEnd3_2:
                            goto innerInnerEnd3_2;
                        }
                        if (words[k3] == null)
                        {
                            words[k3] = pageWords[j3_2];
                            pageNumbers[k3][0] = i3 + 1;
                            goto innerInnerEnd3_2;
                        }
                        k3++;
                        goto innerInner3_2;
                    }
                innerInnerEnd3_2:
                    j3_2++;
                    goto inner3_2;
                }
            innerEnd3_2:
                i3++;
                goto outer3;
            }
        outerEnd3:

            // sort
            string? temp = null;
            int[]? tempArray = null;
            int write = 0;
        outer4:
            if (write < words.Length)
            {
                if (words[write] == null) goto outerEnd4;
                int sort = 0;
            inner4:
                if (sort < words.Length - 1)
                {
                    if (words[sort + 1] == null)
                    {
                        goto innerEnd4;
                    }
                    bool firstLonger = words[sort].Length - words[sort + 1].Length > 0;
                    bool firstGreater = false;
                    int i4 = 0;
                innerInner4:
                    if (i4 < (firstLonger ? words[sort + 1].Length : words[sort].Length))
                    {
                        if (words[sort][i4] > words[sort + 1][i4])
                        {
                            firstGreater = true;
                        }
                        if (words[sort][i4] != words[sort + 1][i4])
                        {
                            goto innerInnerEnd4;
                        }
                        i4++;
                        goto innerInner4;
                    }
                innerInnerEnd4:
                    if (firstGreater)
                    {
                        temp = words[sort + 1];
                        words[sort + 1] = words[sort];
                        words[sort] = temp;
                        tempArray = pageNumbers[sort + 1];
                        pageNumbers[sort + 1] = pageNumbers[sort];
                        pageNumbers[sort] = tempArray;
                    }
                    sort++;
                    goto inner4;
                }
            innerEnd4:
                write++;
                goto outer4;
            }
        outerEnd4:

            // print
            int i5 = 0;
        outer5:
            if (i5 < words.Length)
            {
                if (words[i5] == null) goto outerEnd5;
                if (pageNumbers[i5][pageLimit] != 0) goto outerContinue5;
                string output = words[i5] + " - ";
                int j5 = 0;
            inner5:
                if (j5 < pageLimit)
                {
                    if (pageNumbers[i5][j5] == 0) goto innerEnd5;
                    output += pageNumbers[i5][j5];
                    if (j5 != pageLimit - 1 && pageNumbers[i5][j5 + 1] != 0)
                    {
                        output += ", ";
                    }
                    j5++;
                    goto inner5;
                }
            innerEnd5:
                Console.WriteLine(output);
            outerContinue5:
                i5++;
                goto outer5;
            }
        outerEnd5:
            int end;
        }
    }
}