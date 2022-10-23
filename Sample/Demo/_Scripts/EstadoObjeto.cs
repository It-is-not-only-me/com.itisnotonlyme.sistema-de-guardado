using ItIsNotOnlyMe.SistemaDeGuardado;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoObjeto : MonoBehaviour, IGuardable
{
    [System.Serializable]
    private enum TipoObjeto
    {
        Cubo,
        Capsula
    }

    [System.Serializable]
    private class Estado
    {
        public TipoObjeto Tipo;
        public Vector3 Posicion;
        public Quaternion Rotacion;
    }

    [SerializeField] private Estado _estado;

    private string _id = null;

    public string Id()
    {
        if (_id == null)
            _id = Guid.NewGuid().ToString();
        return _id;
    }

    public void Cargar(object estado)
    {
        Estado nuevoEstado = (Estado)estado;
        _estado.Tipo = nuevoEstado.Tipo;
        _estado.Posicion = nuevoEstado.Posicion;
        _estado.Rotacion = nuevoEstado.Rotacion;

        transform.position = _estado.Posicion;
        transform.rotation = _estado.Rotacion;
    }

    public object Guardar()
    {
        _estado.Posicion = transform.position;
        _estado.Rotacion = transform.rotation;
        return _estado;
    }
}