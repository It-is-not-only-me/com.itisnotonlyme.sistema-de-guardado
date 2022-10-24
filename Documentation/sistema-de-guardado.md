# Documentacion

Usando los scritableObject de Manejar guardado y Sistema de guardado, permiten guardar cualquier tipo de dato. En el caso que un tipo de dato no sea seriabilizable por c# como en general pasa con los elementos de unity, se puede hacer sustitutos con la interfaz ISerializacionSustituto.

La recomendación es a cada gameObject que se queria mantener guardando, se puede agregar el monoBehaviour ObjetoGuardable, y crear los datos para guardar extendiendo la interfaz IGuardable. De esta forma se automatiza el guardado con el menor esfuerzo.