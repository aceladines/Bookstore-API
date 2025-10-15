using Bookstore.Domain.Enums;

namespace Bookstore.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public Role Role { get; private set; }

#pragma warning disable CS8618 
        private User() { }
#pragma warning restore CS8618

        public User(string username, string email, string passwordHash, Role role)
        {
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
        }
    }
}
