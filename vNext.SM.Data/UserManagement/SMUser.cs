using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vNext.SM.Data.UserManagement
{
    public class SMUser
    {
        public int SMUserId { get; set; }
        [StringLength(50)]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, ErrorMessage = "Invalid Password", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string UserPassport { get; set; }
        [StringLength(3)]
        public string UserRole { get; set; }
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        [Timestamp]
        public Byte[] CreatedOn { get; set; }

    }
}
