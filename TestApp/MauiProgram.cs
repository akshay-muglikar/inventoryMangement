using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestApp.Constants;
using InventoryDomain.Repository;
using TestApp.HomeScreen;
using TestApp.HomeScreen.AddItem;
using CommunityToolkit.Maui;
using InventoryDomain.Context;
namespace TestApp;

public static class MauiProgram
{
	 public const string DatabaseFilename = "T5.db";
    public static string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddDbContext<ApplicationDbContext>(
			options =>
				options.UseSqlite(
					$"Data Source={DatabasePath}"
				)
		);
		builder.Services.AddScoped<DbContext, ApplicationDbContext>();
		builder.Services.AddTransient<HomePage>();
		builder.Services.AddTransient<AddItem>();
		builder.Services.AddTransient<ItemsViewModel>();
		builder.Services.AddTransient<AddItemViewModel>();
		builder.Services.AddScoped<IItemRepository, ItemRepository>();
		builder.Services.AddScoped<IBillRepository, BillRepository>();


		return builder.Build();
	}
}
