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
                  <span class="hl1name">Web Service Call Properties</span>
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
                <xsl:if test="not(contains(@name,'InputXml')) and 
                              not(contains(@name,'OutputXml')) and
                              not(contains(@name,'InputHeader')) and
                              not(contains(@name,'OutputHeader')) and
                              not(contains(@name,'OutputText'))
                ">
                  <tr bgcolor="EEEEEE" font-weight="bold">
                    <td >
                      <xsl:value-of select="@name"/>
                    </td>
                    <td>
                      <xsl:variable name="val" select="."/>
                      <xsl:if test="contains($val,'&lt;BR&gt;')">
                        <xsl:value-of select='translate($val," ","&#160;")' disable-output-escaping="yes"/>
                      </xsl:if>
                      <xsl:if test="not(contains($val,'&lt;BR&gt;'))">
                        <xsl:value-of select='translate($val," ","&#160;")'/>
                      </xsl:if>
                    </td>
                  </tr>
                </xsl:if>
              </xsl:for-each>
            </table>
          </p>
          <table border="0" cellpadding="3" cellspacing="0" width="100%" >
            <tr>
              <td height="1" class="bg_midblue"/>
            </tr>
            <tr>
              <td height="30">
                <p>
                  <span class="hl1name">Web Service Call HTTP Snapshot</span>
                </p>
              </td>
            </tr>
            <tr>
              <td height="2" class="bg_darkblue"/>
            </tr>
          </table>
          <p>
            <table border="0" cellpadding="1" cellspacing="1" height="100%" >
              <tr>
                <td>
                  <table border="0" cellpadding="2" cellspacing="1" height="95%" bgcolor="black">
                    <tr height="3%">
                      <th bgcolor="#C0CFE2">
                        <font color="white">
                          <a>
                            <xsl:attribute name="href">
                              <xsl:value-of select="/report/InputXml/@FileLocation"/>
                            </xsl:attribute>
                            <xsl:attribute name="target">
                              "_blank"
                            </xsl:attribute>Request
                          </a>
                        </font>
                      </th>
                    </tr>
                    <tr height="3%">
                      <th class="tablehl" bgcolor="EEEEEE">
                        <div class="tablehl">HTTP Header</div>
                      </th>
                    </tr>
                    <tr height="30%">
                      <td bgcolor="white" class="text">
                        <div style="height:100%;width:480;overflow:auto">
                          <pre>
                            <xsl:value-of select="/report/InputHeader"/>
                          </pre>
                        </div>
                      </td>
                    </tr>
                    <tr height="3%">
                      <th class="tablehl" bgcolor="EEEEEE">
                        <div class="tablehl">SOAP</div>
                      </th>
                    </tr>
                    <tr height="41%">
                      <td bgcolor="white" class="text">
                        <div style="height:100%;width:480;overflow:auto">
                          <pre>
                            <xsl:value-of select="/report/InputXml"/>
                          </pre>
                        </div>
                      </td>
                    </tr>

                    <xsl:if test="count(/report/*[starts-with(local-name(.), 'RequestAttachment')]) &gt; 0 or count(/report/*[starts-with(local-name(.), 'ResponseAttachment')]) &gt; 0">
                      <tr height="3%">
                        <th class="tablehl" bgcolor="EEEEEE">
                          <div class="tablehl">Attachments</div>
                        </th>
                      </tr>
                      <tr height="20%">
                        <td bgcolor="white" class="text">
                          <div style="height:100%;width:480;overflow:auto">
                            <table border="1">
                              <xsl:for-each select="/report/*[starts-with(local-name(.), 'RequestAttachment')]">
                                <tr>
                                  <td>Details</td>
                                  <td>
                                    <pre>
                                      <xsl:value-of select="."/>
                                    </pre>
                                  </td>
                                </tr>
                              </xsl:for-each>
                            </table>
                          </div>
                        </td>
                      </tr>
                    </xsl:if>

                  </table>
                </td>
                <td>
                  <table border="0" cellpadding="2" cellspacing="1" height="95%" bgcolor="black">
                    <tr height="3%">
                      <th bgcolor="#C0CFE2">
                        <font color="white">
                          <a>
                            <xsl:attribute name="href">
                              <xsl:value-of select="/report/OutputXml/@FileLocation"/>
                            </xsl:attribute>
                            <xsl:attribute name="target">
                              "_blank"
                            </xsl:attribute>Response
                          </a>
                        </font>
                      </th>
                    </tr>
                    <tr height="3%">
                      <th class="tablehl" bgcolor="EEEEEE">
                        <div class="tablehl">HTTP Header</div>
                      </th>
                    </tr>
                    <tr height="30%">
                      <td bgcolor="white" class="text">
                        <div style="height:100%;width:480;overflow:auto">
                          <pre>
                            <xsl:value-of select="/report/OutputHeader"/>
                          </pre>
                        </div>
                      </td>
                    </tr>
                    <tr height="3%">
                      <th class="tablehl" bgcolor="EEEEEE">
                        <div class="tablehl">
                          <xsl:choose>
                            <xsl:when test="string-length(/report/OutputXml) &gt; 0">
                              SOAP
                            </xsl:when>
                            <xsl:otherwise>
                              HTTP Body
                            </xsl:otherwise>
                          </xsl:choose>
                        </div>
                      </th>
                    </tr>
                    <tr height="41%">
                      <td bgcolor="white" class="text">
                        <div style="height:100%;width:480;overflow:auto">
                          <pre>
                            <xsl:choose>
                              <xsl:when test="string-length(/report/OutputXml) &gt; 0">
                                <xsl:value-of select="/report/OutputXml"/>
                              </xsl:when>
                              <xsl:otherwise>
                                <xsl:value-of select="/report/OutputText"/>
                              </xsl:otherwise>
                            </xsl:choose>
                          </pre>
                        </div>
                      </td>
                    </tr>

                    <xsl:if test="count(/report/*[starts-with(local-name(.), 'ResponseAttachment')]) &gt; 0 or count(/report/*[starts-with(local-name(.), 'RequestAttachment')]) &gt; 0">
                      <tr height="3%">
                        <th class="tablehl" bgcolor="EEEEEE">
                          <div class="tablehl">Attachments</div>
                        </th>
                      </tr>
                      <tr height="20%">
                        <td bgcolor="white" class="text">
                          <div style="height:100%;width:480;overflow:auto">
                            <table border="1">
                              <xsl:for-each select="/report/*[starts-with(local-name(.), 'ResponseAttachment')]">
                                <tr>
                                  <td>Details</td>
                                  <td>
                                    <pre>
                                      <xsl:value-of select="."/>
                                    </pre>
                                  </td>
                                </tr>
                              </xsl:for-each>
                            </table>
                          </div>
                        </td>
                      </tr>
                    </xsl:if>

                  </table>
                </td>
              </tr>
            </table>
          </p>
        </body>
      </html>
    </font>
  </xsl:template>
</xsl:stylesheet>
