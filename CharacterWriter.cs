namespace CharacterConsole;

using System.Globalization;
using CsvHelper;

public class CharacterWriter(string filePath)
{
  private readonly string _filePath = filePath;

  public void WriteCharacters(List<Character> characters)
  {
    using var writer = new StreamWriter(_filePath);
    using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

    csv.WriteRecords(characters);
  }
}