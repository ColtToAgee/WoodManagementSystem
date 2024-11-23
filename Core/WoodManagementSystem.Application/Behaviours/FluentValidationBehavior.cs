using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodManagementSystem.Application.Behaviours
{
    public class FluentValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validator;
        public FluentValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            this.validator = validator;
        }
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failtures = validator.Select(v => v.Validate(context)) //Gelen veriyi validate etme işlemi
                                    .SelectMany(result => result.Errors) //Verideki hataları alma işlemi
                                    .GroupBy(x => x.ErrorMessage) // Hata mesajlarını alma işlemi
                                    .Select(x => x.First())
                                    .Where(f => f != null)
                                    .ToList();
            if (failtures.Any())
            {
                throw new ValidationException(failtures);
            }
            return next();//Aynı middlewaredeki gibi devam etmesini sağlar.Hata olmazsa response üzerinden devam eder. 
        }
    }
}
