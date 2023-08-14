using System.Threading;
using System.Threading.Tasks;
using com.expenses.domain.DomainModel.Login;

namespace com.expenses.infra.Interface.Login
{
    public interface ILoginRepository: IRepositoryBase<LoginModel>
    {
        Task<LoginModel> GetByLogin(string login, CancellationToken cancellationToken);
    }
}
