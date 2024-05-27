using Inz.Areas.Identity.Data;
using Inz.Controllers.Core;
using Inz.Enums;
using Inz.Models.chartsModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inz.CommandsQueries.Queries.ChartsRelatedQueries
{
    public class GetBasicVisitsChartData
    {
        public class Query : IRequest<Result<BasicVisitsChartModel>>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<BasicVisitsChartModel>>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Result<BasicVisitsChartModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var newVisits =   _context.Visits
                    .Include(v => v.doctor)
                    .Where(x => x.Status == (int)VisitStatus.New)
                    .Where(x => x.doctor.Id == request.Id)
                    .Count();

                var totallVisits = _context.Visits
                    .Include(v => v.doctor)
                    .Where(x => x.doctor.Id == request.Id)
                    .Count();

                var finishedVisits = _context.Visits
                    .Include(v => v.doctor)
                    .Where(x => x.Status == (int)VisitStatus.finished)
                    .Where(x => x.doctor.Id == request.Id)
                    .Count();

               var needToApproveVisits = _context.Visits
                    .Include(v => v.doctor)
                    .Where(x => x.Status == (int)VisitStatus.Waiting)
                    .Where(x => x.doctor.Id == request.Id)
                    .Count();

                var response = new BasicVisitsChartModel
                {
                    NewVisits = newVisits,
                    TotalVisits = totallVisits,
                    FinishedVisit = finishedVisits,
                    VisitsNeedToApprove = needToApproveVisits

                };

                if (response != null)
                {

                    return Result<BasicVisitsChartModel>.Success(response);

                }
                return Result<BasicVisitsChartModel>.Failure("error");

            }
        }
    }
}
