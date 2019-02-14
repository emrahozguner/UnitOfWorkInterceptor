using NHibernate;
using WebApi.Entity;
using WebApi.Repository.Base;

namespace WebApi.Repository
{
    public interface IAddressRepository : IRepository<Address>
    { }

    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }
    }
}