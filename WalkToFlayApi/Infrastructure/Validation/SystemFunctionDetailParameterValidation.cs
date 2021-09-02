using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkToFlayApi.Models.Input;

namespace WalkToFlayApi.Infrastructure.Validation
{
    /// <summary>
    /// 附屬功能參數驗證
    /// </summary>
    public class SystemFunctionDetailParameterValidation : AbstractValidator<SystemFunctionDetailParameter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemFunctionDetailParameterValidation"/> class.
        /// </summary>
        public SystemFunctionDetailParameterValidation()
        {
            RuleFor(x => x.FunctionDetailName)
                .NotNull()
                .NotEmpty()
                .WithMessage("附屬功能名稱不能為空")
                .MaximumLength(50)
                .WithMessage("附屬功能名稱不能超過50個字");

            RuleFor(x => x.FunctionDetailChineseName)
                .NotNull()
                .NotEmpty()
                .WithMessage("附屬功能中文名稱不能為空")
                .MaximumLength(50)
                .WithMessage("附屬功能中文名稱不能超過50個字");

            RuleFor(x => x.Remark)
                .MaximumLength(50)
                .WithMessage("備註不能超過50個字");
        }
    }
}
