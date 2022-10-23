using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Evento/Evento objeto", fileName = "Evento objeto")]
public class EventoObjectoSO : ScriptableObject
{
    public Action<Objeto> Evento;

    public void Invoke(Objeto gameObject) => Evento?.Invoke(gameObject);
}
