using System;

namespace Thuria.Barsoom.DataModel
{
  public class UserStatusDataModel
  {
    public Guid Id { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
  }
}
