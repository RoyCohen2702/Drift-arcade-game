using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject _spawntemplate = null;

    private void OnEnable()
    {
        SpawnManager.Instance.RegisterSpawnPoint(this);
    }

    private void OnDisable()
    {
        if (SpawnManager.Exists)
        {
            SpawnManager.Instance.UnregisterSpawnPoint(this);
        }
    }

    public GameObject Spawn()
    {
        return Instantiate(_spawntemplate, transform.position, transform.rotation);
    }
}
