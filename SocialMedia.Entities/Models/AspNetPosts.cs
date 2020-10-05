using System;
using System.Collections.Generic;

namespace SocialMedia.Entities.Models
{
    public partial class AspNetPosts
    {
        public AspNetPosts()
        {
            AspNetComments = new HashSet<AspNetComments>();
        }

        public int PkId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsEdited { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string FkUserId { get; set; }

        public virtual AspNetUsers FkUser { get; set; }
        public virtual ICollection<AspNetComments> AspNetComments { get; set; }
    }
}
