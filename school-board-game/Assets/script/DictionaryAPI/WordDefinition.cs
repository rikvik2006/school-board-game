using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Definition
{
    public string definition;
    public List<string> synonyms;
    public List<string> antonyms;
    public string example;
}

[System.Serializable]
public class Phonetic
{
    public string text;
    public string audio;
    public string sourceUrl;
    public License license;
}

[System.Serializable]
public class License
{
    public string name;
    public string url;
}

[System.Serializable]
public class Meaning
{
    public string partOfSpeech;
    public List<Definition> definitions;
    public List<string> synonyms;
    public List<string> antonyms;
}

[System.Serializable]
public class DictionaryEntry
{
    public string word;
    public string phonetic;
    public List<Phonetic> phonetics;
    public List<Meaning> meanings;
}


