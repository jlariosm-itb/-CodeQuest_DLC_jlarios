# -CodeQuest_DLC_jlarios


# Joc de CodeQuest - Descripció i Jocs de Proves

## Descripció del projecte

El joc CodeQuest és una aventura temàtica de mags on el jugador pot entrenar al seu mag, guanyar nivells derrotant monstres, minar per aconseguir monedes, millorar els seus objectes i atacs, així com desxifrar pergamins antics. El jugador té diferents opcions al menú principal per realitzar accions:

1. Entrenar el mag
2. Augmentar el nivell lluitant contra monstres
3. Minar per obtenir monedes
4. Mostrar l'inventari
5. Comprar objectes
6. Mostrar els atacs disponibles segons el nivell
7. Desxifrar pergamins antics

## Exercicis i jocs de proves

### Exercici 1: Entrenament del mag

**Descripció**: En aquest exercici, el jugador ha de fer entrenar el seu mag per guanyar potència i nivells. El sistema de classificació té en compte la potència aconseguida durant l'entrenament.

| **Test Case** | **Descripció**                                          | **Valor esperat**                          |
|--------------|----------------------------------------------------------|--------------------------------------------|
| **Cas normal** | El jugador entrena el mag durant 5 dies.                 | El mag puja de nivell segons la potència acumulada. |
| **Cas límit**  | El jugador entra un valor de potència molt alt (>80).    | S'ha desbloquejat l'easter egg i el jugador aconsegueix el rang "The June Savior of the ITB". |

### Exercici 2: Augmentar nivell lluitant contra monstres

**Descripció**: El jugador ha de lluitar contra monstres, llançant daus per determinar l'èxit de les seves accions. Els monstres varien en dificultat segons el nivell del jugador.

| **Test Case** | **Descripció**                                          | **Valor esperat**                          |
|--------------|----------------------------------------------------------|--------------------------------------------|
| **Cas normal** | El jugador derrota un monstre de nivell mitjà.           | El jugador guanya punts d'experiència i augmenta el nivell. |
| **Cas límit**  | El jugador derrota un monstre de nivell elevat.          | El jugador guanya un gran nombre de punts d'experiència. |

### Exercici 3: Minar per obtenir monedes

**Descripció**: En aquest exercici, el jugador entra en una mina on ha de cercar monedes. Té un nombre limitat d'intents per trobar-les.

| **Test Case** | **Descripció**                                          | **Valor esperat**                          |
|--------------|----------------------------------------------------------|--------------------------------------------|
| **Cas normal** | El jugador troba una moneda en el segon intent.          | El jugador guanya bits.                    |
| **Cas límit**  | El jugador fa 5 intents i no troba cap moneda.           | El jugador acaba el joc amb 0 bits trobats. |

### Exercici 4: Mostrar inventari

**Descripció**: El jugador pot veure els objectes que ha adquirit fins al moment en l'inventari.

| **Test Case** | **Descripció**                                          | **Valor esperat**                          |
|--------------|----------------------------------------------------------|--------------------------------------------|
| **Cas normal** | El jugador té diversos objectes a l'inventari.           | Es mostren tots els objectes amb els seus valors. |
| **Cas límit**  | L'inventari del jugador està buit.                       | Es mostra el missatge "El teu inventari està buit". |

### Exercici 5: Comprar objectes

**Descripció**: El jugador pot comprar objectes amb els bits que ha minat, millorant el seu personatge.

| **Test Case** | **Descripció**                                          | **Valor esperat**                          |
|--------------|----------------------------------------------------------|--------------------------------------------|
| **Cas normal** | El jugador compra un objecte de 30 bits.                 | El jugador veu una actualització del seu inventari. |
| **Cas límit**  | El jugador intenta comprar un objecte sense tenir suficients bits. | Es mostra el missatge "No tens prou bits". |

### Exercici 6: Mostrar atacs disponibles per nivell

**Descripció**: El jugador pot veure els atacs que té disponibles segons el seu nivell actual.

| **Test Case** | **Descripció**                                          | **Valor esperat**                          |
|--------------|----------------------------------------------------------|--------------------------------------------|
| **Cas normal** | El jugador és de nivell 3.                              | Es mostren els atacs disponibles per al nivell 3. |
| **Cas límit**  | El jugador té un nivell més gran que 5.                  | El jugador té accés a tots els atacs.       |

### Exercici 7: Desxifrar pergamins antics

**Descripció**: El jugador ha de resoldre un conjunt de desxiframents per desbloquejar atacs secrets o altres recompenses.

| **Test Case** | **Descripció**                                          | **Valor esperat**                          |
|--------------|----------------------------------------------------------|--------------------------------------------|
| **Cas normal** | El jugador elimina els espais del primer pergamí.       | Es mostra el pergamí desxifrat sense espais. |
| **Cas límit**  | El jugador intenta desxifrar un pergamí amb dades incompletes. | Es mostra un missatge d'error indicant que el pergamí no es pot desxifrar. |


