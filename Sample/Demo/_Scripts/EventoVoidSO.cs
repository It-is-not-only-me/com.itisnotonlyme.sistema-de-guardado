using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Evento Void", menuName = "Evento/Evento void")]
public class EventoVoidSO : ScriptableObject
{
    public Action Evento;

    public void Invoke() => Evento?.Invoke();
}
