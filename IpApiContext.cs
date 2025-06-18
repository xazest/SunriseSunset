using Newtonsoft.Json;

class IpApiContext
{
    private IpApiContext() { }
    [JsonProperty("lat")] public float Latitude { get; private set; }
    [JsonProperty("lon")] public float Longitude { get; private set; }
    [JsonProperty("timezone")] public string Timezone { get; private set; } = string.Empty;

    private async Task GetGeoDataAsync()
    {
        string url = $"http://ip-api.com/json/?fields=lat,lon,timezone";
        using (HttpClient client = new())
        {
            var response = await client.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<IpApiContext>(response);
            XMapper<IpApiContext, IpApiContext>.xMapper.Map(result, this);

            Console.WriteLine($"Coordinates acquired\nLatitude - {Latitude}" +
                $"\nLongitude - {Longitude}\n");
        }
    }
    public static async Task<IpApiContext> Create()
    {
        var instance = new IpApiContext();
        await instance.GetGeoDataAsync();
        return instance;
    }
}
