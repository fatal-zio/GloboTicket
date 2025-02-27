using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using Application.Models.Mail;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository, IEmailService emailService) : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository = eventRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IEmailService _emailService = emailService;

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = _mapper.Map<Event>(request);

            var validator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            @event = await _eventRepository.AddAsync(@event);

            var email = new Email() { To = "jayme.desrosiers@mbll.ca", Body = $"A new event was created: {request}", Subject = "A new event was created" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                //this shouldn't stop the API from doing else so this can be logged
            }

            return @event.EventId;
        }
    }
}
