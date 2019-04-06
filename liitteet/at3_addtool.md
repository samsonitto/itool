# "Navigoiminen" ominaisuuden hyväksyntätesti

| | |
|:-:|:-:|
| Testitapauksen kuvaus | Kelpuutetaan asiakkaalla jos asiakas pystyy navigoimaan vaelluskartalla   |
| Testitapaus ID | AT03 |
| Testitapauksen suunnittelija | Amanda Waltari | 
| Testitapauksen hyväksyjä: | Samson Gold |
| Luontipvm | 11.3.2019 |
| Luokitus | Hyväksyntätesti / Acceptance Test |

**Päivityshistoria**

* versio 0.1 

**Testin kuvaus / tavoite**

* Yritetään navigoida paikasta A paikkaan B luontopolulla navigointi-ominaisuutta käyttäen.

**Linkit vaatimuksiin tai muihin lähteisin**

* Vaatimus: FUNC-REQ-0007
* Ominaisuus: FT02 - navigointi

**Testin alkutilanne (Pre-state)** 

* Alkutilanne, "Hae sijainti"

**Testiaskeleet (Test Steps)**

1. Kirjaudutaan palveluun
2. Haetaan sijainti minne halutaan navigoida
3. Asetetaan oman sijainnin aloituspisteeksi
4. Navigoidaan
5. Päästään päätypisteeseen
6. Tarkistetaan onko päätypiste sama kun aiemmin haettu sijainti
7. Kirjaudutaan ulos palvelusta

**Testin lopputilanne (End-State)**


* Testin ajon aikana käydään kaikki testiaskelet läpi ja lopputilanne on se,
* että ollaan navigoitu paikasta A paikkaan B onnistuneesti.



<!--**Huomioitava testin aikana**

* Huomio 1
* Huomio 2-->


**Testin "tuomio"/tulos (Pass/Fail Criteria)**


* PASS Navigointi paikasta A paikkaan B onnistui 
* FAIL Navigointi paikasta A paikkaan B epäonnistui