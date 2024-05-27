using Inz.Areas.Identity.Data;
using Inz.Controllers.Core;
using MediatR;

namespace Inz.CommandsQueries.Commands
{
    public class RemoveDoctorCommand
    {
            public class Command : IRequest<Result<AppUser>>
            {
                public string id;

            }

            public class Handler : IRequestHandler<Command, Result<AppUser>>
            {
                private readonly AppDbContext _context;
                public Handler(AppDbContext context)
                {
                    _context = context;
                }

                public async Task<Result<AppUser>> Handle(Command request, CancellationToken cancellationToken)
                {
                    var doctorToRemove = _context.AspNetUsers.FirstOrDefault(x => x.Id == request.id);

                    _context.AspNetUsers.Remove(doctorToRemove);
                    int rowsAffected = await _context.SaveChangesAsync();


                    if (rowsAffected > 0)
                    {
                        return Result<AppUser>.Success(doctorToRemove);
                    }
                    else
                    {
                        return Result<AppUser>.Failure("No rows were affected in the database.");
                    }

                }
            }
        
    }
}
