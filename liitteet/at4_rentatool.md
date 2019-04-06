# "Asiakaspalvelu" ominaisuuden hyväksyntätesti

| | |
|:-:|:-:|
| Testitapauksen kuvaus | Kelpuutetaan käyttäjällä jos käyttäjä pystyy vuokraamaan työkaluja |
| Testitapaus ID | AT03 |
| Testitapauksen suunnittelija | Samson Azizyan | 
| Testitapauksen hyväksyjä: | Samson Azizyan |
| Luontipvm | 6.4.2019 |
| Luokitus | Hyväksyntätesti / Acceptance Test |

**Päivityshistoria**

* versio 0.1 

**Testin kuvaus / tavoite**

* Yritetään vuokrata työkalu

**Linkit vaatimuksiin tai muihin lähteisin**

* Ominaisuus: [Ominaisuus: Vuokraaminen](f6_rentatool.md)

**Testin alkutilanne (Pre-state)** 

* MainPage auki, lista saavilla olevista työkaluista on esillä, työkalu on valittuna

**Testiaskeleet (Test Steps)**

1. Määritetään moneksi päiväksi halutaan vuokrata työkalu
2. Klikataan "Rent a tool" painiketta
3. Työkalu häviää saatavilla olevista työkaluiden listasta
4. Avataan Profiili-ikkuna
5. Työkalu näkyy omassa "Vuokratut työkalut listalla"

**Testin lopputilanne (End-State)**


* Testin ajon aikana käydään kaikki testiaskelet läpi ja lopputilanne on se,
* että ollaan onnistuneesti vuokrattu työkalu.


**Testin "tuomio"/tulos (Pass/Fail Criteria)**


* PASS Työkalun vuokraaminen onnistuu
* FAIL Työkalun vuokraaminen epäonnistuu