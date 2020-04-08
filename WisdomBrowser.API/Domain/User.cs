using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WisdomBrowser.API.Domain
{
    public class User : IdentityUser<int>
    {
        //public int Id { get; set; }
        //public string UserName { get; private set; }
        //public byte[] PasswordHash { get; private set; }
        //public byte[] PasswordSalt { get; private set; }
        
        private HashSet<Course> _courses; 
        public IEnumerable<Course> Courses => _courses?.ToList();
        public User()
        {
            
        }
        public User(string login):base(login)
        {

        }
        //public User(string name, byte[] passwordHash, byte[] passwordSalt)
        //{
        //    UserName = name;
        //    PasswordSalt = passwordSalt;
        //    PasswordHash = passwordHash;
        //}
        public void AddCourse(int numStars, string comment, string voterName /*, DbContext context = null*/) 
        {
            /*
            if (_courses != null)    
            {
               // _courses.Add(new Course(numStars, comment, voterName));   
            }
            else if (context == null)
            {
                throw new ArgumentNullException(nameof(context), 
                    "You must provide a context if the Courses collection isn't valid.");
            }
            else if (context.Entry(this).IsKeySet)  
            {
                //context.Add(new Course(numStars, comment, voterName, UserId));
            }
            else                                    
            {                                        
                throw new InvalidOperationException("Could not add a new course.");  
            }*/
        }
        public void RemoveCourse(Course course){}
    }
}