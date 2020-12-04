using ClientConsoleSharps;
using MesServer;
using ServerSharps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientFormsSharps
{
  public partial class Form1 : Form
  {
    private delegate bool ConsoleCtrlHandlerDelegate(int sig);
    [DllImport("Kernel32")]
    private static extern bool SetConsoleCtrlHandler(ConsoleCtrlHandlerDelegate handler, bool add);
    static ConsoleCtrlHandlerDelegate _consoleCtrlHandler;

    static Settings setts;
    static string url = "http://localhost:5000/api/";
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      
      setts = JsonSerializer.Deserialize<Settings>(File.ReadAllText("config.json"));
      this.Width = setts.WindowWidth;
      this.Height = setts.WindowHeight;
      MyResize();
    }

    public void MyResize()
    {
      TextBoxMessages.Height = this.Height - 100;
      TextBoxMessages.Width = this.Width - 160;
      OnlineTextBox.Location = new Point(this.Width - 130, OnlineTextBox.Location.Y);
      OnlineTextBox.Height = this.Height - 280;
      MessageText.Width = this.Width - 160;
      SendButton.Location = new Point(this.Width - 130, SendButton.Location.Y);
      label1.Location = new Point(this.Width - 130, label1.Location.Y);
      UserNameTextBox.Location = new Point(this.Width - 130, UserNameTextBox.Location.Y);
      label2.Location = new Point(this.Width - 130, label2.Location.Y);
      PassWordTextBox.Location = new Point(this.Width - 130, PassWordTextBox.Location.Y);
      GoOnlineButton.Location = new Point(this.Width - 130, GoOnlineButton.Location.Y);
      Emoji1.Location = new Point(this.Width - 130, Emoji1.Location.Y);
      Emoji2.Location = new Point(this.Width - 104, Emoji2.Location.Y);
      Emoji3.Location = new Point(this.Width - 78, Emoji3.Location.Y);
      Emoji4.Location = new Point(this.Width - 52, Emoji4.Location.Y);
      Update.Interval = setts.updateInterval;
    }

    private void Update_Tick(object sender, EventArgs e)
    {
      List<string> temp = new List<string>();

      System.Net.WebRequest reqGET = System.Net.WebRequest.Create(url+"chat/");
      System.Net.WebResponse resp = reqGET.GetResponse();
      System.IO.Stream stream = resp.GetResponseStream();
      System.IO.StreamReader sr = new System.IO.StreamReader(stream);
      string s = sr.ReadToEnd();
      temp = s.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
      string accumulate = "";
      foreach (string m in temp)
      {
        message msg = JsonSerializer.Deserialize<message>(m);
        accumulate+=msg.username + ":\"" + msg.text + "\" | " + msg.timestamp+ "\r\n";
      }
      TextBoxMessages.Text = accumulate;

      reqGET = System.Net.WebRequest.Create(url + "Online/");
      resp = reqGET.GetResponse();
      stream = resp.GetResponseStream();
      sr = new System.IO.StreamReader(stream);
      s = sr.ReadToEnd();
      temp = s.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
      accumulate = "Users online:\r\n";
      foreach (string m in temp)
      {
        accumulate += m+"\r\n";
      }
      OnlineTextBox.Text = accumulate;

    }

    private void SendButton_Click(object sender, EventArgs e)
    {
      string username = UserNameTextBox.Text;
      string text = MessageText.Text;
      string hash = Hashtool.GetHash(SHA256.Create(), PassWordTextBox.Text);
      message msg = new message(username,hash, text);
      string json = JsonSerializer.Serialize(msg);

      var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "chat/");
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

      MessageText.Text = "";
    }

    private void Emoji1_Click(object sender, EventArgs e)
    {
      MessageText.Text = MessageText.Text + Emoji1.Text;
    }

    private void Emoji2_Click(object sender, EventArgs e)
    {
      MessageText.Text = MessageText.Text + Emoji2.Text;
    }

    private void Emoji3_Click(object sender, EventArgs e)
    {
      MessageText.Text = MessageText.Text + Emoji3.Text;
    }

    private void Emoji4_Click(object sender, EventArgs e)
    {
      MessageText.Text = MessageText.Text + Emoji4.Text;
    }

    private void GoOnlineButton_Click(object sender, EventArgs e)
    {
      GoOnlineButton.Enabled = false;
      UserNameTextBox.Enabled = false;
      PassWordTextBox.Enabled = false;
      MessageText.Enabled = true;
      SendButton.Enabled = true;
      Emoji1.Enabled = true;
      Emoji2.Enabled = true;
      Emoji3.Enabled = true;
      Emoji4.Enabled = true;
      IAmStatus(new OnlineStatus(UserNameTextBox.Text, "online", Hashtool.GetHash(SHA256.Create(), PassWordTextBox.Text)));
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

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      if(SendButton.Enabled==true)
        IAmStatus(new OnlineStatus(UserNameTextBox.Text, "offline", Hashtool.GetHash(SHA256.Create(), PassWordTextBox.Text)));
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
      MyResize();
    }
  }
}
