using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe.SistemaDeGuardado
{
    public interface IGuardable
    {
        public string Id();
        public void Cargar(object estado);
        public object Guardar();
    }
}
