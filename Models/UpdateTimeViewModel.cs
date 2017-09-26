using System;
using System.ComponentModel.DataAnnotations;

namespace RagnarEstimator.Models
{
  public class UpdateTimeViewModel
  {
    [Required(ErrorMessage = "Time is required")]
    [RegularExpression(@"^[0-9]{1,2}:[0-9]{2}")]
    public string newTime {get; set;}
  }
}