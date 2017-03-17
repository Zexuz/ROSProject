namespace ROS.Models
{
    public class MsSqlLoginCredentials
    {
        public string Host { get; set; }
        public string Database { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }

        public MsSqlLoginCredentials(string host, string database, string loginName, string password)
        {
            Host = host;
            Database = database;
            LoginName = loginName;
            Password = password;
        }
    }
}