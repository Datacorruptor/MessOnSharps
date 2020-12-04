using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServerSharps
{
  
  [Serializable]
  public class User
  {
    public string username { get; set; }
    public string SHA256 { get; set; }
    public User()
    {}
    public User(string username,string SHA256)
    {
      this.username = username;
      this.SHA256 = SHA256;
    }
  }

  [Serializable]
  public class Users
  {
    static public List<User> users = new List<User>();
    static public string PATH = @"c:\temp\Users.txt";
    static public void add(User usr)
    {
      File.AppendAllText(PATH, JsonSerializer.Serialize(usr).ToString() + "\n");
      users.Add(usr);
      Console.WriteLine("Added new User " + usr.username + " with password " + usr.SHA256);
    }
    static Users()
    {
      if (File.Exists(PATH))
      {
        using (StreamReader sr = File.OpenText(PATH))
        {
          string s;
          while ((s = sr.ReadLine()) != null)
          {
            User us = JsonSerializer.Deserialize<User>(s);
            users.Add(us);
            Console.WriteLine("remembered user " + us.username + " with password " + us.SHA256);
          }
        }
      }
    }
  }
}
