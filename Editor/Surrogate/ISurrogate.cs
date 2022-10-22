using System;
using System.Runtime.Serialization;

namespace ItIsNotOnlyMe.SistemaDeGuardado
{
    public interface ISurrogate : ISerializationSurrogate
    {
        public Type Tipo { get; }
    }
}


