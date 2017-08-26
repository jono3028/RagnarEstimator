using System;
using System.ComponentModel.DataAnnotations;

namespace RagnarEstimator.Models
{
  public class RaceSegment : BaseEntity
  {
    [Key]
    public int RaceSegmentId {get; set;}
    public int Distance {get; set;}
    public int Difficulty {get; set;}
    public string ColorCode {get; set;}
    public string SegmentNotes {get; set;}
    public DateTime RunnerStartTimeEst {get; set;}
    public DateTime RunnerFinishTimeEst {get; set;}
    public DateTime RunnerStartTimeAct { get; set; }
    public DateTime RunnerFinishTimeAct { get; set; }
  }
}