﻿using FlashcardRepositoryImplementation.Model;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace FlashcardRepositoryImplementation
{
    public class FlashcardRepository : IBaseRepository<Flashcard>
    {
        private readonly FlashcardContext context;
        private bool disposed = false;

        public FlashcardRepository(FlashcardContext context)
        {
            this.context = context;
        }

        public IEnumerable<Flashcard> Select() 
            => context.Flashcards.ToList();

        public Flashcard? Select(Guid id) 
            => context.Flashcards.Find(id);

        public void Insert(Flashcard entity) 
            => context.Flashcards.Add(entity);

        public void Update(Guid id, Flashcard entity)
        {
            Flashcard? flashcard = context.Flashcards.Find(id);
            if (flashcard != null)
            {
                flashcard.Body = entity.Body;
                flashcard.HiddenBody = entity.HiddenBody;
            }
        }

        public void Delete(Guid id)
        {
            Flashcard? flashcard = context.Flashcards.Find(id);
            if (flashcard != null)
            {
                context.Flashcards.Remove(flashcard);
            }
        }

        public void Save()
            => context.SaveChanges();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
