using System.Runtime.CompilerServices;

List<string> DifMulConv(List<string> word, int count) 
{
    if (count == 0) return word;
    else 
    {
        count--;
        List<string> answer = [];
        for (int i = 1; i < word.Count(); i += 2) 
        {
            if (word[i] == "/")
            {
                int x = int.Parse(word[i - 1]);
                int y = int.Parse(word[i + 1]);
                string result = Convert.ToString(x / y);
                answer.Add(result);
                for (int j = i + 2; j < word.Count(); j++)
                {
                    answer.Add(word[j]);
                }
                break;
            }
            else if (word[i] == "*")
            {
                int x = int.Parse(word[i - 1]);
                int y = int.Parse(word[i + 1]);
                string result = Convert.ToString(x * y);
                answer.Add(result);
                for (int j = i + 2; j < word.Count(); j++)
                {
                    answer.Add(word[j]);
                }
                break;
            }
            else 
            {
                answer.Add(word[i - 1]);
                answer.Add(word[i]);   
            }
        }
        return DifMulConv(answer,count);
    }
}
List<string> Summer(List<string> word) 
{
    if (word.Count() < 3) return word;
    else 
    {
        List<string> answer = [];
        for (int i = 1; i < word.Count(); i += 2)
        {
            if (word[i] == "+")
            {
                int x = int.Parse(word[i - 1]);
                int y = int.Parse(word[i + 1]);
                string result = Convert.ToString(x + y);
                answer.Add(result);
                for (int j = i + 2; j < word.Count(); j++)
                {
                    answer.Add(word[j]);
                }
                break;
            }
            else if (word[i] == "-")
            {
                int x = int.Parse(word[i - 1]);
                int y = int.Parse(word[i + 1]);
                string result = Convert.ToString(x - y);
                answer.Add(result);
                for (int j = i + 2; j < word.Count(); j++)
                {
                    answer.Add(word[j]);
                }
                break;
            }
        }
        return Summer(answer);
    }

}

string pathToWrite = "C:\\Users\\Ging\\source\\repos\\SomeProject\\SomeProject\\answer.txt";
StreamWriter Writer = new StreamWriter(pathToWrite,false);
string pathToRead = "C:\\Users\\Ging\\source\\repos\\SomeProject\\SomeProject\\file.txt";
StreamReader Reader = new StreamReader(pathToRead);

string[] phrase = Reader.ReadLine().Split(" ");
List<string> words = [];
int count = 0;
foreach (string word in phrase) words.Add(word);

for (int i = 1; i < words.Count; i += 2) 
{
    if (words[i] == "/" || words[i] == "*") count++;
}

if (count != 0)
{
    List<string> answer = DifMulConv(words, count);
    List<string> secondAnswer = Summer(answer);
    foreach (string word in secondAnswer)
    {
        Writer.Write(word);
    }
    Writer.Flush();// очищает поток
}
else 
{
    List<string> answer = Summer(words); ;
    foreach (string word in answer)
    {
        Writer.Write(word);
    }
    Writer.Flush();
}