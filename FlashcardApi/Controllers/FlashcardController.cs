using DataAccessLayer.Models;
using DataAccessLayer.Services.FlashcardRepository;
using Microsoft.AspNetCore.Mvc;
using NLog.Fluent;

namespace FlashcardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardController : ControllerBase
    {
        private readonly ILogger<FlashcardController> logger;
        private readonly IFlashcardRepository flashcardRepository;

        public FlashcardController(ILogger<FlashcardController> logger, IFlashcardRepository flashcardRepository)
        {
            this.logger = logger;
            this.flashcardRepository = flashcardRepository;
        }

        [HttpGet]
        public IEnumerable<Flashcard> Get()
        {
            var flashcards = flashcardRepository.Select();

            logger.LogInformation("Get");

            return flashcards;
        }

        [HttpGet("{id}")]
        public Flashcard Get(Guid id)
        {
            logger.LogInformation("Get by id");
            Flashcard? flashcard = flashcardRepository.Select(id);
            return flashcard;
        }

        [HttpPost]
        public IActionResult Post(Flashcard flashcard)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            flashcardRepository.Insert(flashcard);
            flashcardRepository.Save();

            logger.LogInformation("Posted");

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Flashcard editedFlashcard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            flashcardRepository.Update(id, editedFlashcard);
            flashcardRepository.Save();

            logger.LogInformation("Updated");

            return Ok();

        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            flashcardRepository.Delete(id);
            flashcardRepository.Save();
            logger.LogInformation("Deleted");
        }
    }
}
