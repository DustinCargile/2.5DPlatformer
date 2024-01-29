using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _collected;
    private int _collectibleCount = 0;
    public static Action<int> OnCollectibleCollected;
    public static Action<int> OnCollectibleUpdate;


    private void OnEnable()
    {
        OnCollectibleCollected += AddCollectibleCount;
        OnCollectibleUpdate += UpdateCoinCount;
    }
    void Start()
    {
        _collected.text = _collectibleCount.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void AddCollectibleCount(int count) 
    {
        _collectibleCount += count;
        _collected.text = _collectibleCount.ToString();

    }
    private void UpdateCoinCount(int count) 
    {
        _collectibleCount = count;
        _collected.text = _collectibleCount.ToString();
    }

    private void OnDisable()
    {
        OnCollectibleCollected -= AddCollectibleCount;
        OnCollectibleUpdate -= UpdateCoinCount;
    }

   

}
