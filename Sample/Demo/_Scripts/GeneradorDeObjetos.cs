using Codice.Client.Common.GameUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeObjetos : MonoBehaviour
{
    [SerializeField] private List<Objeto> _listaDeObjetosAGenerar = new List<Objeto>();

    [Space]

    [SerializeField] private EventoVoidSO _eventoGenear;

    private void OnEnable() 
    {
        if (_eventoGenear != null)
            _eventoGenear.Evento += GenerarObjeto;
    }

    private void OnDisable()
    {
        if (_eventoGenear != null)
            _eventoGenear.Evento -= GenerarObjeto;
    }

    private void GenerarObjeto()
    {
        int indiceObjeto = Random.Range(0, _listaDeObjetosAGenerar.Count);
        Instantiate(_listaDeObjetosAGenerar[indiceObjeto], transform);
    }
}
