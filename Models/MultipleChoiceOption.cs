using System.ComponentModel.DataAnnotations;

namespace bpt.api.Models
{
    public class MultipleChoiceOption
    {
        public int Id { get; set; }
        [MinLength(3)]
        public string Text { get; set; }
        public bool IsAnswer { get; set; }
    }
}
