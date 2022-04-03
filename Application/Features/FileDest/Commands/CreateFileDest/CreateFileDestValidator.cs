using FluentValidation;

namespace Application.Features.FileDest.Commands.CreateFileDest
{
    public class CreateFileDestValidator : AbstractValidator<CreateFileDestCommand>
    {
        public CreateFileDestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("من فضلك أملاء الحقل")
                .NotNull().WithMessage("Name cannot be null")
                .MaximumLength(25).WithMessage("أقصي عدد للحروف 25 حرف ")
                .MinimumLength(2).WithMessage("أقل عدد للحروف 2 حرف");

        }
    }
}
