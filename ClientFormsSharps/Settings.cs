using System;
using System.Collections.Generic;
using System.Text;

namespace ClientConsoleSharps
{
  [Serializable]
  class Settings
  {
    public int updateInterval { get; set; }
    public int WindowHeight { get; set; }
    public int WindowWidth { get; set; }
    public Settings()
    {
      this.updateInterval = 0;
      this.WindowHeight = 490;
      this.WindowWidth = 820;
    }
  }
}
