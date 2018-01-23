using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class SpeechController : MonoBehaviour, ISpeechHandler {

    private NumberFactory _numberFactory;

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        Debug.Log("MEOW");
        switch (eventData.RecognizedText.ToLower())
        {
           case "undo":
                _numberFactory.Undo();
                break;
           case "reset":
                _numberFactory.Reset();
                break;
            default:
                _numberFactory.SpawnNumber(eventData.RecognizedText);
                break;
        }
    }
}
