using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItIsNotOnlyMe.SistemaDeGuardado;
using System;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "Quaterion Sustituto", menuName = "Sistema de Guardado/Sustitutos/Quaternion")]
public class QuaternionSerializacionSustituto : SerializacionSustitutoSO
{
    public override Type Tipo => typeof(Quaternion);

    public override void GetObjectData(object objecto, SerializationInfo info, StreamingContext contexto)
    {
        Quaternion quaterion = (Quaternion)objecto;
        info.AddValue("x", quaterion.x);
        info.AddValue("y", quaterion.y);
        info.AddValue("z", quaterion.z);
        info.AddValue("w", quaterion.w);
    }

    public override object SetObjectData(object objeto, SerializationInfo info, StreamingContext contexto, ISurrogateSelector selector)
    {
        Quaternion quaternion = (Quaternion)objeto;

        quaternion.x = (float)info.GetValue("x", typeof(float));
        quaternion.y = (float)info.GetValue("y", typeof(float));
        quaternion.z = (float)info.GetValue("z", typeof(float));
        quaternion.w = (float)info.GetValue("w", typeof(float));

        objeto = quaternion;
        return objeto;
    }
}
