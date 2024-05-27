using Inz.Areas.Identity.Data;
using Inz.Controllers.Core;
using Inz.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inz.CommandsQueries.Queries
{
    public class GetAllDoctorsQuery
    {
        public class Query : IRequest<Result<List<AppUser>>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<AppUser>>>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<AppUser>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var response = await _context.AspNetUsers
                 .Where(x => x.RoleId == (int)Roles.Doctor)
                 .ToListAsync();
                if (response != null)
                {

                    return Result<List<AppUser>>.Success(response);

                }
                return Result<List<AppUser>>.Failure("error");

            }
        }
    }
}
