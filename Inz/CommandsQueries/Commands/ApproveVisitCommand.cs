using Inz.Areas.Identity.Data;
using Inz.Controllers.Core;
using Inz.Enums;
using Inz.Models;
using MediatR;

namespace Inz.CommandsQueries.Commands
{
    public class ApproveVisitCommand
    {
        public class Command : IRequest<Result<Visit>>
        {
            public int Id { get; set; }
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
                var visitToUpdate = _context.Visits.FirstOrDefault(v => v.Id == request.Id);

                visitToUpdate.Status = (int)VisitStatus.New;


                _context.Visits.Update(visitToUpdate);
                int rowsAffected = await _context.SaveChangesAsync();

                if (rowsAffected > 0)
                {
                    return Result<Visit>.Success(visitToUpdate);
                }
                else
                {
                    return Result<Visit>.Failure("No rows were affected in the database.");
                }

            }
        }
    }
}

