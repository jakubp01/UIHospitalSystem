using Inz.Areas.Identity.Data;
using Inz.Controllers.Core;
using Inz.Models;
using MediatR;

namespace Inz.CommandsQueries.Commands
{
    public class AddInterviewCommand
    {
        public class Command : IRequest<Result<InterviewModel>>
        {
            public InterviewModel interview;

        }

        public class Handler : IRequestHandler<Command, Result<InterviewModel>>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Result<InterviewModel>> Handle(Command request, CancellationToken cancellationToken)
            { 
                    var Visit = _context.Visits.FirstOrDefault(x => x.Id == request.interview.VisitId);

                    Visit.IsInterviewExist = true;
                    _context.Visits.Update(Visit);
                    _context.Interviews.Add(request.interview);
                    int rowsAffected = await _context.SaveChangesAsync();


                if (rowsAffected > 0)
                {
                    return Result<InterviewModel>.Success(request.interview);
                }
                else
                {
                    return Result<InterviewModel>.Failure("No rows were affected in the database.");
                }

            }
        }
    }
}
