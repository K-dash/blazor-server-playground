using System.ComponentModel.DataAnnotations;

[CustomValidation(typeof(CustomerInfo), "validationDate")]
public class CustomerInfo
{
    [Display(Name = "会社名")]
    [Required(ErrorMessage = "会社名を入力してください")]
    public string? CompanyName { get; set; }

    [Display(Name = "担当者名")]
    [Required(ErrorMessage = "担当者名を入力してください")]
    public string? FullName { get; set; }

    [Display(Name = "メールアドレス")]
    [Required(ErrorMessage = "メールアドレスを入力してください")]
    [EmailAddress(ErrorMessage ="メールアドレス形式で入力してください")]
    public string? EmailAddress { get; set; }

    [Display(Name = "利用人数")]
    [Required(ErrorMessage = "利用人数を入力してください")]
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "1以上の数値を入力してください")]
    public string? NumberOfUsers { get; set; }

    [Display(Name = "プラン")]
    [Required(ErrorMessage = "プランを入力してください")]
    public string? Plan { get; set; }

    [Display(Name = "利用開始日")]
    [Required(ErrorMessage = "利用開始日を入力してください")]
    public DateTime? StartDate { get; set; }

    [Display(Name = "利用終了日")]
    [Required(ErrorMessage = "利用終了日を入力してください")]
    public DateTime? EndDate { get; set; }

    public List<string>? authorityUsers {get; set;}
    
    [Display(Name = "広告形式")]
    [Required(ErrorMessage = "選択してください")]
    public List<string> AdvertisingFormats { get; set; }
    
    // フォームレベルでの単体入力チェック項目に対するバリデーションロジックを実装
    public static ValidationResult? validationDate(CustomerInfo ci, ValidationContext ctx)
    {
        if (ci.StartDate > ci.EndDate) {
            return new ValidationResult("利用終了日は利用開始日よりも後の日付を指定してください", new List<string>() {
                "StartDate", "EndDate"
            });
        }
        return ValidationResult.Success;
    }
}
