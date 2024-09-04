﻿namespace CharacterConsole.Tests;

public class MockOutput : IOutput
{
    public string Output { get; private set; } = string.Empty;

    public void WriteLine(string message)
    {
        Output += message + "\n";
    }

    public void Write(string message)
    {
        Output += message;
    }
}