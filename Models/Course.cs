using System;
using System.ComponentModel.DataAnnotations;

namespace RagnarEstimator.Models
{
  public class Course: BaseEntity
  {
    [Key]
    public int CourseId {get; set;}
    public int Distance {get; set;}
    public int Difficulty {get; set;}
    public string ColorCode {get; set;}
    public string Notes {get; set;}
  }
}