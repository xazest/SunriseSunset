using Newtonsoft.Json;
using System.Globalization;


HttpClient client = new HttpClient();
var geoData = await GetGeoDataAsync();
var sunriseSunset = await GetSunriseSunsetAsync();

TimeOnly sunrise = TimeOnly.ParseExact(sunriseSunset.results.sunrise,
    "h:mm:ss tt",
    CultureInfo.InvariantCulture);
TimeOnly sunset = TimeOnly.ParseExact(sunriseSunset.results.sunset,
    "h:mm:ss tt",
    CultureInfo.InvariantCulture);

Console.WriteLine($"Sunrise {sunrise.ToString("HH:mm")}\nSunset {sunset.ToString("HH:mm")}");
Console.ReadKey();

async Task<SunriseSunset> GetSunriseSunsetAsync()
{
    string url = $"https://api.sunrise-sunset.org/json" +
        $"?lat={geoData.lat}" +
        $"&lng={geoData.lon}" +
        $"&date=today" +
        $"&tzid={geoData.timezone}";

    using (client)
    {
        var response = await client.GetStringAsync(url);
        var result = JsonConvert.DeserializeObject<SunriseSunset>(response);

        return result;
    }
}
async Task<IpApiContext> GetGeoDataAsync()
{
    string url = $"http://ip-api.com/json/?fields=lat,lon,timezone";
    var response = await client.GetStringAsync(url);
    var result = JsonConvert.DeserializeObject<IpApiContext>(response);
    Console.WriteLine($"Coordinates acquired\nLatitude - {result.lat}" +
        $"\nLongitude - {result.lon}\n");

    return result;
}


class IpApiContext
{
    public float lat { get; set; }
    public float lon { get; set; }
    public string timezone { get; set; }
}
class SunriseSunset
{
    public ResultsContainer results { get; set; }
    public class ResultsContainer
    {
        public string sunrise { get; set; }
        public string sunset { get; set; }
    }
}