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
    public float RacePaceMultiplyer {get; set;}
    public string RaceName {get; set;}
    public bool Type {get; set;}
    public string RaceNotes {get; set;}
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

    private void UpdateEstFromStartTime(int LapId, DateTime STime)
    {
      var idx = LapId - 1;

      while (idx < Laps.Count)
      {
        Lap _lap = Laps[idx];
        _lap.FinishTimeEst = STime + TimeSpan.FromTicks(_lap.Runner.RunnerPace.Ticks * _lap.Course.Distance);

        if (idx++ < Laps.Count)
        {
          Lap _lapNext = this.Laps[idx];
          _lapNext.StartTimeEst = _lap.FinishTimeEst;
        }
      }
    }
    private void UpdateEstFromFinishTime(int LapId, DateTime FTime)
    {
      var idx = LapId;
      
      while (idx < Laps.Count)
      {
        Lap _lap = Laps[idx];
        _lap.StartTimeEst = FTime;
        this.UpdateEstFromStartTime(LapId, _lap.StartTimeEst);
        idx++;
      }
    }
  }
}