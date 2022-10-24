using System;
using UnityEngine;

namespace ItIsNotOnlyMe.SistemaDeGuardado
{
    [CreateAssetMenu(fileName = "Evento guardar", menuName = "Sistema de Guardado/Evento/Guardar")]
    public class EventoGuardarSO : ScriptableObject
    {
        public Action EventoGuardar;

        public void Guardando() => EventoGuardar?.Invoke(); 
    }
}