<h1 align="center">Be-better</h1>

**Projektgruppe:** Kenan Pipic, Muhammet Altuntas

**Klasse:** 2 AHIF 

**Jahr:** 2025 



## Fotos mit Namen 

<table>
  <tr>
    <th>Kenan Pipic</th>
    <th>Muhammet Altuntas</th>
  </tr>
  <tr>
    <td><img src="KenanBild.jpg" width="300"/></td>
    <td><img src="MuhammetBild.png" width="300"/></td>
  </tr>
</table>

**Betreuer:** Lukas Diem 




## Kurzbeschreibung 
be Better ist eine WPF-basierte App, die dir hilft, dich in den Bereichen Fitness, Ernährung und Organisation gezielt zu verbessern. Mit täglichen Challenges wie z. B. „30 Liegestütze machen“ motiviert dich die App, kontinuierlich an dir zu arbeiten. Ob bessere Ernährung, mehr Bewegung oder strukturierter Alltag – be Better begleitet dich Schritt für Schritt auf deinem Weg zur besten Version deiner selbst.


## Screenshot-Collage
![Collage unserer App](BeBetterCollage.png)

## Relevanter Programmcode 
```sql 
if (File.Exists("Challenges.json"))
{
    string challangeDaten = File.ReadLines("Challenges.json").First();

    if (!string.IsNullOrWhiteSpace(challangeDaten))
    {
        if (Tag == heute)
        {
            Textblock_challange.Text = challangeDaten;
        }
        else
        {
            string neueChallenge = KICallenges(punkte);
            Textblock_challange.Text = neueChallenge;
            File.WriteAllText("Challenges.json", neueChallenge);
        }
    }
    else
    {
        string neueChallenge = KICallenges(punkte);
        Textblock_challange.Text = neueChallenge;
        File.WriteAllText("Challenges.json", neueChallenge);
    }
}
else
{
    string neueChallenge = KICallenges(punkte);
    Textblock_challange.Text = neueChallenge;
    File.WriteAllText("Challenges.json", neueChallenge);
}
```

- Dieser Code ist dafür zuständig, dass der User jeden Tag eine neue Challenge bekommt. Wenn bereits eine Challenge für den aktuellen Tag existiert, wird diese angezeigt.
Ansonsten wird über die Funktion KICallenges eine neue Challenge generiert (basierend auf dem Punktestand) und gespeichert.

## 1. Inhaltsverzeichnis

- [Kurzbeschreibung](#kurzbeschreibung)
- [Must-Have Features](#must-have)
- [Nice-to-Have Features](#nice-to-have)
- [Screenshots](#screenshots)
- [Fotos mit Namen](#fotos-mit-namen)
- [Relevanter Programmcode](#relevanter-programmcode)
- [Fazit](#fazit)


## 2. Projektzeitplan 

## Aufgabenverlauf - Muhammet Altuntas 

| Datum       | Aufgabe                                                                 | Bearbeiter | Status (%) |
|-------------|-------------------------------------------------------------------------|------------|------------|
| 14.05.2025  | Repositorie erstellen und mit Klassen angefangen                        | Muhammet   | 50%        |
| 16.05.2025  | Klassen einbauen                                                         | Muhammet   | 100%       |
| 21.05.2025  | KI einbauen – Fehlgeschlagen                                             | Muhammet   | 0%         |
| 24.05.2025  | KI-Klasse verbessert und simpler gemacht, aber speichert nicht ab        | Muhammet   | 70%        |
| 25.05.2025  | KI kann jetzt abspeichern                                                | Muhammet   | 97%        |
| 28.05.2025  | Interface für Fitnessplan erstellt                                       | Muhammet   | 70%        |
| 28.05.2025  | KI-Klasse etwas erweitert                                                | Muhammet   | 98%        |
| 03.06.2025  | Ernährungsplanerstellung erstellt und mit der KI-Klasse verbunden       | Muhammet   | 70%        |
| 03.06.2025  | Ernährung-Verzweigung gemacht                                            | Muhammet   | 100%       |
| 03.06.2025  | Ernährung-Diagramm angefangen und LiveCharts heruntergeladen            | Muhammet   | 10%        |
| 04.06.2025  | Versuch, Diagramm weiterzumachen, war nicht sehr erfolgreich             | Muhammet   | 30%        |
| 04.06.2025  | KI-Klasse verbessert und komplett fertiggestellt (funktioniert perfekt) | Muhammet   | 100%       |
| 06.06.2025  | Diagramm weitergearbeitet                                                | Muhammet   | 40%        |
| 07.06.2025  | Diagramm wird abgespeichert, aber kann nicht aufgerufen werden          | Muhammet   | 60%        |
| 08.06.2025  | Diagramm kann aufgerufen werden                                          | Muhammet   | 80%        |
| 09.06.2025  | Abspeicherung und Aufrufung verbessert                                   | Muhammet   | 99%       |
| 10.06.2025  | Änderung bei Mainwindow dass die Challanges rinpassen usw                | Muhammet   | 60%       |
| 11.06.2025  | KI windows desinged außer zurück button was kenan macht                  | Muhammet   | 100%       |
| 12.06.2025  | Rank, Punkte, Streak,challange gemacht                                   | Muhammet   | 80%       |
| 13.06.2025  | Die Buttons bei einzelne körperteile angepasst dass sie auf muskel sind  | Muhammet   | 100%       |
| 13.06.2025  | Rank Bilder eingabaut                                                    | Muhammet   | 100%       |
| 14.06.2025  | achivements eingebaut                                                    | Muhammet   | 100%       |
| 14.06.2025  | Tägliche challanges eingebaut                                            | Muhammet   | 100%       |
| 14.06.2025  | Änderung dass bein kcal diagramm man bei der x achse wochentage sieht    | Muhammet   | 100%       |

## Aufgabenverlauf – Kenan Pipic

| Datum       | Aufgabe                                                                                                                        | Bearbeiter   | Status (%) |
|-------------|--------------------------------------------------------------------------------------------------------------------------------|--------------|------------|
| 10.05.2025  | Main- Menü mit Sidebar, Icons und modernem Design erstellt (Video-Inspiration)                                                 | Kenan Pipic  | 100%       |
| 14.05.2025  | Choose-Menü mit Buttons zu Trainingsplan und Körpertraining erstellt                                                           | Kenan Pipic  | 100%       |
| 21.05.2025  | Mensch (KI-Erstellt) + Textboxen im Menü für Körperteile eingefügt                                                             | Kenan Pipic  | 70%        |
| 28.05.2025  | Textbox-Hovereffekte und GIFs ausprobiert                                                                                      | Kenan Pipic  | 50%        |
| 04.06.2025  | Einzelkörperteil-Menü begonnen (Start: Bizeps) mit eigenem UserControl umgesetzt                                               | Kenan Pipic  | 80%        |
| 05.06.2025  | Bizeps, Trizeps und Bauchmuskel mit GIFs umgesetzt – Nutzungsrechte eingeholt                                                  | Kenan Pipic  | 100%       |
| 06.06.2025  | Weitere Trainingsbereiche (Schulter, Brust) umgesetzt – GIF-Erlaubnisse eingeholt                                              | Kenan Pipic  | 100%       |
| 07.06.2025  | Kalender mit Syncfusion Scheduler integriert – zur Anzeige und Planung von Terminen und Trainings                              | Kenan Pipic  | 100%       |
| 11.06.2025  | UserControl gestaltet, das Kalendereinträge im MainWindow anzeigt                                                              | Kenan Pipic  | 80%        |
| 11.06.2025  | Schedule- und GlobalSchedule-Klasse erstellt – zum speichern der Termine                                                       | Kenan Pipic  | 100%       |
| 12.06.2025  | Kalender-Einträge im MainWindow anzeigen und korrekt speichern                                                                 | Kenan Pipic  | 100%       |
| 13.06.2025  | GUI für Kalorienzähler gestaltet – Eingabefeld und Oberfläche erstellt                                                         | Kenan Pipic  | 100%       |
| 14.06.2025  | Hinweis „Im Moment keine Termine“ eingebaut, wenn keine Kalenderdaten vorhanden sind                                           | Kenan Pipic  | 100%       |
| 14.06.2025  | Einzelkörperteile erweitert → Bein Training                                                                                    | Kenan Pipic  | 100%       |


## 3. Lastenheft (Kurzbeschreibung, Funktionsumfang, Skizzen)
### 2.1 Kurzbeschreibung 
- Be Better ist eine Desktop-Anwendung, die Nutzer motiviert, sich in den Bereichen Fitness, Ernährung und Organisation zu verbessern.
Die App bietet tägliche Challenges, Trainingspläne, eine Kalorienübersicht und einen Wochenkalender zur Planung.
Durch Belohnungssysteme wie Streaks, Punkte und Abzeichen bleibt der Nutzer langfristig motiviert.

### 2.2. Skizzen

### Menü
**Beschreibung:** Das Hauptmenü ermöglicht die Navigation zu den Bereichen „Fitness“, „Ernährung“, „Organisation“ und "Gespeichert".
![Menü](Menü.png)  

### Choose-Menü
**Beschreibung:** Von hier wählt der Nutzer, ob er einen Trainingsplan erstellen oder einzelne Körperteile trainieren möchte.
![Choose-Menü](ChooseMenü.png)  

### Einzelne Körperteile trainieren
**Beschreibung:** Eine visuelle Übersicht mit Menschengrafik – Buttons auf den Körperteilen öffnen gezielte Trainingsansichten.
![EinzelneKörperteileTrainieren](EinzelneKörperteileTrainieren.png)  


### Trainingsplan erstellen
**Beschreibung:** Ermöglicht dem Nutzer, einen individuellen Trainingsplan aus Übungen zusammenzustellen.
![TrainingsplanErstellen](TrainingsplanErstellen.png)  


### Essensplan erstellen
**Beschreibung:** Hier können Mahlzeiten für einzelne Tage eingetragen werden – unterstützt durch Vorschläge.
![EssenPlanErstellen](EssenPlanErstellen.png)  


### Kalorieneingabe und Auswertung
**Beschreibung:** Eine grafische Darstellung zeigt, wie viele Kalorien pro Tag aufgenommen wurden.
![GrafikKalorien](GrafikKalorien.png)  




### Kalenderansicht
**Beschreibung:** Übersicht über geplante Aktivitäten, erstellt mit dem Syncfusion Scheduler.
![Kalender](Kalender.png)  


## 2.3. Funktionsumfang



### Must-Have-Funktionen

| Funktion                       | Beschreibung                                                                 |
|-------------------------------|------------------------------------------------------------------------------|
| Trainingsplan nach Körperteil | Nutzer kann gezielt für bestimmte Körperteile Übungen auswählen und planen. |
| Fitnessplan                   | Der Nutzer erhält strukturierte Trainingsübersichten mit ausgewählten Übungen. |
| Ernährung eingeben/anpassen   | Kalorien und Mahlzeiten werden manuell eingetragen und angepasst.            |
| Tägliche Challenges           | Jeden Tag wird automatisch eine neue Fitness-Challenge angezeigt.            |
| Winstreak                     | Wird eine Challenge erfolgreich abgeschlossen, erhöht sich der Streak.       |
| Punkte durch Challenges       | Für abgeschlossene Challenges bekommt der Nutzer Punkte.                     |
| Rangsystem                    | Je nach Punktestand wird ein Rang (z. B. Bronze, Silber, Diamant) vergeben.  |
| Kalorien-Diagramm             | Zeigt an, wie viele Kalorien pro Tag gegessen wurden.                        |
| Abzeichen                     | Der Nutzer erhält bei besonderen Erfolgen visuelle Auszeichnungen.           |

---

### Nice-to-Have-Funktionen

| Funktion                              | Beschreibung                                                                 |
|--------------------------------------|------------------------------------------------------------------------------|
| Soziale Medien                       | Möglichkeit, Bilder oder Erfolge mit anderen zu teilen.                      |
| Foto-Kalorien-Erkennung              | Nutzer kann ein Bild vom Essen machen, KI schätzt die Kalorien.             |
| KI-Challengeprüfung                  | KI erkennt, ob die Challenge wirklich gemacht wurde.                         |
| Körper-Fortschrittsdokumentation     | Jede Woche wird ein Foto gespeichert, um Fortschritt zu sehen.              |
| Zweite Chance (Power-Up)             | Mit Punkten kann man verlorene Streaks zurückkaufen.                         |
| Mehrsprachigkeit                     | App ist umschaltbar zwischen Deutsch und Englisch.                           |
| Erinnerungen & Push-Nachrichten      | Die App erinnert automatisch an Trainings oder Challenges.                   |
| Finanzübersicht                      | Überblick über Einnahmen, Ausgaben und Spartipps.                            |
| Nutzerkonto                          | Möglichkeit zur Registrierung und Anmeldung.                                |
| Wochenplan-Organisation              | Nutzer kann seinen Tages-/Wochenplan individuell gestalten.                  |

### Zusammenfassung

Die wichtigsten Funktionen konnten wir gut umsetzen. Einige Nice-to-Have-Ideen wie Social Media oder die KI-Fotoauswertung waren aber viel zu aufwendig.  
Gerade die Bildauswertung mit KI hätte mehr Zeit und Wissen gebraucht, als wir zur Verfügung hatten.  
Im Nachhinein haben wir gemerkt, dass wir uns bei manchen Ideen ein bisschen zu viel vorgenommen haben.

## 4. Pflichtenheft 
### 4.1	Interner Programmaufbau (Programmlogik)

**schedule.cs:** verwaltet eine Liste von Terminen und erlaubt das Hinzufügen, Entfernen sowie Speichern und Laden dieser Termine.
|                                Schedule.cs                             |
|------------------------------------------------------------------------|
| + ObservableCollection<ScheduleAppointment>                            |
|------------------------------------------------------------------------|
| + Schedule()                                                           |
|------------------------------------------------------------------------|
| + AddTermin(ScheduleAppointment: termin) void                          |
| + RemoveTermin(ScheduleAppointment: termin) void                       |
| + GetAlleTermine()  ObservableCollection<ScheduleAppointment>          |
| + SaveToFile(string: path)  void                                       |
| + LoadFromFile(string: path) void                                      |

**SerializableAppointment.cs** ist eine einfache Hilfsklasse, die Termine in speicherbare Form bringt, damit sie z. B. als JSON gespeichert werden können.
|                      SerializableAppointment.cs                      |
|----------------------------------------------------------------------|
| + string Subject                                                     |
| + DateTime StartTime                                                 |
| + DateTime EndTime                                                   |
| + string Location                                                    |

**GlobalSchedule.cs:** stellt das zentrale Schedule-Objekt bereit, auf das alle Fenster der App gemeinsam zugreifen können.

|                         GlobalSchedule.cs                            |
|----------------------------------------------------------------------|
| + static Schedule SharedSchedule                                     |

**Kalorienanzhalprotag.cs** Ist da dass ich besser die Kalorien abspeichern kann die rausgelesn werden

|                       Kalorienanzhalprotag.cs                        |
|----------------------------------------------------------------------|
| + int Tag1                                                           |
| + int Tag2                                                           |
| + int Tag3                                                           |
| + int Tag4                                                           |
| + int Tag5                                                           |
| + int Tag6                                                           |
| + int Tag7                                                           |
| + DateOnly Tag                                                       |
|----------------------------------------------------------------------|
| + void DeserializeFromCsv(string Data)                               |

**KIKlasse.cs** Ist da dass man Mit KI interagieren kann und die antwort abspeichern kann

|                              KIKlasse.cs                             |
|----------------------------------------------------------------------|
| + void DeserializeFromCsv(string Data)                               |

**TrainingsData.cs** Ist eine Klasse wo ich die Inzelnen Trainingsübunden unterteilen kann in 3 verschiedenen Gruppen

|                           Trainingsdata.cs                           |
|----------------------------------------------------------------------|
| + List<string> repetitive                                            |
| + List<string> shortDuration                                         |
| + List<string> longDuration                                          |





### 4.2 Umsetzungsdetails
- Bei der Umsetzung der Terminverwaltung wurde zunächst die Klasse Schedule erstellt.
Eine Herausforderung war das Speichern von ScheduleAppointment-Objekten, da diese nicht direkt serialisierbar sind.
Dieses Problem wurde gelöst, indem die Hilfsklasse SerializableAppointment eingeführt wurde, die nur primitive Datentypen enthält.
Beim Laden werden die gespeicherten Daten wieder in echte Termine umgewandelt.
Zusätzlich wurde mit GlobalSchedule eine zentrale Zugriffsstelle geschaffen, damit alle Fenster dieselben Daten verwenden.
 
### 4.3 Ergebnisse, Interpretation (Tests)
**Wie läuft das Programm?**

Das Programm läuft im Großen und Ganzen stabil.  
Die wichtigsten Funktionen wie tägliche Challenges, Kalorieneingabe, Trainingsplanerstellung und der Kalender funktionieren zuverlässig.  
Auch das Punktesystem und die Streak-Anzeige reagieren wie erwartet.

**Welche Schwachstellen hat es?**
- Die Muskelbereiche im Einzelkörper-Menü sind nicht sehr genau positioniert – Buttons liegen teilweise nicht exakt über dem jeweiligen Muskel, was die Benutzerfreundlichkeit einschränkt.


## 5. Anleitung

### 5.1 Installationsanleitung

| NuGet-Paket             | Zweck der Verwendung                            |
|-------------------------|--------------------------------------------------|
| **Serilog**             | Logging und Fehlerprotokollierung                |
| **LiveCharts**          | Anzeige von Diagrammen (z. B. Kalorienverlauf)   |
| **OpenAI**              | Kommunikation mit der KI für Challenge-Generierung |
| **Syncfusion.SFSchedule** | Kalender-Darstellung für Wochenplanung         |
| **WPFAnimated**         | Anzeige animierter GIFs bei den Übungen         |
| **Newtonsoft.Json**     | Speicherung und Laden von Daten als JSON        |

Datei für API-Key(Settings.settings) unter Properties abspeichern



### 5.2 Bedienungsanleitung 

Die App ist einfach zu bedienen und für Einsteiger verständlich:

1. **App starten:** Die Anwendung öffnet sich im Hauptmenü.
2. **Bereich auswählen:**  
   - **Fitness**: Trainingsplan erstellen oder einzelne Körperteile trainieren  
   - **Ernährung**: Kalorien eingeben, Essenspläne erstellen  
   - **Organisation**: Kalender zur Wochenplanung nutzen
3. **Challenge sehen:** Jeden Tag wird automatisch eine neue Challenge angezeigt.
4. **Streak & Punkte:** Wird eine Challenge abgeschlossen, erhält man Punkte und die Streak steigt.
5. **Speichern & Laden:** Fortschritt wird automatisch gespeichert (z. B. Punkte, Pläne).
6. **Kalorien verfolgen:** Im Diagramm sieht man, wie viele Kalorien man an den letzten Tagen aufgenommen hat.


## 6. Bekannte Bugs, Probleme

### Noch bestehende Probleme:

