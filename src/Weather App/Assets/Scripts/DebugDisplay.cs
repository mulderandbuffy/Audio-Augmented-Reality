using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DebugDisplay : MonoBehaviour
{
    
    private static string _document;
    public bool isEnabled;

    private static TextMeshPro textMesh;
    

    private void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
    }
    

    public static void CreateLog(string message)
    {
        _document += "\n" + message;
        print(_document);

        _document = TrimDocument();
    }

    private static string TrimDocument()
    {
        if (_document.Length >= 200)
        {
            return _document.Remove(0, 100);
        }

        return _document;
    }
    
    public static void SetText(string text)
    {
        textMesh.text = text;
    }
    
}
