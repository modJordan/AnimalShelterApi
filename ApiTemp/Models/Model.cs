using System.ComponentModel.DataAnnotations;

namespace ApiTemp.Models
{
  public class Model
  {
    [Required]
    public int ModelId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
  }
}