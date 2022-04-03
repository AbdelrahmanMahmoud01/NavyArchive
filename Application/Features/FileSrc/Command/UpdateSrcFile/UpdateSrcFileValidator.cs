using FluentValidation;

namespace Application.Features.FileSrc.Command.UpdateSrcFile
{
    public class UpdateSrcFileValidator : AbstractValidator<UpdateSrcFileCommand>
    {
        public UpdateSrcFileValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("من فضلك أملاء الحقل")
                .NotNull().WithMessage("name cannot be null")
                .MaximumLength(25).WithMessage("أقصي عدد للحروف 25 حرف")
                .MinimumLength(2).WithMessage("أقل عدد للحروف 2 حرف");

        }
    }
}
