namespace IAM.Core.Models
{
    public class Personal : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string INN { get; set; }

        public string FullName { get { return $"{LastName} {FirstName} {FatherName}"; } }
    }
}
