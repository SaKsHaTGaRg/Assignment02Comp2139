using System.Security.Claims;
using Xunit;
using Assignment02Comp2139.Areas.Management;



namespace Assignment02Comp2139.Tests.Controllers;

public class    CategoryControllerTests
{
    [Fact]
    public async Task Index_ReturnsViewResult()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<Assignment01DB>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

        using (var context = new Assignment01DB(options))
        {
            // Seed fake data if needed
            context.Categories.Add(new Assignment02Comp2139.Areas.Management.Models.Category
            {
                CategoryId = 1,
                CategoryName = "Test Category",
                CategoryDescription = "Test Description"
            });
            await context.SaveChangesAsync();

            var controller = new CategoryController(context);

            // Mock User and HttpContext
            var user = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "TestUser")
            }, "mock"));

            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult.Model); // Optional: make sure data is passed
        }
    }
}