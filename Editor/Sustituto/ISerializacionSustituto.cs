using System;
using System.Runtime.Serialization;

namespace ItIsNotOnlyMe.SistemaDeGuardado
{
    public interface ISerializacionSustituto : ISerializationSurrogate
    {
        public Type Tipo { get; }
    }
}


