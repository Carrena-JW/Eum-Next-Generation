using System.Transactions;
using Eum.Module.Organization.Core.Commands.Company;
using Eum.Module.Organization.Shared.Interfaces.Repositories;
using Eum.Module.Organization.Shared.Models.Entities;
using MediatR;

namespace Eum.Module.Organization.Core.CommandHandlers.Company;

public class CreateCommandHandler: IRequestHandler<CreateCompanyCommand, int>
{
    private readonly IMediator _mediator;
    private readonly ICompanyRepository<CompanyEntity> _repository;
    private readonly ICompanyExtentionRepository<CompanyExtentionEntity> _extentionRepository;
    
    public CreateCommandHandler(IMediator mediator, 
        ICompanyRepository<CompanyEntity> repository, 
        ICompanyExtentionRepository<CompanyExtentionEntity> extentionRepository)
    {
        _mediator = mediator;
        _repository = repository;
        _extentionRepository = extentionRepository;
    }

    public async Task<int> Handle(CreateCompanyCommand message, CancellationToken cancellationToken)
    {
        int createdId = 0;
        //Transaction scope?
        //같은 연결 내에 처리가 되어야 할건데 ??????
        //연결같지 않아도 되네 
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            try
            {
                // MAIN COMPANY 
                var mainEntity = new CompanyEntity
                {
                    Identity = message.Identity,
                    Name = message.Name,
                    Description = message.Description,
                    IsShow = message.IsShow,
                    IsActive = message.IsActive
                };
                
                //return createdid 
                createdId = await _repository.CreateCompany((mainEntity));

                // 기존 스키마에  없는 확장 값을 추가하는 경우
                if (message.Extentions is not null)  
                {
                    foreach (KeyValuePair<string, string> entry in message.Extentions)
                    {
                        var extention = new CompanyExtentionEntity
                        {
                            Identity = $"{message.Identity}_{entry.Key}",
                            CompanyIdentity = message.Identity,
                            Key = entry.Key,
                            Value = entry.Value
                        };
                        await _extentionRepository.CreateCompanyExtention(extention);
                    }
                }
                scope.Complete();
            }
            catch (Exception e)
            {
                throw e;
            }
            
            return createdId;
        }
       
    }
}