﻿using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler(IMapper mapper, IAsyncRepository<Event> eventRepository) : IRequestHandler<DeleteEventCommand>
    {
        private readonly IAsyncRepository<Event> _eventRepository = eventRepository;
        private readonly IMapper _mapper = mapper;

        public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var eventToDelete = await _eventRepository.GetByIdAsync(request.EventId);

            await _eventRepository.DeleteAsync(eventToDelete);
        }
    }
}
