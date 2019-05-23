using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsoleApp2
{
   public class TestClass
   {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public virtual int Id { get; set; }

      public virtual DateTime? LastChangedDate { get; set; }

      public virtual string LastChangedUser { get; set; }

      [Required]
      public string Code { get; set; }

      [Required]
      public string Name { get; set; }

      [Required]
      public string CostCenter { get; set; }

      [Required]
      [StringLength(1)]
      public string Unit { get; set; }

      [Required]
      [Column(TypeName = "DECIMAL(18, 3)")]
      public decimal Rate { get; set; }
   }
}
