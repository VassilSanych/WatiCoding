var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
		app.UseSwagger();
		app.UseSwaggerUI();
}


app.MapGet("/add", (int num1, int num2) =>
{
		var sum = new Sum
				(
						num1,
						num2
				);
		return sum.Result;
})
.WithName("Sum")
.WithOpenApi();

app.Run();

internal record Sum(int Num1, int Num2)
{
		public int Result => Num1 + Num2;
}
