namespace MVC5_Week1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VaildationAttributes;

    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人 : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var db = new 客戶資料Entities();

            if (this.Id == 0)
            {
                //Create
                if(db.客戶聯絡人.Where(p => p.客戶Id == this.客戶Id &&p.Email == this.Email).Any())
                {
                    yield return new ValidationResult("Email已存在");
                }
            }
            else
            {
                //Update
                if (db.客戶聯絡人.Where(p => p.Id != this.Id && p.客戶Id == this.客戶Id && p.Email == this.Email).Any())
                {
                    yield return new ValidationResult("Email已存在");
                }
            }

            yield return ValidationResult.Success;
        }
    }

    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int 客戶Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 職稱 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 姓名 { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [Required]
        [EmailAddress(ErrorMessage ="必須為Email格式")]
        public string Email { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [檢核手機格式(ErrorMessage = "手機格式必須符合4碼-6碼(ex:0911-111111)")]
        public string 手機 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 電話 { get; set; }
    
       
        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
