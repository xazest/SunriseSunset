using Newtonsoft.Json;

class SunriseSunset
{
    private IpApiContext? _geoData;
    private SunriseSunset()
    {
        Results = new ResultsContainer();
    }

    public TimeOnly SunriseTime { get => TimeOnly.Parse(Results.Sunrise); }
    public TimeOnly SunsetTime { get => TimeOnly.Parse(Results.Sunset); }
    public TimeSpan DayLength { get => TimeSpan.Parse(Results.DayLength); }
    public TimeSpan NightLength { get => TimeSpan.FromHours(24) - DayLength; }

    [JsonProperty("results")] public ResultsContainer Results { get; set; }
    public class ResultsContainer
    {
        [JsonProperty("sunrise")] public string Sunrise { get; set; } = string.Empty;
        [JsonProperty("sunset")] public string Sunset { get; set; } = string.Empty;
        [JsonProperty("day_length")] public string DayLength { get; set; } = string.Empty;
    }

    private async Task GetSunriseSunsetAsync()
    {
        _geoData = await IpApiContext.Create();

        string url = $"https://api.sunrise-sunset.org/json" +
            $"?lat={_geoData.Latitude}" +
            $"&lng={_geoData.Longitude}" +
            $"&tzid={_geoData.Timezone}" +
            $"&date=today";

        var response = await HttpC.Client.GetStringAsync(url);
        var result = JsonConvert.DeserializeObject<SunriseSunset>(response);
        XMapper.Map(result, this);
    }
    public static async Task<SunriseSunset> Create()
    {
        var instance = new SunriseSunset();
        await instance.GetSunriseSunsetAsync();
        return instance;
    }
}