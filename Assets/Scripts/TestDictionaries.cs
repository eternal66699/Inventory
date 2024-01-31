using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDictionaries : MonoBehaviour
{
    Dictionary<string, int> BountyPirates = new Dictionary<string, int>()
    {
        {"Luffy", 300000000},
        {"Chopper", 1000}
    };
    Dictionary<string, string> CelestialDragon = new Dictionary<string, string>()
    {
        {"Saturn", "EggHead"}
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UpdateBounty("Luffy", 600000000);
            Debug.Log("PiratesCount: " + BountyPirates.Count);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            AddPirate("Kuma", 296000000);
            AddPirate("Mihawk", 359000000);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CelestialDragon.ContainsKey("Saturn") && CelestialDragon.ContainsValue("EggHead"))
            {
                DeletePirate("Kuma");
            }
        }
    }

    void UpdateBounty(string pirateName, int newBounty)
    {
        BountyPirates[pirateName] = newBounty;
    }

    void AddPirate(string pirateName, int bounty)
    {
        BountyPirates.Add(pirateName, bounty);
    }
    
    void DeletePirate(string pirateName)
    {
        BountyPirates.Remove(pirateName);
    }
}
