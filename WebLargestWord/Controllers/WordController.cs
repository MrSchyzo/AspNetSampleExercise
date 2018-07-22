using Microsoft.AspNetCore.Mvc;
using WebLargestWord.Models;
using WordRetriever;

namespace WebLargestWord.Controllers
{
    public class WordController : Controller
    {
        private IWordRetriever retriever;

        public WordController(IWordRetriever retriever)
        {
            this.retriever = retriever;
        }

        public IActionResult Index()
        {
            return View(new WordRequest());
        }

        [HttpPost]
        public IActionResult Largest(WordRequest request)
        {
            var phrase = request.Phrase;
            var largestWord = retriever.Retrieve(phrase);

            return View(new WordResponse { LargestWord = largestWord });
        }
    }
}
