using System;
using UnityEngine;

namespace ItIsNotOnlyMe.SistemaDeGuardado
{
    [CreateAssetMenu(fileName = "Evento cargar", menuName = "Sistema de Guardado/Evento/Cargar")]
    public class EventoCargar : ScriptableObject
    {
        public Action Cargar;

        public void Cargando() => Cargar?.Invoke();
    }
}