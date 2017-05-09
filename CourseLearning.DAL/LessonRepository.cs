using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CourseLearning.DAL.Interface;
using CourseLearning.Model;
using CourseLearning.Model.ContentStorage;
using CourseLearning.Model.Lessons;
using CourseLearning.Model.Questions;

namespace CourseLearning.DAL
{
    public class LessonRepository : BaseRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(DbContext context) : base(context)
        {
        }

        public async Task<IList<Lesson>> GetModuleLessonsAsync(int moduleId)
        {
            return await Context.Set<Lesson>().Where(l => l.ModuleId == moduleId).ToListAsync();
        }

        public void AddLessonPage(LessonPage lessonPage)
        {
            Context.Set<LessonPage>().Add(lessonPage);
        }

        public override async Task<Lesson> FindAsync(int id)
        {
            return await Context.Set<Lesson>()
                .Include(l => l.LessonPages.Select(p => p.LessonPageTransitions))
                .Include(l => l.LessonPages.Select(p => p.Question))
                .Include(l => l.LessonPages.Select(p => p.Question.ControlList))
                .Include(l => l.LessonPages.Select(p => p.StorageResources))
                .FirstOrDefaultAsync(l => l.LessonId == id);
        }

        public override async Task Update(Lesson lesson)
        {
            var dbLesson = await Context.Set<Lesson>()
                .Include(l => l.LessonPages.Select(p => p.LessonPageTransitions))
                .Include(l => l.LessonPages.Select(p => p.StorageResources))
                .FirstOrDefaultAsync(l => l.LessonId == lesson.LessonId);

            await UpdateLessonPages(dbLesson, lesson);

            Context.Entry(dbLesson).CurrentValues.SetValues(lesson);
        }

        private async Task UpdateLessonPages(Lesson dbLesson, Lesson lesson)
        {
            foreach (var dbLessonPage in dbLesson.LessonPages)
            {
                var page = lesson.LessonPages.SingleOrDefault(l => l.LessonPageId == dbLessonPage.LessonPageId);
                if (page == null)
                {
                    Context.Entry(dbLessonPage).State = EntityState.Deleted;
                    return;
                }

                Context.Entry(dbLessonPage).CurrentValues.SetValues(page);

                await UpdatePageResources(dbLessonPage, page);
                UpdatePageTransitions(dbLessonPage, page);
                UpdatePageQuestion(dbLessonPage, page);
            }
        }

        private async Task UpdatePageResources(LessonPage dbPage, LessonPage page)
        {
            foreach (var dbResource in dbPage.StorageResources.ToList())
            {
                var resource1 = dbResource;
                var resource = page.StorageResources.SingleOrDefault(r => r.StorageResourceId == resource1.StorageResourceId);
                if (resource == null)
                {
                    dbPage.StorageResources.Remove(dbResource);
                }
            }

            foreach (var pageResource in page.StorageResources)
            {
                bool isNewAttached = dbPage.StorageResources.All(r => r.StorageResourceId != pageResource.StorageResourceId);
                if (!isNewAttached)
                {
                    continue;
                };

                var dbResource = await Context.Set<StorageResource>().FindAsync(pageResource.StorageResourceId);
                dbPage.StorageResources.Add(dbResource);
            }
        }

        private void UpdatePageTransitions(LessonPage dbPage, LessonPage page)
        {
            foreach (var dbTransition in dbPage.LessonPageTransitions.ToList())
            {
                var transition = page.LessonPageTransitions.FirstOrDefault(t => t.LessonPageTransitionId == dbTransition.LessonPageTransitionId);
                if (transition == null)
                {
                    Context.Set<LessonPageTransition>().Remove(dbTransition);
                    continue;                  
                }

                Context.Entry(dbTransition).CurrentValues.SetValues(transition);
            }

            foreach (var newTransition in page.LessonPageTransitions.Where(t => t.LessonPageTransitionId == 0))
            {
                dbPage.LessonPageTransitions.Add(newTransition);
            }
        }

        private void UpdatePageQuestion(LessonPage dbPage, LessonPage page)
        {
            if (dbPage.Question == null && page.Question == null)
            {
                return;
            }

            if (page.Question.QuestionId == 0)
            {
                int creatorId = 1;
                page.Question.CreatorId = creatorId;
                //var question = Context.Set<Question>().Add(page.Question);
                dbPage.Question = page.Question;
                //Context.Entry(dbPage).Reference(p => p.Question).CurrentValue = page.Question;
                return;
            }

            if (dbPage.Question != null)
            {
                Context.Entry(dbPage.Question).CurrentValues.SetValues(page.Question);
            }
        }
    }
}