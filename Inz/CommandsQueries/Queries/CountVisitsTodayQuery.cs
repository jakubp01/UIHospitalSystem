using Inz.Areas.Identity.Data;
using Inz.Controllers.Core;
using Inz.Enums;
using Inz.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inz.CommandsQueries.Queries
{
    public class CountVisitsTodayQuery
    {
        public class Query : IRequest<Result<int>>
        {
            public string DoctorId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<int>>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Result<int>> Handle(Query request, CancellationToken cancellationToken)
            {
                var allowedStatus = new[] { (int)VisitStatus.New, (int)VisitStatus.during };

                var response = 6;
                if (response != null)
                {

                    return Result<int>.Success(response);

                }
                return Result<int>.Failure("error");

            }
        }
    }
}
