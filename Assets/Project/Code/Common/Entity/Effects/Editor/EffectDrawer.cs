using Code.Common.Entity.Effects;
using Project.Code.Utils.ActionList.Editor;
using UnityEditor;

namespace Project.Code.Common.Entity.Effects.Editor
{
    [CustomPropertyDrawer(typeof(Effect))]
    public class EffectDrawer: ActionListAttributeDrawer<Effect>
    {
        
    }
}