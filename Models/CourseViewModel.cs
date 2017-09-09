using System;
using System.ComponentModel.DataAnnotations;

namespace RagnarEstimator.Models
{
  public class CourseViewModel
  {
    public double newCourseDistance {get; set;}
    public int newCourseElevation {get; set;}
    public int newCourseDifficulty {get; set;}
    public int newCourseSequence {get; set;}
  }
}