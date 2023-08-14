using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.expenses.infra.Interface
{
    public interface IUnitOfWork
    {
        Task saveAsync();
    }
}
