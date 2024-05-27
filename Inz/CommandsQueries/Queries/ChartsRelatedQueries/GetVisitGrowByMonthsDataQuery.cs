using Inz.Areas.Identity.Data;
using Inz.Controllers.Core;
using Inz.Models.chartsModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Inz.CommandsQueries.Queries.ChartsRelatedQueries
{
    public class GetVisitGrowByMonthsDataQuery
    {
        public class Query : IRequest<Result<List<VisitByMonthsChart>>>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<VisitByMonthsChart>>>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<VisitByMonthsChart>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var response = _context.Visits
                .Where(v => v.Date != null) // Dodaj warunek, który eliminuje rekordy z pustą datą
                .GroupBy(v => new { Month = v.Date.Month, Year = v.Date.Year })
                .Select(g => new VisitByMonthsChart
                {
                    Month = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key.Month)} {g.Key.Year}",
                    AmountOfVisit = g.Count()
                })
                .ToList();

                var init = 10;


                if (response != null)
                {

                    return Result<List<VisitByMonthsChart>>.Success(response);

                }
                return Result<List<VisitByMonthsChart>>.Failure("error");

            }
        }
    }
}
