using AutoMapper;
public static class XMapper
{
    public static void Map<TSource>(TSource source, object destination)
    {
        var config = new MapperConfiguration(cfg =>
        cfg.CreateMap(typeof(TSource), destination.GetType()));
        var mapper = config.CreateMapper();
        mapper.Map(source, destination);
    }
}
