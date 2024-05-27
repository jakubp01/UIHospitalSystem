using Inz.Areas.Identity.Data;
using Inz.Controllers.Core;
using Inz.Enums;
using Inz.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inz.Queries
{
    public class GetAllPatientsQuery
    {
        public class Query : IRequest<Result<List<Patient>>>
        {
           
        }

        public class Handler : IRequestHandler<Query, Result<List<Patient>>>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Patient>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var response = await _context.Patients.ToListAsync();
                if (response != null)
                {

                    return Result<List<Patient>>.Success(response);

                }
                return Result<List<Patient>>.Failure("error");

            }
        }
    }
}
