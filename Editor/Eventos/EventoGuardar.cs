using System;
using UnityEngine;

namespace ItIsNotOnlyMe.SistemaDeGuardado
{
    [CreateAssetMenu(fileName = "Evento guardar", menuName = "Sistema de Guardado/Evento/Guardar")]
    public class EventoGuardar : ScriptableObject
    {
        public Action Guardar;

        public void Guardando() => Guardar?.Invoke(); 
    }
}