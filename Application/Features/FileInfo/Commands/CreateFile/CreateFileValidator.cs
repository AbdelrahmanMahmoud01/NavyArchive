using Application.Features.FileInfo.Commands.CreateFileCommand;
using FluentValidation;

namespace Application.Features.FileInfo.Commands.CreateFile
{
    public class CreateFileValidator : AbstractValidator<CreateFileViewModel>
    {
        public CreateFileValidator()
        {
            RuleFor(x => x.SourceId)
                .NotEmpty().WithMessage("من فضلك أملاء الحقل")
                .NotNull().WithMessage("من فضلك أملاء الحقل");

            RuleFor(x => x.Source)
                .NotEmpty().WithMessage("من فضلك أملاء الحقل")
                .NotNull().WithMessage("من فضلك أملاء الحقل");

            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage("من فضلك أملاء الحقل")
                .NotNull().WithMessage("من فضلك أملاء الحقل");

            RuleFor(x => x.Department)
                .NotEmpty().WithMessage("من فضلك أملاء الحقل")
                .NotNull().WithMessage("من فضلك أملاء الحقل");

            RuleFor(x => x.Source)
                .NotEmpty().WithMessage("من فضلك أملاء الحقل")
                .NotNull().WithMessage("من فضلك أملاء الحقل");

            RuleFor(x => x.OfficerId)
                .NotEmpty().WithMessage("من فضلك أملاء الحقل")
                .NotNull().WithMessage("من فضلك أملاء الحقل");

            RuleFor(x => x.Const)
                .NotEmpty().WithMessage("من فضلك أملاء الحقل")
                .NotNull().WithMessage("من فضلك أملاء الحقل");

            RuleFor(x => x.AboutTag)
                .NotEmpty().WithMessage("من فضلك أملاء الحقل")
                .NotNull().WithMessage("من فضلك أملاء الحقل");

            RuleFor(x => x.ReminderDate)
                .NotEmpty().WithMessage("من فضلك أملاء الحقل")
                .NotNull().WithMessage("من فضلك أملاء الحقل");
        }
    }
}