using UnityEngine;
using UnityEngine.SceneManagement;

public class BolaController : MonoBehaviour
    //Criando a variavel para saber quem e meu rigidbody
{
    
    public Rigidbody2D meuRB;

    private Vector2 MinhaVelocidade;

    public float Velocidade = 5f;

    public float limiteHorizontal = 12f;

    public AudioClip boing;

    public Transform camera;

    public float delay = 2f;

    public bool jogoIniciado = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Passando a velocidade para a minha velocidade
        
      

    }

    // Update is called once per frame
    void Update()
    {
        //Iniciando a bola com delay

        //Diminuindo o valor do delay
        delay = delay - Time.deltaTime;

        //Checando se o delay chegou em zero
        if (delay <= 0 && jogoIniciado == false)
        {
            Debug.Log("Cheguei no zero!");

            jogoIniciado = true;
            //Iniciandoo jogo

            //Tentando gerar um valor aleatório
            int direcao = Random.Range(0, 4);
            //Debug.Log(direcao);

            //Randomizando a direção
            if (direcao == 0)
            {
                MinhaVelocidade.x = Velocidade;
                MinhaVelocidade.y = Velocidade;
            }
            if (direcao == 1)
            {
                MinhaVelocidade.x = -Velocidade;
                MinhaVelocidade.y = Velocidade;
            }
            if (direcao == 2)
            {
                MinhaVelocidade.x = -Velocidade;
                MinhaVelocidade.y = -Velocidade;
            }
            if (direcao == 3)
            {
                MinhaVelocidade.x = Velocidade;
                MinhaVelocidade.y = -Velocidade;
            }

            meuRB.linearVelocity = MinhaVelocidade;
        }

        //Checando se a bola passou para os dois players
        if (transform.position.x > limiteHorizontal)
        {
            SceneManager.LoadScene(0);
        }
        if (transform.position.x < -limiteHorizontal)
        {
            SceneManager.LoadScene(0);
        }
    }

    //Criando o meu evento de colisao
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(boing, camera.position);
    }
}
