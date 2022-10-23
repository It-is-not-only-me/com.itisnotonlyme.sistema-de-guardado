using ItIsNotOnlyMe.SistemaDeGuardado;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Manejar guardado", menuName = "Sistema de Guardado/Manejar guardado")]
public class ManejarGuardadoSO : ScriptableObject
{
    [SerializeField] private SistemaDeGuardadoSO _sistemaDeGuardado;

    [Space]

    [SerializeField] private EventoVoidSO _eventoGuardar, _eventoCargar;
    [SerializeField] private EventoObjectoSO _eventoSeguirObjecto;

    private List<Objeto> _objectosEnSeguimiento;

    private void OnEnable()
    {
        _objectosEnSeguimiento = new List<Objeto>();

        if (_eventoCargar != null)
            _eventoCargar.Evento += Cargar;

        if (_eventoGuardar != null)
            _eventoGuardar.Evento += Guardar;

        if (_eventoSeguirObjecto != null)
            _eventoSeguirObjecto.Evento += SeguirObjecto;
    }

    private void OnDisable()
    {
        if (_eventoCargar != null)
            _eventoCargar.Evento -= Cargar;

        if (_eventoGuardar != null)
            _eventoGuardar.Evento -= Guardar;

        if (_eventoSeguirObjecto != null)
            _eventoSeguirObjecto.Evento -= SeguirObjecto;
    }

    private void Cargar()
    {
        Debug.Log("Cargando...");
        foreach (Objeto objeto in _objectosEnSeguimiento)
        {
            EstadoObjeto estadoNuevo = (EstadoObjeto)_sistemaDeGuardado.Cargar(objeto.Id());
            if (estadoNuevo == null)
            {
                Debug.LogError("Algo salio mal");
                continue;
            }
            
            objeto.Cargar(estadoNuevo);
        }
    }

    private void Guardar()
    {
        Debug.Log("Guardando...");
        foreach (Objeto objeto in _objectosEnSeguimiento)
        {
            EstadoObjeto estado = objeto.Guardar();
            _sistemaDeGuardado?.Guardar(objeto.Id(), estado);
        }
    }

    private void SeguirObjecto(Objeto objeto)
    {
        if (_objectosEnSeguimiento.Contains(objeto))
            return;
        _objectosEnSeguimiento.Add(objeto);
    }
}
