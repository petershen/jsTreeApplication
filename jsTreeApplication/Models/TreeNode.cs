using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace jsTreeApplication.Models
{
    public class TreeNode
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Parent is required.")]
        public string Parent { get; set; }
        [Required(ErrorMessage = "Text is required.")]
        public string Text { get; set; }
        public string Notes { get; set; }
    }
}
