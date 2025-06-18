using Newtonsoft.Json;

class SunriseSunset
{


    private IpApiContext _geoData;
    private SunriseSunset() 
    {
        Results = new ResultsContainer();
    }

    public string PSunrise { get => Results.Sunrise; }
    public string PSunset { get => Results.Sunset; }

    [JsonProperty("results")] public ResultsContainer Results { get; set; }
    public class ResultsContainer
    {
        [JsonProperty("sunrise")] public string Sunrise { get; set; } = string.Empty;
        [JsonProperty("sunset")] public string Sunset { get; set; } = string.Empty;
    }


    private async Task GetSunriseSunsetAsync()
    {
        _geoData = await IpApiContext.Create();
        string url = $"https://api.sunrise-sunset.org/json" +
            $"?lat={_geoData.Latitude}" +
            $"&lng={_geoData.Longitude}" +
            $"&tzid={_geoData.Timezone}" +
            $"&date=today";

        using (HttpClient client = new())
        {
            var response = await client.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<SunriseSunset>(response);
            XMapper<SunriseSunset, SunriseSunset>.xMapper.Map(result, this);
        }
    }
    public static async Task<SunriseSunset> Create()
    {
        var instance = new SunriseSunset();
        await instance.GetSunriseSunsetAsync();
        return instance;
    }
}