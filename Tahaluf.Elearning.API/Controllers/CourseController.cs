using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.Elearning.API.Data;

namespace Tahaluf.Elearning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private static readonly List<Course> Courses = new List<Course>
        {

            new Course()
            {
                Id = 1,
                Name = "Math101",
                createDate = new DateTime(),
                category = "Math"
            },

              new Course()
            {
                Id = 2,
                Name = "English101",
                createDate = new DateTime(),
                category = "Languages"
            },

                 new Course()
            {
                Id = 3,
                Name = "IT101",
                createDate = new DateTime(),
                category = "IT"
            }

        };
        [HttpGet]//to retrive data from class
        [ProducesResponseType(typeof (List<Course>), StatusCodes.Status200OK)]//explain notebook
        public List<Course> GetAll()//no parametrs
        {
            return Courses;//return list

        }

        [Route("{Id}")]//fun type get with parameters
        [HttpGet]//to retrive data from class
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]//explain notebook
        public Course GetCourseById(int Id)//not return list single row
        {
            return Courses.FirstOrDefault(C => C.Id == Id);//(FirstOrDefault)when find it stop search //B object from book list
        }

        [Route("CourseName/{CourseName}")]
        [HttpGet]//to retrive data from class
        [ProducesResponseType(typeof(List<Course>), StatusCodes.Status200OK)]//search in list name return more than one value
        [ProducesResponseType(StatusCodes.Status404NotFound)]//to rsponse error 404 (notebbook) if Category (null) not return 404 error   
        public List<Course> GetWithOptionalValue(string CourseName,[FromQuery] string Category)//qurey in body....name of function GetWithOptionalValue  ==> optional (category)
        {
            if (Category == null)//defualt result query null
                return Courses.Where(c => c.Name == CourseName).ToList();
            else
                return Courses.Where(c => c.Name == CourseName && c.category == Category).ToList();


        }

        [HttpPost]//to send data from body to server
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]//create one course typeof(Course)
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//bad Request => to prevent conflict in memory while transform data
        public Course Create([FromBody] Course course) //read from body (html)
        {
            return new Course(); //to add to list 
        }

        //test in postman
        /*
         *  {       "Id": 20,
                "Name": "M1",
                "CreateDate": "0001-01-01T00:00:00",
                "Category": "M"
        }
        in body (postman) to test
   
         */

        [HttpPut] //update
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//bad Request => to prevent conflict in memory while transform data
        public Course Update([FromBody] Course course)
        {
            return new Course();
        }

        [HttpDelete("{Id}")]//send parmter id (delete by id)
        public bool Delete(int Id)
        {
            return true;
        }


    }
}

