# TOWER DEFENSE THE GAME BY AAAA
Asimetrinis bokštų gynimo žaidimas kur vienas žaidėjas gyna miestą statant bokštus, o kitas atakuoja miestą siunčiant priešu bangas.


Technologijos:
=============
- C# kalba
- ASP.NET karkasas
- SignalR biblioteka

Reikalavimai
=============
- Paspaudus atitinkamo bokšto ikoną ir pasirinkus atitinkamą vietovę paspaudus bokštas pastatomas.  
- Paspaudus atitinkamo priešo ikoną priešas iškviečiamas kelio pradžioje ir keliauja link galutinio tikslo.
- Bokštai automatiškai puola priešus.
- Žaidėjai turi galimybę aktyvuoti pastiprinimo bei pasilpninimo efektus.
- Gynėjas pasirinkęs blokados ikoną gali ją pastatyti ant kelią.
- Priešai priėję prie blokados ją atakuoja.
- Kai priešas pasiekia galą gynėjas praranda atitinkam1 kiekį gyvybių.
- Praėjus 5-ioms minutėms nuo žaidimo pradžios jei gynėjas turi gyvybių gynėjas laimi.
- Kai vienas iš žaidėjų laimi yra išmetamas revanšo mygtukas, jei abu žaidėjai sutinka su revanšu yra pereinama į kitą lygį.
- Žaidimo pradžioje automatiškai parenkamas vienas iš keletos žemėlapių.
- Kai priešas nudvėsta jis prideda gynėjui atitinkamą pinigų kiekį.
- Kas 15 sekundčių puolėjas gauną po 100 pinigų.
- Gynėjas pradeda žaidimą su 500 pinigų.
- Gynėjas pradeda su 150 gyvybių.


Priešai, bokštai ir žemėlapiai
=============
- Pirmasis priešų tipas turi 50 gyvybių ir 20 atakos taškų.
- Antrasis priešo tipas turi 15 gyvybių taškų ir 3 atakos taškus, jis taip pat ir gydo aplink jį esančius sąjungininkus.
- Trečiasis priešo tipas turi 2 gyvybių taškus ir 0 atakos taškų, jis kiekvieną sekundę kol nemiršta generuoja 3.1452 pinigų puolėjui.- 

- Pirmasis bokšto tipas kainuoja 150 pinigų ir atakuoja vienas šūvis per sekundę greičiu arčiausiai esantį prieša.
- Antrasis bokšto tipas kainuoja 450 pinigų ir atakuoja kas 3 sekundes visus jo diapazone esančius priešus.
- Trečiasis bokšto tipas kainuoja 999 pinigų kol jis aktyvus gynėjas gauna 15 pinigų per sekundę.- 

- Pirmasis žemėlapis turi paprastą topologija.
- Antrasis žemėlapis turi keletą vandens telkinių kur gynėjas negali dėti bokštų.
- Trečiasis žemėlapis turi vietas kur priešai palėtėja.

Panaudojimo atvejų diagrama
=============
![image](files://C:/Users/arnas/Desktop/Model.jpg)