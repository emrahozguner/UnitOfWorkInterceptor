using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkInterceptor
{
    public interface IUnitOfWorkManager
    {
        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}