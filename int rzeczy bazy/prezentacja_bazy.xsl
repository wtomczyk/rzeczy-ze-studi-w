<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="/">
  <html>
  <head>
	<title>Prezentacja XSL bazy danych</title>
	<link rel="stylesheet" href="./style_bazy.css" type="text/css" />
  </head>
  <body>
  
	<p>Baza zawiera:
		<xsl:value-of select="count(moje_kontakty/kontakt)"/> kontaktów.
	</p>
	
	  <h3>Ulubione kontakty</h3>
	  <div class="siatkaUlu" >
		<xsl:for-each select="moje_kontakty/kontakt[@ulubione='tak']">
		<!-- <xsl:for-each select="moje_kontakty/kontakt"> -->
			<div class="siatkaKontakt">
				<img>
					<xsl:attribute name="src">
						<xsl:value-of select="zdjęcie/img/@src"/>		
					</xsl:attribute>
				</img>
				<div class="siatkaNazwa">
					<xsl:value-of select="imię"/>&#160;<xsl:value-of select="nazwisko"/>
				</div>
			</div>
		</xsl:for-each>
	  </div>
 
 
  <h3>Lista wszystkich kontaktów posortowana wg nazwisk</h3>
  <table class="tabela2" id="listaTop">
    <tr> 
      <th>Zdjęcie</th>
      <th>Imię i nazwisko</th>
	  <th>Numer telefonu</th>
	  <th>e-mail</th>
	  <th>Adres</th>
    </tr>
    <xsl:for-each select="moje_kontakty/kontakt">
	<xsl:sort select="nazwisko"/>
    <tr>
		<td>
			<img>
				<xsl:attribute name="src">
					<xsl:value-of select="zdjęcie/img/@src"/>		
				</xsl:attribute>
			</img>
		</td>
      <td>
		<a>
			<xsl:attribute name="href">
				#<xsl:value-of select="./@id"/>		
			</xsl:attribute>
			<xsl:value-of select="imię"/>&#160;<xsl:value-of select="nazwisko"/>
		</a>
	  </td>
	  <td><xsl:value-of select="telefon"/></td>
	  <td><xsl:value-of select="email"/></td>
	  <td><xsl:value-of select="adres"/></td>
    </tr>
    </xsl:for-each>
  </table>
  
  <h3>Podgląd kontaktów</h3>
   <xsl:for-each select="moje_kontakty/kontakt">
	   <div class="profil">
			<xsl:attribute name="id">
				<xsl:value-of select="@id"/>	
			</xsl:attribute>
			
			<div class="profilZdjecie">
			<img>
				<xsl:attribute name="src">
					<xsl:value-of select="zdjęcie/img/@src"/>		
				</xsl:attribute>
			</img>		
			</div>
			<div class="profilNazwa">
				<xsl:value-of select="imię"/>&#160;<xsl:value-of select="nazwisko"/>
			</div>
			<div class="profilPodpis">
				<xsl:value-of select="adres/miasto"/>
			</div>
			<xsl:if test="count(telefon)>0">
				<div class="profilInfo">
					<p>Telefon:</p>
					<xsl:value-of select="telefon"/>
				</div>
			</xsl:if>
			<xsl:if test="count(email)>0">
				<div class="profilInfo">
					<p>E-mail:</p>
					<xsl:value-of select="email"/>
				</div>
			</xsl:if>
			<div class="profilGrupy">
				<xsl:for-each select="./grupy/grupa">
					<div>
						<xsl:value-of select="."/>
					</div>
				</xsl:for-each>
			</div>
			<div class="profilNawigacja">
				<a href="#listaTop">Powrót do listy</a>
			</div>
	   </div>
    </xsl:for-each>
 
  
  </body>
  </html>
</xsl:template>

</xsl:stylesheet>