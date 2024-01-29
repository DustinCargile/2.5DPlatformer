using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int _value = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            Player player = other.GetComponent<Player>();
            if (player != null) 
            {
                player.AddCoins(_value);
            }
            Destroy(this.gameObject);
        }
        
    }
}
