using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotonEventoGenerar : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private EventoVoidSO _eventoGenerar;

    public void OnPointerClick(PointerEventData eventData)
    {
        _eventoGenerar?.Invoke();
    }
}
