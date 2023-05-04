//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ABCD_Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Galleries = new HashSet<Gallery>();
        }
    
        public int productId { get; set; }
        [Required]
        public string productName { get; set; }
        [Required]
        public string productDescription { get; set; }
        [Required]
        public decimal price { get; set; }
        [Required]
        public int shopId { get; set; }
        [Required]
        public string imagePath { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gallery> Galleries { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
