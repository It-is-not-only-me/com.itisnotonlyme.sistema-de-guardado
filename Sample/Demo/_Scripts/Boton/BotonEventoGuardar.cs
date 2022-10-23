using ItIsNotOnlyMe.SistemaDeGuardado;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotonEventoGuardar : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private EventoGuardarSO _eventoGuardar;

    public void OnPointerClick(PointerEventData eventData)
    {
        _eventoGuardar?.Guardando();
    }
}
