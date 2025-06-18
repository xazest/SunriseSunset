using AutoMapper;
public static class XMapper<T, T2>
{
    public static readonly IMapper xMapper = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<T, T2>();
    }).CreateMapper();
}