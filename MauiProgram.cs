using Microsoft.Extensions.Logging;

namespace noteApp
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
                    fonts.AddFont("times new roman bold.ttf", "TNRB");
                    fonts.AddFont("times new roman bold italic.ttf", "TNRBI");
                    fonts.AddFont("times new roman italic.ttf", "TNRI");
                    fonts.AddFont("times new roman.ttf", "TNR");
                    fonts.AddFont("BrittanySignature.ttf", "Brittany");
                });
                

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
