using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MVC5_Week1.Models.VaildationAttributes
{
    public class 檢核手機格式: DataTypeAttribute
    {
        public 檢核手機格式() : base(DataType.Text)
        {

        }
        public override bool IsValid(object value)
        {
            var strValue = (string)value;
            return Regex.IsMatch(strValue, RegularExp.mobile);
        }
        private struct RegularExp
        {
            public const string mobile = @"\d{4}-\d{6}";
        }
    }
}