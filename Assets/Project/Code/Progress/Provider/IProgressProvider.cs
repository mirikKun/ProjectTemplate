using Project.Code.Progress.Data;

namespace Project.Code.Progress.Provider
{
    public interface IProgressProvider
    {
        ProgressData ProgressData { get; }
        void SetProgressData(ProgressData data);
    }
}