using System;
using UnityEngine;

namespace ItIsNotOnlyMe.SistemaDeGuardado
{
    [CreateAssetMenu(fileName = "Evento cargar", menuName = "Sistema de Guardado/Evento/Cargar")]
    public class EventoCargarSO : ScriptableObject
    {
        public Action EventoCargar;

        public void Cargando() => EventoCargar?.Invoke();
    }
}