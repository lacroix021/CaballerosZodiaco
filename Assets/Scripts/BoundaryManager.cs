using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryManager : MonoBehaviour
{
    private BoxCollider2D managerBox; //este es el boxcollider de el boundaryManager
    public GameObject boundary; //la camara real de cada boundary que sera activada y desactivada
    
    private Transform _player;
    private Transform player
    {
        get
        {
            if (_player != null) return _player;
            var go = GameObject.FindGameObjectWithTag("Player");
            _player = go == null ? null : go.transform;
            return _player;
        }
    }   //la posicion del jugador




    // Start is called before the first frame update
    void Start()
    {
        managerBox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageBoundary();
    }

    void ManageBoundary()
    {
        if (player == null) return;
        if (managerBox.bounds.min.x < player.position.x && player.position.x < managerBox.bounds.max.x && managerBox.bounds.min.y < player.position.y && player.position.y < managerBox.bounds.max.y)
        {
            boundary.SetActive(true);
            //se agrego este partMap para crear el mapa del juego, se podria agregar un array manual en el GameManager para que cuente la totalidad de partMap y si al final tiene todo el mapa marque un 100%

        }
        else
        {
            boundary.SetActive(false);
        }
    }
}
