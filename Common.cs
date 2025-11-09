namespace SchoolManagement
{
    public class Common
    {
        private readonly IConfiguration _configuration;

        public Common(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string getConnection()
        {
            return _configuration.GetConnectionString("DefaultConnection"); 
        }
    }
}
