using System.ComponentModel.DataAnnotations;
using WebApp.Models.CustomAttributes;

namespace WebApp.Models.BindingModel
{
    public class PlayerBindingModel
    {

        #region
        [PlayerCustom] // Refere to CustomAttributes/PlayerCustomAttribute
        [RegularExpression(@"[\w ]*", ErrorMessage = "Only letters and numbers")]
        [StringLength(30, ErrorMessage = "Maximum length is {1}")]
        [MinLength(2, ErrorMessage = "At least 2 Charachter")]
        public string Player1Name { get; set; }

        [ColorRequired("Player1Name", ErrorMessage = "Please Choose Color")] // Refere to CustomAttributes/ColorRequiredAttribute
        public Color Color1 { get; set; }
        #endregion // Player1

        #region
        [PlayerCustom]
        [RegularExpression(@"[\w ]*", ErrorMessage = "Only letters and numbers")]
        [StringLength(45, ErrorMessage = "Maximum length is {1}")]
        [MinLength(2, ErrorMessage = "At least 2 Charachter")]
        public string Player2Name { get; set; }

        [ColorRequired("Player2Name", ErrorMessage = "Please Choose Color")]
        [ColorUniqAttribute("Color1", ErrorMessage = "Color already taken")] // Refere to CustomAttributes/ColorUniqAttribute
        public Color Color2 { get; set; }
        #endregion // Player2m

        #region
        [RegularExpression(@"[\w ]*", ErrorMessage = "Only letters and numbers")]
        [StringLength(45, ErrorMessage = "Maximum length is {1}")]
        [MinLength(2, ErrorMessage = "At least 2 Charachter")]
        public string Player3Name { get; set; }

        [ColorRequired("Player3Name", ErrorMessage = "Please Choose Color")]
        [ColorUniqAttribute("Color1", ErrorMessage = "Color already taken")]
        [ColorUniqAttribute("Color2", ErrorMessage = "Color already taken")]
        public Color Color3 { get; set; }
        #endregion // Player3

        #region
        [RegularExpression(@"[\w ]*", ErrorMessage = "Only letters and numbers")]
        [StringLength(45, ErrorMessage = "Maximum length is {1}")]
        [MinLength(2, ErrorMessage = "At least 2 Charachter")]
        public string Player4Name { get; set; }

        [ColorRequired("Player4Name", ErrorMessage = "Please Choose Color")]
        [ColorUniqAttribute("Color3", ErrorMessage = "Color already taken")]
        [ColorUniqAttribute("Color2", ErrorMessage = "Color already taken")]
        [ColorUniqAttribute("Color1", ErrorMessage = "Color already taken")]
        public Color Color4 { get; set; }
        #endregion // Player4
    }

    public enum Color
    {
        color,
        red,
        green,
        blue,
        yellow
    }
}