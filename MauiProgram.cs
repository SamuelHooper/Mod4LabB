using Microsoft.Extensions.Logging;
using Microsoft.Maui.Storage;

namespace Mod3LabB
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Question repo
            string dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, "question.db3");
            builder.Services.AddSingleton<QuestionRepository>(s => ActivatorUtilities.CreateInstance<QuestionRepository>(s, dbPath));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
