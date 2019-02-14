using FluentNHibernate.Mapping;

namespace WebApi.Entity.Maps
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.SurName);
            Table("Users");
        }
    }
}