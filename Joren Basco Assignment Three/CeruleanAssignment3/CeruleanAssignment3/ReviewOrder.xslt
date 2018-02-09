<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">

      <div>
        <table class="xslTable table-responsive">
          <tr>
            <th>Order ID</th>
            <th>Name</th>
            <th>Date of Order</th>
            <th>Address</th>
            <th>Quantity</th>
            <th>Total</th>
            <th>Item</th>
          </tr>
          <xsl:for-each select="NewDataSet/Table">           
          <tr>
            <td>
              <xsl:value-of select="orderID"/>
            </td>
            <td>
              <xsl:value-of select="Name"/>
            </td>
            <td>
              <xsl:value-of select="orderDate"/>
            </td>
            <td>
              <xsl:value-of select="address"/>
            </td>
            <td>
              <xsl:value-of select="quantity"/>
            </td>
            <td>
              <xsl:value-of select="total"/>
            </td>
            <td>
              <xsl:value-of select="itemName"/>
            </td>
            <td>
            <img height="50" width="50">
              <xsl:attribute name="src">               
               /Merch/<xsl:value-of select="itemImg"/>
              </xsl:attribute>
            </img>
            </td>
          </tr>
          </xsl:for-each>
        </table>
      </div>
    </xsl:template>
</xsl:stylesheet>
