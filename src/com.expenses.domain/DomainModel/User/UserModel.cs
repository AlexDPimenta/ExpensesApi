namespace com.expenses.domain.DomainModel.User
{
    public class UserModel: BaseModel
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Cnpj { get; private set; }
        public string Password { get; private set; }
        public string PhoneNumber { get; private set; }
        public string CompanyName { get; private set; }
    }
}
