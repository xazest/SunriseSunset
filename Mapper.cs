using AutoMapper;
public static class Maper<T, T2>
{
    public static readonly IMapper XMaper = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<T, T2>();
    }).CreateMapper();
}


//private static readonly IMapper _mapper = new MapperConfiguration(cfg =>
//{
//    cfg.CreateMap<IpApiContext, IpApiContext>();
//}).CreateMapper();
