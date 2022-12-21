using System;
namespace ApiUsers.Helpers
{
	public class ApiUsersDatabaseSettings
	{
		public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string UsersCollectionName { get; set; } = null!;
    }
}

