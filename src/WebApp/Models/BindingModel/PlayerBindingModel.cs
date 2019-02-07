using System.ComponentModel.DataAnnotations;
using WebApp.Models.CustomAttributes;

namespace WebApp.Models.BindingModel
{
    public class PlayerBindingModel
    {
        [PlayerCustom]
        [StringLength(30, ErrorMessage = "Maximum length is {1}")]
        [MinLength(2, ErrorMessage = "At least 2 Charachter")]
        public string Player1Name { get; set; }


        public Color Color1 { get; set; }

        [PlayerCustom]
        [StringLength(45, ErrorMessage = "Maximum length is {1}")]
        [MinLength(2, ErrorMessage = "At least 2 Charachter")]
        public string Player2Name { get; set; }

        [ColorCustom("Color1", ErrorMessage = "Color already taken")]
        public Color Color2 { get; set; }


        [StringLength(45, ErrorMessage = "Maximum length is {1}")]
        [MinLength(2, ErrorMessage = "At least 2 Charachter")]
        public string Player3Name { get; set; }

        [ColorCustom("Color1", ErrorMessage = "Color already taken")]
        [ColorCustom("Color2", ErrorMessage = "Color already taken")]
        public Color Color3 { get; set; }

        [StringLength(45, ErrorMessage = "Maximum length is {1}")]
        [MinLength(2, ErrorMessage = "At least 2 Charachter")]
        public string Player4Name { get; set; }

        [ColorCustom("Color3", ErrorMessage = "Color already taken")]
        [ColorCustom("Color2", ErrorMessage = "Color already taken")]
        [ColorCustom("Color1", ErrorMessage = "Color already taken")]
        public Color Color4 { get; set; }

    }

    public enum Color
    {
        red,
        yellow,
        blue,
        green
    }
}