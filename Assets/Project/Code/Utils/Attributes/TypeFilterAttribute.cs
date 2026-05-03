using System;
using Code.Utils.Extensions;
using UnityEngine;

namespace Code.Utils.Attributes
{
    public class TypeFilterAttribute : PropertyAttribute
    {
        public Func<Type, bool> Filter { get; }
        
        public TypeFilterAttribute(Type filterType)
        {
            Filter = type => !type.IsAbstract &&
                             !type.IsInterface &&
                             !type.IsGenericType &&
                             type.InheritsOrImplements(filterType);
        }
    }
}
