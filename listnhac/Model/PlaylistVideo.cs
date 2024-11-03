namespace listnhac.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PlaylistVideo
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlaylistID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VideoID { get; set; }

        public int? OrderNumber { get; set; }

        public DateTime? DateAdded { get; set; }

        public virtual Playlist Playlist { get; set; }

        public virtual Video Video { get; set; }
    }
}
