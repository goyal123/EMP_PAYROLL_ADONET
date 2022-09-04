using System.Data.SqlClient;
namespace ConsoleApp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program.connection();
            Console.ReadLine();
        }

        public static void connection()
        {
            String cs = "Data Source=localhost;Initial catalog=PAYROLL_SERVICE;Trusted_Connection=True"; 
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                        Console.WriteLine("Connection successful");

                    string query = "select * from EMPLOYEE_PAYROLL";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while(dr.Read())
                    {
                        Console.WriteLine("ID = " + dr["ID"] + " Name = " + dr["Name"] + " Salary = " + dr["Salary"]);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        
        }
    }
}