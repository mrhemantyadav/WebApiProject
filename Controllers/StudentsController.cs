using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIProject.Models;

namespace WebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        string str = string.Empty;
        StudentContext db = new StudentContext();

        [HttpGet]
        public List<StudentModel> Get()
        {

            List<StudentModel> allStu = db.GetStudent();

            return allStu;
        }

        [HttpGet("{id}")]
        public StudentModel GetById(int id)
        {

            StudentModel row = db.GetStudent().Find(X => X.Id == id);
            return row;
        }


        [HttpPost]
        public string Post(StudentModel sm)
        {
           
            if (ModelState.IsValid)
            {
                bool check = db.PostData(sm);
                if (check == true)
                {
                    str = "Data Insert";
                }
                else
                {
                    str = "Somthing is wrong ";
                }
            }
            return str;
        }

        [HttpPut]
        public string Edit(int id, StudentModel sm)
        {
            if (ModelState.IsValid)
            {

                bool check = db.Edit(id, sm);
                if (check == true)
                {
                    str = "Data successfull modifiy   ";
                }
                else
                {
                    str = "Somthing is wrong ";
                }
            }
            return str;

        }



        [HttpDelete]
        public string Delete(int id) 
        {

            if (ModelState.IsValid)
            {
              
                bool check = db.Delete(id);
                if (check == true)
                {
                    str = "Successfull delete Data";
                }
                else
                {
                    str = "Somthing is wrong ";
                }
            }
            return str;

        }
    }
}
