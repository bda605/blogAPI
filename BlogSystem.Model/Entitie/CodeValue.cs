using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Model.Entitie
{
    [Table("CodeValue")]
    public class CodeValue
    {
        public string TypeCode { get; set; }
        public string Code { get; set; }
        public string SubCode { get; set; }
        
        public string Value { get; set; }


        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
