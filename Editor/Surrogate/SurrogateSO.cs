using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace ItIsNotOnlyMe.SistemaDeGuardado
{
    public abstract class SurrogateSO : ScriptableObject, ISurrogate
    {
        public abstract Type Tipo { get; }

        public abstract void GetObjectData(object obj, SerializationInfo info, StreamingContext context);
        public abstract object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector);
    }
}


