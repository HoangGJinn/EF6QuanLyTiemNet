using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public static class DbHelper
    {
        public static string BuildEntityConnectionString(string user, string pass)
        {
            string providerConnectionString = $"Data Source=.;Initial Catalog=QuanLyTiemNet;User ID={user};Password={pass};Encrypt=True;TrustServerCertificate=True";

            string metadata = "res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl";

            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder
            {
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = providerConnectionString,
                Metadata = metadata
            };

            return entityBuilder.ToString();
        }

    }
}
