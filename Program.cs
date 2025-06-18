using System.Globalization;


var sunriseSunsetTask = SunriseSunset.Create();
var sunriseSunset = await sunriseSunsetTask;

TimeOnly sunrise = TimeOnly.ParseExact(sunriseSunset.PSunrise,
    "h:mm:ss tt",
    CultureInfo.InvariantCulture);
TimeOnly sunset = TimeOnly.ParseExact(sunriseSunset.PSunset,
    "h:mm:ss tt",
    CultureInfo.InvariantCulture);

Console.WriteLine($"Sunrise {sunrise.ToString("HH:mm")}\nSunset {sunset.ToString("HH:mm")}");
Console.ReadKey();

