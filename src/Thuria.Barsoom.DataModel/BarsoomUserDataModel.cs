using System;
using Thuria.Thark.DataModel.Attributes;

namespace Thuria.Barsoom.DataModel
{
  public class BarsoomUserDataModel
  {
    public Guid Id { get; set; }

    public string UserName { get; set; }
    public Guid UserStatusId { get; set; }
    public bool IsActive { get; set; }
  }
}
