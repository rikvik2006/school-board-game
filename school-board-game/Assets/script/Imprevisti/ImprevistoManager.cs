using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprevistoManager : MonoBehaviour
// Questa classe serve per salvare gli imporevisti e per fornire un metodo per ottenere un imporevisto casuale.
// Questa classe NON serve per controllare se un utente ha già un imporevisto assegnato.
{
    public List<Imprevisto> imprevisti = new List<Imprevisto>();

    void Start()
    {

    }

    public Imprevisto GetImprevisto(int index)
    {
        return imprevisti[index];
    }

    public Imprevisto GetRandomImporevisto()
    {
        return imprevisti[Random.Range(0, imprevisti.Count)];
    }
}
