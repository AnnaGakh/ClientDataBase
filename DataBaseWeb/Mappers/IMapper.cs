namespace DataBaseWeb.Mappers
{
    internal interface IMapper<Tdbclass,Tclass>
    {
        Tdbclass ToDb(Tclass item);
        Tclass FromDb(Tdbclass item);
    }
}
