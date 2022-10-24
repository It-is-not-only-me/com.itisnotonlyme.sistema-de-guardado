using System;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe.SistemaDeGuardado
{
    public class ObjetoGuardable : MonoBehaviour, IGuardable
    {
        [SerializeField] private EventoSincronizarObjeto _sincronizarObjeto;

        private string _id = null;

        private void Start() => _sincronizarObjeto?.SincronzarGuardable(this);

        public string Id()
        {
            if (_id == null)
                _id = Guid.NewGuid().ToString();
            return _id;
        }

        public void Cargar(object estado)
        {
            Dictionary<string, object> nuevoEstado = (Dictionary<string, object>)estado;

            foreach (IGuardable guardable in GetComponents<IGuardable>())
            {
                if (guardable == (IGuardable)this)
                    continue;

                string tipoDeDato = guardable.Id();
                if (nuevoEstado.TryGetValue(tipoDeDato, out object estadoGuardable))
                    guardable.Cargar(estadoGuardable);
            }
        }

        public object Guardar()
        {
            Dictionary<string, object> estado = new Dictionary<string, object>();

            foreach (IGuardable guardable in GetComponents<IGuardable>())
            {
                if (guardable == (IGuardable)this)
                    continue;

                string clave = guardable.Id();
                estado[clave] = guardable.Guardar();
            }

            return estado;
        }
    }
}