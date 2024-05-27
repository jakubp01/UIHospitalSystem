using Inz.Areas.Identity.Data;
using Inz.Controllers.Core;
using Inz.Models;
using MediatR;

namespace Inz.CommandsQueries.Commands
{
    public class RemovePatientProfileCommand
    {
        public class Command : IRequest<Result<Patient>>
        {
            public int id;
        }

        public class Handler : IRequestHandler<Command, Result<Patient>>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Result<Patient>> Handle(Command request, CancellationToken cancellationToken)
            {
                var patientToRemove = _context.Patients.FirstOrDefault(x => x.Id == request.id);

                _context.Patients.Remove(patientToRemove);
                int rowsAffected = await _context.SaveChangesAsync();


                if (rowsAffected > 0)
                {
                    return Result<Patient>.Success(patientToRemove);
                }
                else
                {
                    return Result<Patient>.Failure("No rows were affected in the database.");
                }

            }
        }
    }
}
