using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RagnarEstimator.Models
{
  public class Course : BaseEntity
  {
    [Key]
    public int CourseId {get; set;}
    public double Distance {get; set;}
    public int ElevGain {get; set;}
    public int Difficulty {get; set;}
    public int CourseSequence {get; set;}
    public string CourseNotes {get; set;}
    public List<Lap> Laps {get; set;}

    public Course()
    {
      Laps = new List<Lap>();
    }
    public string ColorCode()
    {
      switch (this.Difficulty)
      {
        case 1:
          return "green";
        case 2:
          return "yellow";
        case 3:
          return "red";
        default:
          return "blue";
      }
    }
  }
}