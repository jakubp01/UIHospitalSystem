using Inz.Areas.Identity.Data;
using Inz.Controllers.Core;
using Inz.Models;
using MediatR;

namespace Inz.CommandsQueries.Commands
{
    public class CreateVisitCommand
    {
        public class Command : IRequest<Result<Visit>>
        {
            public CreateVisitModel visit;
            
        }

        public class Handler : IRequestHandler<Command, Result<Visit>>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Result<Visit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var patient = _context.Patients.FirstOrDefault(x => x.Id == request.visit.patient);
                var doctor = _context.AspNetUsers.FirstOrDefault(x => x.Id == request.visit.doctor);

                var visit = new Visit
                {
                    Id = request.visit.Id,
                    Date = request.visit.Date,
                    doctor = doctor,
                    patient = patient,
                    Desctription = request.visit.Desctription,
                    Status = request.visit.Status,
                };

                _context.Visits.Add(visit);
                int rowsAffected = await _context.SaveChangesAsync();

                if (rowsAffected > 0)
                {
                    return Result<Visit>.Success(visit);
                }
                else
                {
                    return Result<Visit>.Failure("No rows were affected in the database.");
                }

            }
        }
    }
}
