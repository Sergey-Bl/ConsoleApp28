using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        // Загрузка имен из файла JSON / Получилось только через абсолютный путь, через другие пути не получилось
        List<string> names = LoadNamesFromJson("/Users/sergei/RiderProjects/ConsoleApp3/ConsoleApp3/Code/Names.json");

        // Имена, заканчивающиеся на 's'
        List<string> namesEndingWithS = names.FindAll(name => name.EndsWith("s", StringComparison.OrdinalIgnoreCase));
        Console.WriteLine("Имена, заканчивающиеся на 's':");
        foreach (string name in namesEndingWithS)
        {
            Console.WriteLine(name);
        }

        // Самое длинное имя и его размер
        var longestName = names.MaxBy(name => name.Length);
        Console.WriteLine("Самое длинное имя: " + longestName);
        Console.WriteLine("Размер самого длинного имени: " + longestName.Length);
    }

    static List<string> LoadNamesFromJson(string filePath)
    {
        List<string> names = new List<string>();

        try
        {
            string json = File.ReadAllText(filePath);
            dynamic data = JsonConvert.DeserializeObject(json);
            foreach (var name in data.names)
            {
                names.Add(name.ToString());
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден: " + filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при загрузке имен из файла: " + ex.Message);
        }

        return names;
    }
}