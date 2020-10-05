using System;
using System.Collections.Generic;

namespace SocialMedia.Entities.Models
{
    public partial class AspNetComments
    {
        public int PkId { get; set; }
        public string FkUserId { get; set; }
        public int FkPostId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsEdited { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public virtual AspNetPosts FkPost { get; set; }
        public virtual AspNetUsers FkUser { get; set; }
    }
}
