using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDll
{
    // Remove unnecessary spaces
    // Add summary to the properties
    // Rename the class to RequestModel
    // Instead of creating seperate class library you can create the folder Models and create the model
    public class Request
    {

        [Required]
        public string Subject { get; set; }
        [Required]
        public string Difficulty { get; set; }
        [Range(1, 25)]
        public int Number { get; set; }
    }

}
