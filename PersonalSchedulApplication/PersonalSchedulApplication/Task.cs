using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalSchedulApplication
{
    class Task
    {
       
        public int Id { get; set; }
        public String Title { get; set; }
        public String StartTime { get; set; }
        public String EndTime { get; set; }
        public String CurrentTime { get; set; }



        public string SaveInDatabase()
        {

            string connection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\lab2\Desktop\Mahfuz.Training\Git\PersonalSchedulingApplication\PersonalSchedulApplication\PersonalSchedulApplication\DBTable\DEVELOPER-PC.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection connectionobj = new SqlConnection(connection);

          //  string query = string.Format("INSERT INTO Task VALUES('{0}','{1}','{2}','{3}')", Title, StartTime, EndTime, CurrentTime);

            string query = string.Format("INSERT INTO Task VALUES('{0}','{1}','{2}','{3}')", Title, StartTime, EndTime, CurrentTime);

            SqlCommand command = new SqlCommand(query,connectionobj);

            connectionobj.Open();

            int number = command.ExecuteNonQuery();
            connectionobj.Close();

            if (number > 0)
            {
                return "data inserted";
                
                
            }
            else
            {
                return "something error";
            }
           
            


        }


        public List<Task> getData()
        {

            string connection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\lab2\Desktop\Mahfuz.Training\Git\PersonalSchedulingApplication\PersonalSchedulApplication\PersonalSchedulApplication\DBTable\DEVELOPER-PC.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection connectionobj = new SqlConnection(connection);


            string readQuery = string.Format("SELECT * FROM Task");

            SqlCommand command = new SqlCommand(readQuery, connectionobj);
            

            command.CommandText = readQuery;
            connectionobj.Open();
            SqlDataReader aReader = command.ExecuteReader();
            List<Task> tasks = new List<Task>();
            if (aReader != null)
            {
                while (aReader.Read())
                {

                    Task aTask = new Task();
                    
                    aTask.Title = aReader["Title"].ToString();
                    aTask.StartTime = (string) (aReader["StartTime"]);
                    aTask.EndTime = (string) (aReader["EndTime"]);
                   
                    tasks.Add(aTask);

                }
            }
            connectionobj.Close();
            return tasks;
        }
    }
}
