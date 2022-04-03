using FluentValidation;

namespace Application.Features.FileSrc.Command.CreateSrcFile
{
    public class CreateSrcFileValidator : AbstractValidator<CreateSrcFileCommand>
    {
        public CreateSrcFileValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("من فضلك أملاء الحقل")
                .NotNull().WithMessage("Name cannot be null")
                .MaximumLength(25).WithMessage("أقصي عدد للحروف 25 حرف ")
                .MinimumLength(2).WithMessage("أقل عدد للحروف 2 حرف");
                
        }
    }
}
