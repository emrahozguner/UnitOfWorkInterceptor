using NHibernate;
using WebApi.Entity;
using WebApi.Repository.Base;

namespace WebApi.Repository
{
    public interface IUserRepository : IRepository<User>
    { }

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }
    }
}