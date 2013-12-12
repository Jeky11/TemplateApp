using System;

namespace TemplateApp.Data.Entities
{
    public class DbUser
    {
        public Int64 DbUserId { get; set; }

        public String Login { get; set; }

        public String Password { get; set; }

        public String Email { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String FullName { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset UpdatedDate { get; set; }
    }
}
