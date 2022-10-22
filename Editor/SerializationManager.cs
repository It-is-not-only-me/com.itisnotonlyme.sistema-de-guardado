using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class SerializationManager
{
    public static bool Save(string saveName, object saveData)
    {
        BinaryFormatter formatter = GetBinaryFormatter();
        string pathDirectory = Application.persistentDataPath + "/saves";

        if (!Directory.Exists(pathDirectory))
            Directory.CreateDirectory(pathDirectory);

        string path = pathDirectory + "/" + saveName + ".save";

        FileStream file = File.Create(path);
        formatter.Serialize(file, saveData);
        file.Close();

        return true;
    }

    public static object Load(string path)
    {
        if (!File.Exists(path)) 
            return null;

        BinaryFormatter formatter = GetBinaryFormatter();
        FileStream file = File.Open(path, FileMode.Open);

        object save;

        try 
        {
            save = formatter.Deserialize(file);
        }
        catch (SerializationException)
        {
            Debug.LogErrorFormat("Failed to load file at {0}", path);
            save = null;
        }
        catch (SecurityException)
        {
            Debug.LogErrorFormat("Failed to load file at {0} for security exception", path);
            save = null;
        }

        file.Close();
        return save;
    }

    private static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        SurrogateSelector selector = new SurrogateSelector();

        Vector3SerializationSurrogate vector3Surrogate = new Vector3SerializationSurrogate();

        selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), vector3Surrogate);

        formatter.SurrogateSelector = selector;

        return formatter;
    }
}
