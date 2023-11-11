using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = PruebaTecnica.Application.Exceptions.ValidationException

namespace PruebaTecnica.Application.Behaviours
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }


        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResult = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResult.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if (failures.Count != 0)
                {
                    throw new ValidationException(failures);
                }
            }
            return await next();
        }
    }
}
