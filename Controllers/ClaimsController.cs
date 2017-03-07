using Microsoft.AspNetCore.Mvc;
using FisherInsuranceApi.Data;
using FisherInsuranceApi.Models;

[Route("api/claims")]
 public class ClaimsController : Controller
 {
//      private IMemoryStore db;
    //public ClaimsController(iMemoryStore repo)
    public ClaimsController(FisherContext context)
    {
     db = context;
    } 
     // POST api/claims
 [HttpPost]
 public IActionResult Post([FromBody]Claim claim)
 {
//return Ok(db.CreateClaim(claim));
  var newClaim = db.Claims.Add(claim);
  db.SaveChanges();

  return CreatedAtRoute("GetClaim", new { id = claim.Id }, claim);
 }

// GET api/claims/5
 [HttpGet("{id}", Name = "GetClaim")]
 public IActionResult Get(int id)
 {
 //return Ok(db.RetrieveClaim(id)); 
   return Ok(db.Claims.Find(id));
 }

 [HttpGet]
public IActionResult GetClaims()
{
 //return Ok(db.RetrieveAllClaims);
   return Ok(db.Claims);
} 

// PUT api/claims/id
 [HttpPut("{id}")]
 public IActionResult Put(int id, [FromBody]Claim claim)
 {
 //return Ok(db.UpdateClaim(claim));
   var newClaim = db.Claims.Find(id);
   if (newClaim == null)
   {
     return NotFound();
   }
   newClaim = claim;
   db.Claims.Update(newClaim);
   db.SaveChanges();
   return Ok(newClaim);
 }

 // DELETE api/claims/id
 [HttpDelete("{id}")]
 public IActionResult Delete(int id)
 {
 //db.DeleteClaim(id);
 var claimToDelete = db.Claims.Find(id);
 if (claimToDelete == null)
 {
 return NotFound();
 }
 db.Claims.Remove(claimToDelete);
 db.SaveChangesAsync();
 return NoContent(); 
 }
private readonly FisherContext db;

 }