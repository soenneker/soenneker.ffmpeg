using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Soenneker.Ffmpeg.Abstract;
using Soenneker.Utils.File.Abstract;

namespace Soenneker.Ffmpeg;

///<inheritdoc cref="IFfmpegInit"/>
public class FfmpegInit : IFfmpegInit
{
    private readonly IFileUtil _fileUtil;

    public FfmpegInit(IFileUtil fileUtil)
    {
        _fileUtil = fileUtil;
    }

    public string GetFfmpegPath()
    {
        return Path.Combine(GetExecutingPath(), "Resources", "Ffmpeg.exe");
    }

    public string GetExecutingPath()
    {
        return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
    }

    public async ValueTask Init()
    {
        if (_fileUtil.Exists(GetFfmpegPath()))
            return;

        var assembly = Assembly.GetExecutingAssembly();

        string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("ffmpeg.exe"));

        await using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
        {
            await _fileUtil.WriteFile(GetFfmpegPath(), stream);
        }
    }
}