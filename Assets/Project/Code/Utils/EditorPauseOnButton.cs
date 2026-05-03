

using UnityEditor;
using UnityEngine;

namespace Project.Scripts.Utils
{
    public class EditorPauseOnButton : MonoBehaviour
    {
#if UNITY_EDITOR

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
                EditorApplication.isPaused = !EditorApplication.isPaused;
        }
#endif
    }
}