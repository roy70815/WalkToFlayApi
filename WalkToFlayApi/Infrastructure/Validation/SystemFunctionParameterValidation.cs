using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkToFlayApi.Models.Input;

namespace WalkToFlayApi.Infrastructure.Validation
{
    /// <summary>
    /// 大功能參數驗證
    /// </summary>
    public class SystemFunctionParameterValidation : AbstractValidator<SystemFunctionParameter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemFunctionParameterValidation"/> class.
        /// </summary>
        public SystemFunctionParameterValidation()
        {
            RuleFor(x => x.FunctionName)
                .NotNull()
                .NotEmpty()
                .WithMessage("大功能名稱不能為空")
                .MaximumLength(50)
                .WithMessage("大功能名稱不能超過50個字");

            RuleFor(x => x.FunctionChineseName)
                .NotNull()
                .NotEmpty()
                .WithMessage("大功能中文名稱不能為空")
                .MaximumLength(50)
                .WithMessage("大功能中文名稱不能超過50個字");

            RuleFor(x => x.Remark)
                .MaximumLength(50)
                .WithMessage("備註不能超過50個字");
        }
    }
}
