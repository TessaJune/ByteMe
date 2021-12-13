using System.ComponentModel.DataAnnotations;

namespace Trainor.Storage.Entities
{
    /* 
        Question: Should GivenName, LastName && Email be required? 
        Added: I added an Id to a user. Maybe this could be done differently
    */
    public class User
    {
        // public User(string givenName, string lastName, string email)
        // {
        //     GivenName = givenName;
        //     LastName = lastName;
        //     Email = email;
        // }

        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string? GivenName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }
}