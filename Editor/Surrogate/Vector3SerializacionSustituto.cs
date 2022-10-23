using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace ItIsNotOnlyMe.SistemaDeGuardado
{
    [CreateAssetMenu(fileName = "Vector3 Sustituto", menuName = "Sistema de Guardado/Sustitutos/Vector3")]
    public class Vector3SerializacionSustituto : SerializacionSustitutoSO
    {
        public override Type Tipo => typeof(Vector3);

        public override void GetObjectData(object objeto, SerializationInfo info, StreamingContext contexto)
        {
            Vector3 vector3 = (Vector3)objeto;
            info.AddValue("x", vector3.x);
            info.AddValue("y", vector3.y);
            info.AddValue("z", vector3.z);
        }

        public override object SetObjectData(object objeto, SerializationInfo info, StreamingContext contexto, ISurrogateSelector selector)
        {
            Vector3 vector3 = (Vector3)objeto;

            vector3.x = (float)info.GetValue("x", typeof(float));
            vector3.y = (float)info.GetValue("y", typeof(float));
            vector3.z = (float)info.GetValue("z", typeof(float));

            objeto = vector3;
            return objeto;
        }
    }
}


