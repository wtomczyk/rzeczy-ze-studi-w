<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="/">
  <html>
  <head>
	<title>Przykłady przekształceń XSL</title>
	<link rel="stylesheet" href="./style_bazy.css" type="text/css" />
  </head>
  <body>
  <h3>Pierwszy element bazy</h3>
  <table class="tabela1" >
    <tr>
      <td><xsl:value-of select="moje_kontakty/kontakt/imię"/></td>
      <td><xsl:value-of select="moje_kontakty/kontakt/nazwisko"/></td>
    </tr>
  </table>
  
  <p></p>
  
   <h3>2 pierwsze i 2 ostatnie elementy bazy</h3>
   <table class="tabela1">
    <tr>
      <td>
		<xsl:value-of select="moje_kontakty/kontakt[1]/imię"/> <br/>
		<xsl:value-of select="moje_kontakty/kontakt[1]/nazwisko"/>
	  </td>
      <td>
		<xsl:value-of select="moje_kontakty/kontakt[2]/imię"/> <br/>
		<xsl:value-of select="moje_kontakty/kontakt[2]/nazwisko"/>
	  </td>
    </tr>
	<tr>
      <td>
		<xsl:value-of select="moje_kontakty/kontakt[last()]/imię"/> <br/>
		<xsl:value-of select="moje_kontakty/kontakt[last()]/nazwisko"/>
	  </td>
      <td>
		<xsl:value-of select="moje_kontakty/kontakt[last()-1]/imię"/> <br/>
		<xsl:value-of select="moje_kontakty/kontakt[last()-1]/nazwisko"/>
	  </td>	
	</tr>
  </table>
 
 
  <h3>Lista wszystkich kontaktów</h3>
  <table class="tabela1">
    <tr> 
      <th>Imię i nazwisko</th>
	  <th>Numer telefonu</th>
	  <th>e-mail</th>
	  <th>Adres</th>
    </tr>
    <xsl:for-each select="moje_kontakty/kontakt">
    <tr>
      <td><xsl:value-of select="imię"/>&#160;<xsl:value-of select="nazwisko"/></td>
	  <td><xsl:value-of select="telefon"/></td>
	  <td><xsl:value-of select="email"/></td>
	  <td><xsl:value-of select="adres"/></td>
    </tr>
    </xsl:for-each>
  </table>
  
  <p></p>
  <h3>Lista wszystkich kontaktów</h3>
  <table class="tabela1">
    <tr> 
      <th>Zdjęcie</th>
      <th>Imię i nazwisko</th>
	  <th>Numer telefonu</th>
	  <th>e-mail</th>
	  <th>Adres</th>
    </tr>
    <xsl:for-each select="moje_kontakty/kontakt">
    <tr>
		<td>
			<img>
				<xsl:attribute name="src">
					<xsl:value-of select="zdjęcie/img/@src"/>		
				</xsl:attribute>
				<xsl:attribute name="width">50</xsl:attribute>
			</img><br/>
		</td>
      <td><xsl:value-of select="imię"/>&#160;<xsl:value-of select="nazwisko"/></td>
	  <td><xsl:value-of select="telefon"/></td>
	  <td><xsl:value-of select="email"/></td>
	  <td><xsl:value-of select="adres"/></td>
    </tr>
    </xsl:for-each>
  </table>
  
  <p>Baza kontaktów zawiera:</p>
  <ul>
    <li><xsl:value-of select="count(moje_kontakty/kontakt)"/> kontaktów</li>
	<li><xsl:value-of select="count(moje_kontakty/kontakt/email)"/> adresów e-mail</li>
	<li><xsl:value-of select="count(moje_kontakty/kontakt/telefon)"/> telefonów</li>
  </ul>
  
  </body>
  </html>
</xsl:template>

</xsl:stylesheet>