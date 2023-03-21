using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Ffmpeg.Abstract;

namespace Soenneker.Ffmpeg.Registrars;

public static class FfmpegInitRegistrar
{
    /// <summary>
    /// Adds IFfmpegInit as a scoped service. <para/>
    /// Shorthand for <code>services.TryAddScoped</code> <para/>
    /// </summary>
    public static void AddFfmpegInitAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IFfmpegInit, FfmpegInit>();
    }

    /// <summary>
    /// Adds IFfmpegInit as a singleton service. <para/>
    /// Shorthand for <code>services.TryAddSingleton</code> <para/>
    /// </summary>
    public static void AddFfmpegInitAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IFfmpegInit, FfmpegInit>();
    }
}