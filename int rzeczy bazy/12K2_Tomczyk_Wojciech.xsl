<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="/">
  <html>
  <head>
	<title>Państwa</title>
	<link rel="stylesheet" href="./12K2_Tomczyk_Wojciech.css" type="text/css" />
  </head>
  <body>
  <div id="body">
   <h3>Ogólne informacje o państwach</h3>
   <table class="tab1">
    <tr> 
      <th>Nazwa</th>
	  <th>Język</th>
	  <th>Waluta</th>
	  <th>Kontynent</th>
	  <th>Flaga</th>
    </tr>
    <xsl:for-each select="państwa/państwo">
    <tr>
      <td><xsl:value-of select="nazwa"/></td>
	  <td><xsl:value-of select="język"/></td>
	  <td><xsl:value-of select="waluta"/></td>
	  <td><xsl:value-of select="kontynent"/></td>
	  <td>
			<img>
				<xsl:attribute name="src">
					<xsl:value-of select="flaga/img/@src"/>		
				</xsl:attribute>
				<xsl:attribute name="width">50</xsl:attribute>
			</img>
	  </td>
    </tr>
    </xsl:for-each>
  </table>
  <h3>Dwa pierwsze i dwa ostanie elementy tablicy</h3>
  <table class="tab1">
  <tr>
	<th>Nazwa</th>
	<th>Kontynent</th>
  </tr>
  <tr>
      <td><xsl:value-of select="państwa/państwo[1]/nazwa"/></td>
	  <td><xsl:value-of select="państwa/państwo[1]/kontynent"/></td>
  </tr>
  <tr>
      <td><xsl:value-of select="państwa/państwo[2]/nazwa"/></td>
	  <td><xsl:value-of select="państwa/państwo[2]/kontynent"/></td>
  </tr>
  <tr>
      <td><xsl:value-of select="państwa/państwo[last()]/nazwa"/></td>
	  <td><xsl:value-of select="państwa/państwo[last()]/kontynent"/></td>
  </tr>
  <tr>
      <td><xsl:value-of select="państwa/państwo[last()-1]/nazwa"/></td>
	  <td><xsl:value-of select="państwa/państwo[last()-1]/kontynent"/></td>	
	</tr>
  </table>
  <h3>W bazie znajduje się</h3>
  <ul>
    <li><xsl:value-of select="count(państwa/państwo)"/> państw</li>
	<li><xsl:value-of select="count(państwa/państwo/waluta[not(. = preceding::waluta)])"/> różnych walut</li>
	<li><xsl:value-of select="count(państwa/państwo/kontynent[not(. = preceding::kontynent)])"/> kontynentów</li>
  </ul>
 <h3>Ilość sąsiadów dla poszczególnych państw</h3>
 <table class="tab1">
  <tr>
	<th>Nazwa</th>
	<th>Ilość</th>
  </tr>
 <xsl:for-each select="państwa/państwo">
    <tr>
      <td><xsl:value-of select="nazwa"/></td>
	  <td>
		<xsl:value-of select="count(sąsiedzi/sąsiad)"/>
	  </td>
    </tr>
    </xsl:for-each>
  </table>
  <h3>Sąsiedzi Niemiec</h3>
  <table class="tab1">
    <tr>
	  <xsl:for-each select="państwa/państwo[@id='2']/sąsiedzi/sąsiad">
		  <td>
			<xsl:value-of select="nazwa"/>
		  </td>
	  </xsl:for-each>
	</tr>
  </table>
  <h3>Sąsiedzi Polski</h3>
  <table class="tab1">
    <tr>
	  <xsl:for-each select="państwa/państwo[@id='1']/sąsiedzi/sąsiad">
		  <td>
			<xsl:value-of select="nazwa"/>
		  </td>
	  </xsl:for-each>
	</tr>
  </table>
  <h3>Sąsiedzi Portugali</h3>
  <table class="tab1">
    <tr>
	  <xsl:for-each select="państwa/państwo[@id='9']/sąsiedzi/sąsiad">
		  <td>
			<xsl:value-of select="nazwa"/>
		  </td>
	  </xsl:for-each>
	</tr>
  </table>
  <h3>W bazie danych są</h3>
  <ul>
	<li><xsl:value-of select="count(państwa/państwo/kontynent[.='Europa'])"/> państw z Europy</li>
	<li><xsl:value-of select="count(państwa/państwo/kontynent[.='Azja'])"/> państwo z Azji</li>
	<li><xsl:value-of select="count(państwa/państwo/kontynent[.='Afryka'])"/> państwo z Afryki</li>
	<li><xsl:value-of select="count(państwa/państwo/kontynent[.='Ameryka Południowa'])"/> państwo z Ameryki Południowej</li>
	<li><xsl:value-of select="count(państwa/państwo/kontynent[.='Ameryka Północna'])"/> państwo z Ameryki Północnej</li>
	<li><xsl:value-of select="count(państwa/państwo/kontynent[.='Australia i Oceania'])"/> państw z Australi i Oceani</li>
  </ul>
  <h3>Państwa używające Euro jako walutę</h3>
  <table class="tab1">
  <tr>
	<th>Nazwa</th>
	<th>Flaga</th>
  </tr>
  <xsl:for-each select="państwa/państwo/waluta[.='Euro']">
  <tr>
		  <td>
			<xsl:value-of select="../nazwa"/>
		  </td>
		  <td>
			<img>
				<xsl:attribute name="src">
					<xsl:value-of select="../flaga/img/@src"/>		
				</xsl:attribute>
				<xsl:attribute name="width">50</xsl:attribute>
			</img>
		  </td>
		  </tr>
	  </xsl:for-each>
  </table>
  <h3>Państwa europejskie</h3>
  <table class="tab1">
  <tr>
	<th>Nazwa</th>
	<th>Flaga</th>
  </tr>
  <xsl:for-each select="państwa/państwo/kontynent[.='Europa']">
  <tr>
		  <td>
			<xsl:value-of select="../nazwa"/>
		  </td>
		  <td>
			<img>
				<xsl:attribute name="src">
					<xsl:value-of select="../flaga/img/@src"/>		
				</xsl:attribute>
				<xsl:attribute name="width">50</xsl:attribute>
			</img>
		  </td>
		  </tr>
	  </xsl:for-each>
  </table>
  </div>
  </body>
  </html>
</xsl:template>

</xsl:stylesheet>