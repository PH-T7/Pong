using Unity.VisualScripting;
using UnityEngine;

public class RaqueteController : MonoBehaviour
{
    //Criando meu vector 3
    private Vector3 MinhaPosicao;
    private float meuY;
    public float Velocidade = 5f;
    public float MeuLimite = 3.54f;


    //indentificando se sou o player 1
    public bool player1;
    //Indentificar se é uma AI
    public bool automatico = false;
    //Pegando a posicao da bola
    public Transform Bola;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Pegando a posição inicial da raquete e aplicando a minha posição
        MinhaPosicao = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //MinhaPosicao.x = -7f;


        //Transform- Classe Tipo Abstrata
        //transform- Individual objeto do jogo

        //Debug.Log(transform.position.y);

        //Passando o meuY para o eixo Y daminhaPosicao
        MinhaPosicao.y = meuY;


        //Modificar a posição da minha raquete
        transform.position = MinhaPosicao;

        //Velocidade final

        float deltaVelocidade = Velocidade * Time.deltaTime;

        //Pegandoa setinha para cima
        //Se eu apertar a setinha para cima ele vai subir a raquete e mesma coisa para baixo

        //Se o automatico nao é true(ou seja ele é falso)
        if (!automatico)
        {
           
            //Controlando a raquete player 1 
            if (player1)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    //Subindo


                    meuY = meuY + deltaVelocidade;

                }

                if (Input.GetKey(KeyCode.S))
                {
                    //Descendo


                    meuY = meuY - deltaVelocidade;
                }
            }
            //Controlando a raquete player 2
            else
            {
                if (Input.GetKey(KeyCode.Return))
                {
                    automatico = true;
                }

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    //Subindo

                    meuY = meuY + deltaVelocidade;

                }
                //Descendo
                if (Input.GetKey(KeyCode.DownArrow))
                {

                    meuY = meuY - deltaVelocidade;
                }
            }
            //impendindo que a raquete saia acima da tela
            if (meuY > MeuLimite)
            {
                meuY = MeuLimite;
            }
            //impendindo que a raquete saia debaixo da tela
            if (meuY < -MeuLimite)
            {
                meuY = -MeuLimite;
            }
        }
        //Senão caso seja automatico
        else{

            //Tirando ele do automatico 
            //Checando se ele e um jogador ou nao com a cetinha
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                automatico = false;
            }


            //Para acessar funcoes matematicas nos usamos a classe mathf
            meuY = Mathf.Lerp(meuY, Bola.position.y, 0.08f);

        }
        //impendindo que a raquete saia acima da tela
        if (meuY > MeuLimite)
        {
            meuY = MeuLimite;
        }
        //impendindo que a raquete saia debaixo da tela
        if (meuY < -MeuLimite)
        {
            meuY = -MeuLimite;
        }

     


    }
}
