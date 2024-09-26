public class CustomerInfo
{
    public string CompanyName { get; set; }
    public string FullName { get; set; }
    public int NumberOfUsers { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public List<string> authorityUsers {get; set;}
}
