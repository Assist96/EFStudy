namespace CodeOnly
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderInfo")]
    public partial class OrderInfo
    {
        public int Id { get; set; }

        [StringLength(32)]
        public string Content { get; set; }

        public int UserInfoId { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}
