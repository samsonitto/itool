# CODE001 - user tunnuksen ylikirjoitus

CODE001 käytetään silloin kun käyttäjä halua poistaa oman tunnuksen ja kaikki tiedot tietokannasta. Relaatiotietokannasta on vaikeata poistaa tiedot sellaisesta taulusta,
jonka primary key on käytetty muissa tauluissa foreign key:na ja kyseisen taulun tiedon (userID) säilyttäminen on tärkeä transaktiohistorian kannalta. Kaikki muut kentät
ylikirjoitetaan, paitsi userID.

### Esimerkki
```sql
 SELECT * FROM user WHERE userName = 'CODE001';
+--------+----------+-----------------+-------------+-----------+--------------+---------------+------------+----------------------------------+-------------+
| userID | userName | userSurname     | userAddress | userEmail | userLocation | paymentMethod | userMobile | userPassword                     | userPicture |
+--------+----------+-----------------+-------------+-----------+--------------+---------------+------------+----------------------------------+-------------+
|     26 | CODE001  | PROFILE DELETED | DELETED     | DELETED   | DELETED      | DELETED       | 0          | 6cd5f3e6d5f285f82ec3c351faa42294 | NULL        |
|     30 | CODE001  | PROFILE DELETED | DELETED     | DELETED   | DELETED      | DELETED       | 0          | 0060c2455b7c36897634ae1e9fe73889 | NULL        |
+--------+----------+-----------------+-------------+-----------+--------------+---------------+------------+----------------------------------+-------------+
```