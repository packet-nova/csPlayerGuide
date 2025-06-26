/*
 Objectives:
• Create a new dynamic variable, holding a reference to an ExpandoObject.
• Give the dynamic object an ID property whose type is int and assign each robot a new number.
• Ask the user if they want to name the robot, and if they do, collect it and store it in a Name property.
• Ask if they want to provide a size for the robot. If so, collect a width and height from the user and
store those in Width and Height properties.
• Ask if they want to choose a color for the robot. If so, store their choice in a Color property.
• Display all existing properties for the robot to the console window using the following code:
foreach (KeyValuePair<string, object> property in (IDictionary<string, object>)robot)
Console.WriteLine($"{property.Key}: {property.Value}");
• Loop repeatedly to allow the user to design and build multiple robots.
*/

using System.Dynamic;

int robotsCreated = 0;
bool wantsAnotherRobot = true;

while (wantsAnotherRobot)
{
    dynamic robot = new ExpandoObject();
    robot.ID = ++robotsCreated;

    if (UserWants("Do you want to set a name? "))
    {
        robot.Name = UserInput("What is its name? ");
    }

    if (UserWants("Does this robot have a specific size? "))
    {
        robot.Height = UserInput("What is its height? ");
        robot.Width = UserInput("What is its width? ");
    }

    if (UserWants("Does this robot need to be a specific color? "))
    {
        robot.Color = UserInput("What is its color? ");
    }

    foreach (KeyValuePair<string, object> property in (IDictionary<string, object>)robot)
        Console.WriteLine($"{property.Key}: {property.Value}");

    if (!UserWants("Do you want to create another robot? "))
    {
        wantsAnotherRobot = false;
    }
}

bool UserWants(string prompt)
{
    Console.Write(prompt);
    string? response = Console.ReadLine().ToLower().Trim();
    return response == "yes" || response == "y";
}

dynamic UserInput(string prompt)
{
    Console.Write(prompt);
    dynamic? answer = Console.ReadLine();
    return answer;
}