class Task
{
    public virtual void Run()
    {
        Console.WriteLine("Running base task");
    }
}
class Task1 : Task
{
    public override void Run()
    {
        string text = "один три восемь девять семь пять ноль";
        string centralWord = FindCentralWord(text);

        Console.WriteLine("центральное слово: " + centralWord);
    }
    static string FindCentralWord(string text)
    {
        string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        int size = words.Length;
        int centralIndex = size / 2;

        return words[centralIndex];
    }
}
class Task2 : Task
{
    public override void Run()
    {
        string text = "раз два, три, раз три,";
        text = text.Replace(",", "").Replace(".", "").Replace("!", "").Replace("?", "");

        string[] words = text.Split(' ');

        List<string> repeatedWords = new List<string>();
        List<string> checkedWords = new List<string>();

        foreach (string word in words)
        {
            if (!checkedWords.Contains(word))
            {
                checkedWords.Add(word);
            }
            else if (!repeatedWords.Contains(word))
            {
                repeatedWords.Add(word);
            }
        }
        foreach (string repeatedWord in repeatedWords)
        {
            Console.WriteLine("повторяющиеся слова: " + repeatedWord);
        }
    }
}
class Program
{
    static void Main()
    {
        Task task1 = new Task1();
        Task task2 = new Task2();

        task1.Run();
        task2.Run();
    }
}
