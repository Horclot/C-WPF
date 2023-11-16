using System;

public static class Planet
{
    public static string CalculateLightTime(string planetName)
    {
        double distanceInAstronomicalUnits = GetDistanceInAstronomicalUnits(planetName);
        double distanceInMeters = distanceInAstronomicalUnits * 149597870700;
        double lightSpeed = 299792458;
        double timeInSeconds = distanceInMeters / lightSpeed;

        TimeSpan timeSpan = TimeSpan.FromSeconds(timeInSeconds);

        return $"{timeSpan.Hours} часов, {timeSpan.Minutes} минут, {timeSpan.Seconds} секунд";
    }

    private static double GetDistanceInAstronomicalUnits(string planetName)
    {
        switch (planetName.ToLower())
        {
            case "меркурий":
                return 0.39;
            case "венера":
                return 0.72;
            case "земля":
                return 1.0;
            case "марс":
                return 1.52;
            case "юпитер":
                return 5.20;
            case "сатурн":
                return 9.54;
            case "уран":
                return 19.19;
            case "нептун":
                return 30.07;
            default:
                throw new ArgumentException("Некорректное название планеты.");
        }
    }
}

public class EventHandlers
{
    public static void HandleCorrectInput(object sender, EventArgs e)
    {
        Console.Beep(262, 500);
        Console.WriteLine("Верный ввод!");
    }

    public static void HandleIncorrectInput(object sender, EventArgs e)
    {
        Console.Beep(261, 500);
        Console.WriteLine("Некорректный ввод!");
    }
}

public class Program
{
    public static void Main()
    {
        UserInput.CorrectInput += EventHandlers.HandleCorrectInput;
        UserInput.IncorrectInput += EventHandlers.HandleIncorrectInput;

        while (true)
        {
            Console.WriteLine("Введите название планеты:");
            string planetName = Console.ReadLine();

            if (UserInput.IsValidPlanetName(planetName))
            {
                UserInput.OnCorrectInput();
            }
            else
            {
                UserInput.OnIncorrectInput();
            }

            try
            {
                string lightTime = Planet.CalculateLightTime(planetName);
                Console.WriteLine($"Время света от Солнца до планеты {planetName}: {lightTime}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

public static class UserInput
{
    public static event EventHandler CorrectInput;
    public static event EventHandler IncorrectInput;

    public static bool IsValidPlanetName(string planetName)
    {
        switch (planetName.ToLower())
        {
            case "меркурий":
            case "венера":
            case "земля":
            case "марс":
            case "юпитер":
            case "сатурн":
            case "уран":
            case "нептун":
                return true;
            default:
                return false;
        }
    }

    public static void OnCorrectInput()
    {
        CorrectInput?.Invoke(null, EventArgs.Empty);
    }

    public static void OnIncorrectInput()
    {
        IncorrectInput?.Invoke(null, EventArgs.Empty);
    }
}
