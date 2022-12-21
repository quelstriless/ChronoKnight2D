using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
public class SaveManager : MonoBehaviour
{
    private FakeSave _loadLevel;
    private void Awake()
    {
        _loadLevel = GameObject.FindObjectOfType<FakeSave>();
    }
    public void Save()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/Level.dat", FileMode.OpenOrCreate);

        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, _loadLevel.loadData);
        }
        catch (SerializationException e)
        {
            Debug.LogError("There is a serialize issue" + e.Message);
        }
        finally
        {
            file.Close();
        }
    }
    public void Load()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/Level.dat", FileMode.Open);

        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            _loadLevel.loadData = (CurrentLevel)formatter.Deserialize(file);
        }
        catch (SerializationException e)
        {
            Debug.LogError("Error serializing data" + e.Message);
        }
        finally
        {
            file.Close();
        }


    }
}
