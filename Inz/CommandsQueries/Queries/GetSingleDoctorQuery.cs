using Inz.Areas.Identity.Data;
using Inz.Controllers.Core;
using Inz.Models;
using MediatR;

namespace Inz.CommandsQueries.Queries
{
    public class GetSingleDoctorQuery
    {
        public class Query : IRequest<Result<AppUser>>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<AppUser>>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Result<AppUser>> Handle(Query request, CancellationToken cancellationToken)
            {
                var response = _context.AspNetUsers.FirstOrDefault(x => x.Id == request.Id);


                if (response != null)
                {

                    return Result<AppUser>.Success(response);

                }
                return Result<AppUser>.Failure("error");

            }
        }
    }
}
