Module MainModule

    ''' ----------------------------------------------------------
    ''' <summary>
    ''' Datenstruktur zur Speicherung eines Bibliotheksbenutzers
    ''' </summary>
    ''' <remarks>
    ''' Enthält die eindeutige Benutzer-ID sowie den Namen
    ''' des Benutzers.
    ''' </remarks>
    Structure Benutzer
        Public UserID As String
        Public Name As String
    End Structure


    ''' ----------------------------------------------------------
    ''' <summary>
    ''' Datenstruktur zur Speicherung eines Buches
    ''' </summary>
    ''' <remarks>
    ''' Enthält ISBN, Titel, Autor sowie den aktuellen
    ''' Ausleihstatus und die Benutzer-ID des Ausleihers.
    ''' </remarks>
    Structure Buch
        Public ISBN As String
        Public Title As String
        Public Author As String
        Public Status As String
        Public EntliehenVon As String
    End Structure


    Dim BenutzerListe As New List(Of Benutzer)
    Dim BuchListe As New List(Of Buch)



    ''' ----------------------------------------------------------
    ''' <summary>
    ''' Startpunkt des Bibliothekssystems
    ''' </summary>
    ''' <remarks>
    ''' Zeigt das Hauptmenü an und verarbeitet die Eingaben
    ''' des Benutzers. Je nach Auswahl wird die entsprechende
    ''' Funktion des Systems aufgerufen.
    ''' </remarks>
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
                        NeuerBenutzer()

                    Case "2"
                        AlleBuecherAnzeigen()

                    Case "3"
                        AlleBenutzerAnzeigen()

                    Case "4"
                        BuchAusleihen()

                    Case "5"
                        BuchZurueckgeben()

                    Case "6"
                        AusgelieheneBuecherAnzeigen()

                    Case "0"
                        Console.WriteLine("Programm wird beendet...")
                        running = False

                    Case Else
                        Console.WriteLine("Ungültige Auswahl. Bitte Zahlen von 0 bis 6 eingeben.")

                End Select

            End If

            If running Then
                Console.WriteLine()
                Console.WriteLine("Drücken Sie eine Taste, um zum Menü zurückzukehren...")
                Console.ReadKey()
            End If

        End While

    End Sub



    ''' ----------------------------------------------------------
    ''' <summary>
    ''' Zeigt alle im System gespeicherten Benutzer an
    ''' </summary>
    ''' <remarks>
    ''' Durchläuft die Benutzerliste und gibt Benutzer-ID
    ''' und Namen jedes Benutzers in der Konsole aus.
    ''' </remarks>
    Sub AlleBenutzerAnzeigen()

        Console.WriteLine("=== Alle hinterlegten Benutzer ===")
        Console.WriteLine()

        For Each ben In BenutzerListe

            Console.WriteLine("Benutzer-ID: " & ben.UserID)
            Console.WriteLine("Name:        " & ben.Name)
            Console.WriteLine("----------------------------------------------")

        Next

    End Sub



    ''' ----------------------------------------------------------
    ''' <summary>
    ''' Zeigt alle im System vorhandenen Bücher an
    ''' </summary>
    ''' <remarks>
    ''' Gibt ISBN, Titel, Autor sowie den aktuellen
    ''' Verfügbarkeitsstatus der Bücher aus.
    ''' </remarks>
    Sub AlleBuecherAnzeigen()

        Console.WriteLine("=== Alle hinterlegten Bücher ===")
        Console.WriteLine()

        For Each buch In BuchListe

            Dim statusDeutsch As String =
                If(buch.Status.ToLower() = "available", "verfügbar", "ausgeliehen")

            Console.WriteLine("ISBN:   " & buch.ISBN)
            Console.WriteLine("Titel:  " & buch.Title)
            Console.WriteLine("Autor:  " & buch.Author)
            Console.WriteLine("Status: " & statusDeutsch)

            Console.WriteLine("----------------------------------------------")

        Next

    End Sub



    ''' ----------------------------------------------------------
    ''' <summary>
    ''' Legt einen neuen Benutzer im System an
    ''' </summary>
    ''' <remarks>
    ''' Der Benutzer gibt seinen Namen ein. Das System erzeugt
    ''' automatisch eine eindeutige Benutzer-ID und speichert
    ''' den neuen Benutzer in der Benutzerliste.
    ''' </remarks>
    Sub NeuerBenutzer()

        Console.WriteLine("=== Neuen Benutzer anlegen ===")

        If BenutzerListe.Count >= 999 Then
            Console.WriteLine("Maximale Anzahl von 999 Benutzern erreicht.")
            Return
        End If

        Console.Write("Bitte geben Sie den vollständigen Namen ein: ")

        Dim name As String = Console.ReadLine().Trim()

        If name = "" Then
            Console.WriteLine("Ungültige Eingabe. Name darf nicht leer sein.")
            Return
        End If

        Dim neueID As String = "U" & (BenutzerListe.Count + 1).ToString("000")

        Dim neuerBenutzer As New Benutzer With {
            .UserID = neueID,
            .Name = name
        }

        BenutzerListe.Add(neuerBenutzer)

        Console.WriteLine()
        Console.WriteLine("Benutzer wurde erfolgreich angelegt!")
        Console.WriteLine("Neue UserID: " & neueID)
        Console.WriteLine("Name:       " & name)

    End Sub



    ''' ----------------------------------------------------------
    ''' <summary>
    ''' Ermöglicht die Rückgabe eines ausgeliehenen Buches
    ''' </summary>
    ''' <remarks>
    ''' Der Benutzer gibt seine Benutzer-ID sowie die ISBN
    ''' des Buches ein. Das System prüft, ob das Buch existiert,
    ''' ausgeliehen ist und von diesem Benutzer ausgeliehen wurde.
    ''' Anschließend wird der Status des Buches auf verfügbar gesetzt.
    ''' </remarks>
    Sub BuchZurueckgeben()

        Console.WriteLine("=== Buch zurückgeben ===")

        Console.Write("Benutzer-ID eingeben: ")
        Dim userID As String = Console.ReadLine().Trim()

        Dim benutzerExistiert As Boolean = False

        For Each ben In BenutzerListe
            If ben.UserID = userID Then
                benutzerExistiert = True
            End If
        Next

        If Not benutzerExistiert Then
            Console.WriteLine("Fehler: Benutzer existiert nicht.")
            Return
        End If

        Console.Write("ISBN des Buches eingeben: ")
        Dim isbn As String = Console.ReadLine().Trim()

        For i As Integer = 0 To BuchListe.Count - 1

            If BuchListe(i).ISBN = isbn Then

                If BuchListe(i).Status = "available" Then
                    Console.WriteLine("Dieses Buch ist aktuell nicht ausgeliehen.")
                    Return
                End If

                If BuchListe(i).EntliehenVon <> userID Then
                    Console.WriteLine("Dieses Buch wurde nicht von diesem Benutzer ausgeliehen.")
                    Return
                End If

                Dim buchTemp = BuchListe(i)

                buchTemp.Status = "available"
                buchTemp.EntliehenVon = ""

                BuchListe(i) = buchTemp

                Console.WriteLine()
                Console.WriteLine("Buch erfolgreich zurückgegeben!")
                Console.WriteLine("Titel: " & buchTemp.Title)

                Return

            End If

        Next

        Console.WriteLine("Fehler: Buch mit dieser ISBN wurde nicht gefunden.")

    End Sub



    ''' ----------------------------------------------------------
    ''' <summary>
    ''' Lädt eine Liste vordefinierter Benutzer
    ''' </summary>
    ''' <remarks>
    ''' Simuliert das Einlesen von Benutzerdaten aus einer CSV-Datei.
    ''' Die Daten werden in die Benutzerliste eingefügt.
    ''' </remarks>
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



    ''' ----------------------------------------------------------
    ''' <summary>
    ''' Lädt eine Liste vordefinierter Bücher
    ''' </summary>
    ''' <remarks>
    ''' Simuliert das Einlesen von Buchdaten aus einer CSV-Datei
    ''' und speichert diese in der Buchliste.
    ''' </remarks>
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
    ''' ----------------------------------------------------------
    ''' <summary>
    ''' Ermöglicht das Ausleihen eines Buches
    ''' </summary>
    ''' <remarks>
    ''' Der Benutzer gibt seine Benutzer-ID sowie die ISBN
    ''' des gewünschten Buches ein. Das System prüft, ob
    ''' der Benutzer existiert und ob das Buch verfügbar ist.
    ''' Anschließend wird der Status des Buches auf
    ''' ausgeliehen gesetzt und die Benutzer-ID gespeichert.
    ''' </remarks>
    Sub BuchAusleihen()

        Console.WriteLine("=== Buch ausleihen ===")

        Console.Write("Benutzer-ID eingeben: ")
        Dim userID As String = Console.ReadLine().Trim()

        Dim benutzerExistiert As Boolean = False

        For Each ben In BenutzerListe
            If ben.UserID = userID Then
                benutzerExistiert = True
            End If
        Next

        If Not benutzerExistiert Then
            Console.WriteLine("Fehler: Benutzer existiert nicht.")
            Return
        End If

        Console.Write("ISBN des Buches eingeben: ")
        Dim isbn As String = Console.ReadLine().Trim()

        For i As Integer = 0 To BuchListe.Count - 1

            If BuchListe(i).ISBN = isbn Then

                If BuchListe(i).Status <> "available" Then
                    Console.WriteLine("Dieses Buch ist bereits ausgeliehen.")
                    Return
                End If

                Dim buchTemp = BuchListe(i)

                buchTemp.Status = "lent"
                buchTemp.EntliehenVon = userID

                BuchListe(i) = buchTemp

                Console.WriteLine()
                Console.WriteLine("Buch erfolgreich ausgeliehen!")
                Console.WriteLine("Titel: " & buchTemp.Title)

                Return

            End If

        Next

        Console.WriteLine("Fehler: Buch mit dieser ISBN wurde nicht gefunden.")

    End Sub
    ''' ----------------------------------------------------------
    ''' <summary>
    ''' Zeigt alle ausgeliehenen Bücher eines Benutzers an
    ''' </summary>
    ''' <remarks>
    ''' Der Benutzer gibt seine Benutzer-ID ein. Das System
    ''' durchsucht die Buchliste und gibt alle Bücher aus,
    ''' die aktuell von diesem Benutzer ausgeliehen wurden.
    ''' </remarks>
    Sub AusgelieheneBuecherAnzeigen()

        Console.WriteLine("=== Ausgeliehene Bücher anzeigen ===")

        Console.Write("Benutzer-ID eingeben: ")
        Dim userID As String = Console.ReadLine().Trim()

        Dim benutzerExistiert As Boolean = False

        For Each ben In BenutzerListe
            If ben.UserID = userID Then
                benutzerExistiert = True
            End If
        Next

        If Not benutzerExistiert Then
            Console.WriteLine("Fehler: Benutzer existiert nicht.")
            Return
        End If

        Console.WriteLine()
        Console.WriteLine("Ausgeliehene Bücher von Benutzer " & userID & ":")

        Dim gefunden As Boolean = False

        For Each buch In BuchListe

            If buch.EntliehenVon = userID Then

                Console.WriteLine("ISBN:  " & buch.ISBN)
                Console.WriteLine("Titel: " & buch.Title)
                Console.WriteLine("Autor: " & buch.Author)
                Console.WriteLine("----------------------------------------------")

                gefunden = True

            End If

        Next

        If Not gefunden Then
            Console.WriteLine("Dieser Benutzer hat aktuell keine Bücher ausgeliehen.")
        End If

    End Sub
End Module
