Module MainModule

    ' ============================
    ' Structures
    ' ============================
    Structure Benutzer
        Public UserID As String
        Public Name As String
    End Structure

    Structure Buch
        Public ISBN As String
        Public Title As String
        Public Author As String
        Public Status As String
    End Structure

    ' ============================
    ' Listen für Testdaten
    ' ============================
    Dim BenutzerListe As New List(Of Benutzer)
    Dim BuchListe As New List(Of Buch)

    ' ============================
    ' MAIN
    ' ============================
    Sub Main()

        ' Testdaten laden
        LadeTestdatenBenutzer()
        LadeTestdatenBuecher()

        Dim running As Boolean = True

        While running
            Console.Clear()
            Console.WriteLine("===============================================================")
            Console.WriteLine("   Bibliothekssystem DHBW Ravensburg Campus Friedrichshafen    ")
            Console.WriteLine("===============================================================")
            Console.WriteLine()
            Console.WriteLine("1) Neuen Benutzer anlegen")
            Console.WriteLine("2) Alle Bücher anzeigen")
            Console.WriteLine("3) Alle Benutzer anzeigen")
            Console.WriteLine("4) Buch ausleihen (über ISBN)")
            Console.WriteLine("5) Buch zurückgeben (über ISBN)")
            Console.WriteLine("6) Ausgeliehene Bücher eines Benutzers anzeigen")
            Console.WriteLine("0) Programm beenden")
            Console.WriteLine()
            Console.Write("Bitte wählen Sie eine Option: ")

            Dim input As String = Console.ReadLine()
            Console.WriteLine()

            Select Case input
                Case "1"
                    Console.WriteLine(">> Funktion: Neuen Benutzer anlegen (noch nicht implementiert)")

                Case "2"
                    AlleBuecherAnzeigen()

                Case "3"
                    AlleBenutzerAnzeigen()

                Case "4"
                    Console.WriteLine(">> Funktion: Buch ausleihen (noch nicht implementiert)")

                Case "5"
                    Console.WriteLine(">> Funktion: Buch zurückgeben (noch nicht implementiert)")

                Case "6"
                    Console.WriteLine(">> Funktion: Ausgeliehene Bücher eines Benutzers anzeigen (noch nicht implementiert)")

                Case "0"
                    Console.WriteLine("Programm wird beendet...")
                    running = False

                Case Else
                    Console.WriteLine("Ungültige Eingabe. Bitte erneut versuchen.")
            End Select

            If running Then
                Console.WriteLine()
                Console.WriteLine("Drücken Sie eine Taste, um zum Hauptmenü zurückzukehren...")
                Console.ReadKey()
            End If

        End While

    End Sub


    ' ============================================
    ' FUNKTION: Benutzer anzeigen
    ' ============================================
    Sub AlleBenutzerAnzeigen()
        Console.WriteLine("=== Alle Benutzer ===")

        For Each ben In BenutzerListe
            Console.WriteLine($"{ben.UserID} - {ben.Name}")
        Next
    End Sub


    ' ============================================
    ' FUNKTION: Bücher anzeigen
    ' ============================================
    Sub AlleBuecherAnzeigen()
        Console.WriteLine("=== Alle Bücher ===")

        For Each buch In BuchListe
            Console.WriteLine($"{buch.ISBN} | {buch.Title} | {buch.Author} | Status: {buch.Status}")
        Next
    End Sub


    ' ============================================
    ' TESTDATEN: Benutzer laden
    ' ============================================
    Sub LadeTestdatenBenutzer()

        Dim usrTestData As String =
            "U001;Max Mustermann|" &
            "U002;Erika Musterfrau|" &
            "U003;Hans Meier|" &
            "U004;Laura Schmidt"

        Dim userEntries() As String = usrTestData.Split("|"c)

        For Each entry In userEntries
            If entry.Trim() <> "" Then
                Dim parts() As String = entry.Split(";"c)
                Dim neu As New Benutzer With {
                    .UserID = parts(0),
                    .Name = parts(1)
                }
                BenutzerListe.Add(neu)
            End If
        Next

    End Sub


    ' ============================================
    ' TESTDATEN: Bücher laden
    ' ============================================
    Sub LadeTestdatenBuecher()

        Dim libraryTestData As String =
            "978-3-16-148410-0;Einführung in die Informatik;Müller;verfügbar|" &
            "978-0-13-110362-7;Programmieren mit VB.NET;Schneider;verfügbar|" &
            "978-3-540-69006-6;Grundlagen der Softwaretechnik;Meier;ausgeliehen|" &
            "978-3-642-05445-3;Datenstrukturen und Algorithmen;Klein;verfügbar"

        Dim bookEntries() As String = libraryTestData.Split("|"c)

        For Each entry In bookEntries
            If entry.Trim() <> "" Then
                Dim parts() As String = entry.Split(";"c)
                Dim neu As New Buch With {
                    .ISBN = parts(0),
                    .Title = parts(1),
                    .Author = parts(2),
                    .Status = parts(3)
                }
                BuchListe.Add(neu)
            End If
        Next

    End Sub

End Module


