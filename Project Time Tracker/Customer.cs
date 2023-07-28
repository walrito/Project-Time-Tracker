using Elements.Database;
using System.Data.SQLite;

namespace Project_Time_Tracker
{
    public class Customer
    {
        public static List<CustomerList> GenerateCustomerList(bool excludeHidden)
        {
            List<CustomerList> customerList = new();
            string whereClause = excludeHidden ? "where CustomerID > 0 " : "";
            string query = "select CustomerID, CustomerName from Customers " + whereClause + "order by CustomerName collate nocase";

            SQLiteDataReader? dr = SQLite.ExecuteReader(query, SQLite.spl, "ProjectTimeTracker");
            if (dr is { HasRows: true })
            {
                while (dr.Read())
                {
                    customerList.Add(new CustomerList { CustomerId = dr.GetInt32(0), CustomerName = dr.GetString(1) });
                }
                dr.Close();
            }

            return customerList;
        }

        public static int AddCustomer(string customerName)
        {
            SQLite.spl.Add(new SQLiteParameter("@CustomerName", customerName));
            return SQLite.ExecuteNonQuery("insert into Customers (CustomerName) values (@CustomerName)", SQLite.spl, "ProjectTimeTracker");
        }

        public static void UpdateCustomer(int customerId, string customerName)
        {
            SQLite.spl.Add(new SQLiteParameter("@CustomerID", customerId));
            SQLite.spl.Add(new SQLiteParameter("@CustomerName", customerName));
            SQLite.ExecuteNonQuery("update Customers set CustomerName = @CustomerName where CustomerId = @CustomerID", SQLite.spl, "ProjectTimeTracker");
        }

        public static void DeleteCustomer(int customerId, bool deleteAll)
        {
            string deleteQuery = "delete from Customers";
            if (!deleteAll) deleteQuery += " where CustomerId = @CustomerID";
            SQLite.spl.Add(new SQLiteParameter("@CustomerID", customerId));
            SQLite.ExecuteNonQuery(deleteQuery, SQLite.spl, "ProjectTimeTracker");

            deleteQuery = "delete from CustomerProject";
            if (!deleteAll) deleteQuery += " where CustomerId = @CustomerID";
            SQLite.spl.Add(new SQLiteParameter("@CustomerID", customerId));
            SQLite.ExecuteNonQuery(deleteQuery, SQLite.spl, "ProjectTimeTracker");

            if (customerId == 0 || deleteAll) { SQLite.PopulateDefaultTableValues("ProjectTimeTracker"); }
        }

        public static int GetCustomerId(string customerName)
        {
            if (string.IsNullOrEmpty(customerName)) return 0;

            int customerId = -1;

            SQLite.spl.Add(new SQLiteParameter("@CustomerName", customerName));
            SQLiteDataReader? dr = SQLite.ExecuteReader("select CustomerID from Customers where CustomerName = @CustomerName and CustomerID > 0 limit 1", SQLite.spl, "ProjectTimeTracker");
            if (dr is { HasRows: true })
            {
                while (dr.Read())
                {
                    customerId = dr.GetInt32(0);
                }
                dr.Close();
            }
            else
            {
                customerId = AddCustomer(customerName);
            }

            return customerId;
        }
    }

    public class CustomerList
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
    }
}