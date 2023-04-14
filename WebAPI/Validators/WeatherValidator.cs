namespace WebAPI.Validators
{
    using FluentValidation;
    using WebAPI.Models;
    
    public class WeatherValidator : AbstractValidator<Input>
    {
        public WeatherValidator()
        {
            this.RuleFor(_ => _.Days)
                .GreaterThan(0)
                .WithMessage("Forecast days to return should be greater than 0");

            this.RuleFor(_ => _.City)
                .NotEmpty()
                .WithMessage("City cannot be null or empty");
        }
    }
}
