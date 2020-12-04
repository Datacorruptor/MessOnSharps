using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading;
using ClientConsoleSharps;
using MesServer;
using ServerSharps;

namespace MesClientSharps
{
  class Program
  {

    private delegate bool ConsoleCtrlHandlerDelegate(int sig);
    [DllImport("Kernel32")]
    private static extern bool SetConsoleCtrlHandler(ConsoleCtrlHandlerDelegate handler, bool add);
    static ConsoleCtrlHandlerDelegate _consoleCtrlHandler;




    static int top = 0;
    static string url = "http://localhost:5000/api/";
    static Settings setts;
    static void Main(string[] args)
    {
     


      setts = JsonSerializer.Deserialize<Settings>(File.ReadAllText("config.json"));
      
      Console.Write("Username:");
      string username = Console.ReadLine();

      Console.Write("Password:");
      string pass = Console.ReadLine();
      string hash = Hashtool.GetHash(SHA256.Create(), pass);
      IAmStatus(new OnlineStatus(username, "online", hash));

      _consoleCtrlHandler += s =>
      {
        IAmStatus(new OnlineStatus(username, "offline", hash));
        return false;
      };
      SetConsoleCtrlHandler(_consoleCtrlHandler, true);



      Thread upd = new Thread(Update);

      while (true)
      {
        Console.Clear();
        Console.WriteLine("(" + username + ") Message:");
        top = printAllMessages();
        top = printAllOnlineUsers();
        if (!upd.IsAlive)
          upd.Start();
        Console.SetCursorPosition(("(" + username + ") Message:").Length, 0);
        string text = Console.ReadLine();



        message msg = new message(username,hash, text);
        string json = JsonSerializer.Serialize(msg);

        var httpWebRequest = (HttpWebRequest)WebRequest.Create(url+"chat/");
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "POST";

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
          streamWriter.Write(json);
        }

        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
          var result = streamReader.ReadToEnd();
        }

      }
    }

    static void IAmStatus(OnlineStatus stat)
    {
     
      string json = JsonSerializer.Serialize(stat);

      var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "Online/");
      httpWebRequest.ContentType = "application/json";
      httpWebRequest.Method = "POST";

      using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
      {
        streamWriter.Write(json);
      }

      var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
      using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
      {
        var result = streamReader.ReadToEnd();
      }
    }

    static int printAllMessages()
    {
      List<string> temp = new List<string>();
      //int i = 0;
      //while(getMessage(i) != "not found")
      //  temp.Add(getMessage(i++));
      //temp.Reverse();

      temp = getAllMessages().Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList<string>();
      foreach (string m in temp)
      {
        message msg = JsonSerializer.Deserialize<message>(m);
        Console.WriteLine(msg.username + ":\"" + msg.text + "\" | " + msg.timestamp);
      }
      return (Console.CursorTop);
    }

    static int printAllOnlineUsers()
    {
      List<string> temp = new List<string>();
      Console.WriteLine("Users online:");
      temp = getOnlineUsers().Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList<string>();
      foreach (string m in temp)
      {
        Console.WriteLine(m);
      }
      return (Console.CursorTop);
    }

    static string getMessage(int id)
    {
      System.Net.WebRequest reqGET = System.Net.WebRequest.Create(url + "chat/" + id);
      System.Net.WebResponse resp = reqGET.GetResponse();
      System.IO.Stream stream = resp.GetResponseStream();
      System.IO.StreamReader sr = new System.IO.StreamReader(stream);
      string s = sr.ReadToEnd();
      return s;
    }

    static string getAllMessages()
    {
      System.Net.WebRequest reqGET = System.Net.WebRequest.Create(url + "chat/");
      System.Net.WebResponse resp = reqGET.GetResponse();
      System.IO.Stream stream = resp.GetResponseStream();
      System.IO.StreamReader sr = new System.IO.StreamReader(stream);
      string s = sr.ReadToEnd();
      return s;
    }

    static string getOnlineUsers()
    {
      System.Net.WebRequest reqGET = System.Net.WebRequest.Create(url + "Online/");
      System.Net.WebResponse resp = reqGET.GetResponse();
      System.IO.Stream stream = resp.GetResponseStream();
      System.IO.StreamReader sr = new System.IO.StreamReader(stream);
      string s = sr.ReadToEnd();
      return s;
    }
    static void CASF()
    {
      int x = Console.CursorLeft;
      //Sets the cursor position
      for (int i = 1; i <= top; i++)
      {
        Console.SetCursorPosition(0, i);
        Console.WriteLine("                                                                                                                                                             ");
      }
      Console.SetCursorPosition(0, 1);
      printAllMessages();
      printAllOnlineUsers();
      Console.SetCursorPosition(x, 0);
    }

    static void Update()
    {
      while (true)
      {
        Thread.Sleep(setts.updateInterval);
        CASF();
      }
    }
  }
}
