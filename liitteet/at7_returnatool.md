# "Kaverilista" ominaisuuden hyväksyntätesti


| | |
|:-:|:-:|
| Testitapauksen kuvaus | Kelpuutetaan käyttäjällä jos käyttäjä pystyy palauttamaan lainatun työkalun |
| Testitapaus ID | AT06 |
| Testitapauksen suunnittelija | Samson Azizyan | 
| Testitapauksen hyväksyjä: | Samson Azizyan |
| Luontipvm | 6.4.2019 |
| Luokitus | Hyväksyntätesti / Acceptance Test |

**Päivityshistoria**

* versio 0.1 

**Testin kuvaus / tavoite**

* Yritetään palauttaa lainatun työkalun takaisin omistajalle.


**Testin alkutilanne (Pre-state)** 

* Profiili-ikkuna auki ja lista vuokratuista työkaluista on auki.

**Testiaskeleet (Test Steps)**

1. Valitaan työkalu jonka halutaan palauttaa
2. Klikataan Return painiketta
3. Varmistus ikkuna avautuu
4. Klikataan "Yes"
5. Työkalu on poistunut vuokrattujen työkalujen listasta

**Testin lopputilanne (End-State)**


* Testin ajon aikana käydään kaikki testiaskelet läpi ja lopputilanne on se,
* että ollaan palautettu vuokratun työkalun omistajalleen.


**Testin "tuomio"/tulos (Pass/Fail Criteria)**


* PASS Käyttäjää on palauttanut vuokratun työkalun onnistuneesti ja transaktio kirjautuu tr_completion tauluun mysql tietokannassa.
* FAIL Käyttäjä ei onnistunut palauttamaan työkalua.