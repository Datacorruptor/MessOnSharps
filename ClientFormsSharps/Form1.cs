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
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientFormsSharps
{
  public partial class Form1 : Form
  {
    static Settings setts;
    static string url = "http://localhost:5000/api/chat/";
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      
      setts = JsonSerializer.Deserialize<Settings>(File.ReadAllText("config.json"));
      this.Width = setts.WindowWidth;
      this.Height = setts.WindowHeight;
      TextBoxMessages.Height = setts.WindowHeight - 100;
      TextBoxMessages.Width = setts.WindowWidth - 160;
      MessageText.Width = setts.WindowWidth - 160;
      SendButton.Location = new Point(setts.WindowWidth - 130, SendButton.Location.Y);
      label1.Location = new Point(setts.WindowWidth - 130, label1.Location.Y);
      UserNameTextBox.Location = new Point(setts.WindowWidth - 130, UserNameTextBox.Location.Y);
      label2.Location = new Point(setts.WindowWidth - 130, label2.Location.Y);
      PassWordTextBox.Location = new Point(setts.WindowWidth - 130, PassWordTextBox.Location.Y);
      Emoji1.Location = new Point(setts.WindowWidth - 130, Emoji1.Location.Y);
      Emoji2.Location = new Point(setts.WindowWidth - 104, Emoji2.Location.Y);
      Emoji3.Location = new Point(setts.WindowWidth - 78, Emoji3.Location.Y);
      Emoji4.Location = new Point(setts.WindowWidth - 52, Emoji4.Location.Y);
      Update.Interval = setts.updateInterval;
    }

    private void Update_Tick(object sender, EventArgs e)
    {
      List<string> temp = new List<string>();

      System.Net.WebRequest reqGET = System.Net.WebRequest.Create(url);
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
    }

    private void SendButton_Click(object sender, EventArgs e)
    {
      string username = UserNameTextBox.Text;
      string text = MessageText.Text;
      string hash = Hashtool.GetHash(SHA256.Create(), PassWordTextBox.Text);
      message msg = new message(username,hash, text);
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
  }
}
