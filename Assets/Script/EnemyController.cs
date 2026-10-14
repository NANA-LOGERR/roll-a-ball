using UnityEngine;
using TMPro; // Use 'using UnityEngine.UI;' se estiver usando a UI antiga

public class EnemyFollow : MonoBehaviour
{
    [Header("Configurações de Perseguição")]
    public Transform player;
    public float speed = 3.0f;

    [Header("Interface e Elementos")]
    public TextMeshProUGUI loseText; // Altere para 'Text' se não usar TextMeshPro

    private void Start()
    {
        // Garante que o texto comece oculto
        if (loseText != null)
        {
            loseText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (player != null)
        {
            // Move o objeto na direção do Player
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            // Faz o objeto olhar para o Player
            transform.LookAt(player);
        }
    }

    // Detecta colisão física (sem usar "Is Trigger")
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se colidiu com o objeto que tem a tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Ativa o texto de derrota
            if (loseText != null)
            {
                loseText.gameObject.SetActive(true);
            }

            // Encontra e destrói todos os objetos com a tag "PickUp"
            GameObject[] pickups = GameObject.FindGameObjectsWithTag("PickUp");
            foreach (GameObject pickup in pickups)
            {
                Destroy(pickup);
            }

            // Desativa o próprio inimigo após a colisão
            gameObject.SetActive(false);
        }
    }
}