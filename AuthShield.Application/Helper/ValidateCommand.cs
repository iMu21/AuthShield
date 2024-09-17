using AuthShield.Application.Responses;
using FluentValidation;

namespace AuthShield.Application.Helper
{
    internal static class ValidateCommand
    {

        private static async Task<BaseResponse> ValidateRulesAsync<TEntity>(TEntity entity,
            AbstractValidator<TEntity> validator)
            where TEntity : class
        {

            var response = new BaseResponse();

            var validationResult = await validator.ValidateAsync(entity);
            if (!validationResult.IsValid && validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.Errors = new List<string>();
                foreach (var item in validationResult.Errors)
                {
                    response.Errors.Add(item.ErrorMessage);
                }
            }

            return response;
        }

        public static async Task<BaseResponse> ValidateAsync<TEntity, TValidator>(this TEntity command)
            where TEntity : class
        {
            var validator = Activator.CreateInstance<TValidator>();

            if (validator == null)
            {
                throw new InvalidOperationException($"{nameof(TValidator)} doesn't found");
            }

            var response = await ValidateRulesAsync(command, validator as AbstractValidator<TEntity>);

            return response;
        }

    }
}
