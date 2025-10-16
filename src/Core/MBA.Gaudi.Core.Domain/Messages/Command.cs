using FluentValidation.Results;
using MediatR;

namespace MBA.Gaudi.Core.Domain.Messages
{
    public abstract class Command : Message, IRequest<bool>
    {
        public DateTime Timestamp { get; set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
        
        public abstract bool IsValid();
    }
}

