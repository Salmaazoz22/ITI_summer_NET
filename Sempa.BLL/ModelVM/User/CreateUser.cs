using System.ComponentModel.DataAnnotations;

namespace Resturant.BLL.ModelVM.User
{
    public class CreateUser

    {
        [Required(ErrorMessage = "Name is required :(")]
        [MinLength(2, ErrorMessage = "Plz enter min length")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is required :(")]
        [Range(20,60, ErrorMessage = "Plz enter age between 20 and 60")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Type is required :(")]
        public Restaurant.DAL.Enum.Type Type { get; set; }
    }
}
