using System;
using Code.Common.Health;
using Code.Utils.ActionList;
using UnityEngine;

namespace Code.Common.Entity.Effects
{
    [Serializable]
    public abstract class Effect : IActionElement
    {
        public event Action<Effect> OnCompleted;

        public abstract void Execute(BaseEntity caster, BaseEntity target, Transform from);

        public virtual void Cancel() => RaiseCompleted();

        protected void RaiseCompleted() => OnCompleted?.Invoke(this);
    }

    [Serializable]
    public class DamageEffect : Effect
    {
        [SerializeField] private float _amount;

        public override void Execute(BaseEntity caster, BaseEntity target, Transform from)
        {
            if (caster == target)
            {
                RaiseCompleted();
                return;
            }

            if (target && target.TryGet(out IHealth health))
            {
                health.TakeDamage(_amount, caster);
            }

            RaiseCompleted();
        }
    }
}