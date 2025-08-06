using AutoMapper;
using Core.Module.Transaction.Dtos;
using DB.Entities;
using Shared.Vistas;

namespace Core.Module.Transaction.Mapper
{
    public class TransactionMapper : Profile
    {
        public TransactionMapper() {

            CreateMap<Transactions, TransactionDto>();
            CreateMap<TransactionDto, Transactions>();

            CreateMap<Transactions, TransactionSaveDto>();
            CreateMap<TransactionSaveDto, Transactions>();
        }

    }
}
