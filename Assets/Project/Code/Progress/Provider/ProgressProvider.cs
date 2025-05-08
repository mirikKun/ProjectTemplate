using Project.Code.Progress.Data;

namespace Project.Code.Progress.Provider
{
    public class ProgressProvider : IProgressProvider
    {
        public ProgressData ProgressData { get; private set; }

        public void SetProgressData(ProgressData data)
        {
            ProgressData = data;
        }
    }
}