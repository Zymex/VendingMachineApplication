using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using MediatR;

namespace CleanArchitecture.Application.VendingMachines.Queries.DrinkMachine;
public record GetDrinkMachinesWithPaginationQuery : IRequest<PaginatedList<SnackMachineBriefDto>>
{
    public Guid Id { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
}
public class GetDrinkMachinesWithPaginationQueryHandler : IRequestHandler<GetDrinkMachinesWithPaginationQuery, PaginatedList<SnackMachineBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetDrinkMachinesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<PaginatedList<SnackMachineBriefDto>> Handle(GetDrinkMachinesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.DrinkMachines
            .Where(x => x.Id == request.Id)
            .OrderBy(d => d.DateCreated)
            .ProjectTo<SnackMachineBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
