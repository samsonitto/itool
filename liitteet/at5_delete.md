# "Tunnusten poistaminen" ominaisuuden hyväksyntätesti

| | |
|:-:|:-:|
| Testitapauksen kuvaus | Kelpuutetaan asiakkaalla jos asiakas pystyy poistamaan omat tunnukset palvelun tietokannasta  |
| Testitapaus ID | AT05 |
| Testitapauksen suunnittelija | Amanda Waltari | 
| Testitapauksen hyväksyjä: | Samson Gold |
| Luontipvm | 11.3.2019 |
| Luokitus | Hyväksyntätesti / Acceptance Test |

**Päivityshistoria**

* versio 0.1 

**Testin kuvaus / tavoite**

* Yritetään poistaa käyttäjätilin.

**Linkit vaatimuksiin tai muihin lähteisin**

* Vaatimus: FUNC-REQ-0010
* Ominaisuus: [FT05 - Asiakaspalvelu](f3_delete_account.md)

**Testin alkutilanne (Pre-state)** 

* Alkutilanne, "Kirjaudu palveluun"

**Testiaskeleet (Test Steps)**

1. Luodaan tunnukset
2. Kirjaudutaan palveluun
3. Siirrytään "Poista tili" valikkoon
4. Poistetaan tili
5. Varmistetaan poisto
6. Tarkistetaan palvelun tietokannat, että henkilötiedot on varmasti poistettu

**Testin lopputilanne (End-State)**


* Testin ajon aikana käydään kaikki testiaskelet läpi ja lopputilanne on se,
* että ollaan poistettu just luodun käyttäjätilin ja sen henkilötiedot palvelun tietokannasta.



<!--**Huomioitava testin aikana**

* Huomio 1-->
* Huomio 1 Kaikkien henkilötietojen pitää olla poistettuna tietokannasta


**Testin "tuomio"/tulos (Pass/Fail Criteria)**


* PASS Tunnusten poistaminen palvelun tietokannasta onnistui
* FAIL Tunnusten poistaminen palvelun tietokannasta epäonnistui