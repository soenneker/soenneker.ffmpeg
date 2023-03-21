using System.Threading.Tasks;

namespace Soenneker.Ffmpeg.Abstract;

public interface IFfmpegInit
{
    ValueTask Init();
}