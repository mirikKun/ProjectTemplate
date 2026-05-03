using UnityEngine;
using UnityEngine.Pool;

namespace Project.Scripts.Utils.Templates
{
    public class Templates
    {
        private ObjectPool<T> CreatePool<T>(Transform parent, T prefab) where T : Component
        {
            ObjectPool<T> pool = new ObjectPool<T>(
                createFunc: () =>
                {
                    var instance = Object.Instantiate(prefab, parent);
                    instance.gameObject.SetActive(false);
                    return instance;
                },
                actionOnGet: instance => instance.gameObject.SetActive(true),
                actionOnRelease: instance => instance.gameObject.SetActive(false),
                actionOnDestroy: instance => Object.Destroy(instance.gameObject),
                collectionCheck: false
            );
            return pool;
        }
    }
}