using AutoMapper;
using Transactions.Api.DTOs;
using Transaction = Transactions.Domain.Entities.Transaction;

namespace Transactions.Api.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Transaction, TransactionDto>().ReverseMap();
        }
    }
}
