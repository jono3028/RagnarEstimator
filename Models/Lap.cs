using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RagnarEstimator.Models
{
  public class Lap : BaseEntity
  {
    [Key]
    public int LapId {get; set;}
    public int LapSequence {get; set;}
    public int RunnerId {get; set;}
    public Runner Runner {get; set;}
    public int CourseId {get; set;}
    public Course Course {get; set;}
    public DateTime StartTimeEst { get; set; }
    public DateTime FinishTimeEst { get; set; }
    public DateTime? StartTimeAct {get; set;}
    public DateTime? FinishTimeAct { get; set; }
    public string LapNotes {get; set;}

    public Lap()
    {
      StartTimeAct = null;
      FinishTimeAct = null;
    }
  }  
}