public class Character
{
  public string Name { get; set; }
  public string Class { get; set; }
  public uint Level { get; set; }
  public string Equipment { get; set; }

  /// <summary>
  /// Gets the name of the users character and does basic input validation
  /// </summary>
  static private string PromptCharacterName()
  {
    string? characterName = "";

    while (string.IsNullOrEmpty(characterName))
    {
      Console.Write("Enter your character's name: ");
      characterName = Console.ReadLine();
    }

    return characterName;
  }
  /// <summary>
  /// Gets the class of the users character and does basic input validation
  /// </summary>
  static private string PromptCharacterClass()
  {
    string? characterClass = "";

    while (string.IsNullOrEmpty(characterClass))
    {
      Console.Write("Enter your character's class: ");
      characterClass = Console.ReadLine();
    }

    return characterClass;
  }
  /// <summary>
  /// Gets the level of the users character and does basic input validation
  /// </summary>
  static private uint PromptCharacterLevel()
  {
    uint characterLevel = 0;
    bool isValidLevel = false;

    while (!isValidLevel)
    {
      Console.Write("Enter your character's level: ");
      isValidLevel = uint.TryParse(Console.ReadLine(), out characterLevel);
    }

    return characterLevel;
  }
  /// <summary>
  /// Gets the equipment of the users character and does basic input validation
  /// </summary>
  static private string PromptCharacterEquipment()
  {
    Console.Write("Enter your character's equipment (separate items with a '|'): ");

    string? characterEquipment = Console.ReadLine();

    return characterEquipment ?? "";
  }

    public override string ToString()
    {
      return $"Name: {Name} Class: {Class} Level: {Level} Equipment: {string.Join(", ", Equipment.Split("|"))}";
    }

    public Character(string? Name = null, string? Class = null, uint? Level = null, string? Equipment = null) {
      this.Name = Name ?? PromptCharacterName();
      this.Class = Class ?? PromptCharacterClass();
      this.Level = Level ?? PromptCharacterLevel();
      this.Equipment = Equipment ?? PromptCharacterEquipment();
    }
}