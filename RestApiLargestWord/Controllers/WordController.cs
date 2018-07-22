using Microsoft.AspNetCore.Mvc;
using RestApiLargestWord.Models;
using WordRetriever;

namespace RestApiLargestWord.Controllers
{
    [Route("api/[controller]")]
    public class WordController : Controller
    {
        private IWordRetriever retriever;

        public WordController(IWordRetriever retriever)
            => this.retriever = retriever;

        // GET api/Word
        [HttpGet]
        public IActionResult Get()
            => Json(new {
                Instructions = "Post a JSON object with this <format> and in the <route> I give you",
                Route = "api/word/Largest",
                Method = "Post",
                Format = "{phrase:<string with a phrase inside>}"
            });
        
        // POST api/Word/Largest
        [HttpPost]
        [Route("Largest")]
        public WordResponse Largest([FromBody] WordRequest value)
        {
            var phrase = value.Phrase;
            var word = retriever.Retrieve(phrase);

            return new WordResponse { Word = word };
        }
    }
}
