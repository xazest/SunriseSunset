using Newtonsoft.Json;
class IpApiContext
{
    private IpApiContext() { }
    [JsonProperty("lat")] public float Latitude { get; private set; }
    [JsonProperty("lon")] public float Longitude { get; private set; }
    [JsonProperty("timezone")] public string Timezone { get; private set; } = string.Empty;
    [JsonProperty("proxy")] public bool IsProxy { get; private set; }

    private async Task GetGeoDataAsync()
    {
        string url = $"http://ip-api.com/json/?fields=lat,lon,timezone,proxy";
        var response = await HttpC.Client.GetStringAsync(url);
        var result = JsonConvert.DeserializeObject<IpApiContext>(response);
        XMapper.Map(result, this);

        Console.Clear();
        if (IsProxy)
        {
            Console.WriteLine("VPN/Proxy detected, data can be incorrect.\n");
        }
        Console.WriteLine($"Coordinates acquired\nLatitude - {Latitude}" +
                $"\nLongitude - {Longitude}\n");
    }
    public static async Task<IpApiContext> Create()
    {
        var instance = new IpApiContext();
        await instance.GetGeoDataAsync();
        return instance;
    }
}
