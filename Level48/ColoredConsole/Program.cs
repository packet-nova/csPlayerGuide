/*
 The Medallion of Large Solutions lies behind a sealed stone door and can only be unlocked by building a
solution with two correctly linked projects. This multi-project solution is a key that unseals the door.
Objectives:
• Create a new console project from scratch.
• Add a second Class Library project to the solution.
• Add a static class, ColoredConsole, to the library project.
• Add the method public static string Prompt(string question) that writes question
to the console window, then switches to cyan to get the user’s response all on the same line.
• Add the method public static void WriteLine(string text, ConsoleColor color)
that writes the given text on its own line in the given color.
• Add the method public static void Write(string text, ConsoleColor color) that
writes the given text without a new line in the given color.
• Add the right references between projects so that the main program can use the following code:
    string name = ColoredConsole.Prompt("What is your name?");
    ColoredConsole.WriteLine("Hello " + name, ConsoleColor.Green);
 */

string name = ColoredConsole.Prompt("What is your name? ");
ColoredConsole.WriteLine("Hello " + name + "!", ConsoleColor.Green);
Console.ResetColor();