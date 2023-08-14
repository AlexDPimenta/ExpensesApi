namespace com.expenses.domain.DomainModel.Customer
{
    public class CustomerModel: BaseModel
    {
        public string Cnpj { get; set; }
        public string ComercialName { get; set; }
        public string LegalName { get; set; }
    }
}
