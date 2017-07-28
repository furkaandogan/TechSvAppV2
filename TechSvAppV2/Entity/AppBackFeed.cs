using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [DataContract]
    public class AppFeedBack : ICopyMembers<AppFeedBack>
    {

        public FeedBackType Type { get; set; }

        public string Subject { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }

    }
}
