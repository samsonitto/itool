# CODE001 - työkalun ylikirjoitus

CODE002 käytetään silloin kun käyttäjä halua poistaa työkalun ja kaikki sen tiedot tietokannasta. Relaatiotietokannasta on vaikeata poistaa tiedot sellaisesta taulusta,
jonka primary key on käytetty muissa tauluissa viiteavaimena aj työkalun ID:n säilyttäminen on tärkeätä transaktiohistorian kannalta. Kaikki muut kentät ylikirjoitetaan, paitsi toolID, toolCategoryID ja userOwnerID.

### Esimerkki

```sql
mysql> SELECT * FROM tool WHERE toolName = 'CODE002';
+--------+----------+-----------------+-----------+---------------+----------------+-------------+-------------+
| toolID | toolName | toolDescription | toolPrice | toolCondition | toolCategoryID | userOwnerID | toolPicture |
+--------+----------+-----------------+-----------+---------------+----------------+-------------+-------------+
|     83 | CODE002  | TOOL DELETED    |      0.00 | DELETED       |              9 |           1 | NULL        |
|    175 | CODE002  | TOOL DELETED    |      0.00 | DELETED       |              6 |          30 | NULL        |
+--------+----------+-----------------+-----------+---------------+----------------+-------------+-------------+
```