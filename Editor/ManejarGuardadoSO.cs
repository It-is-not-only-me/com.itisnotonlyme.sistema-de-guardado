using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

namespace ItIsNotOnlyMe.SistemaDeGuardado
{

    [CreateAssetMenu(fileName = "Manejar guardado", menuName = "Sistema de Guardado/Manejar guardado")]
    public class ManejarGuardadoSO : ScriptableObject
    {
        [SerializeField] private SistemaDeGuardadoSO _sistemaDeGuardado;

        [Space]

        [SerializeField] private EventoSincronizarObjeto _sincronizarObjetos;
        [SerializeField] private EventoGuardar _eventoGuardar;
        [SerializeField] private EventoCargar _eventoCargar;

        private List<IGuardable> _objetosGuardables = new List<IGuardable>();

        private void OnEnable()
        {
            if (_sincronizarObjetos != null)
                _sincronizarObjetos.EventoSincronizar += GuardarObjetos;

            if (_eventoGuardar != null)
                _eventoGuardar.Guardar += Guardar;

            if (_eventoCargar != null)
                _eventoCargar.Cargar += Cargar;
        }

        private void OnDisable()
        {
            if (_sincronizarObjetos != null)
                _sincronizarObjetos.EventoSincronizar -= GuardarObjetos;

            if (_eventoGuardar != null)
                _eventoGuardar.Guardar -= Guardar;

            if (_eventoCargar != null)
                _eventoCargar.Cargar -= Cargar;
        }

        private void GuardarObjetos(IGuardable guardable)
        {
            if (_objetosGuardables.Contains(guardable))
                return;
            _objetosGuardables.Add(guardable);
        }

        private void Guardar()
        {
            foreach (IGuardable guardable in _objetosGuardables)
            {
                string nombre = guardable.Id();
                object estado = guardable.Guardar();

                _sistemaDeGuardado.Guardar(nombre, estado);
            }
        }

        private void Cargar()
        {
            foreach (IGuardable guardable in _objetosGuardables)
            {
                string nombre = guardable.Id();
                object nuevoEstado = _sistemaDeGuardado.Cargar(nombre);

                guardable.Cargar(nuevoEstado);
            }
        }
    }
}