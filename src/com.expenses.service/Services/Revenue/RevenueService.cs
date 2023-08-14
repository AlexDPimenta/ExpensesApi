using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.datacomunication.DTO.RevenueDTO;
using com.expenses.domain.DomainModel.Revenue;
using com.expenses.infra.Interface.Customer;
using com.expenses.infra.Interface.Revenue;
using com.expenses.service.Interface.Revenue;
using com.expenses.tools.DomainExceptions;

namespace com.expenses.service.Services.Revenue
{
    public class RevenueService : IRevenueService
    {
        private readonly IRevenueRepository _repository;
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;
        private readonly NotificationContext _context;

        public RevenueService(IRevenueRepository repository, IMapper mapper, NotificationContext context, ICustomerRepository customerRepo)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
            _customerRepo = customerRepo;
        }

        public async Task<RevenueResponseDTO> CreateAsync(RevenueRequestDTO revenueRequestDTO, CancellationToken cancellationToken)
        {
            var customer = await _customerRepo.GetByIdAsync(revenueRequestDTO.CustomerId, cancellationToken);
            if(customer == null)
            {
                _context.AddNotification("customerID", "Customer not found");
                return null;
            }
            var revenue = await _repository.AddAsync(_mapper.Map<RevenueModel>(revenueRequestDTO), cancellationToken);
            return new RevenueResponseDTO { RevenueId = revenue.Id };
        }

        public async Task<bool> DeleteAsync(Guid revenueId, CancellationToken cancellationToken)
        {
            var revenue = await GetRevenueAsync(revenueId, cancellationToken);
            if (revenue == null)
            {
                _context.AddNotification("revenueID", "Revenue not found");
                return false;
            }

            await _repository.RemoveAsync(revenue, cancellationToken);

            return true;
        }

        public async Task<bool> UpdateAsync(RevenueToUpdateDTO revenueDto, CancellationToken cancellationToken)
        {
            var revenue = await GetRevenueAsync(revenueDto.RevenueId, cancellationToken);
            if ( revenue == null)
            {
                _context.AddNotification("revenueID", "Revenue not found");
                return false;
            }

            var revenueToUpdate = _mapper.Map<RevenueModel>(revenueDto);

            revenueToUpdate.Id = revenueDto.RevenueId;
            revenueToUpdate.CustomerId = revenue.CustomerId;

            await _repository.UpdateAsync(revenueToUpdate, cancellationToken);

            return true;
        }

        private async Task<RevenueModel> GetRevenueAsync(Guid revenueId, CancellationToken cancellationToken)
            => await _repository.GetByIdAsync(revenueId, cancellationToken);
    }
}
