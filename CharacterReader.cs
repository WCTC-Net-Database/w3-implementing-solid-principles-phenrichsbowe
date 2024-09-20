namespace CharacterConsole;

using System.Globalization;
using CsvHelper;

public class CharacterReader(string filePath)
{
  private readonly string _filePath = filePath;

    public List<Character> ReadAllCharacters()
  {
    List<Character> characters = [];

    using var streamReader = new StreamReader(_filePath);
    using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);

    var records = csvReader.GetRecords<Character>().ToList();

    foreach (Character character in records)
    {
      characters.Add(character);
    }

    return characters;
  }

  public static Character? FindCharacterByName(List<Character> characters)
  {
    string? name = null;

    while (string.IsNullOrEmpty(name)) {
      Console.Write("Enter the name of the character you would like to find:");
      name = Console.ReadLine();
    }

    Character? character = characters.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    if (character == null) {
      Console.WriteLine($"Could not find character by name {name}");
      return character;
    }

    Console.WriteLine($"Found character {character}");

    return character;
  }
}
