using System;

namespace com.expenses.domain.DomainModel
{
    public class BaseModel
    {     
        public Guid Id { get; set; }

        public BaseModel()
        {
            Id = Guid.NewGuid();
        }
	}
}
