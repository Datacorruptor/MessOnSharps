using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading;
using MesServer;
namespace MesClientSharps
{
  class Program
  {
    static int top = 0;
    static string url = "http://localhost:5000/api/chat/";
    static void Main(string[] args)
    {


      
      Console.Write("Username:");
      string username = Console.ReadLine();
      ThreadStart starter = new ThreadStart(Update);
      Thread upd = new Thread(starter);



      while (true)
      {
        Console.Clear();
        Console.WriteLine("(" + username + ") Message:");
        top = printAllMessages();
        if (!upd.IsAlive)
          upd.Start();
        Console.SetCursorPosition(("(" + username + ") Message:").Length, 0);
        string text = Console.ReadLine();

        message msg = new message(username, text);
        string json = JsonSerializer.Serialize(msg);

        var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
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

    static int printAllMessages()
    {
      List<String> temp = new List<string>();
      //int i = 0;
      //while(getMessage(i) != "not found")
      //  temp.Add(getMessage(i++));
      //temp.Reverse();

      temp = getAllMessages().Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList<String>();
      foreach (string m in temp)
      {
        message msg = JsonSerializer.Deserialize<message>(m);
        Console.WriteLine(msg.username + ":\"" + msg.text + "\" | " + msg.timestamp);
      }
      return (Console.CursorTop);
    }

    static string getMessage(int id)
    {
      System.Net.WebRequest reqGET = System.Net.WebRequest.Create(url + id);
      System.Net.WebResponse resp = reqGET.GetResponse();
      System.IO.Stream stream = resp.GetResponseStream();
      System.IO.StreamReader sr = new System.IO.StreamReader(stream);
      string s = sr.ReadToEnd();
      return s;
    }

    static string getAllMessages()
    {
      System.Net.WebRequest reqGET = System.Net.WebRequest.Create(url);
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
      Console.SetCursorPosition(x, 0);
    }

    static void Update()
    {
      while (true)
      {
        Thread.Sleep(5000);
        CASF();
      }
    }
  }
}
