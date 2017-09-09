using System;
using System.ComponentModel.DataAnnotations;

namespace RagnarEstimator.Models
{
  public class RaceViewModel
  {
    [Required(ErrorMessage="Race name not vaild")]
    [MinLength(2)]
    public string newRaceName {get; set;}

    [Required(ErrorMessage="Invalid start date")]
    public string newStartDate {get; set;}

    [Required(ErrorMessage="Invalid Start Time")]
    public string newStartTime {get; set;}

    public string newEndTime {get; set;}

    public string newRaceType {get; set;}

    public double newMultiplyer {get; set;}

    public string newTeamName {get; set;}
  }
}