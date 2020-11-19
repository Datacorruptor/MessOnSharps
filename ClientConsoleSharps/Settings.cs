using System;
using System.Collections.Generic;
using System.Text;

namespace ClientConsoleSharps
{
  [Serializable]
  class Settings
  {
    public int updateInterval { get; set; }
    public Settings()
    {
      this.updateInterval = 0;
    }
  }
}
