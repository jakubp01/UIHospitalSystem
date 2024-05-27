using Inz.Areas.Identity.Data;
using Inz.Controllers.Core;
using Inz.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inz.Queries
{
    public class GetSingleVisitQuery
    {
        public class Query : IRequest<Result<Visit>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Visit>>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Result<Visit>> Handle(Query request, CancellationToken cancellationToken)
            {
                var response = await _context.Visits
                 .Include(v => v.doctor)
                 .Include(v => v.patient)
                 .FirstOrDefaultAsync(e => e.Id == request.Id);


                if (response != null)
                {

                    return Result<Visit>.Success(response);

                }
                return Result<Visit>.Failure("error");

            }
        }
    }
}
