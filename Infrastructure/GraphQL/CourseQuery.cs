using Infrastructure.Models;
using Infrastructure.Services;

namespace Infrastructure.GraphQL;
public class CourseQuery(ICourseService courseService)
{
    private readonly ICourseService _courseService = courseService;

    [GraphQLName("getCourses")]
    public async Task<IEnumerable<Course>> GetCoursesAsync()
    {
        return await _courseService.GetCoursesAsync();
    }


    [GraphQLName("getCourseById")]
    public async Task<Course> GetCourseByIdAsync(string id)
    {
        return await _courseService.GetCourseByIdAsync(id);
    }

    [GraphQLName("getUserCourseIds")]
    public async Task<IEnumerable<string>> GetUserCourseIdsAsync(string userId)
    {
        var courseIds = await _courseService.GetUserCourseIds(userId);
        return courseIds;
    }
}
