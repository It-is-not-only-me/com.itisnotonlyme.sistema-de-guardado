using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum TipoObjeto
{
    Cubo,
    Capsula
}

[System.Serializable]
public class EstadoObjeto
{
    public string Id;
    public TipoObjeto Tipo;
    public Vector3 Posicion;
    public Quaternion Rotacion;

    public EstadoObjeto()
    {

    }

    public EstadoObjeto(string id, TipoObjeto tipo, Vector3 posicion, Quaternion rotacion)
    {
        Id = id;
        Tipo = tipo;
        Posicion = posicion;
        Rotacion = rotacion;
    }
}
