using FluentValidation;

namespace Application.Features.Officer.Commands.UpdateCommand
{
    public class UpdateOfficerValidation : AbstractValidator<UpdateOfficerPostCommand>
    {
        public UpdateOfficerValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("من فضلك أملاء الحقل")
                .NotNull().WithMessage("Name cannot be null")
                .MaximumLength(50).WithMessage("أقصي عدد للحروف 50 حرف ")
                .MinimumLength(2).WithMessage("أقل عدد للحروف 2 حرف");

            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage("أختر فرع")
                .NotNull().WithMessage("Department cannot be null");
        }
    }
}
