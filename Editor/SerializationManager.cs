using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using UnityEngine;

namespace ItIsNotOnlyMe.SistemaDeGuardado
{
    [CreateAssetMenu(fileName = "Serializacion de objetos", menuName = "Sistema de Guardado/Serializacion de objetos")]
    public class SerializacionDeDatosSO : ScriptableObject
    {
        public string NombreCarpeta = "saves";
        public string Extension = ".objeto";

        [Space]

        public List<SurrogateSO> Surrogates = new List<SurrogateSO>();

        public bool Guardar(string nombre, object objeto)
        {
            BinaryFormatter formatter = GetBinaryFormatter();

            string pathDirectorio = Application.persistentDataPath + "/" + NombreCarpeta;

            if (!Directory.Exists(pathDirectorio))
                Directory.CreateDirectory(pathDirectorio);

            string path = pathDirectorio + "/" + nombre + "." + Extension;

            FileStream archivo = File.Create(path);
            formatter.Serialize(archivo, objeto);
            archivo.Close();

            return true;
        }

        public object Cargar(string path)
        {
            if (!File.Exists(path))
                return null;

            BinaryFormatter formatter = GetBinaryFormatter();
            FileStream archivo = File.Open(path, FileMode.Open);

            object objeto;

            try
            {
                objeto = formatter.Deserialize(archivo);
            }
            catch (SerializationException)
            {
                Debug.LogErrorFormat("Falla al abrir archivo en {0}", path);
                objeto = null;
            }
            catch (SecurityException)
            {
                Debug.LogErrorFormat("Falla al abrir archivo en {0} por cuestiones de seguridad", path);
                objeto = null;
            }

            archivo.Close();
            return objeto;
        }


        private BinaryFormatter GetBinaryFormatter()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            SurrogateSelector selector = new SurrogateSelector();

            StreamingContext streamingContext = new StreamingContext(StreamingContextStates.All);
            foreach (SurrogateSO surrogate in Surrogates)
            {
                selector.AddSurrogate(surrogate.Tipo, streamingContext, surrogate);
            }

            formatter.SurrogateSelector = selector;

            return formatter;
        }
    }
}


