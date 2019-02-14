using FluentNHibernate.Mapping;

namespace WebApi.Entity.Maps
{
    public class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {
            Id(x => x.Id);
            Map(x => x.CityCode);
            Map(x => x.DistrictCode);
            Map(x => x.Description);
            Map(x => x.UserId);
            Table("Address");
        }
    }
}