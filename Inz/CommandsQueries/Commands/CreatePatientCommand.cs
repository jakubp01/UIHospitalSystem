using Inz.Areas.Identity.Data;
using Inz.Controllers.Core;
using Inz.Models;
using MediatR;

namespace Inz.CommandsQueries.Commands
{
    public class CreatePatientCommand
    {
        public class Command : IRequest<Result<Patient>>
        {
            public Patient patient;
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
                _context.Patients.Add(request.patient);
                int rowsAffected = await _context.SaveChangesAsync();

                if (rowsAffected > 0)
                {
                    return Result<Patient>.Success(request.patient);
                }
                else
                {
                    return Result<Patient>.Failure("No rows were affected in the database.");
                }

            }
        }
    }
}

