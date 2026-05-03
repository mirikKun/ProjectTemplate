using System;
using UnityEngine;

namespace Code.Common.Factory
{
    public abstract class Flyweight<TType>:MonoBehaviour where TType:Enum
    {
        public abstract TType Type { get; }
    }
}