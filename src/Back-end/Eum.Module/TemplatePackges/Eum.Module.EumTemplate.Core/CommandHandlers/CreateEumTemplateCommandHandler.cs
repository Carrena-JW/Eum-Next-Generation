﻿
namespace Eum.Module.EumTemplate.Core.CommandHandlers;

public class CreateEumTemplateCommandHandler : IRequestHandler<CreateEumTemplateCommand, int>
{
    public Task<int> Handle(CreateEumTemplateCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(1);
    }
}