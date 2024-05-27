using Inz.Areas.Identity.Data;
using Inz.Controllers.Core;
using Inz.Enums;
using Inz.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inz.CommandsQueries.Queries
{
    public class GetVisitInterview
    {
        public class Query : IRequest<Result<InterviewModel>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<InterviewModel>>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Result<InterviewModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var response = _context.Interviews.FirstOrDefault(x => x.VisitId == request.Id);


                if (response != null)
                {

                    return Result<InterviewModel>.Success(response);

                }
                return Result<InterviewModel>.Failure("error");

            }
        }
    }
}
