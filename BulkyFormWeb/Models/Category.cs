using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyFormWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Номер")]
        [Range(1, 1000, ErrorMessage ="Порядок выполнения может принимать значение от 1 до 1000 !")]
        public int DisplayOrder { get; set; }
        [DisplayName("Дата и время создания")]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
	}
}