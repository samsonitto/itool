# "Salasanan nollaus" ominaisuuden hyväksyntätesti

<!--[![](http://img.youtube.com/vi/YQ9rZBOMs6g/0.jpg)](http://www.youtube.com/watch?v=YQ9rZBOMs6g "")-->


| | |
|:-:|:-:|
| Testitapauksen kuvaus | Kelpuutetaan asiakkaalla jos asiakas pystyy nollaamaan salasanansa |
| Testitapaus ID | AT02 |
| Testitapauksen suunnittelija | Amanda Waltari | 
| Testitapauksen hyväksyjä: | Samson Gold |
| Luontipvm | 11.3.2019 |
| Luokitus | Hyväksyntätesti / Acceptance Test |

**Päivityshistoria**

* versio 0.1 

**Testin kuvaus / tavoite**

* Nollataan unohtunut salasana ja luodaan uusi

**Linkit vaatimuksiin tai muihin lähteisin**

* Käyttötapaus: [Use Case 3 - salasanan nollaus](usecase3.md) 

**Testin alkutilanne (Pre-state)** 

* Alkutilanne, "Unohtuiko salasana?"

**Testiaskeleet (Test Steps)**

1. Klikataan "Unohtuiko salasana?"
2. Syötetään s-posti
3. Tarkistetaan s-posti
4. Klikataan salasanan nollauslinkkiä s-postissa
5. Luodaan uusi salasana
6. Klikataan varmistussähköpostissa olevaa linkkiä
7. Kirjaudutaan palveluun uutta salasanaa käyttäen

**Testin lopputilanne (End-State)**


* Testin ajon aikana käydään kaikki testiaskelet läpi ja lopputilanne on se,
* että ollaan kirjautuneena palveluun uutta salasanaa käyttäen.



<!--**Huomioitava testin aikana**

* Huomio 1
* Huomio 2-->


**Testin "tuomio"/tulos (Pass/Fail Criteria)**


* PASS Kirjautuminen palveluun uutta salasanaa käyttäen onnistui 
* FAIL Kirjautuminen palveluun uutta salasanaa käyttäen epäonnistui