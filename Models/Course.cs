using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RagnarEstimator.Models
{
  public class Course : BaseEntity
  {
    [Key]
    public int CourseId {get; set;}
    public int Distance {get; set;}
    public int Difficulty {get; set;}
    public string ColorCode {get; set;}
    public string CourseNotes {get; set;}
    public List<Lap> Laps {get; set;}

    public Course()
    {
      Laps = new List<Lap>();
    }
  }
}