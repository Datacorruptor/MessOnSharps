using ServerSharps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;

namespace MesServer
{
  [Serializable]
  public class message
  {
    public string username { get; set; }
    public string text { get; set; }
    public string hash { get; set; }
    public DateTime timestamp { get; set; }

    public message()
    {
      this.username = "Server";
      this.text = "Server is running";
      this.timestamp = DateTime.UtcNow;
      this.hash = "0";
    }

    public message(string username, string hash, string text)
    {
      this.username = username;
      this.text = text;
      this.timestamp = DateTime.UtcNow;
      this.hash = hash;
    }
  }
  [Serializable]
  public class MesClass
  {
    public List<message> messages = new List<message>();
    static public string PATH = @"c:\temp\Messages.txt";
    public void Add(message ms)
    {
      ms.timestamp = DateTime.UtcNow;
      File.AppendAllText(PATH, JsonSerializer.Serialize(ms).ToString() + "\n");
      messages.Add(ms);
      Console.WriteLine("Added message " + ms.text + " from user " + ms.username);
    }
    public void Add(string username, string hash, string text)
    {
      message ms = new message(username, hash, text);
      this.Add(ms);
    }

    public MesClass()
    {
      messages.Clear();

      //Open the file to read from.
      if (File.Exists(PATH))
      {
        using (StreamReader sr = File.OpenText(PATH))
        {
          string s;
          while ((s = sr.ReadLine()) != null)
          {
            message msg = JsonSerializer.Deserialize<message>(s);
            messages.Add(msg);
            Console.WriteLine("Loaded message " + msg.text + " from user " + msg.username);
          }
        }
      }
      message ms = new message();
      this.Add(ms);
    }

    public override string ToString()
    {
      return messages.ToString();
    }
  }

}
