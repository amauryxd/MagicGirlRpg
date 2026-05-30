using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rockola : MonoBehaviour
{
    public AudioSource audioRef;
    public List<AudioClip> songsList;
    public List<TextMeshProUGUI> textos;
    private int localIndex;

    private void Awake()
    {
        localIndex = 0;
        changeSongFor(0);
    }
    public void changeSongFor(int index)
    {
        audioRef.Stop();
        switch (index)
        {
            case 0:
                localIndex = 0;
                textos[0].color = Color.yellow;
                audioRef.clip = songsList[0];
                audioRef.Play();
                ChangeEverythingExcept();
                break;
            case 1:
                localIndex = 1;
                textos[1].color = Color.yellow;
                audioRef.clip = songsList[1];
                audioRef.Play();
                ChangeEverythingExcept();
                break;
            case 2:
                localIndex = 2;
                textos[2].color = Color.yellow;
                audioRef.clip = songsList[2];
                audioRef.Play();
                ChangeEverythingExcept();
                break;
            case 3:
                localIndex = 3;
                textos[3].color = Color.yellow;
                audioRef.clip = songsList[3];
                audioRef.Play();
                ChangeEverythingExcept();
                break;
            case 4:
                localIndex = 4;
                textos[4].color = Color.yellow;
                audioRef.clip = songsList[4];
                audioRef.Play();
                ChangeEverythingExcept();
                break;
            case 5:
                localIndex = 5;
                textos[5].color = Color.yellow;
                audioRef.clip = songsList[5];
                audioRef.Play();
                ChangeEverythingExcept();
                break;
            case 6:
                localIndex = 6;
                textos[6].color = Color.yellow;
                audioRef.clip = songsList[6];
                audioRef.Play();
                ChangeEverythingExcept();
                break;
            case 7:
                localIndex = 7;
                textos[7].color = Color.yellow;
                audioRef.clip = songsList[7];
                audioRef.Play();
                ChangeEverythingExcept();
                break;
            case 8:
                localIndex = 8;
                textos[8].color = Color.yellow;
                audioRef.clip = songsList[8];
                audioRef.Play();
                ChangeEverythingExcept();
                break;
            default:
                break;
        }
    }

    void ChangeEverythingExcept()
    {
        for(int i = 0; i < songsList.Count; i++)
        {
            if(i == localIndex)
                continue;

            textos[i].color = Color.white;
        }
    }
    public void ButSiguiente()
    {
        int newIndex = localIndex + 1;
        if(newIndex > 7)
        {
            newIndex = 0;
        }

        changeSongFor(newIndex);
    }
    public void ButAnterior()
    {
        int newIndex = localIndex - 1;
        if (newIndex < 0)
        {
            newIndex = 7;
        }

        changeSongFor(newIndex);
    }
}
