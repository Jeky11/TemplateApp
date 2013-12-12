using System;

namespace TemplateApp.Web.Models.Home
{
    public class DbUserModel
    {
        public Int64 DbUserId { get; set; }

        public String Email { get; set; }

        public String FullName { get; set; }

        public Int32 HourlyRate { get; set; }
    }
}