using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace WebAPIProject.Models
{
    public class StudentContext
    {

        SqlConnection _con = new SqlConnection("server = HEMANT\\SQLEXPRESS; integrated security = true; initial catalog = APIWithDB");
        SqlCommand cmd;
        SqlDataAdapter adp;
        DataTable dt = new DataTable();

        public List<StudentModel> GetStudent()
        {
            List<StudentModel> addList = new List<StudentModel>();

            cmd = new SqlCommand("GetData", _con);
            adp = new SqlDataAdapter(cmd);

            cmd.CommandType = CommandType.StoredProcedure;

            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                StudentModel sm = new StudentModel()
                {
                    Id = Convert.ToInt32(dr["ID"]),
                    Name = dr["Name"].ToString(),
                    Email = dr["Email"].ToString(),
                    MobileNo = Convert.ToInt64(dr["MobileNo"]),
                    Password = dr["Password"].ToString(),
                    Gender = dr["Gender"].ToString(),
                    SchoolName = dr["SchoolName"].ToString(),
                    Address = dr["Address"].ToString(),
                    Country = dr["Country"].ToString(),
                    State = dr["State"].ToString(),
                };
                addList.Add(sm);
            }
            return addList;
        }


        public bool PostData(StudentModel sm)
        {
            string message = string.Empty;
            cmd = new SqlCommand("InsertData", _con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Name", sm.Name);
            cmd.Parameters.AddWithValue("Email", sm.Email);
            cmd.Parameters.AddWithValue("MobileNo", sm.MobileNo);
            cmd.Parameters.AddWithValue("Password", sm.Password);
            cmd.Parameters.AddWithValue("Gender", sm.Gender);
            cmd.Parameters.AddWithValue("SchoolName", sm.SchoolName);
            cmd.Parameters.AddWithValue("Address", sm.Address);
            cmd.Parameters.AddWithValue("Country", sm.Country);
            cmd.Parameters.AddWithValue("State", sm.State);
            if (_con.State == ConnectionState.Closed)
            {
                _con.Open();
            }
            int affected = cmd.ExecuteNonQuery();

            if (_con.State != ConnectionState.Closed)
            {
                _con.Close();

            }
            if (affected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Edit(int id, StudentModel sm)
        {
            string message = string.Empty;
            cmd = new SqlCommand("EditData", _con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Id", id);
            cmd.Parameters.AddWithValue("Name", sm.Name);
            cmd.Parameters.AddWithValue("Email", sm.Email);
            cmd.Parameters.AddWithValue("MobileNo", sm.MobileNo);
            cmd.Parameters.AddWithValue("Password", sm.Password);
            cmd.Parameters.AddWithValue("Gender", sm.Gender);
            cmd.Parameters.AddWithValue("SchoolName", sm.SchoolName);
            cmd.Parameters.AddWithValue("Address", sm.Address);
            cmd.Parameters.AddWithValue("Country", sm.Country);
            cmd.Parameters.AddWithValue("State", sm.State);
            if (_con.State == ConnectionState.Closed)
            {
                _con.Open();
            }
            int affected = cmd.ExecuteNonQuery();

            if (_con.State != ConnectionState.Closed)
            {
                _con.Close();

            }
            if (affected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            string message = string.Empty;
            cmd = new SqlCommand("DeleteData", _con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Id", id);

            if (_con.State == ConnectionState.Closed)
            {
                _con.Open();
            }

            int affected = cmd.ExecuteNonQuery();

            if (_con.State != ConnectionState.Closed)
            {
                _con.Close();
            }
            if (affected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
