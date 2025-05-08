using System;

namespace Project.Code.Infrastructure.Loading
{
    public interface ISceneLoader
    {
        void LoadScene(string name, Action onLoaded = null);
    }
}