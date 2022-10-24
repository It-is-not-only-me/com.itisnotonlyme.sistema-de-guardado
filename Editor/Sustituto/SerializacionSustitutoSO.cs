using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace ItIsNotOnlyMe.SistemaDeGuardado
{
    public abstract class SerializacionSustitutoSO : ScriptableObject, ISerializacionSustituto
    {
        public abstract Type Tipo { get; }

        public abstract void GetObjectData(object objeto, SerializationInfo info, StreamingContext contexto);
        public abstract object SetObjectData(object objeto, SerializationInfo info, StreamingContext contexto, ISurrogateSelector selector);
    }
}


