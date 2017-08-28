using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RagnarEstimator.Models
{
  public class Race : BaseEntity
  {
    [Key]
    public int RaceId {get; set;}
    public DateTime RaceStart {get; set;}
    public DateTime RaceEnd {get; set;}
    public DateTime Sunset {get; set;}
    public DateTime Sunrise {get; set;}
    public float PaceMultiplyer {get; set;}
    public string RaceName {get; set;}
    public bool Type {get; set;}
    public string Notes {get; set;}
    public string TeamName {get; set;}
    public List<Runner> Runners {get; set;}
    public List<Course> Courses {get; set;}
    public List<Lap> Laps {get; set;}

    public Race()
    {
      Runners = new List<Runner>();
      Courses = new List<Course>();
      Laps = new List<Lap>();
    }
  }
}