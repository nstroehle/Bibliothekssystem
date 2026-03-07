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
    ' Listen für Benutzer und Bücher
    ' ============================
    Dim BenutzerListe As New List(Of Benutzer)
    Dim BuchListe As New List(Of Buch)

    ' ============================
    ' MAIN
    ' ============================
    Sub Main()

        LadeBenutzerCSV()
        LadeBuecherCSV()

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

            Dim input As String = Console.ReadLine().Trim()
            Console.WriteLine()

            If input = "" Then
                Console.WriteLine("Leere Eingabe ist ungültig.")
            Else
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
                        Console.WriteLine(">> Funktion: Ausgeliehene Bücher anzeigen (noch nicht implementiert)")

                    Case "0"
                        Console.WriteLine("Programm wird beendet...")
                        running = False

                    Case Else
                        Console.WriteLine("Ungültige Auswahl. Bitte nur Zahlen von 0 bis 6 eingeben.")
                End Select
            End If

            If running Then
                Console.WriteLine()
                Console.WriteLine("Drücken Sie eine Taste, um zum Menü zurückzukehren...")
                Console.ReadKey()
            End If

        End While

    End Sub

    ' ============================
    ' AUSGABE FUNKTIONEN
    ' ============================
    Sub AlleBenutzerAnzeigen()
        Console.WriteLine("=== Alle Benutzer ===")
        For Each ben In BenutzerListe
            Console.WriteLine(ben.UserID & " - " & ben.Name)
        Next
    End Sub

    Sub AlleBuecherAnzeigen()
        Console.WriteLine("=== Alle Bücher ===")
        For Each buch In BuchListe
            Console.WriteLine(buch.ISBN & " | " & buch.Title & " | " & buch.Author & " | Status: " & buch.Status)
        Next
    End Sub

    ' ============================
    ' CSV DATEN LADEN – Benutzer
    ' ============================
    Sub LadeBenutzerCSV()

        BenutzerListe.Add(New Benutzer With {.UserID = "U001", .Name = "Max Johnson"})
        BenutzerListe.Add(New Benutzer With {.UserID = "U002", .Name = "Emily Smith"})
        BenutzerListe.Add(New Benutzer With {.UserID = "U003", .Name = "Daniel Brown"})
        BenutzerListe.Add(New Benutzer With {.UserID = "U004", .Name = "Laura Wilson"})
        BenutzerListe.Add(New Benutzer With {.UserID = "U005", .Name = "Michael Taylor"})
        BenutzerListe.Add(New Benutzer With {.UserID = "U006", .Name = "Sarah Anderson"})
        BenutzerListe.Add(New Benutzer With {.UserID = "U007", .Name = "James Miller"})
        BenutzerListe.Add(New Benutzer With {.UserID = "U008", .Name = "Anna Davis"})
        BenutzerListe.Add(New Benutzer With {.UserID = "U009", .Name = "Robert Clark"})
        BenutzerListe.Add(New Benutzer With {.UserID = "U010", .Name = "Linda Moore"})
        BenutzerListe.Add(New Benutzer With {.UserID = "U011", .Name = "Thomas Martin"})
        BenutzerListe.Add(New Benutzer With {.UserID = "U012", .Name = "Jessica Thompson"})
        BenutzerListe.Add(New Benutzer With {.UserID = "U013", .Name = "Kevin White"})
        BenutzerListe.Add(New Benutzer With {.UserID = "U014", .Name = "Rachel Harris"})
        BenutzerListe.Add(New Benutzer With {.UserID = "U015", .Name = "Steven Lewis"})

    End Sub

    ' ============================
    ' CSV DATEN LADEN – Bücher
    ' ============================
    Sub LadeBuecherCSV()

        BuchListe.Add(New Buch With {.ISBN = "978-0-13-110362-7", .Title = "Introduction to Programming", .Author = "John Smith", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-0-201-03801-9", .Title = "Data Structures Basics", .Author = "Alice Brown", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-0-262-03384-8", .Title = "Algorithms Explained", .Author = "Thomas White", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-0-321-48681-3", .Title = "Software Engineering Fundamentals", .Author = "Emily Johnson", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-1-491-94600-8", .Title = "Learning VB.NET", .Author = "Michael Green", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-0-596-52068-7", .Title = "Clean Code", .Author = "Robert Martin", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-0-13-235088-4", .Title = "Agile Development", .Author = "James Wilson", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-1-59327-584-6", .Title = "Programming Logic", .Author = "Sarah Miller", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-0-201-70073-2", .Title = "Computer Systems", .Author = "David Lee", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-0-321-12742-6", .Title = "Object-Oriented Design", .Author = "Laura Clark", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-0-07-352332-3", .Title = "Engineering Mathematics", .Author = "Peter Adams", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-0-262-16209-8", .Title = "Discrete Mathematics", .Author = "Brian Scott", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-1-118-09387-9", .Title = "Introduction to Databases", .Author = "Kevin Turner", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-0-596-15806-4", .Title = "Operating Systems Concepts", .Author = "Nancy Hall", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-0-13-468599-1", .Title = "Modern Software Testing", .Author = "Richard Young", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-1-4842-0077-9", .Title = "Beginning Algorithms", .Author = "Steven King", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-0-321-35668-0", .Title = "System Analysis and Design", .Author = "Angela Moore", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-0-07-337622-6", .Title = "Technical Communication", .Author = "Mark Taylor", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-1-491-94729-6", .Title = "Programming Basics", .Author = "Rachel Evans", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-0-13-708107-3", .Title = "Introduction to Networks", .Author = "Daniel Harris", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-0-262-53205-1", .Title = "Artificial Intelligence Basics", .Author = "Helen Brooks", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-1-59327-282-1", .Title = "Problem Solving with Computers", .Author = "Chris Baker", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-0-596-51774-8", .Title = "Linux Fundamentals", .Author = "Paul Walker", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-0-13-187325-4", .Title = "Computer Architecture", .Author = "Andrew Collins", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-1-491-94618-3", .Title = "Programming in Practice", .Author = "Olivia Reed", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-0-321-99278-8", .Title = "Human Computer Interaction", .Author = "Jason Turner", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-0-07-180855-2", .Title = "Information Systems", .Author = "Rebecca Lewis", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-1-59327-599-0", .Title = "Software Development Tools", .Author = "Matthew Perez", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-0-596-52067-0", .Title = "Coding Standards", .Author = "Benjamin Foster", .Status = "available"})
        BuchListe.Add(New Buch With {.ISBN = "978-0-13-117705-5", .Title = "Fundamentals of Computing", .Author = "Sophia Anderson", .Status = "available"})

    End Sub

End Module


