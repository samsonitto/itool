# TTOS0300 (Käyttöliittymäohjelmointi) Kurssin harjoitustyö - iTool

## Tekijä

* Samson Azizyan
* M3156 
* Versionumero 0.1


## Sisällysluettelo 


* [Sovelluksen yleiskuvaus](#sovelluksen-yleiskuvaus)
* [Kohdeyleisö](#kohdeyleisö)
* [Käyttöympäristö ja käytetyt teknologiat](#käyttöympäristö-ja-käytetyt-teknologiat)
* [Käyttäjäroolit](#käyttäjäroolit)
* [Ominaisuudet](#ominaisuudet)
* [Käyttötapaukset](#toiminnallisia-vaatimuksia)
* [Hyväksyntätestit](#hyväksyntätestit)
* [Käsitemalli](#tärkeimmät-käyttötapaukset-general-use-cases)
* [Luokkakaavio](#palvelu-mockup-prototyyppi)
* [Työnjako](#tärkeimmät-tunnistetut-ominaisuudetpiirteet-features)
* [Työaikasuunnitelma](#käyttäjätarinat)

# Sovelluksen yleiskuvaus

Tarkoituksena on suunnitella ja toteuttaa työkaluvuokraussovelluksen prototyyppi,
joka aluksi toimisi vain paikallisesti. Vuokrausmenetelmä toimisi samalla periaatteella kun
Über-sovelluksen kyytipalvelu eli jokainen käyttäjä voi vuokrata jokaisen käyttäjän vuokralle
asettamat työkalut, työkalun omistajan hintapyynnön mukaan. Käyttäjät pystyy kommentoimaan työkaluja
ja antaa 1-5 arvion käyttäjistä, joiden kanssa on suorittanut transaction.

# Kohdeyleisö

Kohdeyleisö on kaikki henkilöt, joilla ei ole monipuolista työkalukokoelmaa. Eli todennäköisesti
kaupungeissa asuvat ihmiset.

# Käyttöympäristö ja käytetyt teknologiat

* Microsoft Windows (Käyttöympäristö)
* Visual Studio 2017
* WPF
* C#
* MySql

# Käyttäjäroolit

## Asiakas

Asiakas käyttää sovellusta vuoratakseen tai laittakseen vuokralle työkaluja.

## Ylläpitäjä

Ylläpitäjä ylläpitää palvelua ja pitää huolta siitä, että työkaluja myöhässä palauttaneiden käyttäjätilit
laitetaan joko jäähylle tai jäädytetään kokonaan.

# Ominaisuudet

| Tunnus | Ominaisuus | Prioriteetti | Muuta |
| :-: | :-: | :-: | :-: |
| FT01 | [ Tunnusten luominen ja kirjautuminen](liitteet/f1_login.md) | Pakollinen | |
| FT02 | [ Lisää/poistaa työkalu ](liitteet/f2_tools) | Pakollinen | |
| FT03 | [ Tunnusten poistaminen](liitteet/f3_delete_account.md) | Pakollinen | |
| FT04 | [ Mahdollisuus arvioida käyttäjiä ](liitteet/f4_rating.md) | Nice to Have | |
| FT05 | [ Työkalujen kommentointi ](liitteet/f5_comment.md) | Nice to Have | |
| FT06 | [ Työkalujen vuokraaminen ](liitteet/f6_rentatool.md) | Pakollinen | |

# Käyttötapaukset

## Tunnusten luominen ja kirjautuminen

```plantuml
@startuml
    Käyttäjä --> (Tunnusten luominen)
    Käyttäjä --> (Kirjautuminen)
@enduml
```
**Käyttötapauksen kuvaus**

1. Käyttäjä luo tunnukset
2. Käyttäjä kirjautuu palveluun

**Poikkeukset**
 
* P1 Käyttäjä ei täyttänyt kaikki kentät oikein, saa virheilmoituksen
* P2 Käyttäjä ei muista salasanaa, ottaa yhteyttä ylläpitoon
	
**Lopputulos**	

* Asiakas on luonut tunnukset ja on päässyt kirjautumaan iTool sovellukseen

**Käyttötiheys** 

* Tunnusten luominen: Kerran per sähköposti
* Kirjautuminen: rajaton

## Työkalujen selailu, vuokraus ja palautus

```plantuml
@startuml
    Käyttäjä --> (Työkalujen selailu)
    Käyttäjä --> (Työkalun vuokraus)
    Käyttäjä --> (Työkalun palautus)
    :Työkalunomistaja: --> (Työkalun vuokraus)
    :Työkalunomistaja: --> (Työkalun palautus)
@enduml
```