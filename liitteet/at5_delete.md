# "Tunnusten poistaminen" ominaisuuden hyväksyntätesti

| | |
|:-:|:-:|
| Testitapauksen kuvaus | Kelpuutetaan Käyttäjällä jos Käyttäjä pystyy poistamaan omat tunnukset sovelluksen tietokannasta  |
| Testitapaus ID | AT04 |
| Testitapauksen suunnittelija | Samson Azizyan | 
| Testitapauksen hyväksyjä: | Samson Azizyan |
| Luontipvm | 6.4.2019 |
| Luokitus | Hyväksyntätesti / Acceptance Test |

**Päivityshistoria**

* versio 0.1 

**Testin kuvaus / tavoite**

* Yritetään poistaa käyttäjätilin.

**Linkit vaatimuksiin tai muihin lähteisin**

* Ominaisuus: [Käyttäjätilin poistaminen](f3_delete_account.md)

**Testin alkutilanne (Pre-state)** 

* Profiilisivu

**Testiaskeleet (Test Steps)**

1. Klikataan "Poista käyttäjätili" painiketta
2. Varmistus ikkuna avautuu
3. Klikataan "Yes" painiketta
4. Kaikki ikkunat sulkeutuu ja aukee Login (MainWindow) ikkuna

**Testin lopputilanne (End-State)**


* Testin ajon aikana käydään kaikki testiaskelet läpi ja lopputilanne on se,
* että ollaan poistettu käyttäjätilin ja sen henkilötiedot palvelun tietokannasta.



**Huomioitava testin aikana**

* Huomio 1 Kaikkien henkilötietojen pitää olla poistettuna tietokannasta


**Testin "tuomio"/tulos (Pass/Fail Criteria)**


* PASS Tunnusten poistaminen palvelun tietokannasta onnistui
* FAIL Tunnusten poistaminen palvelun tietokannasta epäonnistui