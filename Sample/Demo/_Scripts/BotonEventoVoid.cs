using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotonEventoVoid : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private EventoVoidSO _evento;

    public void OnPointerClick(PointerEventData eventData)
    {
        _evento?.Invoke();
    }
}
