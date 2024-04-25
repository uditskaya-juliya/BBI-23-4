using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

abstract class Task
{
    public abstract override string ToString();
}

//1
class LetterFrequency : Task
{
    private string text;

    public LetterFrequency(string text)
    {
        this.text = text;
    }

    public override string ToString()
    {
        var letters = text.Where(char.IsLetter).GroupBy(char.ToLower).Select(group => new
        {
            Letter = group.Key,
            Frequency = (double)group.Count() / text.Length
        });

        return string.Join("\n", letters.Select(b => $"Letter: {b.Letter}, Frequency: {b.Frequency:P2}"));
    }
}

//3
class TextSplitting : Task
{
    private string text;

    public TextSplitting(string text)
    {
        this.text = text;
    }

    public override string ToString()
    {
        List<string> lines = new List<string>();
        string currentLine = "";

        foreach (var word in text.Split(' '))
        {
            if ((currentLine + word).Length > 50)
            {
                lines.Add(currentLine.Trim());
                currentLine = "";
            }
            currentLine += word + " ";
        }

        if (currentLine.Length > 0)
            lines.Add(currentLine.Trim());

        return string.Join("\n", lines);
    }
}


//6
class SyllableCount : Task
{
    private string text;

    public SyllableCount(string text)
    {
        this.text = text;
    }

    private int CountSyllables(string word)
    {
        char[] vowels = new char[] { 'а', 'е', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
        int syllableCount = 0;
        word = word.ToLower();

        for (int i = 0; i < word.Length; i++)
        {
            if (vowels.Contains(word[i]))
            {
                if (i == 0 || !vowels.Contains(word[i - 1]))
                {
                    syllableCount++;
                }
            }
        }


        if (word.EndsWith("е") || word.EndsWith("о"))
        {
            syllableCount--;
        }

        return Math.Max(syllableCount, 1);
    }

    public override string ToString()
    {
        var words = Regex.Split(text, @"\W+").Where(w => w != string.Empty);
        var syllableCounts = words.Select(word => CountSyllables(word));
        var syllableGroups = syllableCounts.GroupBy(count => count).Select(group => new
        {
            SyllableCount = group.Key,
            WordCount = group.Count()
        });

        return string.Join("\n", syllableGroups.Select(g => $"Слогов: {g.SyllableCount}, Слов: {g.WordCount}"));
    }
}


//12
class WordCodeReplacement : Task
{
    private string text;
    private Dictionary<string, int> wordToCodeMap;
    private Dictionary<int, string> codeToWordMap;

    public WordCodeReplacement(string text)
    {
        this.text = text;
        wordToCodeMap = new Dictionary<string, int>();
        codeToWordMap = new Dictionary<int, string>();
        InitializeWordCodeMaps();
    }

    private void InitializeWordCodeMaps()
    {
        int code = 1;
        var words = Regex.Split(text, @"\W+").Where(w => w != string.Empty).Distinct();
        foreach (var word in words)
        {
            wordToCodeMap[word] = code;
            codeToWordMap[code] = word;
            code++;
        }
    }

    private string ReplaceWordsWithCodes(string inputText)
    {
        return Regex.Replace(inputText, @"\b(\w+)\b", match =>
        {
            int code;
            if (wordToCodeMap.TryGetValue(match.Value, out code))
            {
                return code.ToString();
            }
            return match.Value;
        });
    }

    private string ReplaceCodesWithWords(string inputText)
    {
        return Regex.Replace(inputText, @"\b(\d+)\b", match =>
        {
            int code = int.Parse(match.Value);
            string word;
            if (codeToWordMap.TryGetValue(code, out word))
            {
                return word;
            }
            return match.Value;
        });
    }

    public override string ToString()
    {
        string codedText = ReplaceWordsWithCodes(text);
        string decodedText = ReplaceCodesWithWords(codedText);
        return $"Закодированный текст:\n{codedText}\n\nДекодированный текст:\n{decodedText}";
    }
}


//13
class LetterStartPercentage : Task
{
    private string text;

    public LetterStartPercentage(string text)
    {
        this.text = text;
    }

    private Dictionary<char, double> CalculateLetterStartPercentage()
    {
        var words = Regex.Split(text, @"\W+").Where(w => w != string.Empty);
        var totalWords = words.Count();
        var letterStartCounts = words
            .GroupBy(w => char.ToLower(w[0]))
            .ToDictionary(group => group.Key, group => group.Count());

        return letterStartCounts.ToDictionary(
            kvp => kvp.Key,
            kvp => (double)kvp.Value / totalWords * 100);
    }

    public override string ToString()
    {
        var letterPercentages = CalculateLetterStartPercentage();
        return string.Join("\n", letterPercentages.Select(kvp =>
            $"Буква: {kvp.Key}, Доля: {kvp.Value:F2}%"));
    }
}


//15
class SumOfNumbers : Task
{
    private string text;

    public SumOfNumbers(string text)
    {
        this.text = text;
    }

    private int CalculateSumOfNumbers()
    {
        var matches = Regex.Matches(text, @"\b\d+\b");
        return matches.Cast<Match>().Sum(m => int.Parse(m.Value));
    }

    public override string ToString()
    {
        int sum = CalculateSumOfNumbers();
        return $"Сумма чисел в тексте: {sum}";
    }
}


static class Program
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        string fileContent = File.ReadAllText("texts.txt");
        string[] texts = fileContent.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        int i = 1;
        foreach (string text in texts)
        {
            Console.WriteLine("\n--------------------------------------------------\n");
            Console.WriteLine($"Текст для анализа {i}:");
            Console.WriteLine(text);
            Console.WriteLine("\n--------------------------------------------------\n");

            var letterFrequency = new LetterFrequency(text);
            var textSplitting = new TextSplitting(text);
            var syllableCount = new SyllableCount(text);
            var wordCodeReplacement = new WordCodeReplacement(text);
            var letterStartPercentage = new LetterStartPercentage(text);
            var sumOfNumbers = new SumOfNumbers(text);

            Console.WriteLine("\nЗадание 1\n");
            Console.WriteLine(letterFrequency.ToString());
            Console.WriteLine("\nЗадание 3\n");
            Console.WriteLine(textSplitting.ToString());
            Console.WriteLine("\nЗадание 6\n");
            Console.WriteLine(syllableCount.ToString());
            Console.WriteLine("\nЗадание 12\n");
            Console.WriteLine(wordCodeReplacement.ToString());
            Console.WriteLine("\nЗадание 13\n");
            Console.WriteLine(letterStartPercentage.ToString());
            Console.WriteLine("\nЗадание 15\n");
            Console.WriteLine(sumOfNumbers.ToString());

            Console.WriteLine("\n--------------------------------------------------\n");
            Console.WriteLine($"Конец анализа текста {i}");
            Console.WriteLine("\n--------------------------------------------------\n");
            i++;
        }
    }
}
