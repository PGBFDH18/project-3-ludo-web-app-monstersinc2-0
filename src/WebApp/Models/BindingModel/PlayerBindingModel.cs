using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.BindingModel
{
    public class PlayerBindingModel
    {
        [Required]
        [StringLength(30, ErrorMessage = "Maximum length is {1}")]
        [MinLength(2, ErrorMessage = "At least 2 Charachter")]
        public string PlayerName { get; set; }

        [Required]
        public Color Color { get; set; }
    }

    public enum Color
    {
        red,
        yellow,
        blue,
        green
    }
}