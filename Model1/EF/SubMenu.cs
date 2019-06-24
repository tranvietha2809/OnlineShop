namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubMenu")]
    public partial class SubMenu
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Text { get; set; }

        [StringLength(55)]
        public string Link { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public int? DisplayOrder { get; set; }
    }
}
