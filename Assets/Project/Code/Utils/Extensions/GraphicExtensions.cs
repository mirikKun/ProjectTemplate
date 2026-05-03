using UnityEngine.UI;

namespace Project.Scripts.Utils.Extensions
{
    public static class GraphicExtensions
    {
        public static void SetAlpha(this Graphic graphic, float alpha)
        {
            var color = graphic.color;
            color.a = alpha;
            graphic.color = color;
        }
    }
}