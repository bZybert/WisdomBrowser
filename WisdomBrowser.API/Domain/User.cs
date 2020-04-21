using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WisdomBrowser.API.Domain
{
    public class User : IdentityUser<int>
    {        
        private HashSet<Video> _videos; 
        public IEnumerable<Video> Videos => _videos?.ToList();
        public User()
        {
            
        }
        public User(string login):base(login)
        {

        }
        
        public void AddVideo(Video video /*, DbContext context = null*/) 
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
        public void RemoveVideo(Video video){}
    }
}