using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moduit.Interview.Class;
using Moduit.Interview.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Moduit.Interview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        Helper Helper = new Helper();
        //Please create a controller that sends request to this endpoint: /backend/question/one
        //and please mirror all responses that you get from that endpoint.
        // GET: api/Answers/AnswerOne
        [Route("AnswerOne")]
        [HttpGet]
        public InputOutputOne GetAnswerOne()
        {
            InputOutputOne InputOutputOne = null;
            var baseUrl = "https://screening.moduit.id/";
            var paramurl = "backend/question/One";

            var result = Helper.getStringResponseFromAsync(baseUrl, paramurl);

            if (result != null)
            {
                InputOutputOne = JsonConvert.DeserializeObject<InputOutputOne>(result.Result.ToString());
            }
            return InputOutputOne;
        }

        //Please create a controller that sends request to this endpoint: /backend/question/two
        //then please apply the following filter to the response:

        //1.    Description that contains "Ergonomics" or Title that contains "Ergonomics"
        //2.    Tags that contains "Sports"
        //3.    Order by Id descending
        //4.    Get the last 3 (three) items only
        //Please put the resulting output from the above filter to the response.

        // GET: api/Answers/AnswerTwo
        [Route("AnswerTwo")]
        [HttpGet]
        public List<InputOutputTwo> GetAnswerTwo()
        {
            List<InputOutputTwo> InputOutputTwo = null;
            var baseUrl = "https://screening.moduit.id/";
            var paramurl = "backend/question/Two";

            var result = Helper.getStringResponseFromAsync(baseUrl, paramurl);

            if (result != null)
            {

                var InputTwo = JsonConvert.DeserializeObject<List<InputOutputTwo>>(result.Result.ToString());

                StringComparison compOrdinalIgnoreCase = StringComparison.OrdinalIgnoreCase;
                InputOutputTwo = InputTwo.Where(x =>
                (x.description.Contains("Ergonomic", compOrdinalIgnoreCase) || x.title.Contains("Ergonomic", compOrdinalIgnoreCase))
                && x.tags.Any(y => y.Contains("Sport", compOrdinalIgnoreCase))).OrderByDescending(y => y.id)
                    .TakeLast(3)
                    .ToList();

            }

            return InputOutputTwo;
        }


        //Please create a controller that sends request to this endpoint: /backend/question/three
        //then please flatten property items from the response.

        // GET: api/Answers/AnswerThree
        [Route("AnswerThree")]
        [HttpGet]
        public List<OutputThree> GetAnswerThree()
        {
            List<OutputThree> OutputThree = new List<OutputThree>();
            var baseUrl = "https://screening.moduit.id/";
            var paramurl = "backend/question/Three";

            var result = Helper.getStringResponseFromAsync(baseUrl, paramurl);

            if (result != null)
            {
                var InputThree = JsonConvert.DeserializeObject<List<InputThree>>(result.Result.ToString());

                foreach (var item in InputThree)
                {
                    foreach (var x in item.items)
                    {
                        OutputThree.Add(new OutputThree()
                        {
                            id = item.id,
                            category = item.category,
                            title = x.title,
                            description = x.description,
                            footer = x.footer,
                            createdAt = item.createdAt
                        });
                    }
                }
            }

            return OutputThree;
        }
    }
}
