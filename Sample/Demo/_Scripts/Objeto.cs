using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

public class Objeto : MonoBehaviour
{
    [SerializeField] private TipoObjeto _tipoObjeto;

    [Space]

    [SerializeField] private EventoObjectoSO _sincronizarObjeto;

    private static int id = 0;

    private EstadoObjeto _estadoGeneral;
    private EstadoObjeto _estado
    {
        get
        {
            if (_estadoGeneral == null)
                _estadoGeneral = new EstadoObjeto(id.ToString(), _tipoObjeto, transform.position, transform.rotation);
            return _estadoGeneral;
        }
    }
    

    private void Awake()
    {
        _sincronizarObjeto?.Invoke(this);
    }

    private void Update()
    {
        _estado.Posicion = transform.position;
        _estado.Rotacion = transform.rotation;
    }

    public void Cargar(EstadoObjeto estado)
    {
        _estado.Id = estado.Id;
        _estado.Tipo = estado.Tipo;
        _estado.Posicion = estado.Posicion;
        _estado.Rotacion = estado.Rotacion;

        transform.position = estado.Posicion;
        transform.rotation = estado.Rotacion;
        Debug.Log("Modifique mi estado");
    }

    public EstadoObjeto Guardar()
    {
        return _estado;
    }

    public string Id()
    {
        return _estado.Id;
    }
}
