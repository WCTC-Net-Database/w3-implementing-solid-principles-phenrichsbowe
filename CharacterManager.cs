namespace CharacterConsole;

public class CharacterManager
{
    private readonly IInput _input;
    private readonly IOutput _output;
    private static readonly string _filePath = "input.csv";
    private readonly List<Character> characters = [];
    private readonly CharacterReader characterReader = new(_filePath);
    private readonly CharacterWriter characterWriter = new(_filePath);

    public CharacterManager(IInput input, IOutput output)
    {
        _input = input;
        _output = output;

        foreach (Character character in characterReader.ReadAllCharacters()) {
            characters.Add(character);
        }
    }

    public void Run()
    {
        _output.WriteLine("Welcome to Character Management");

        while (true)
        {
            _output.WriteLine("Menu:");
            _output.WriteLine("1. Display Characters");
            _output.WriteLine("2. Find Character");
            _output.WriteLine("3. Add Character");
            _output.WriteLine("4. Level Up Character");
            _output.WriteLine("5. Exit");
            _output.Write("Enter your choice: ");
            var choice = _input.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayCharacters();
                    break;
                case "2":
                    CharacterReader.FindCharacterByName(characters);
                    break;
                case "3":
                    AddCharacter();
                    break;
                case "4":
                    LevelUpCharacter();
                    break;
                case "5":
                    characterWriter.WriteCharacters(characters);
                    return;
                default:
                    _output.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayCharacters()
    {
        foreach (Character character in characters)
        {
            _output.WriteLine(character.ToString());
        }
    }

    public void AddCharacter()
    {
        Character character = new();

        characters.Add(character);
    }

    public void LevelUpCharacter()
    {
        Character? character = CharacterReader.FindCharacterByName(characters);

        if (character == null) return;

        character.Level += 1;

        Console.WriteLine($"Success character {character.Name} leveled up!");
    }
}