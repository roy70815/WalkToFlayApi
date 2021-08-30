using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkToFlayApi.Models.Input;

namespace WalkToFlayApi.Infrastructure.Validation
{
    /// <summary>
    /// 登入參數驗證
    /// </summary>
    public class LogginParameterValidator : AbstractValidator<LogginParameter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogginParameterValidator"/> class.
        /// </summary>
        public LogginParameterValidator()
        {
            RuleFor(x => x.MemberId)
                .NotEmpty()
                .NotNull()
                .WithMessage("帳號不能為空");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("密碼不能為空");
        }
    }
}