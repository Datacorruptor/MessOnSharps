using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using ServerSharps;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MesServer.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ChatController : ControllerBase
  {
    static MesClass ms = new MesClass();
    static Users Us = new Users();
    // GET: api/<ChatController>
    [HttpGet]
    public string Get()
    {
      string all = "";
      string json;
      for (int i = ms.messages.Count - 1; i >= 0; i--)
      {
        json = JsonSerializer.Serialize(ms.messages.ElementAt(i));
        all = all + json.ToString() + "\n";
      }
      return all;
    }

    
    // GET api/<ChatController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      string json = "not found";
      if (id < ms.messages.Count && id >= 0)
      {
        json = JsonSerializer.Serialize(ms.messages.ElementAt(id));
      }
      return json.ToString();
    }

    // POST api/<ChatController>
    [HttpPost]
    public void Post([FromBody] message msg)
    {
      User user = Us.users.Find(usr => usr.username == msg.username);

      if (user == null)
        Us.add(new User(msg.username, msg.hash));
      else if (user.SHA256 != msg.hash)
        return;

      ms.Add(msg);
    }

    //// PUT api/<ChatController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    //// DELETE api/<ChatController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
  }
}
