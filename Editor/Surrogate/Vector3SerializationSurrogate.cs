using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace ItIsNotOnlyMe.SistemaDeGuardado
{
    [CreateAssetMenu(fileName = "Vector3 Surrogates", menuName = "Sistema de Guardado/Surrogates/Vector3")]
    public class Vector3SerializationSurrogate : SurrogateSO
    {
        public override Type Tipo => typeof(Vector3);

        public override void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            Vector3 v3 = (Vector3)obj;
            info.AddValue("x", v3.x);
            info.AddValue("y", v3.y);
            info.AddValue("z", v3.z);
        }

        public override object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            Vector3 v3 = (Vector3)obj;

            v3.x = (float)info.GetValue("x", typeof(float));
            v3.y = (float)info.GetValue("y", typeof(float));
            v3.z = (float)info.GetValue("z", typeof(float));

            obj = v3;
            return obj;
        }
    }
}


