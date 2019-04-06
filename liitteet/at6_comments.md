# "Kaverilista" ominaisuuden hyväksyntätesti


| | |
|:-:|:-:|
| Testitapauksen kuvaus | Kelpuutetaan asiakkaalla jos asiakas pystyy lisäämään ja poistamaan käyttäjiä kaverilistalle sekä kommunikoimaan heidän kanssa  |
| Testitapaus ID | AT06 |
| Testitapauksen suunnittelija | Amanda Waltari | 
| Testitapauksen hyväksyjä: | Samson Gold |
| Luontipvm | 11.3.2019 |
| Luokitus | Hyväksyntätesti / Acceptance Test |

**Päivityshistoria**

* versio 0.1 

**Testin kuvaus / tavoite**

* Yritetään hakea, lisätä ja poistaa käyttäjiä kaverilistalle.
* Yritetään kommunikoida kvaerilistalla olevien käyttäjien kanssa.

**Linkit vaatimuksiin tai muihin lähteisin**

* Vaatimus: FUNC-REQ-0009
* Ominaisuus: FT06 - Kaverilista

**Testin alkutilanne (Pre-state)** 

* Alkutilanne, "Hae käyttäjä"

**Testiaskeleet (Test Steps)**

1. Haetaan käyttäjä
2. Lisätään käyttäjä kaverilistalle
3. Käyttäjä hyväksyy kaverilistalle lisäämisen pyynnön
4. Aloitetaan keskustelu kaverilistalla olevan käyttäjän kanssa
5. Kommunikoidaan kaverilistalla olevan käyttäjän kanssa
6. Poistetaan käyttäjä kaverilistalta

**Testin lopputilanne (End-State)**


* Testin ajon aikana käydään kaikki testiaskelet läpi ja lopputilanne on se,
* että ollaan haettu, lisätty ja poistettu käyttäjä kaverilistalta
* sekä ollaan kommunikoitu kaverilistalla olevan käyttäjän kanssa.



<!--**Huomioitava testin aikana**

* Huomio 1
* Huomio 1 Kaikkien henkilötietojen pitää olla poistettuna tietokannasta-->


**Testin "tuomio"/tulos (Pass/Fail Criteria)**


* PASS Käyttäjää on haettu, lisätty kaverilistalle ja poistettu kaverilistalta onnistuneesti. Kaverilistalla olevan käyttäjän kanssa on kommunikoitu onnistuneesti.
* FAIL Joko haku, lisäys, poisto tai kommunikointi on epäonnistunut.