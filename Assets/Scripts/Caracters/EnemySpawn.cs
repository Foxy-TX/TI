using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
  public GameObject[] interativos;
  public static EnemySpawn instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(InstanciarObjetos), 2f, 1f);
    }

    public void InstanciarObjetos()
    {
        int index = Random.Range(0, interativos.Length);
        GameObject selecionado = interativos[index];
        Vector3 Posi = new Vector3(transform.position.x,transform.position.y,0f);
        Instantiate(selecionado, Posi, Quaternion.identity);

    }
}
