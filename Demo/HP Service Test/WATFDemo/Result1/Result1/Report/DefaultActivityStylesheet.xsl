<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns="http://www.w3.org/TR/xhtml1/strict">
  <xsl:template match="/">
    <font face="Calibri">
      <html>
        <META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=UTF-8"/>
        <link rel="stylesheet" media="screen">
          <xsl:attribute name="href">..\Results.css</xsl:attribute>
        </link>
        <body>
          <table border="0" cellpadding="3" cellspacing="0" width="100%">
            <tr>
              <td height="1" class="bg_midblue"/>
            </tr>
            <tr>
              <td height="30">
                <p>
                  <span class="hl1name">Step Properties</span>
                </p>
              </td>
            </tr>
            <tr>
              <td height="2" class="bg_darkblue"/>
            </tr>
          </table>
          <p>
            <table border="0" cellpadding="2" cellspacing="1" width="800" bgcolor="black">
              <COLGROUP>
                <COL width="25%"/>
                <COL width="75%"/>
              </COLGROUP>
              <tr bgcolor="EEEEEE">
                <th>Name</th>
                <th>Value</th>
              </tr>
              <xsl:for-each select="/report/*">
                <tr>
                  <xsl:if test="position()  mod 2 = 1">
                    <td bgcolor="White" font-weight="bold" class="tablehl">
                      <xsl:value-of select="@name"/>
                    </td>
                    <td bgcolor="White" class="text">
                      <xsl:variable name="val" select="."/>
			                <xsl:if test="contains($val,'&lt;BR&gt;')">
                        	<xsl:value-of select='translate($val," ","&#160;")' disable-output-escaping="yes"/>
                     	</xsl:if>
                      <xsl:if test="not(contains($val,'&lt;BR&gt;'))">
                        	<xsl:value-of select='translate($val," ","&#160;")'/>
                      </xsl:if>
                    </td>
                  </xsl:if>
                  <xsl:if test="position()  mod 2 = 0">
                    <td bgcolor="EEEEEE" font-weight="bold" class="tablehl">
                      <xsl:value-of select="@name"/>
                    </td>
                    <td bgcolor="EEEEEE" class="text">
                      <xsl:variable name="val" select="."/>
			                  <xsl:if test="contains($val,'&lt;BR&gt;')">
                        	<xsl:value-of select='translate($val," ","&#160;")' disable-output-escaping="yes"/>
                      	</xsl:if>
                      	<xsl:if test="not(contains($val,'&lt;BR&gt;'))">
                        	<xsl:value-of select='translate($val," ","&#160;")'/>
                      	</xsl:if>
                    </td>
                  </xsl:if>

                </tr>
              </xsl:for-each>
            </table>
          </p>
        </body>
      </html>
    </font>
  </xsl:template>
</xsl:stylesheet>
