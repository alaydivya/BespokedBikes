using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Data.SqlClient;

namespace BespokedBikes
{
    public partial class Products : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "tcp:bepoked-server.database.windows.net";
            builder.UserID = "divyaalay";
            builder.Password = "admin@123";
            builder.InitialCatalog = "bespokesbikes";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                String sql = "SELECT top 10 * from products";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    productsGridView.DataSource = command.ExecuteReader();
                    productsGridView.DataBind();
                }
            }
        }
    }
}