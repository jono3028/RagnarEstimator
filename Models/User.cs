using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RagnarEstimator.Models
{
  public class User : BaseEntity
  {
    [Key]
    public int UserId {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string NickName {get; set;}
    public string RunnerNotes {get; set;}
    public TimeSpan RunnerPace {get; set;}
    public float RunnerPaceMultiplyer {get; set;}
    public int RunnerSequence {get; set;}
    public List<RaceSegment> Segments { get; set; }

    public User()
    {
      Segments = new List<RaceSegment>();
    }
  }
}