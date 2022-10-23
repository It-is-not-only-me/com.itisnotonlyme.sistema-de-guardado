using ItIsNotOnlyMe.SistemaDeGuardado;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotonEventoCargar : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private EventoCargarSO _eventoGenerar;

    public void OnPointerClick(PointerEventData eventData)
    {
        _eventoGenerar?.Cargando();
    }
}