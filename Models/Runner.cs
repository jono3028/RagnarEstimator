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
    public string Notes {get; set;}
    public TimeSpan Pace {get; set;}
    public float PaceMultiplyer {get; set;}
    public int Sequence {get; set;}
  }
}