VAR SUJETO = "skibidi"

VAR estaMuerto = false
VAR int = 50
-> capitulo_1

== capitulo_1 ==
Eres: {"Xx_"+SUJETO+int+"_xX"}

-> capitulo_2

== capitulo_2 ==
bienvenido al mundo 2

    *** gdfg
    -> absurdez
    *** ghkjhk
    -> muerte
== absurdez ==
    jhgfjg
    -> continuacion_decision


== muerte ==
Lamentablemente debido a esto, has muerto :<
~estaMuerto=true
 CLEAR
->continuacion_decision

== continuacion_decision ==
pos toma la tarta que para nada es un mentira.
{ muerte: 
¿Por que no comes? oh es verdad.
}
{ not muerte: -> tarta_comida}
-> END
== tarta_comida==
¿Te ha gustado?
*** Si
->END
*** NOOOOOOO, ES UNA MIERR
->END