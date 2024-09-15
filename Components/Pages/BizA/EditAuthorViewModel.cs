using System.ComponentModel.DataAnnotations;

[CustomValidation(typeof(EditAuthorViewModel), "NameAndPhoneCheck")]
public class EditAuthorViewModel
{
    [Display(Name = "著者ID")]
    public string AuthorId { get; set; } = "";

    [Display(Name = "著者名(名)")]
    [Required(ErrorMessage = "著者名(名)を入力してください")]
    [RegularExpression(@"^[¥u0020-¥u007E]{1,20}$", ErrorMessage = "著者名(名)は半角20文字以内で入力してください")]
    public string AuthorFirstName { get; set; } = "";

    [Display(Name = "著者名(性)")]
    [Required(ErrorMessage = "著者名(性)を入力してください")]
    [RegularExpression(@"^[¥u0020-¥u007E]{1,40}$", ErrorMessage = "著者名(性)は半角40文字以内で入力してください")]
    public string AuthorLastName { get; set; } = "";

    [Display(Name = "電話番号")]
    [Required(ErrorMessage = "電話番号を入力してください")]
    [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "電話番号の書式が正しくありません")]
    public string Phone { get; set; } = "";
    
    [Display(Name = "プラン")]
    public List<Person> personSelectList = new List<Person>();
    
    public string? SelectedPlanKey { get; set; }
    
    [Display(Name = "家族メンバー")]
    public List<FamilyMember> FamilyMembers { get; set; } = new List<FamilyMember>();

    // フォームレベルでの単体入力チェック項目に対するバリデーションロジックを実装
    public static ValidationResult? NameAndPhoneCheck(EditAuthorViewModel vm, ValidationContext ctx)
    {
        if (vm.AuthorFirstName == "hoge" && vm.AuthorLastName == "fuga") {
            return new ValidationResult("hogeとfugaは登録済みなので登録できません", new List<string>() {
                "AuthorFirstName", "AuthorLastName"
            });
        }
        return ValidationResult.Success;
    }
}


public class Person {
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Profession { get; set; } = "";
    public string Remarks { get; set; } = "";
}

public class FamilyMember
{
    public string Name { get; set; } = "";
    // 他の必要な家族情報のプロパティ...
}
