using Infrastructure.Data.Contexts;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;
public class CourseService(IDbContextFactory<DataContext> contextFactory) : ICourseService
{
    private readonly IDbContextFactory<DataContext> _contextFactory = contextFactory;

    public async Task<Course> CreateCourseAsync(CourseCreateRequest request)
    {
        await using var context = _contextFactory.CreateDbContext();

        var courseEntity = CourseFactory.CreateCourse(request);
        context.Courses.Add(courseEntity);
        await context.SaveChangesAsync();

        return CourseFactory.CreateToModel(courseEntity);

    }

    public async Task<bool> DeleteCourseAsync(string id)
    {
        await using var context = _contextFactory.CreateDbContext();
        var courseEntity = await context.Courses.FirstOrDefaultAsync(c => c.Id == id);
        if (courseEntity == null) return false;

        context.Courses.Remove(courseEntity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<Course> GetCourseByIdAsync(string id)
    {
        await using var context = _contextFactory.CreateDbContext();
        var courseEntity = await context.Courses.FirstOrDefaultAsync(c => c.Id == id);
        if (courseEntity == null)
        { 
            return null!;
        }
        else
        {
            return courseEntity == null ? null! : CourseFactory.CreateToModel(courseEntity);
        }
       
    }

    public async Task<IEnumerable<Course>> GetCoursesAsync()
    {
        await using var context = _contextFactory.CreateDbContext();
        var courseEntities = await context.Courses.ToListAsync();
        return courseEntities.Select(CourseFactory.CreateToModel);

    }

    public async Task<Course> UpdateCourseAsync(CourseUpdateRequest request)
    {
        await using var context = _contextFactory.CreateDbContext();
        var existingCourse = await context.Courses.FirstOrDefaultAsync(c => c.Id == request.Id);
        if (existingCourse == null)
        {
            return null!;
        }
        var updatedCourseEntity = CourseFactory.UpdateCourse(request);
        updatedCourseEntity.Id = existingCourse.Id;
        context.Entry(existingCourse).CurrentValues.SetValues(updatedCourseEntity);

        await context.SaveChangesAsync();
        return CourseFactory.CreateToModel(updatedCourseEntity);
    }
}
public interface ICourseService
{
    Task<Course> CreateCourseAsync(CourseCreateRequest request);

    Task<Course> UpdateCourseAsync(CourseUpdateRequest request);

    Task<bool> DeleteCourseAsync(string id);

    Task<IEnumerable<Course>> GetCoursesAsync();
    Task<Course> GetCourseByIdAsync(string id);
}


