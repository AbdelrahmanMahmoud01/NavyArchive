using FluentValidation;

namespace Application.Features.FileDest.Commands.UpdateFileDest
{
    public class UpdateFileDestValidator : AbstractValidator<UpdateFileDestCommand>
    {
        public UpdateFileDestValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("من فضلك أملاء الحقل")
                .NotNull().WithMessage("name cannot be null")
                .MaximumLength(25).WithMessage("أقصي عدد للحروف 25 حرف")
                .MinimumLength(2).WithMessage("أقل عدد للحروف 2 حرف");

        }
    }
}
