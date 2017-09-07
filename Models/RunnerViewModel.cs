using System;
using System.ComponentModel.DataAnnotations;

namespace RagnarEstimator.Models
{
  public class RunnerViewModel
  {
    [Required(ErrorMessage="Runner Name is Required")]
    public string newRunnerName {get; set;}
    [Required(ErrorMessage="Runner pace not in valid format")]
    [RegularExpression(@"^[0-9]{1,2}:[0-9]{2}")]
    public string newRunnerPace {get; set;}
    public int newRunnerSequence {get; set;}
    public decimal newRunnerMultiplyer {get; set;}
  }
}