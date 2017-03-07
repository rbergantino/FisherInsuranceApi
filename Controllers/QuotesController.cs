using Microsoft.AspNetCore.Mvc;
using FisherInsuranceApi.Data;
using FisherInsuranceApi.Models;

[Route("api/quotes")]
 public class QuotesController : Controller
 {
    // private IMemoryStore db;
    private readonly FisherContext db;

    //public QuotesController(IMemoryStore repo)
    public QuotesController(FisherContext context)
    {
     db = context;
    } 

     // POST api/quotes
 [HttpPost]
 public IActionResult Post([FromBody]Quote quote)
 {
 //return Ok(db.CreateQuote(quote));
   var newQuote = db.Quotes.Add(quote);
   db.SaveChanges();
   return CreatedAtRoute("GetQuote", new { id = quote.Id }, quote);

 }

// GET api/quotes/5
 [HttpGet("{id}", Name = "GetQuote")]
 public IActionResult Get(int id)
 {
 //return Ok(db.RetrieveQuote(id)); 
   return Ok(db.Quotes.Find(id));
 }

 [HttpGet]
public IActionResult GetQuotes()
{
 //return Ok(db.RetrieveAllQuotes);
 return Ok(db.Quotes);
} 

// PUT api/quotes/id
 [HttpPut("{id}")]
 public IActionResult Put(int id, [FromBody]Quote quote)
 {
 //return Ok(db.UpdateQuote(quote)); 
 var newQuote = db.Quotes.Find(id);
 if (newQuote == null)
 {
 return NotFound();
 }
 newQuote = quote;
 db.SaveChanges();
 return Ok(newQuote);
 }

 // DELETE api/quotes/id
 [HttpDelete("{id}")]
 public IActionResult Delete(int id)
 {
 //db.DeleteQuote(id);
 var quoteToDelete = db.Quotes.Find(id);
 if (quoteToDelete == null)
 {
 return NotFound();
 }
 db.Quotes.Remove(quoteToDelete);
 db.SaveChangesAsync();
 return NoContent(); 
 }



 }