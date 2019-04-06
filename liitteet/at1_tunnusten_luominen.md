# "Kirjautuminen" ominaisuuden hyväksyntätesti


| | |
|:-:|:-:|
| Testitapauksen kuvaus | Kelpuutetaan asiakkaalla jos asiakas pystyy kirjautumaan palveluun omilla tunnuksilla   |
| Testitapaus ID | AT01 |
| Testitapauksen suunnittelija | Amanda Waltari | 
| Testitapauksen hyväksyjä: | Samson Gold |
| Luontipvm | 11.3.2019 |
| Luokitus | Hyväksyntätesti / Acceptance Test |

**Päivityshistoria**

* versio 0.1 

**Testin kuvaus / tavoite**

* Luodaan tunnukset palveluun ja yritetään kirjautua palveluun näitä tunnuksia käyttäen.
* Sen jälkeen kokeillaan kirjautua facebook-tunnuksilla.

**Linkit vaatimuksiin tai muihin lähteisin**

* Vaatimus: FUNC-REQ-0001
* Käyttötapaus: [Use Case 2 - kirjautuminen](usecase2.md) 
* Ominaisuus: [Ominaisuus - Tunnusten luominen ja kirjautuminen](f1_login.md)

**Testin alkutilanne (Pre-state)** 

* Alkutilanne, "kirjaudu palveluun"

**Testiaskeleet (Test Steps)**

1. Luodaan tunnukset
2. Klikataan linkkiä varmistussähköpostissa
3. Syötetään s-posti
4. Syötetään salasana
5. Syötetään google authenticator varmistuskoodi
6. Kirjaudutaan ulos palvelusta
7. Kirjaudutaan Facebook-tunnuksilla palveluun

**Testin lopputilanne (End-State)**


* Testin ajon aikana käydään kaikki testiaskelet läpi ja lopputilanne on se,
* että ollaan kirjautuneena palveluun ja voidaan käyttää palvelua.



<!--**Huomioitava testin aikana**

* Huomio 1
* Huomio 2-->


**Testin "tuomio"/tulos (Pass/Fail Criteria)**


* PASS Kirjautuminen palveluun onnistuu sekä luomilla tunnuksilla että facebook-tunnuksilla 
* FAIL Kirjautuminen palveluun epäonnistuu jommalla kummalla tai mollemmin tavoin