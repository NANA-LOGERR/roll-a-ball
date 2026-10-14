using UnityEngine;




  

public class CameraController : MonoBehaviour

{

    // Arraste o Player para este campo no Inspector 

    public GameObject player;



    // Distância entre a câmera e a bola 

    private Vector3 offset;



    void Start()

    {

        // Calcula a distância inicial câmera -> bola 

        offset = transform.position - player.transform.position;

    }



    // LateUpdate roda depois que tudo se moveu no frame 

    void LateUpdate()

    {

        // A câmera vai para a posição da bola + a distância 

        transform.position = player.transform.position + offset;

    }

}