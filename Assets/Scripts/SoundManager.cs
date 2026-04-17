using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Transform placeSfxPrefab;
    [SerializeField] private Transform winSfxPrefab;
    [SerializeField] private Transform loseSfxPrefab;
    private void Start()
    {
        GameManager.Instance.OnPlacedObject += GameManager_OnPlacedObject;
        GameManager.Instance.OnGameWin += GameManager_OnGameWin;
    }

    private void GameManager_OnGameWin(object sender, GameManager.OnGameWinEventArgs e)
    {
        if(GameManager.Instance.GetLocalPlayerType() == e.winPlayerType)
        {
            Transform sfxTransform = Instantiate(winSfxPrefab);
            Destroy(sfxTransform.gameObject, sfxTransform.GetComponent<AudioSource>().clip.length);
        }
        else
        {
            Transform sfxTransform = Instantiate(loseSfxPrefab);
            Destroy(sfxTransform.gameObject, sfxTransform.GetComponent<AudioSource>().clip.length);
        }
    }

    private void GameManager_OnPlacedObject(object sender, EventArgs e)
    {
        Transform sfxTransform = Instantiate(placeSfxPrefab);
        Destroy(sfxTransform.gameObject, sfxTransform.GetComponent<AudioSource>().clip.length);
    }
}
