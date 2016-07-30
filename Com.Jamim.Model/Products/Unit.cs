using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Com.Jamim.Model.Products
{
    public class Unit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Notation { get; set; }
        public string Description { get; set; }

    }
}
