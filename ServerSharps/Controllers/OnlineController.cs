using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerSharps.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OnlineController : ControllerBase
  {
    // GET: api/<OnlineController>
    public static List<string> online_users = new List<string>();
    [HttpGet]
    public string Get()
    {
      string s = "";
      foreach (string user in online_users)
        s = s + user + "\n";
      return s;
    }

    // GET api/<OnlineController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }

    // POST api/<OnlineController>
    [HttpPost]
    public void Post([FromBody] OnlineStatus stat)
    {
      User user = Users.users.Find(usr => usr.username == stat.username);

      if (user == null)
        Users.add(new User(stat.username, stat.hash));
      else if (user.SHA256 != stat.hash)
        return;

      Console.WriteLine(stat.username +" is " + stat.status);

      if (stat.status == "online")
        online_users.Add(stat.username); 
      else
        online_users.Remove(stat.username); 
    }

    // PUT api/<OnlineController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<OnlineController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
