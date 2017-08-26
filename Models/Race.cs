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
    public bool RaceType {get; set;}
    public string RaceNotes {get; set;}
    public string TeamName {get; set;}
    public List<User> Runners {get; set;}
  }
}