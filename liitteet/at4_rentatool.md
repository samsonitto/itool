# "Asiakaspalvelu" ominaisuuden hyväksyntätesti

| | |
|:-:|:-:|
| Testitapauksen kuvaus | Kelpuutetaan asiakkaalla jos asiakas pystyy ottamaan yhteyttä asiakaspalveluun   |
| Testitapaus ID | AT04 |
| Testitapauksen suunnittelija | Amanda Waltari | 
| Testitapauksen hyväksyjä: | Samson Gold |
| Luontipvm | 11.3.2019 |
| Luokitus | Hyväksyntätesti / Acceptance Test |

**Päivityshistoria**

* versio 0.1 

**Testin kuvaus / tavoite**

* Yritetään navigoida paikasta A paikkaan B luontopolulla navigointi-ominaisuutta käyttäen.

**Linkit vaatimuksiin tai muihin lähteisin**

* Vaatimus: FUNC-REQ-0006
* Ominaisuus: [FT05 - Asiakaspalvelu](f5_aspa.md)

**Testin alkutilanne (Pre-state)** 

* Alkutilanne, "Asiakaspalvelu"

**Testiaskeleet (Test Steps)**

1. Kirjaudutaan palveluun
2. Siirrytään asiakaspalvelu valikkoon
3. Otetaan yhteyttä asiakaspalveluun chat ominaisuudella
4. Kommunikoidaan asiakaspalvelijan kanssa
5. Soitetaan asiakaspalveluun sovelluksen kautta
6. Kommunikoidaan asiakaspalvelijan kanssa
7. Kirjaudutaan ulos palvelusta

**Testin lopputilanne (End-State)**


* Testin ajon aikana käydään kaikki testiaskelet läpi ja lopputilanne on se,
* että ollaan saatu yhteyttä asiakaspalveluun sekä chatin että puhelun kautta.



<!--**Huomioitava testin aikana**

* Huomio 1
* Huomio 2-->


**Testin "tuomio"/tulos (Pass/Fail Criteria)**


* PASS Yhteydenotto asiakaspalveluun sekä chatilla että puhelulla onnistui
* FAIL Yhteydenotto asiakaspalveluun jommalla kummalla tai molemmin tavoin epäonnistui