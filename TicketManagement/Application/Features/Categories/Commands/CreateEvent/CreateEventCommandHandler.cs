using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands.CreateEvent
{
    public class CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper) : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository = eventRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = _mapper.Map<Event>(request);

            var validator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            @event = await _eventRepository.AddAsync(@event);
            
            return @event.EventId;
        }
    }
}
