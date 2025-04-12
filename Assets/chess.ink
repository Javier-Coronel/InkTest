VAR peon = "peon"
VAR alfil = "alfil"
VAR roca = "roca"
VAR caballo = "caballo"
VAR reina = "reina"
VAR rey = "rey"
VAR markus = "rasputin"
VAR pipo = "pipo"
VAR white = "white"
VAR black = "black"
VAR normal = "normal"
VAR muerte = "muerte"
VAR amenaza = "amenaza"

VAR estaMuerto = false
VAR promesaATorreEnemiga = false
VAR promesaAAlfilEnemigo = false
VAR promesaACaballoEnemigo = false

EXTERNAL ShowCharacter(name, position, mood)
EXTERNAL ShowCharacterWhithColor(name, position, mood, color)
EXTERNAL HideCharacter(name)
EXTERNAL ChangeMood(name, mood)
EXTERNAL ChangeSong(name)


-> capitulo_1

== capitulo_1 ==
~ChangeSong(normal)
¿Donde... donde estoy?

~ShowCharacter(peon, "center", normal)

¡Oh no! Aparentemente me he convertido en una pieza de ajedrez.
Lo peor es que me he convertido en un peon.
Aunque, a lo mejor tengo suerte y la persona que me controle es buena jugando al ajedrez.
~HideCharacter(peon)
¡Y aqui estan los jugadores de hoy!
~ShowCharacter(pipo, "left", normal)
Persona generica jugando con las blancas.
~HideCharacter(pipo)
~ShowCharacter(markus, "right", normal)
~ChangeSong("stop")
Contra Magnus Carlsen jugando con las negras.
~HideCharacter(markus)
~ShowCharacter(peon, "center", normal)
Oh dios, voy a morir aqui.

-> capitulo_2

== capitulo_2 ==
~ChangeSong(normal)
~ShowCharacterWhithColor(roca, "left", normal, black)
~ShowCharacterWhithColor(alfil, "right", normal, black)
Despues de un tiempo en el que has estado yendo hacia delante, te encuentras contra una torre y un alfil.
Puedes tomar a cualquiera de ambos.
    *** Tomar el alfil
    ~HideCharacter(alfil)
    De pronto la torre se acerca.
    ~ChangeSong(amenaza)
    -> alfil_negro_tomado
    *** Tomar la torre
    -> torre_negra_tomada
    *** No hacer nada
    -> alfil_negro_atacandote
    *** Moverse hacia delante
    Parece que no te acordaste de que la torre podia atacarte aqui.
    ~HideCharacter(alfil)
    ~ChangeSong(amenaza)

    -> alfil_negro_tomado

== alfil_negro_tomado ==
    Hola peon, parece que estas cerca de llegar al limite del tablero.
    Te propongo un trato, no te tomo si promueves a otra torre. ¿Que me dices?
    *** ¿Por que te haria caso? ¿No somos enemigos?
    ~ChangeSong(muerte)
    Que mala elección de palabras.
    ~HideCharacter(peon)
    Tras esto la torre te ataco y moriste.
    -> END
    *** De acuerdo.
    ~promesaATorreEnemiga = true
    Bien, adios.
    ~HideCharacter(roca)
    La torre se fue y tu puedes continuar.
    ->PeonEnemigo
    *** {promesaAAlfilEnemigo} Ya le hecho una promesa a otro, lo siento
    ~ChangeSong(muerte)
    Que mala suerte la tuya.
    ~HideCharacter(peon)
    Tras esto la torre te ataco y moriste.
    -> END



== torre_negra_tomada
    ~HideCharacter(alfil)
    ~HideCharacter(roca)
    ~ChangeSong(amenaza)
    Al moverte para tomar la torre viste que detras del alfil habia un caballo enemigo.
    Pero ya es demasiado tarde.
    ~ShowCharacterWhithColor(caballo, "right", normal, black)
    ¡Peon! parece que estas en mi punto de mira, pero mi posicion actual es muy buena.
    Si no te promueves a un caballo acabare contigo ¿me entiendes?
    ~promesaACaballoEnemigo = true
    ~HideCharacter(caballo)
    Despues de esto pudiste continuar.
    ->PeonEnemigo

== alfil_negro_atacandote ==
    ~ChangeSong(amenaza)
    ~HideCharacter(roca)
    Vaya, que mala suerte que no te hayan movido, te dejare vivir si al promover te haces un alfil.
    ¿Que me dices?
    *** De acuerdo
    Muy bien.
    ~promesaAAlfilEnemigo = true
    ~HideCharacter(alfil)
    Asi que continuaste.
    ~ShowCharacterWhithColor(roca, "left", normal, black)
    Aunque aún no te acordabas de la torre que tenias al otro lado.
    ->alfil_negro_tomado

    *** No
    Que tonto eres, pero tienes suerte, me necesitan en otra parte.
    ~HideCharacter(alfil)
    El alfil se fue y continuaste.
    ~ShowCharacterWhithColor(roca, "left", normal, black)
    Aunque aún no te acordabas de la torre que tenias al otro lado.
    ->alfil_negro_tomado

== PeonEnemigo ==
~ChangeSong(normal)
~HideCharacter(peon)
Casi al final del camino, un peon enemigo se mueve justo a tu derecha.
~ShowCharacterWhithColor(peon, "right", normal, black)
¡Jajajaja! parecia que ibas a tomarme, pero me he adelantado.
    *** Moverse hacia delante
    Hay pobre peon, pero yo tambien tengo que llegar a tu parte del tablero.
        ~HideCharacter(peon)
    -> llegada_a_final_de_tablero
    *** Moverse detras del peon enemigo
    ¡Ah! ¿Como te has movido hasta ahi?
        **** Googlea on pessant.
        ~ChangeMood(peon, "phoneBlack")
        A ver.
        Oh...
        ~HideCharacter(peon)
        De pronto el peon enemigo desaparece y puedes continuar.
        -> llegada_a_final_de_tablero
        **** No tengo ni idea.
        Ni yo.
        ~HideCharacter(peon)
        De pronto el peon enemigo desaparece como si hubiese sido capturado.
        -> llegada_a_final_de_tablero
-> llegada_a_final_de_tablero


== llegada_a_final_de_tablero ==
~ShowCharacter(peon, "center", normal)
¡Bien! He llegado al final del tablero, ahora tengo que elegir en que pieza convertirme:

*** En una reina.
~HideCharacter(peon)
~ShowCharacter(reina, "center", normal)
{promesaACaballoEnemigo:
    ~ChangeSong(muerte)
    Debido al altercado que tuviste con el caballo enemigo anteriormente, este te ataco por haber elegido esto.
- else:
    Gracias a esta decision te hiciste la pieza mas poderosa y unica de lo que quedaba en el tablero.
    Dio igual las promesas que hubieses incumplido al hacerlo, con tu poder ninguna otra pieza pudo contra ti.
    Y gracias a esto la persona que te movia gano la partida.
}
->END

*** En un caballo.
~HideCharacter(peon)
~ShowCharacter(caballo, "center", normal)
    Aunque no fue la mejor decision para la partida, puede que fuese la mejor decision para ti.
    Dio igual las promesas que hubieses incumplido al hacerlo, niguna pieza que quedaba en el tablero pudo contigo.
    Y la partida quedo en tablas contigo aun en el tablero.
->END
->END

*** En un alfil.
~HideCharacter(peon)
~ShowCharacter(alfil, "center", normal)
{
    -promesaACaballoEnemigo:
        ~ChangeSong(muerte)
        ~ShowCharacterWhithColor(caballo, "right", normal, black)
        Debido al altercado que tuviste con el caballo enemigo anteriormente, este te ataco por haber elegido esto.
    - promesaATorreEnemiga: 
        ~ChangeSong(muerte)
        ~ShowCharacterWhithColor(roca, "right", normal, black)
        Al no cumplir la promesa con la torre, este te ataco y despues el jugador que te llevaba perdio.
    - else:
        Al elegir ser una roca hubo oportunidades de hacer un jaque mate al rey enemigo.
        Y estas oportunidades fueron usadas, ganasteis la partida.
}
->END

*** En una roca.
~HideCharacter(peon)
~ShowCharacter(roca, "center", normal)
{
    - promesaACaballoEnemigo:
        ~ChangeSong(muerte)
        ~ShowCharacterWhithColor(caballo, "right", normal, black)
        Debido al altercado que tuviste con el caballo enemigo anteriormente, este te ataco por haber elegido esto.
    - promesaAAlfilEnemigo: 
        ~ChangeSong(muerte)
        ~ShowCharacterWhithColor(alfil, "right", normal, black)
        Al no cumplir la promesa con el alfil, este te ataco y despues el jugador que te llevaba perdio.
    - else:
        Al elegir ser una roca hubo oportunidades de hacer un jaque mate al rey enemigo.
        Pero fueron solo eso, promesas.
        La partida quedo en un empate.
}
->END

*** ¿Por que tendria que cambiar? ¡Me quedo como un peon!
¿Por que harias eso? Ahora estas atrapado en el fin del tablero.
Para siempre.
->END

*** ¿Sabes que? ¡Ahora quiero ser un rey!
~HideCharacter(peon)
~ShowCharacter(rey, "center", normal)
Al elegir ser un rey todo el mundo enloquecio.
Los jueces discutieron. Jugadores de otras partidas se acercaron.
Todo el mundo enloquecio, y como nadie entendio como habia pasado esto, la partida quedo en tablas.
->END