Module MainModule

    Sub Main()
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
                    Console.WriteLine(">> Funktion: Alle Bücher anzeigen (noch nicht implementiert)")
                Case "3"
                    Console.WriteLine(">> Funktion: Alle Benutzer anzeigen (noch nicht implementiert)")
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

End Module

