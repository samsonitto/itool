# "Työkalun lisääminen / poisto" ominaisuuden hyväksyntätesti

| | |
|:-:|:-:|
| Testitapauksen kuvaus | Kelpuutetaan käyttäjällä jos käyttäjä pystyy lisäämään ja poistamaan työkaluja |
| Testitapaus ID | AT02 |
| Testitapauksen suunnittelija | Samson Azizyan | 
| Testitapauksen hyväksyjä: | Samson Azizyan |
| Luontipvm | 6.4.2019 |
| Luokitus | Hyväksyntätesti / Acceptance Test |

**Päivityshistoria**

* versio 0.1 

**Testin kuvaus / tavoite**

* Lisätään työkalu tietokantaan ja sen jälkeen poistetaan työkalu tietokannasta.

**Linkit vaatimuksiin tai muihin lähteisin**

* [ Ominaisuus: Lisää / Poista työkalu](f2_tools.md)

**Testin alkutilanne (Pre-state)** 

* Profiili-ikkuna auki, omien työkalujen lista näkyvillä

**Testiaskeleet (Test Steps)**

1. Klikataan "Add a tool" painiketta
2. AddTool ikkuna aukee
3. Täytetään kentät ja valitaan kuva omalta päätelaitteesta
4. Klikataan "Complete" painiketta
5. AddTool ikkuna sulkeutuu
6. Uusi työkalu näkyy datagridissa
7. Valitaan uusi työkalu
8. Kliktaan "Delete" painiketta
9. Varmistus ikkuna aukee
10. Klikataan "Yes"
11. Työkalu ei näy enää datagridissa

**Testin lopputilanne (End-State)**


* Testin ajon aikana käydään kaikki testiaskelet läpi ja lopputilanne on se,
* että meidän lisäämä työkalu on poistettu tietokannasta


**Testin "tuomio"/tulos (Pass/Fail Criteria)**


* PASS Työkalun lisääminen ja poistaminen onnistuu
* FAIL Työkalun lisääminen tai poistaminen epäonnistuu