using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;


public class JSONReader : MonoBehaviour
{
    private IDictionary<int, EffectEntry> _effects = new Dictionary<int, EffectEntry>();

    public string initialJSONFile = "data";

    public string json1 = "data";
    public string json2 = "data2";
    public string json3 = "data3";

    [FormerlySerializedAs("_currentDataset")] public string currentDataset;
    
    // Start is called before the first frame update
    void Start()
    {
        currentDataset = initialJSONFile;
        ParseJSON(initialJSONFile);
        getNextXEntries(12);
    }

    private void ParseJSON(string filePath)
    {
        _effects.Clear();
        var dataObjects = new List<DataEntry>();

        var file = Resources.Load(filePath) as TextAsset;
        var json = file.ToString();
        dataObjects = JsonConvert.DeserializeObject<List<DataEntry>>(json);
        

        foreach (var d in dataObjects)
        {
            EffectEntry entry = new EffectEntry((weatherEffect)Convert.ToInt32(d.effect), (WindDirection)Convert.ToInt32(d.windAngle));
            _effects[Convert.ToInt32(d.time)] = entry;
        }

        if (_effects.Count == 0)
        {
            Debug.Log("No Data");
        }
    }

    public EffectEntry queryJSON()
    {
        var timeString = DateTime.Now.ToString("HHmm");
        
        var time = Convert.ToInt32(timeString);
    
        var effect = time switch
        {
            >= 0 and < 100 => _effects[0],
            >= 100 and < 200 => _effects[100],
            >= 200 and < 300 => _effects[200],
            >= 300 and < 400 => _effects[300],
            >= 400 and < 500 => _effects[400],
            >= 500 and < 600 => _effects[500],
            >= 600 and < 700 => _effects[600],
            >= 700 and < 800 => _effects[700],
            >= 800 and < 900 => _effects[800],
            >= 900 and < 1000 => _effects[900],
            >= 1000 and < 1100 => _effects[1000],
            >= 1100 and < 1200 => _effects[1100],
            >= 1200 and < 1300 => _effects[1200],
            >= 1300 and < 1400 => _effects[1300],
            >= 1400 and < 1500 => _effects[1400],
            >= 1500 and < 1600 => _effects[1500],
            >= 1600 and < 1700 => _effects[1600],
            >= 1700 and < 1800 => _effects[1700],
            >= 1800 and < 1900 => _effects[1800],
            >= 1900 and < 2000 => _effects[1900],
            >= 2000 and < 2100 => _effects[2000],
            >= 2100 and < 2200 => _effects[2100],
            >= 2200 and < 2300 => _effects[2200],
            >= 2300 => _effects[2300],
            < 0 => new EffectEntry(weatherEffect.NONE, WindDirection.NONE)
        };
        return effect;
    }

    public void switchFile(int fileNumber)
    {
        switch (fileNumber)
        {
            case 1:
                if (currentDataset != json1)
                {
                    ParseJSON(json1);
                    currentDataset = json1;
                }
                break;
            case 2:
                if (currentDataset != json2)
                {
                    ParseJSON(json2);
                    currentDataset = json2;
                }
                break;
            case 3:
                if (currentDataset != json3)
                {
                    ParseJSON(json3);
                    currentDataset = json3;
                }
                break;
            default:
                ParseJSON(initialJSONFile);
                currentDataset = initialJSONFile;
                break;
        }
    }

    public ArrayList getNextXHours(int hoursAhead)
    {
        var output = new ArrayList();
        var now = (DateTime.Now.Hour) * 100;
        output.Add(now);
        
        var next = now;
        for (int  x = 0;  x < hoursAhead;  x++)
        {
            if (next == 2300)
            {
                next = 0;
            }
            else
            {
               next += 100; 
            }
            
            output.Add(next);
        }
        return output;
    }

    public ArrayList getNextXEntries(int hoursAhead)
    {
        var output = new ArrayList();

        var keys = getNextXHours(hoursAhead);

        foreach (int hour in keys)
        {
            output.Add(_effects[hour]);
            print(_effects[hour].effect);
        }

        return output;
    }
    
}

public enum weatherEffect
{
    RAIN, //0
    HEAVYRAIN, //1
    SNOW, //2
    BLIZZARD,  //3
    WIND, //4
    THUNDER, //5
    SUN, //6
    CLOUD, //7
    NONE, //8
    
}

public class EffectEntry
{
    public weatherEffect effect;
    public WindDirection windAngle;

    public EffectEntry(weatherEffect effect, WindDirection angle)
    {
        this.effect = effect;
        this.windAngle = angle;
    }
}

public class DataEntry
{
    public string time;
    public int effect;
    public int windAngle;
}
