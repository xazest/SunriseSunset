Console.WriteLine("Loading...");

var sunriseSunsetTask = SunriseSunset.Create();
var result = await sunriseSunsetTask;

Console.WriteLine($"Sunrise {result.SunriseTime:HH:mm}\n" +
    $"Sunset {result.SunsetTime:HH:mm}\n\n" +
    $"Day Length {result.Results.DayLength}\n" +
    $"Night Length {result.NightLength}\n");

Console.WriteLine("Press any key to exit...");
Console.ReadKey();