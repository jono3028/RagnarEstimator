using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


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
    public double RacePaceMultiplyer {get; set;}
    public string RaceName {get; set;}
    public bool Type {get; set;} //false = Road, true = Trail
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

    public void UpdateStartTime(int idx, TimeSpan STime)
    {
      DateTime prevFinish = (idx == 0) ? this.RaceStart : (DateTime) this.Laps[idx - 1].FinishTimeAct;
      
      if (STime < prevFinish.TimeOfDay) 
      {
        prevFinish.AddDays(1);
      }
      this.Laps[idx].StartTimeAct = prevFinish.Date + STime;
      
      CalcFinishEstimate(idx);

      this.Laps[idx].UpdatedAt = DateTime.Now;

      if (this.Laps[idx].FinishTimeAct == null)
      {
        idx++;
        if (idx < Laps.Count)
        {
          this.Laps[idx].StartTimeEst = this.Laps[idx - 1].FinishTimeEst;
        }
        UpdateEstimates(idx);
      } 
    }

    public void UpdateFinishTime(int idx, TimeSpan FTime)
    {
      DateTime STime = (DateTime) this.Laps[idx].StartTimeAct;

      if (FTime <= STime.TimeOfDay) 
      {
        STime.AddDays(1);
      };

      this.Laps[idx].FinishTimeAct = STime.Date + FTime;

      this.Laps[idx].UpdatedAt = DateTime.Now;

      idx++;

      if (idx < Laps.Count && this.Laps[idx].StartTimeAct == null)
      {
        this.Laps[idx].StartTimeEst = STime.Date + FTime;
        UpdateEstimates(idx);
      }
    }

    private void CalcFinishEstimate(int idx) 
    {
      double pace = this.Runners.Where(r => r.RunnerId == this.Laps[idx].RunnerId).Single().RunnerPace;
      double distance = this.Courses.Where(c => c.CourseId == this.Laps[idx].CourseId).Single().Distance;
      this.Laps[idx].FinishTimeEst = ((this.Laps[idx].StartTimeAct == null) ? this.Laps[idx].StartTimeEst  : (DateTime) this.Laps[idx].StartTimeAct) + (TimeSpan.FromSeconds((pace * distance) * this.RacePaceMultiplyer));
    }

    private void UpdateEstimates(int idx)
    {
      while (idx < Laps.Count)
      {
        CalcFinishEstimate(idx);

        this.Laps[idx].UpdatedAt = DateTime.Now;

        idx++;

        if (idx < Laps.Count && this.Laps[idx - 1].FinishTimeAct == null)
        {
          this.Laps[idx].StartTimeEst = this.Laps[idx - 1].FinishTimeEst;
        }
        else {
          return;
        }
      }
    }
  }
}