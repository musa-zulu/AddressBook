namespace AddressBook.Domain.Entities
{
    public class ContactDetail
    {
        public int ContactDetailId { get; set; }        
        public string Description { get; set; }
        public ContactType ContactTypeId { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
