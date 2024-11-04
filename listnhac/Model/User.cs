namespace listnhac.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Playlists = new HashSet<Playlist>();
        }

        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public bool? RememberMe { get; set; }

        public DateTime? CreatedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}
