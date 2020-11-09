using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MesServer
{
  [Serializable]
  public class message
  {
    public string username { get; set; }
    public string text { get; set; }
    public DateTime timestamp { get; set; }

    public message()
    {
      this.username = "Server";
      this.text = "Server is running";
      this.timestamp = DateTime.UtcNow;
    }
    public message(string username, string text)
    {
      this.username = username;
      this.text = text;
      this.timestamp = DateTime.UtcNow;
    }
  }

  [Serializable]
  public class MesClass
  {
    public List<message> messages = new List<message>();

    public void Add(message ms)
    {
      ms.timestamp = DateTime.UtcNow;
      messages.Add(ms);
      Console.WriteLine("Added message " + ms.text + " from user " + ms.username);
      Console.WriteLine(messages.Count);
    }
    public void Add(string username, string text)
    {
      message ms = new message(username, text);
      ms.timestamp = DateTime.UtcNow;
      messages.Add(ms);
      Console.WriteLine("Added message " + ms.text + " from user " + ms.username);
      Console.WriteLine(messages.Count);
    }

    public MesClass()
    {
      messages.Clear();
      message ms = new message();
      this.Add(ms);
    }

    public MesClass(List<message> messages)
    {
      this.messages.Clear();
      this.messages.AddRange(messages);
      message ms = new message();
      this.Add(ms);
    }

    public override string ToString()
    {
      return messages.ToString();
    }
  }
}
