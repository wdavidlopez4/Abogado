
using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;

namespace Abogado.Application.CasesServices.CreateCase
{
    public class CreateCaseHandler : IRequestHandler<CreateCaseCommand, int>
    {
        private readonly IRepository repository;

        public CreateCaseHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(CreateCaseCommand request, CancellationToken cancellationToken)
        {
            Case caseAux;

            //Verificar que la peticion no este nula
            Guard.Against.Null(request, nameof(request));

            //Crear caso
            caseAux = Case.Build(
                 caseName: request.CaseName,
                 description: request.Description,
                 trial: request.Trial,
                 divorceForm: request.DivorceForm,
                 divorceMechanism: request.DivorceMechanism,
                 fileId: request.FileId,
                 startDate: request.StartDate);

            //Guardar entidad
            await repository.Save<Case>(caseAux);
            await repository.Commit();

            return 0;
        }
    }
}
