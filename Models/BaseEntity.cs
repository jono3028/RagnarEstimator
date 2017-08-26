using System;

namespace RagnarEstimator.Models
{
  public class BaseEntity
  {
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
    public BaseEntity()
    {
      CreatedAt = DateTime.Now;
      UpdatedAt = DateTime.Now;
    }
  }
}
