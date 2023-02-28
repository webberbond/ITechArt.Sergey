namespace Patterns.Builder;

public class Person
{
    public static PersonBuilder Builder => new();

    private string FirstName { get; set; }
    private string LastName { get; set; }
    private string ZipCode { get; set; }

    private Person(string firstName, string lastName, string zipCode)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        ZipCode = zipCode;
    }

    public class PersonBuilder
    {
        private string _firstName = null!;
        private string _lastName = null!;
        private string _zipCode = null!;

        public PersonBuilder FirstName(string firstName)
        {
            _firstName = firstName;

            return this;
        }

        public PersonBuilder LastName(string lastName)
        {
            _lastName = lastName;

            return this;
        }

        public PersonBuilder ZipCode(string zipCode)
        {
            _zipCode = zipCode;

            return this;
        }

        public Person Build()
        {
            return new Person(_firstName, _lastName, _zipCode);
        }
    }

    public string GetFirstName()
    {
        return FirstName;
    }

    public string GetLastName()
    {
        return LastName;
    }

    public string GetZipCode()
    {
        return ZipCode;
    }
}