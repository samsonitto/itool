# "Tunnusten luominen" ominaisuuden hyväksyntätesti


| | |
|:-:|:-:|
| Testitapauksen kuvaus | Kelpuutetaan käyttäjällä jos käyttäjä pystyy kirjautumaan palveluun omilla tunnuksilla |
| Testitapaus ID | AT01 |
| Testitapauksen suunnittelija | Samson Azizyan | 
| Testitapauksen hyväksyjä: | Samson Azizyan |
| Luontipvm | 6.4.2019 |
| Luokitus | Hyväksyntätesti / Acceptance Test |

**Päivityshistoria**

* versio 0.1 

**Testin kuvaus / tavoite**

* Luodaan tunnukset palveluun ja yritetään kirjautua palveluun näitä tunnuksia käyttäen.

**Linkit vaatimuksiin tai muihin lähteisin**

* Käyttötapaus: [Use Case 1 - Tunnusten luominen ja kirjautuminen](../README.md#tunnusten-luominen-ja-kirjautuminen) 
* Ominaisuus: [Ominaisuus - Tunnusten luominen ja kirjautuminen](f1_login.md)

**Testin alkutilanne (Pre-state)** 

* MainWindow, "kirjaudu palveluun"

**Testiaskeleet (Test Steps)**

1. Klikataan "Register" painikettä
2. Täytetään kaikki pakolliset kentät
3. Klikataan "Complete" painikettä
4. Register-ikkuna sulkeutuu ja MainWindow aukee
5. Syötetään s-posti ja salasana
6. Klikataan "Login" painikettä
7. Ollaan kirjautuneena sovellukseen

**Testin lopputilanne (End-State)**


* Testin ajon aikana käydään kaikki testiaskelet läpi ja lopputilanne on se,
* että ollaan kirjautuneena sovellukseen ja voidaan käyttää sovellusta.


**Testin "tuomio"/tulos (Pass/Fail Criteria)**


* PASS Tunnukset tallentui tietokantaan ja kirjautuminen palveluun onnistuu
* FAIL Tunnukset ei tallennu tietokantaan