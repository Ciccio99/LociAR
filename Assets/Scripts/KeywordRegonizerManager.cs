using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class KeywordRegonizerManager : MonoBehaviour {

    public List<KeywordAction> keywordActions = new List<KeywordAction>();

    private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    private KeywordRecognizer _keywordRecognizer;


    // Use this for initialization
    void Start() {
        foreach (var keywordVal in keywordActions) {
            keywords.Add(keywordVal.phrase, keywordVal.action);
        }
        _keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        _keywordRecognizer.OnPhraseRecognized += _OnPhraseRecognition;
        _keywordRecognizer.Start();
    }

    private void _OnPhraseRecognition(PhraseRecognizedEventArgs args) {
        System.Action keywordAction;

        if (keywords.TryGetValue(args.text, out keywordAction))
            keywordAction.Invoke();
    }

}

