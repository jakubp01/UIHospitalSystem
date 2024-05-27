using Inz.Areas.Identity.Data;
using Inz.Controllers.Core;
using Inz.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inz.Queries
{
    public class GetAllVisitsByPatientIdQuery
    {
        public class Query : IRequest<Result<List<Visit>>>
        {
            public int PatientId { get; set; }
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
                 .Where(x => x.patient.Id == request.PatientId)
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
