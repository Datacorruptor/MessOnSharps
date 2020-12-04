using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSharps
{
  public class OnlineStatus
  {
    public string username { get; set; }
    public string hash { get; set; }
    public string status { get; set; }
    public OnlineStatus()
    { }
    public OnlineStatus(string username, string status, string hash)
    {
      this.username = username;
      this.status = status;
      this.hash = hash;
    }
  }
}
