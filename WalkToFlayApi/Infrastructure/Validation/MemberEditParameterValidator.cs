using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkToFlayApi.Models.Input;

namespace WalkToFlayApi.Infrastructure.Validation
{
    /// <summary>
    /// 修改會員參數驗證
    /// </summary>
    public class MemberEditParameterValidator : AbstractValidator<MemberEditParameter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberParameterValidator"/> class.
        /// </summary>
        public MemberEditParameterValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .NotNull()
                .WithMessage("姓氏不能為空")
                .MaximumLength(20)
                .WithMessage("姓氏長度不能超過20");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .NotNull()
                .WithMessage("名稱不能為空")
                .MaximumLength(20)
                .WithMessage("名稱長度不能超過20");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("信箱不能為空")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("請輸入正確的Email格式");

            RuleFor(x => x.BirthDay)
                .NotEmpty()
                .NotNull()
                .WithMessage("生日不能為空");

            RuleFor(x => x.Sex)
                .NotEmpty()
                .NotNull()
                .WithMessage("性別不能為空");

            RuleFor(x => x.MobilePhone)
                .NotEmpty()
                .NotNull()
                .WithMessage("手機不能為空")
                .Matches("^09[0-9]{8}$")
                .WithMessage("請輸入正確的手機格式")
                .Length(10)
                .WithMessage("手機號碼應為10碼");

            RuleFor(x => x.TelePhone)
                .MaximumLength(10)
                .WithMessage("市話長度不能超過10");

            RuleFor(x => x.Address)
                .MaximumLength(50)
                .WithMessage("地址長度不能超過50");
        }
    }
}
