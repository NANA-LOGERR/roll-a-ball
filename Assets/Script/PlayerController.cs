using System;
using TMPro;
using UnityEngine;



                         // NOVO: para usar textos 

  

public class PlayerController : MonoBehaviour

{

    public float speed = 10f;

    public TextMeshProUGUI countText;     // NOVO: texto dos pontos 

    public GameObject winTextObject;      // NOVO: texto de vitória 



    private Rigidbody rb;

    private int count;                    // NOVO: contador de pontos 



    void Start()

    {

        rb = GetComponent<Rigidbody>();

        count = 0;                        // NOVO 

        SetCountText();                   // NOVO 

        winTextObject.SetActive(false);   // NOVO: esconde "Você venceu!" 

    }



    void FixedUpdate()

    {

        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");



        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

    }



    // NOVO: chamado quando a bola entra em um Trigger 

    void OnTriggerEnter(Collider other)

    {

        // Só coleta se o objeto tiver a Tag "PickUp" 

        if (other.gameObject.CompareTag("PickUp"))

        {

            other.gameObject.SetActive(false);  // some com o item 

            count = count + 1;                  // soma 1 ponto 

            SetCountText();

        }
        if (other.gameObject.CompareTag("MorePoints"))

        {

            other.gameObject.SetActive(false);  // some com o item 

            count = count + 3;                  // soma 1 ponto 

            SetCountText();

        }

    }



    // NOVO: atualiza o texto e verifica a vitória 

    void SetCountText()

    {

        countText.text = "Pontos: " + count.ToString();



        if (count >= 15 )

        {

            winTextObject.SetActive(true);

        }

    }

}