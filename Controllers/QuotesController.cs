using Microsoft.AspNetCore.Mvc;
using FisherInsuranceApi.Data;
using FisherInsuranceApi.Models;

[Route("api/quotes")]
 public class QuotesController : Controller
 {
    // private IMemoryStore db;
    //public QuotesController(IMemoryStore repo)
    public QuotesController()
    {
     //db = repo;
    } 

     // POST api/quotes
 [HttpPost]
 public IActionResult Post([FromBody]Quote quote)
 {
 //return Ok(db.CreateQuote(quote));
   return Ok();
 }

// GET api/quotes/5
 [HttpGet("{id}")]
 public IActionResult Get(int id)
 {
 //return Ok(db.RetrieveQuote(id)); 
   return Ok();
 }

 [HttpGet]
public IActionResult GetQuotes()
{
 //return Ok(db.RetrieveAllQuotes);
 return Ok();
} 

// PUT api/quotes/id
 [HttpPut("{id}")]
 public IActionResult Put(int id, [FromBody]Quote quote)
 {
 //return Ok(db.UpdateQuote(quote)); 
 return Ok();
 }

 // DELETE api/quotes/id
 [HttpDelete("{id}")]
 public IActionResult Delete(int id)
 {
 //db.DeleteQuote(id);
 return Ok(); 
 }



 }