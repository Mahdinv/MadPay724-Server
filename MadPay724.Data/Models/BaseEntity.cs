using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MadPay724.Data.Models
{
    public class BaseEntity <T> /*bazi mavaghe masal id inte ya bite ya... ma to tamam modela ino farakhoni mikonim va oonja moshakhas mikonim ke id ma a che noei bashe. masalan ye jaei hast man mikham id ro string tariif konam bara inke primary beshe guid mikonamesh*/
    {
        [Key]
        public T Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateModified { get; set; }
    }
}
