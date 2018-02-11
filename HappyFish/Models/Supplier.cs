using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HappyFish
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(AutoGenerateField = false)]
        public Guid Code { get; set; }

        public List<Product> Products{ get; set; }
        //List of Users Via Guid Code
    }
}