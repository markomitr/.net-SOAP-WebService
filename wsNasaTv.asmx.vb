Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data.SqlClient

<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class NasaTvService
    Inherits System.Web.Services.WebService
    Private greska As Korisnik.TipGreska = Korisnik.TipGreska.Nepoznato
    Private porakaGlobalna As String = ""
    <WebMethod()> _
    Public Function Login(ByVal korisnikLogin As String, ByVal lozinka As String, ByRef poraka As String) As Boolean
        porakaGlobalna = ""
        If Korisnik.proveriKorisnik(korisnikLogin, lozinka, poraka, greska) Then
            Return True
        Else
            porakaGlobalna = poraka
            Return False
        End If
    End Function
    <WebMethod()> _
    Public Function PromeniLozinka(ByVal korisnikLogin As String, ByVal staraLozinka As String, ByVal novaLozinka As String, ByRef poraka As String) As Boolean
        porakaGlobalna = ""
        If Korisnik.proveriKorisnik(korisnikLogin, staraLozinka, poraka, greska) Then
            If Korisnik.izmeniKorisnik(korisnikLogin, novaLozinka, poraka, greska) Then
                Return True
            Else
                porakaGlobalna = poraka
                Return False
            End If
        Else
            porakaGlobalna = poraka
            Return False
        End If
    End Function
    <WebMethod()> _
    Public Function ProveriPoeni(ByVal korisnikIme As String, ByRef poeni As Integer, ByRef poraka As String) As Boolean
        porakaGlobalna = ""
        If Korisnik.ProveriPoeniKorisnik(korisnikIme, poeni, poraka, greska) Then
            Return True
        Else
            porakaGlobalna = poraka
            Return False
        End If
    End Function


    <WebMethod()> _
   Public Function Login01(ByVal korisnikLogin As String, ByVal lozinka As String) As Integer
        Dim poraka As String = ""
        porakaGlobalna = ""
        greska = Korisnik.TipGreska.Nepoznato
        If Korisnik.proveriKorisnik(korisnikLogin, lozinka, poraka, greska) Then
            Return 1
        Else
            porakaGlobalna = poraka
            If greska = Korisnik.TipGreska.GreskaException Then
                Return -1
            ElseIf greska = Korisnik.TipGreska.NePostoiKorisnik Then
                Return 0
            End If
        End If
    End Function
    <WebMethod()> _
    Public Function PromeniLozinka01(ByVal korisnikLogin As String, ByVal staraLozinka As String, ByVal novaLozinka As String) As Integer
        Dim poraka As String = ""
        porakaGlobalna = ""
        greska = Korisnik.TipGreska.Nepoznato
        If Korisnik.proveriKorisnik(korisnikLogin, staraLozinka, poraka, greska) Then
            If Korisnik.izmeniKorisnik(korisnikLogin, novaLozinka, poraka, greska) Then
                Return 1
            Else
                porakaGlobalna = poraka
                If greska = Korisnik.TipGreska.GreskaException Then
                    Return -1
                ElseIf greska = Korisnik.TipGreska.NePostoiKorisnik Then
                    Return 0
                End If
            End If
        Else
            porakaGlobalna = poraka
            If greska = Korisnik.TipGreska.GreskaException Then
                Return -1
            ElseIf greska = Korisnik.TipGreska.NePostoiKorisnik Then
                Return 0
            End If
        End If
    End Function
    <WebMethod()> _
    Public Function ProveriPoeni01(ByVal korisnikIme As String) As Integer
        Dim poraka As String = ""
        porakaGlobalna = ""
        Dim poeni As Integer
        greska = Korisnik.TipGreska.Nepoznato
        If Korisnik.ProveriPoeniKorisnik(korisnikIme, poeni, poraka, greska) Then
            Return Konv.ObjVoInt(poeni)
        Else
            porakaGlobalna = poraka
            If greska = Korisnik.TipGreska.GreskaException Then
                Return -1
            ElseIf greska = Korisnik.TipGreska.NePostoiKorisnik Then
                Return -2
            ElseIf greska = Korisnik.TipGreska.NePostoiZapis Then
                Return 0
            End If
        End If
    End Function
End Class