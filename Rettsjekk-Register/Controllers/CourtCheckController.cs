
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Rettsjekk_Register.Data;
using Rettsjekk_Register.Model;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Rettsjekk_Register.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourtCheckController : ControllerBase
    {
        private readonly CourtCheck data = new();

        [HttpGet("trials/{vatnum}")]
        [SwaggerOperation(Summary = "Get trials (up to 10)", Description = "Gets all the trials the company has had and are planned to have, given their vatnum (up to 10). Date is optional")]
        public ActionResult<IEnumerable<Trials.Trial>> Trials(string vatnum, string date)
        { 
            List<Trials.Trial> trials = data.TrialsSearch(vatnum, date);
            if (trials != null) //compInf.ToString().Length > 71
            {
                return Ok(trials);
        } else
            {
                return NoContent();
    }


        }

        [HttpGet("bankruptcy/{vatnum}")]
        [SwaggerOperation(Summary = "Get bankruptcy data, if there are any", Description = "Get bankruptcy data, if there are any, by givving the company's vatnum")]
        public ActionResult<IEnumerable<Trials.Bankruptcy>> Bankruptcy(string vatnum)
        {
            List<Trials.Bankruptcy> bankruptcies = data.BankruptcySearch(vatnum);
            if (bankruptcies != null) //compInf.ToString().Length > 71
            {
                return Ok(bankruptcies);
            }
            else
            {
                return NoContent();
            }


        }


        [HttpGet("solvent/{vatnum}")]
        [SwaggerOperation(Summary = "Get solvent data, if there are any", Description = "Get solvent data, if there are any, by givving the company's vatnum")]
        public ActionResult<IEnumerable<Trials.Solvent>> Solvent(string vatnum)
        {
            List<Trials.Solvent> solvent = data.SolventSearch(vatnum);
            if (solvent != null) //compInf.ToString().Length > 71
            {
                return Ok(solvent);
            }
            else
            {
                return NoContent();
            }


        }

        //[HttpPost("getToken/{email}&&{password}")] //api key?
        //[SwaggerOperation(Summary = "Get token and account info", Description = "Get token and account info by givving the accounts api-credentials")]
        //public ActionResult<Account.Main> GetUserAndToken(string email, string password, string apikey)
        //{
        //    Account.Main dataa = data.GetToken(email, password, apikey);
        //    if (dataa != null) 
        //    {
        //        return Ok(data);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }


        //}

    }
}  
