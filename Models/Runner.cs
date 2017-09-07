using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RagnarEstimator.Models
{
  public class Runner : BaseEntity
  {
    [Key]
    public int RunnerId {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string NickName {get; set;}
    public string RunnerNotes {get; set;}
    public int RunnerPace {get; set;}
    public decimal RunnerPaceMultiplyer {get; set;}
    public int RunnerSequence {get; set;}
    public List<Lap> Laps {get; set;}

    public Runner()
    {
      Laps = new List<Lap>();
    }
    public string PaceFormatted()
    {
      return TimeSpan.FromSeconds(this.RunnerPace).ToString(@"%m\:ss");  
    }
  }
}