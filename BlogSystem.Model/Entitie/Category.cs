using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Model.Entitie
{
    [Table("Category")]  
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int SubId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set;}


        public virtual ICollection<Article> Articles { get; set; }
    }
}
