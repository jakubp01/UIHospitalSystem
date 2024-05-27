using Inz.Areas.Identity.Data;
using Inz.Controllers.Core;
using Inz.Enums;
using Inz.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inz.Queries
{
    public class GetLatestVisitsByDoctorIdQuery
    {
        public class Query : IRequest<Result<List<Visit>>>
        {
            public string DoctorId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<Visit>>>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Visit>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var response = await _context.Visits
                 .Include(v => v.doctor)
                 .Include(v => v.patient)
                 .Where(x => x.doctor.Id == request.DoctorId && x.Status == (int)VisitStatus.finished)
                 .OrderByDescending(x => x.Date)
                 .Take(3)
                 .ToListAsync();
                if (response != null)
                {

                    return Result<List<Visit>>.Success(response);

                }
                return Result<List<Visit>>.Failure("error");

            }
        }
    }
}
