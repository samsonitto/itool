# "Kommentoiminen" ominaisuuden hyväksyntätesti


| | |
|:-:|:-:|
| Testitapauksen kuvaus | Kelpuutetaan käyttäjällä, jos käyttäjä pystyy kommentoimaan sekä työkaluja että muita kommeteja  |
| Testitapaus ID | AT05 |
| Testitapauksen suunnittelija | Samson Azizyan | 
| Testitapauksen hyväksyjä: | Samson Azizyan |
| Luontipvm | 6.4.2019 |
| Luokitus | Hyväksyntätesti / Acceptance Test |

**Päivityshistoria**

* versio 0.1 

**Testin kuvaus / tavoite**

* Yritetään kommentoida työkalua ja kommettia.

**Linkit vaatimuksiin tai muihin lähteisin**

* Ominaisuus: [Kommentoiminen](f5_comment.md)

**Testin alkutilanne (Pre-state)** 

* MainPage ikkuna auki, saatavilla olevien työkalujen lista auki

**Testiaskeleet (Test Steps)**

1. Valitaan työkalu listasta
2. Klikataan Comment painiketta
3. Kirjoitetaan kommentti
4. Klikataan kommentin alla olevaa Reply painiketta
5. Kirjoitetaan vastaus kommenttiin
6. Suljetaan ikkuna

**Testin lopputilanne (End-State)**


* Testin ajon aikana käydään kaikki testiaskelet läpi ja lopputilanne on se,
* että ollaan kommentoitu sekä työkalua että omaa kommenttiä


**Testin "tuomio"/tulos (Pass/Fail Criteria)**


* PASS Käyttäjä on jättänyt kommentin ja vastauksen kommenttiin onnistuneesti.
* FAIL Käyttäjä epäonnistui jättämään joko kommentin tai vastauksen kommenttiin.