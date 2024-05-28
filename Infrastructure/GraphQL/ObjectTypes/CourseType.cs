using GraphQL.Types;
using Infrastructure.Data.Entities;
using Infrastructure.Models;
using Infrastructure.Services;

namespace Infrastructure.GraphQL.ObjectTypes;
public class CourseType : ObjectType<CourseEntity>
{
    protected override void Configure(IObjectTypeDescriptor<CourseEntity> descriptor)
    {
        descriptor.Field(c => c.Id).Type<NonNullType<IdType>>();
        descriptor.Field(c => c.IsBestseller).Type<BooleanType>();
        descriptor.Field(c => c.IsDigital).Type<BooleanType>();
        descriptor.Field(c => c.Categories).Type<ListType<StringType>>();
        descriptor.Field(c => c.Title).Type<StringType>();
        descriptor.Field(c => c.Ingress).Type<StringType>();
        descriptor.Field(c => c.StarRating).Type<DecimalType>();
        descriptor.Field(c => c.Reviews).Type<StringType>();
        descriptor.Field(c => c.Likes).Type<StringType>();
        descriptor.Field(c => c.LikesInProcent).Type<StringType>();
        descriptor.Field(c => c.Hours).Type<StringType>();
        descriptor.Field(c => c.ImageUri).Type<StringType>();
        descriptor.Field(c => c.ImageHeaderUri).Type<StringType>();
        descriptor.Field(c => c.Authors).Type<ListType<AuthorType>>();
        descriptor.Field(c => c.Prices).Type<PricesType>();
        descriptor.Field(c => c.Content).Type<ContentType>();
    }
}

public class AuthorType : ObjectType<AuthorEntity>
{
    protected override void Configure(IObjectTypeDescriptor<AuthorEntity> descriptor)
    {
        descriptor.Field(a => a.Name).Type<StringType>();
        descriptor.Field(a => a.AuthorImage).Type<StringType>();
    }
}

public class PricesType : ObjectType<PricesEntity>
{
    protected override void Configure(IObjectTypeDescriptor<PricesEntity> descriptor)
    {
        descriptor.Field(p => p.Price).Type<DecimalType>();
        descriptor.Field(p => p.Discount).Type<DecimalType>();
        descriptor.Field(p => p.Currency).Type<StringType>();
    }
}

public class ContentType : ObjectType<ContentEntity>
{
    protected override void Configure(IObjectTypeDescriptor<ContentEntity> descriptor)
    {
        descriptor.Field(c => c.Description).Type<StringType>();
        descriptor.Field(c => c.Includes).Type<ListType<StringType>>();
        descriptor.Field(c => c.ProgramDetails).Type<ListType<ProgramDetailType>>();
    }
}

public class ProgramDetailType : ObjectType<ProgramDetailEntity>
{
    protected override void Configure(IObjectTypeDescriptor<ProgramDetailEntity> descriptor)
    {
        descriptor.Field(p => p.Id).Type<IntType>();
        descriptor.Field(p => p.Title).Type<StringType>();
        descriptor.Field(p => p.Description).Type<StringType>();
    }
}
//public class UserCoursesType : ObjectType<UserCoursesEntity>
//{
//    protected override void Configure(IObjectTypeDescriptor<UserCoursesEntity> descriptor)
//    {
//        descriptor.Field(u => u.UserId).Type<StringType>();
//        descriptor.Field(u => u.CourseId).Type<StringType>();
//    }
//}
//public class UserCoursesQueryType : ObjectType<IEnumerable<string>>
//{
//    private readonly ICourseService _courseService;

//    public UserCoursesQueryType(ICourseService courseService)
//    {
//        _courseService = courseService;
//    }

//    protected override void Configure(IObjectTypeDescriptor<IEnumerable<string>> descriptor)
//    {
//        descriptor.Name("UserCoursesQuery");
//        descriptor.Description("A query to get all course IDs for a user.");
//        descriptor.Field("courseIds")
//            .Type<NonNullType<ListType<NonNullType<StringType>>>>()
//            .Argument("userId", a => a.Type<NonNullType<StringType>>())
//            .Resolve(async context =>
//            {
//                var userId = context.ArgumentValue<string>("userId");
//                var courseIds = await _courseService.GetUserCourseIds(userId);
//                return courseIds;
//            });
//    }

public class UserCoursesInputType : ObjectType<UserCoursesEntity>
{
    protected override void Configure(IObjectTypeDescriptor<UserCoursesEntity> descriptor)
    {
        descriptor.Field(u => u.UserId).Type<StringType>();
        descriptor.Field(u => u.CourseId).Type<StringType>();
    }
}

public class UserCoursesResponseType : ObjectGraphType<UserCourses>
{
    public UserCoursesResponseType()
    {
        Field(x => x.UserId);
        Field(x => x.CourseId);
    }
}


