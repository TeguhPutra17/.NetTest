using System;
using System.Collections.Generic;

namespace CategoryButton.Models.SQLServer
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}
