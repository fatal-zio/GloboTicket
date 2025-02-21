using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.Features.Categories.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepository _eventReposotory;

        public CreateEventCommandValidator(IEventRepository eventRepository)
        {
            _eventReposotory = eventRepository;

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(c => c.Date)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(c => c.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);

            RuleFor(e => e)
                .MustAsync(EventNameAndDateUnique)
                .WithMessage("An event with the same name and date already exists.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);
        }

        private async Task<bool> EventNameAndDateUnique(CreateEventCommand e, CancellationToken token)
        {
            return !await _eventReposotory.IsEventNameAndDateUnique(e.Name, e.Date);
        }
    }
}
