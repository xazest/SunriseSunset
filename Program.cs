Console.WriteLine("Loading...");

var sunriseSunsetTask = SunriseSunset.Create();
var result = await sunriseSunsetTask;

Console.WriteLine($"Sunrise {result.SunriseTime:HH:mm}\nSunset {result.SunsetTime:HH:mm}");
Console.ReadKey();