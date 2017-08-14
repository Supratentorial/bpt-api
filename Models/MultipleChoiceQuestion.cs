using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bpt.api.Models
{
    public class MultipleChoiceQuestion
    {

        public int Id { get; set; }
        [MinLength(10)]
        public string Question { get; set; }
        [Required]
        public List<MultipleChoiceOption> Options { get; set; }
        public string Explanation { get; set; }
        public List<Reference> References { get; set; }
    }
}
