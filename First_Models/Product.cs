using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace First_Models
{
    public class Product
    {
        public Product() 
        {
            TempSqFt = 1;
        }

        [Key]
        public int Id { get; set; }
        [Required] 
        public string Name { get; set; }
		public string shortDesc { get; set; }
		public string Description { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir ürün ücreti giriniz!")]
        public double Price { get; set; }
        public string Image { get; set; }
        [Display(Name = "Category Type")]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }

        [Display(Name = "Application Type")]
        public int ApplicationId { get; set; }
        [ForeignKey(nameof(ApplicationId))]
        public virtual ApplicationType ApplicationType { get; set; }

        [NotMapped]
        [Range(1,10000, ErrorMessage ="Ücret 0 TL'den fazla olmalıdır!")]
        public int TempSqFt { get; set; }
    }
}
