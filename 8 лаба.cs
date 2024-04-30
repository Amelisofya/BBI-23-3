
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
abstract class Task
{
    public Task(string text) { }
    protected virtual string ParseText(string text)
    { return text; }

}
class Task_2 : Task
{
    private string text;
    public Task_2(string text) : base(text) { this.text = text; }
    protected override string ParseText(string text)
    {
        return base.ParseText(text);
    }
    public override string ToString()
    {
        text = ParseText(text);
        return text;
    }
    public static string Encrypt(string message)
    {
        char[] charArray = message.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public static string Decrypt(string encryptedMessage)
    {
        char[] charArray = encryptedMessage.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
class Task_4 : Task
{
    private string text;
    public Task_4(string text) : base(text) { this.text = text; }
    public override string ToString()
    {
        text = ParseText(text);
        return text;
    }
    protected override string ParseText(string text)
    {
        int wordCount = 0;
        int punctCount = 0;

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                wordCount++;
            }
            else if (char.IsPunctuation(c))
            {
                punctCount++;
            }
        }

        return (wordCount + punctCount).ToString();
    }

}
class Task_6 : Task
{
    private string text;
    public Task_6(string text) : base(text) { this.text = text; }
    public override string ToString()
    {
        text = ParseText(text);
        return text;
    }
    protected override string ParseText(string word)
    {
        Regex regex = new Regex("[ёуеыаоэяиюeyuoai]", RegexOptions.IgnoreCase);

        int Counter = regex.Matches(word).Count;

        if (word.EndsWith("e") || word.EndsWith("es"))
        {
            Counter--;
        }

        if (Counter == 0)
        {
            return (1).ToString();
        }

        return (Counter).ToString();
    }

}
class Task_8 : Task
{
    private string text;
    public Task_8(string text) : base(text) { this.text = text; }
    public override string ToString()
    {
        text = ParseText(text);
        return text;
    }
    protected int Count()
    {
        return 0;
    }
    protected override string ParseText(string text)
    {
        int start = 0;
        string result = "";
        int i = 50;
        for (int j = i; j < text.Length; j += i)
        {
            string s = "";
            int k;
            for (k = j; j >= start; k--)
            {
                if (text[k] == ' ')
                {
                    break;
                }
                s += " ";
            }
            string line = text.Substring(start, k - start) + s;
            start = k + 1;
            j = start;
            result += line + "\n";

        }

        return result;

    }
}
class Task_9 : Task
{
    string text;
    private string[] Ke;
    private string[] Codes;
    public Task_9(string text) : base(text) { this.text = text; }
    public string[] GetKeys()
    {
        return Ke;
    }
    public string[] GetCodes()
    {
        return Codes;
    }
    public override string ToString()
    {
        return ParseText(text);
    }

    protected string[] First10KeysToArray(Dictionary<string, int> a)
    {
        return a.Take(10).Select(x => x.Key).ToArray();
    }
    protected Dictionary<string, int> CreateRusLetterDict()
    {
        Dictionary<string, int> letterComb = new Dictionary<string, int>();
        for (int i = 1072; i < 1105; i++)
        {
            for (int j = 1072; j < 1105; j++)
            {
                int n1 = i;
                int n2 = j;
                if (i == 1104) { n1 += 1; }
                if (j == 1104) { n2 += 1; }
                char first = (char)n1;
                char second = (char)n2;
                string k = first.ToString() + second.ToString();
                letterComb.Add(k, 0);
            }
        }
        return letterComb;
    }
    protected Dictionary<string, int> CreateEngLetterDict()
    {
        Dictionary<string, int> letterComb = new Dictionary<string, int>();
        for (int i = 97; i < 123; i++)
        {
            for (int j = 97; j < 123; j++)
            {
                int n1 = i;
                int n2 = j;
                char first = (char)n1;
                char second = (char)n2;
                string k = first.ToString() + second.ToString();
                letterComb.Add(k, 0);
            }
        }

        return letterComb;
    }
    protected bool CheckTextOnLanguage()
    {
        string rusLetter = "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";
        for (int i = 0; i < rusLetter.Length; i++)
        {
            if (text.Contains(rusLetter[i]))
            {
                return true;
            }
        }
        return false;
    }
    protected string[] CreateCode()
    {
        string[] code = new string[10];
        int c = 0;
        for (int i = 33; i < 127; i++)
        {
            if (text.Contains((char)i) == false)
            {
                code[c] = char.ToUpper((char)i).ToString();
                c++;
                if (c == 10)
                {
                    break;
                }
            }

        }
        return code;
    }
    protected override string ParseText(string text)
    {
        Dictionary<string, int> letterComb = new Dictionary<string, int>();

        if (CheckTextOnLanguage() == false)
        {
            letterComb = CreateEngLetterDict();
        }
        else
        {
            letterComb = CreateRusLetterDict();
        }

        for (int i = 0; i < text.Length - 1; i++)
        {
            if (letterComb.ContainsKey(text[i].ToString() + text[i + 1].ToString()))
            {
                letterComb[text[i].ToString() + text[i + 1].ToString()]++;
            }
        }



        var sortedLetterComb = letterComb.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        string[] ke = First10KeysToArray(sortedLetterComb);
        string[] code = CreateCode();

        for (int i = 0; i < ke.Length; i++)
        {
            text = text.Replace(ke[i], code[i]);
        }
        Ke = ke;
        Codes = code;

        return text;
    }

}
class Task_10 : Task
{
    string[] codes;
    string[] keys;
    string text;
    public Task_10(string text, string[] codes, string[] keys) : base(text)
    {
        this.text = text;
        this.codes = codes;
        this.keys = keys;
    }
    public override string ToString()
    {
        return ParseText(text);
    }

    protected override string ParseText(string text)
    {

        string[] ke = keys;
        string[] code = codes;

        for (int i = 0; i < ke.Length; i++)
        {
            text = text.Replace(code[i], ke[i]);
        }

        return text;
    }

}
class Program
{
    public static void Main()
    {
        Console.WriteLine("\n Задание 2 ");
        Console.WriteLine("Введите сообщение для шифрования:");
        string message = Console.ReadLine();

        string encryptedMessage = Task_2.Encrypt(message);
        Console.WriteLine($"Зашифрованное сообщение: {encryptedMessage}");

        string decryptedMessage = Task_2.Decrypt(encryptedMessage);
        Console.WriteLine($"Расшифрованное сообщение: {decryptedMessage}");

        string text1 = "После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений.";
        string text = File.ReadAllText(@"C:\Users\Ameli\OneDrive\Рабочий стол");

        Task_4 task4 = new Task_4(text1);
        Console.WriteLine("\t Задание 4");
        Console.WriteLine(task4);
        Console.WriteLine("\n \t Задание 6");
        Task_6 task6 = new Task_6(text1);
        Console.WriteLine(task6);
        Console.WriteLine("\n \t Задание 8");
        Task_8 task8 = new Task_8(text1);
        Console.WriteLine(task8);
        Console.WriteLine("\n \t Задание 9");
        Task_9 task9 = new Task_9(text1);
        Console.WriteLine(task9);
        Console.WriteLine("\n\t Задание 10");
        Task_10 task10 = new Task_10(task9.ToString(), task9.GetCodes(), task9.GetKeys());
        Console.WriteLine(task10);

    }

}