using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the controller 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/", () => "Api is working fine");

// // GET /api/categories => Read Categories
// app.MapGet("/api/categories", () =>
// {
   

// });


// // Post /api/categories => Create a Category
// app.MapPost("/api/categories", ([FromBody] Category categoryData) =>
// {
//     if (string.IsNullOrEmpty(categoryData.Name))
//     {
//         return Results.BadRequest("Category Name is required and can not be empty");
//     }
//     var newCategory = new Category
//     {
//         CategoryId = Guid.NewGuid(),
//         Name = categoryData.Name,
//         Description = categoryData.Description,
//         CreatedAt = DateTime.UtcNow,

//     };
//     categories.Add(newCategory);
//     return Results.Created($"/api/categories/{newCategory.CategoryId}", newCategory);

// });


// PUT /api/categories => UPDATE A CategorY
// app.MapPut("/api/categories/{categoryId:guid}", (Guid categoryId, [FromBody] Category categoryData) =>
// {
//     var foundCategory = categories.FirstOrDefault(category => category.CategoryId == categoryId);

//     if (foundCategory == null)
//     {
//         return Results.NotFound("Category with this Id does not exit");
//     }
//     if (categoryData == null)
//     {
//         return Results.NotFound("Category data is missing");
//     }

//     if (!string.IsNullOrEmpty(categoryData.Name))
//     {
//         foundCategory.Name = categoryData.Name ?? foundCategory.Name;
//     }
//     if (!string.IsNullOrEmpty(categoryData.Description))
//     {
//         foundCategory.Description = categoryData.Description ?? foundCategory.Description;
//     }
//     return Results.NoContent();


// });

// // DELETE /api/categories => DELETE A CategorY
// app.MapDelete("/api/categories/{categoryId:guid}", (Guid categoryId) =>
// {
//     var foundCategory = categories.FirstOrDefault(category => category.CategoryId == categoryId);

//     if (foundCategory == null)
//     {
//         return Results.NotFound("Category with this Id does not exit");
//     }

//     return Results.NoContent();


// });

app.MapControllers();

app.Run();

