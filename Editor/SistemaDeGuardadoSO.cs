using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using UnityEngine;

namespace ItIsNotOnlyMe.SistemaDeGuardado
{
    [CreateAssetMenu(fileName = "Sistema de guardado", menuName = "Sistema de Guardado/Sistema de guardado")]
    public class SistemaDeGuardadoSO : ScriptableObject
    {
        [SerializeField] private string _nombreCarpeta = "saves";
        [SerializeField] private string _extension = ".save";

        [Space]

        public List<SerializacionSustitutoSO> Sustitutos = new List<SerializacionSustitutoSO>();

        public bool Guardar(string nombre, object objeto)
        {
            BinaryFormatter formatter = GetBinaryFormatter();

            string pathDirectorio = $"{Application.persistentDataPath}/{_nombreCarpeta}";

            if (!Directory.Exists(pathDirectorio))
                Directory.CreateDirectory(pathDirectorio);

            string path = $"{pathDirectorio}/{nombre}.{_extension}";

            FileStream archivo = File.Create(path);
            formatter.Serialize(archivo, objeto);
            archivo.Close();

            return true;
        }

        public object Cargar(string nombre)
        {
            string path = $"{Application.persistentDataPath}/{_nombreCarpeta}/{nombre}.{_extension}";

            if (!File.Exists(path))
                return null;

            BinaryFormatter formatter = GetBinaryFormatter();
            FileStream archivo = File.Open(path, FileMode.Open);

            object objeto = null;

            try
            {
                objeto = formatter.Deserialize(archivo);
            }
            catch (SerializationException)
            {
                Debug.LogErrorFormat("Falla al abrir archivo en {0}", path);
            }
            catch (SecurityException)
            {
                Debug.LogErrorFormat("Falla al abrir archivo en {0} por cuestiones de seguridad", path);
            }

            archivo.Close();
            return objeto;
        }


        private BinaryFormatter GetBinaryFormatter()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            SurrogateSelector selector = GetSurrogateSelector();           

            if (selector != null)
                formatter.SurrogateSelector = selector;

            return formatter;
        }

        private SurrogateSelector GetSurrogateSelector()
        {
            if (Sustitutos.Count <= 0) 
                return null;

            SurrogateSelector selector = new SurrogateSelector();

            StreamingContext streamingContext = new StreamingContext(StreamingContextStates.All);
            foreach (SerializacionSustitutoSO sustituto in Sustitutos)
            {
                selector.AddSurrogate(sustituto.Tipo, streamingContext, sustituto);
            }

            return selector;
        }
    }
}


