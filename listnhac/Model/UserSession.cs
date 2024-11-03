namespace listnhac.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserSession
    {
        [Key]
        public int SessionID { get; set; }

        public int? UserID { get; set; }

        [Required]
        [StringLength(255)]
        public string Token { get; set; }

        [StringLength(500)]
        public string DeviceInfo { get; set; }

        public DateTime ExpiryDate { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }

        public virtual User User { get; set; }
    }
}
