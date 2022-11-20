using System;
using UnityEngine;

namespace ItIsNotOnlyMe.SistemaDeGuardado
{
    [CreateAssetMenu(fileName = "Evento sincronizar", menuName = "Sistema de Guardado/Evento/Sincronizar objetos")]
    public class EventoSincronizarObjetoSO : ScriptableObject
    {
        public Action<IGuardable> EventoSincronizar;

        public void SincronzarGuardable(IGuardable guardable) => EventoSincronizar?.Invoke(guardable);
    }
}