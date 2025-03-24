using Application.Contracts.Persistence;
using Application.Contracts.Infrastructure;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Events.Queries.GetEventsExport
{
    public class GetEventsExportQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository, ICsvExporter csvExporter) : IRequestHandler<GetEventsExportQuery, EventExportFileViewModel>
    {
        private readonly IAsyncRepository<Event> _eventRepository = eventRepository;
        private readonly IMapper _mapper = mapper;
        private readonly ICsvExporter _csvExporter = csvExporter;

        public async Task<EventExportFileViewModel> Handle(GetEventsExportQuery request, CancellationToken cancellationToken)
        {
            var allEvents = _mapper.Map<List<EventExportDto>>((await _eventRepository.ListAllAsync()).OrderBy(x => x.Date));

            var fileData = _csvExporter.ExportEventsToCsv(allEvents);

            var eventExportFileDto = new EventExportFileViewModel() { ContentType = "text/csv", Data = fileData, EventExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
